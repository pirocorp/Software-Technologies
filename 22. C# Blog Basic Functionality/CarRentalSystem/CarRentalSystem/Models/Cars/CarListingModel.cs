using System.ComponentModel.DataAnnotations;

namespace CarRentalSystem.Models.Cars
{
    public class CarListingModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string ImageUrl { get; set; }

        public decimal PricePerDay { get; set; }

        public bool IsRented { get; set; }
    }
}