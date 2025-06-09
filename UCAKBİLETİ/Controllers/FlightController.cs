using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCAKBİLETİ.Bussiness.Abstract;
using UCAKBİLETİ.Bussiness.Concrete;
using UCAKBİLETİ.Models;

namespace UCAKBİLETİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IServices<Flight> _services;

        // Dependency Injection ile FlightManager'ı doğru şekilde inject ediyoruz
        public FlightController(IServices<Flight> services)
        {
            _services = services;
        }

        [HttpGet]
        public List<Flight> Get()
        {
            return _services.GetAll();
        }

        [HttpGet("{id}")]
        public Flight GetById(int id)
        {
            return _services.GetById(id);
        }

        [HttpPost]
        public Flight Post(Flight flight)
        {
            return _services.Create(flight);
        }

        [HttpPut]
        public Flight Put(Flight flight)
        {
            return _services.Update(flight);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _services.Delete(id);
        }
        [HttpPost("BookSeat/{flightId}/{seatId}")]
        public IActionResult BookSeat(int flightId, int seatId)
        {
            try
            {
                _services.BookSeat(flightId, seatId);
                return Ok("Koltuk başarıyla rezerve edildi.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  // Hata mesajını döndürüyoruz
            }
        }
    }
}


