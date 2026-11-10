using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingApp.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(200)]
        public string Address { get; set; }
        public int Stars { get; set; } 

        public List<Room> Rooms { get; set; } = new List<Room>();
    }
}
