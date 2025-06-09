using UCAKBİLETİ.Models.Abstract;
using UCAKBİLETİ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UCAKBİLETİ.Models.Concrete
{
    public class FlightRepository : ITicketRepository<Flight>
    {
        private readonly CustomerDBContext _context;

        public FlightRepository(CustomerDBContext context)
        {
            _context = context;
        }

        public Flight Create(Flight entity)
        {
            _context.Flights.Add(entity);  // 'flights' yerine 'Flights' kullanıldı
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var flight = _context.Flights.Find(id);  // 'flights' yerine 'Flights' kullanıldı
            if (flight != null)
            {
                _context.Flights.Remove(flight);  // 'flights' yerine 'Flights' kullanıldı
                _context.SaveChanges();
            }
        }

        public List<Flight> GetAll()
        {
            return _context.Flights.ToList();  // 'flights' yerine 'Flights' kullanıldı
        }

        public Flight GetById(int id)
        {
            return _context.Flights.FirstOrDefault(f => f.Id == id);  // 'flights' yerine 'Flights' kullanıldı
        }

        public Flight Update(Flight entity)
        {
            var flight = _context.Flights.Find(entity.Id);  // 'flights' yerine 'Flights' kullanıldı
            if (flight != null)
            {
                _context.Entry(flight).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return flight;
            }
            return null;
        }
    }
}
