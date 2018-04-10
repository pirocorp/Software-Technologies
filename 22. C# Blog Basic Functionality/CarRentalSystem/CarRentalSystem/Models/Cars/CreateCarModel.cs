namespace CarRentalSystem.Models.Cars
{
    using System.ComponentModel.DataAnnotations;
    using CarRentalSystem.Data;
    using CarRentalSystem.Infrastructure;

    public class CreateCarModel
    {
        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(1900, 2050)]
        public int Year { get; set; }

        public string Color { get; set; }

        public double Engine { get; set; }

        public int? Power { get; set; }

        [Display(Name = "Engine Type")]
        [ScaffoldColumn(false)]
        public EngineType EngineType { get; set; }

        //In EURO
        [Display(Name = "Price in EUR per day")]
        public decimal PricePerDay { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        [Url]
        [ImageUrl]
        public string ImageUrl { get; set; }
    }
}