using System.ComponentModel.DataAnnotations;

namespace ControllersAndApi.Data
{
    public class ParkingLot
    {
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Number { get; set; }
    }
}