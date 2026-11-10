using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HotelBookingApp.Models;

namespace HotelBookingApp.Data
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            // apply migrations / ensure database
            context.Database.Migrate();

            // avoid duplicating seed data
            if (context.Hotels.Any() || context.Clients.Any() || context.Services.Any() || context.Bookings.Any())
                return;

            var hotel1 = new Hotel { Name = "Sunrise Inn", Address = "123 Beach Ave", Stars = 4 };
            var hotel2 = new Hotel { Name = "Mountain View", Address = "456 Hill Rd", Stars = 3 };

            var room1 = new Room { Hotel = hotel1, RoomNumber = "101", Capacity = 2, PricePerNight = 50m };
            var room2 = new Room { Hotel = hotel1, RoomNumber = "102", Capacity = 4, PricePerNight = 80m };
            var room3 = new Room { Hotel = hotel2, RoomNumber = "201", Capacity = 2, PricePerNight = 60m };
            var room4 = new Room { Hotel = hotel2, RoomNumber = "202", Capacity = 1, PricePerNight = 40m };

            var client1 = new Client { FirstName = "Ivan", LastName = "Petrov", Email = "ivan@example.com", PhoneNumber = "+380501234567" };
            var client2 = new Client { FirstName = "Olena", LastName = "Shevchenko", Email = "olena@example.com", PhoneNumber = "+380631112233" };

            var service1 = new Service { Name = "Breakfast", Price = 5m };
            var service2 = new Service { Name = "Airport Pickup", Price = 20m };

            var booking1 = new Booking
            {
                Client = client1,
                Room = room1,
                CheckInDate = new DateTime(2026, 5, 28),
                CheckOutDate = new DateTime(2026, 5, 31),
            };
            booking1.TotalAmount = (decimal)(booking1.CheckOutDate - booking1.CheckInDate).TotalDays * room1.PricePerNight + service1.Price;
            booking1.Services.Add(service1);

            var booking2 = new Booking
            {
                Client = client2,
                Room = room3,
                CheckInDate = new DateTime(2026, 5, 30),
                CheckOutDate = new DateTime(2026, 6, 1),
            };
            booking2.TotalAmount = (decimal)(booking2.CheckOutDate - booking2.CheckInDate).TotalDays * room3.PricePerNight;

            context.Hotels.AddRange(hotel1, hotel2);
            context.Rooms.AddRange(room1, room2, room3, room4);
            context.Clients.AddRange(client1, client2);
            context.Services.AddRange(service1, service2);
            context.Bookings.AddRange(booking1, booking2);

            context.SaveChanges();
        }
    }
}
