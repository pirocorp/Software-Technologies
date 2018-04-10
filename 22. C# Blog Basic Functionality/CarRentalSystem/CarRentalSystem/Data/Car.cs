namespace CarRentalSystem.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Car
    {
        public Car()
        {
            this.Rentings = new List<Renting>();
        }

        [Key]
        public int Id { get; set; }

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

        public EngineType EngineType { get; set; }

        //In EURO
        public decimal PricePerDay { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool IsRented { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Renting> Rentings { get; set; }
    }
}