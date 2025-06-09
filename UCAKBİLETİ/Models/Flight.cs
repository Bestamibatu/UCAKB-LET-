using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Security.AccessControl;
using System;

namespace UCAKBİLETİ.Models
{
    // Uçuş bilgilerini tutan sınıf
    public class Flight
    {
        // Uçuş ID'si, her uçuşun benzersiz kimliği
        public int Id { get; set; }

        // Uçuşun kalkış yaptığı şehir
        public string FromCity { get; set; }

        // Uçuşun varış yaptığı şehir
        public string ToCity { get; set; }

        // Uçuşun kalkış zamanı
        public DateTime DepartureTime { get; set; }

        // Uçuşun varış zamanı
        public DateTime ArrivalTime { get; set; }

        // Uçuşun havayolu şirketi
        public string Airline { get; set; }

        // Uçuşta bulunan koltukların listesi
        public List<Seat> Seats { get; set; }

        // Uçuşun kota bilgisi (toplam koltuk sayısı)
        public int Quota { get; set; }

        // Uçuşun fiyatı
        public decimal Price { get; set; }

        // Uçuşta kalan koltuk sayısı
        public int AvailableSeats { get; set; }
        
        // Constructor - Başlangıçta Seats listesi boş olacak şekilde başlatılır
        public Flight()
        {
            Seats = new List<Seat>();  // Başlangıçta koltuk listesi boş
        }
    }

    // Koltuk bilgilerini tutan sınıf
    public class Seat
    {
        // Koltuk ID'si
        public int Id { get; set; }

        // Koltuk numarası
        public int SeatNumber { get; set; }

        // Koltuğun rezerve edilip edilmediği bilgisi
        public bool IsBooked { get; set; }
    }
}