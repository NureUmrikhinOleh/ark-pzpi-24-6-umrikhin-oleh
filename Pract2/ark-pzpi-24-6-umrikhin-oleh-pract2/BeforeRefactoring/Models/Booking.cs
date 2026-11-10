using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int RoomId { get; set; }   
        
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalAmount { get; set; }

        public Client? Client { get; set; }
        public Room? Room { get; set; }
        
        public List<Service> Services { get; set; } = new List<Service>();
    }
}