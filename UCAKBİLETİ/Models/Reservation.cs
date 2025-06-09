using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCAKBİLETİ.Models
{
    public class Reservation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReservationID { get; set; }  // Rezervasyonun benzersiz ID'si

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }  // İlişkili müşteri

        public int FlightID { get; set; }
        public Flight Flight { get; set; }  // İlişkili uçuş

        public int SeatId { get; set; }  // Koltuk ID'si

        public DateTime DataTime { get; set; }  // Rezervasyon tarihi

        public int Piece { get; set; }  // Alınan bilet adedi
    }
}
