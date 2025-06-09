using UCAKBİLETİ.Bussiness.Abstract;
using UCAKBİLETİ.Models;
using UCAKBİLETİ.Models.Abstract;
using UCAKBİLETİ.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UCAKBİLETİ.Bussiness.Concrete
{
    public class FlightManager : IServices<Flight>
    {
        private readonly ITicketRepository<Flight> _ticketRepository;

        // FlightManager sınıfına ITicketRepository<Flight> parametresi alacak şekilde constructor ekliyoruz
        public FlightManager(ITicketRepository<Flight> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Flight Create(Flight entity)
        {
            return _ticketRepository.Create(entity);
        }

        public void Delete(int id)
        {
            _ticketRepository.Delete(id);
        }

        public List<Flight> GetAll()
        {
            return _ticketRepository.GetAll();
        }

        public Flight GetById(int id)
        {
            return _ticketRepository.GetById(id);
        }

        public Flight Update(Flight entity)
        {
            return _ticketRepository.Update(entity);
        }

        // Filtreleme işlemi: Kullanıcıdan alınan kriterlere göre uçuşları filtreler
        public List<Flight> FilterFlights(string fromCity, string toCity, DateTime? departureTime)
        {
            var flights = _ticketRepository.GetAll();

            if (!string.IsNullOrEmpty(fromCity))
                flights = flights.Where(f => f.FromCity == fromCity).ToList();

            if (!string.IsNullOrEmpty(toCity))
                flights = flights.Where(f => f.ToCity == toCity).ToList();

            if (departureTime.HasValue)
                flights = flights.Where(f => f.DepartureTime >= departureTime.Value).ToList();

            return flights;
        }

        // Koltuk rezervasyonu yapma işlemi
        public void BookSeat(int flightId, int seatId)
        {
            var flight = _ticketRepository.GetById(flightId);
            if (flight == null)
                throw new Exception("Uçuş bulunamadı.");

            var seat = flight.Seats.FirstOrDefault(s => s.Id == seatId);
            if (seat == null)
                throw new Exception("Koltuk bulunamadı.");

            if (seat.IsBooked)
                throw new Exception("Bu koltuk zaten rezerve edilmiştir.");

            seat.IsBooked = true;
            _ticketRepository.Update(flight);  // Koltuk durumu güncelleniyor
        }
    }
}
