using UCAKBİLETİ.Models.Abstract;
using UCAKBİLETİ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UCAKBİLETİ.Models.Concrete
{
    public class ReservationRepository : ITicketRepository<Reservation>
    {
        private readonly CustomerDBContext _context;

        public ReservationRepository(CustomerDBContext context)
        {
            _context = context;
        }

        public Reservation Create(Reservation entity)
        {
            _context.Reservations.Add(entity);  // 'reservations' yerine 'Reservations' kullanın
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var deleteReservation = GetById(id);
            if (deleteReservation != null)
            {
                _context.Reservations.Remove(deleteReservation);  // 'reservations' yerine 'Reservations' kullanın
                _context.SaveChanges();
            }
        }

        public List<Reservation> GetAll()
        {
            return _context.Reservations.ToList();  // 'reservations' yerine 'Reservations' kullanın
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations.Find(id);  // 'reservations' yerine 'Reservations' kullanın
        }

        public Reservation Update(Reservation entity)
        {
            var reservation = _context.Reservations.Find(entity.CustomerID, entity.FlightID);  // 'reservations' yerine 'Reservations' kullanın
            if (reservation != null)
            {
                _context.Entry(reservation).CurrentValues.SetValues(entity);
                _context.SaveChanges();
                return reservation;
            }
            return null;
        }
    }
}
