using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UCAKBİLETİ.Bussiness.Abstract;
using UCAKBİLETİ.Bussiness.Concrete;
using UCAKBİLETİ.Models;

namespace UCAKBİLETİ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IServices<Reservation> _services;

        // ReservationManager'ı DI ile enjekte ediyoruz.
        public ReservationController(IServices<Reservation> services)
        {
            _services = services;
        }

        [HttpGet]
        public List<Reservation> Get()
        {
            return _services.GetAll();
        }

        [HttpGet("{id}")]
        public Reservation Getid(int id)
        {
            return _services.GetById(id);
        }

        [HttpPost]
        public Reservation post(Reservation reservation)
        {
            return _services.Create(reservation);
        }

        [HttpPut]
        public Reservation put(Reservation reservation)
        {
            return _services.Update(reservation);
        }

        [HttpDelete("{id}")]
        public void delete(int id)
        {
            _services.Delete(id);
        }
    }
}