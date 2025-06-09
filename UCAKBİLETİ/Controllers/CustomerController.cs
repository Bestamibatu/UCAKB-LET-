using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCAKBİLETİ.Bussiness.Abstract;
using UCAKBİLETİ.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.CodeAnalysis.Scripting;

namespace UCAKBİLETİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IServices<Customer> _services;
        private readonly IConfiguration _configuration;

        public CustomerController(IServices<Customer> services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _services.GetAll();
            if (customers == null || customers.Count == 0)
                return NotFound("No customers found.");
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _services.GetById(id);
            if (customer == null)
                return NotFound($"Customer with ID {id} not found.");
            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Invalid customer data.");

            // Şifreyi hashle
            customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);
            var createdCustomer = _services.Create(customer);
            return CreatedAtAction(nameof(GetById), new { id = createdCustomer.CustomerID }, createdCustomer);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Invalid customer data.");
            var updatedCustomer = _services.Update(customer);
            return Ok(updatedCustomer);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingCustomer = _services.GetById(id);
            if (existingCustomer == null)
                return NotFound($"Customer with ID {id} not found.");
            _services.Delete(id);
            return NoContent();
        }

        // 🔐 Kullanıcı Kaydı (Register)
        [HttpPost("register")]
        public IActionResult Register([FromBody] Customer customer)
        {
            if (customer == null)
                return BadRequest("Invalid customer data.");

            var existing = _services.GetAll().FirstOrDefault(x => x.Email == customer.Email);
            if (existing != null)
                return BadRequest("Bu e-posta adresi zaten kayıtlı.");

            // Şifreyi hashle
            customer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);

            var result = _services.Create(customer);
            return Ok(result);
        }

        // 🔑 Kullanıcı Girişi (Login)
        [HttpPost("login")]
        public IActionResult Login([FromBody] Customer loginData)
        {
            if (loginData == null)
                return BadRequest("Invalid login data.");

            var customer = _services.GetAll()
                .FirstOrDefault(c => c.Email == loginData.Email);

            if (customer == null || !BCrypt.Net.BCrypt.Verify(loginData.Password, customer.Password))
                return Unauthorized("E-posta veya şifre yanlış.");

            // JWT token üret
            var token = GenerateJwtToken(customer);

            return Ok(new { Token = token });
        }

        // JWT Token üretimi
        private string GenerateJwtToken(Customer customer)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customer.CustomerID.ToString()),
                new Claim(ClaimTypes.Name, customer.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
