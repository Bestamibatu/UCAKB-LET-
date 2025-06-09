using UCAKBİLETİ.Bussiness.Abstract;
using UCAKBİLETİ.Models;
using UCAKBİLETİ.Models.Abstract;
using UCAKBİLETİ.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UCAKBİLETİ.Bussiness.Concrete
{
    public class ReservationManager : IServices<Reservation>
    {
        private readonly ITicketRepository<Reservation> _reservationRepository;

        public ReservationManager(ITicketRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public List<Reservation> GetAll()
        {
            return _reservationRepository.GetAll();
        }

        public Reservation GetById(int id)
        {
            return _reservationRepository.GetById(id);
        }

        public Reservation Create(Reservation entity)
        {
            return _reservationRepository.Create(entity);
        }

        public Reservation Update(Reservation entity)
        {
            return _reservationRepository.Update(entity);
        }

        public void Delete(int id)
        {
            _reservationRepository.Delete(id);
        }

        public void BookSeat(int flightId, int seatId)
        {
            // BookSeat implementasyonu
        }
    }
}
