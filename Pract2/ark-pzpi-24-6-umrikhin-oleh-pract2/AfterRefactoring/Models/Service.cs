using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Models
{
    public class Service : Entity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public decimal Price { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
