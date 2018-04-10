﻿using System.Data.Entity;

namespace CarRentalSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class CarsDbContext : IdentityDbContext<User>
    {
        public CarsDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Car> Cars { get; set; }
        public virtual IDbSet<Renting> Rentings { get; set; }

        public static CarsDbContext Create()
        {
            return new CarsDbContext();
        }
    }
}