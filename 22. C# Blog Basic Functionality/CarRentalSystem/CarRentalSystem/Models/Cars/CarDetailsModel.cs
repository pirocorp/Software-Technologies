﻿namespace CarRentalSystem.Models.Cars
{
    using CarRentalSystem.Data;

    public class CarDetailsModel
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        public double Engine { get; set; }

        public int? Power { get; set; }

        public EngineType EngineType { get; set; }

        //In EURO
        public decimal PricePerDay { get; set; }

        public string ImageUrl { get; set; }

        public bool IsRented { get; set; }

        public int TotalRents { get; set; }

        public string ContactInformation { get; set; }
    }
}