using System;

namespace ControllersAndApi.Data
{
    public class Booking
    {
        public int Id { get; set; }
        public ParkingLot ParkingLot { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
