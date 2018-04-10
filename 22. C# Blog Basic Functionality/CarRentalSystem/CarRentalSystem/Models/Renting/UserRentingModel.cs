namespace CarRentalSystem.Models.Renting
{
    using System;

    public class UserRentingModel
    {

        public int Days { get; set; }

        public DateTime RentedOn { get; set; }

        public decimal TotalPrice { get; set; }

        public string CarName { get; set; }

        public string CarImageUrl { get; set; }
    }
}