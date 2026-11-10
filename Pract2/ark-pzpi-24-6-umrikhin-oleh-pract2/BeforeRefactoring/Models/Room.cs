using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; } 
        public string RoomNumber { get; set; }
        public int Capacity { get; set; } 
        public decimal PricePerNight { get; set; }

        public Hotel Hotel { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}