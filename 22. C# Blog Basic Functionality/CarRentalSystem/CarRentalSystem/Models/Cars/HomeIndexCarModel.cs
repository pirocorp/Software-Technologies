using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models.Cars
{
    public class HomeIndexCarModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string ImageUrl { get; set; }
    }
}