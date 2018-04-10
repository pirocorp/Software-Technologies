﻿namespace CarRentalSystem.Data
{
    public class Renting
    {
        public int Id { get; set; }

        public int Days { get; set; }

        public decimal TotalPrice { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}