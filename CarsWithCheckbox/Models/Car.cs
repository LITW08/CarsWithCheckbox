using System;

namespace CarsWithCheckbox.Models
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool HasLeatherSeats { get; set; }
        public CarType CarType { get; set; }
    }
}
