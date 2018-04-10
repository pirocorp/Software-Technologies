namespace CarRentalSystem.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CarRentalSystem.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<CarRentalSystem.Data.CarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
            ContextKey = "CarRentalSystem.Data.CarsDbContext";
        }

        protected override void Seed(Data.CarsDbContext context)
        {
            if (context.Cars.Any())
            {
                return;
            }

            var user = context.Users.FirstOrDefault();

            if (user == null)
            {
                return;
            }

            context.Cars.Add(new Car
            {
                Make = "BMW",
                Model = "X5",
                Color = "Black",
                Engine = 5.0,
                EngineType = EngineType.Diesel,
                ImageUrl = "https://smgmedia.blob.core.windows.net/images/105348/800/bmw-x5-suv-diesel-7573eb435ae8.jpg",
                Power = 420,
                PricePerDay = 250,
                Year = 2017,
                OwnerId = user.Id,
            });

            context.Cars.Add(new Car
            {
                Make = "Mercedes",
                Model = "AMG GLA 45 4Matic Yellow Night Edition",
                Color = "Black",
                Engine = 3.5,
                EngineType = EngineType.Diesel,
                ImageUrl = "https://car-images.bauersecure.com/pagefiles/76865/1040x585/merc_gla45_yn_01.jpg",
                Power = 320,
                PricePerDay = 350,
                Year = 2017,
                OwnerId = user.Id,
            });

            context.Cars.Add(new Car
            {
                Make = "BMW",
                Model = "X7",
                Color = "Black",
                Engine = 2.0,
                EngineType = EngineType.Diesel,
                ImageUrl = "https://smgmedia.blob.core.windows.net/images/105348/800/bmw-x5-suv-diesel-7573eb435ae8.jpg",
                Power = 220,
                PricePerDay = 150,
                Year = 2015,
                OwnerId = user.Id,
            });

            context.Cars.Add(new Car
            {
                Make = "Mercedes",
                Model = "AMG GLA 45",
                Color = "Black",
                Engine = 3.5,
                EngineType = EngineType.Gasoline,
                ImageUrl = "https://car-images.bauersecure.com/pagefiles/76865/1040x585/merc_gla45_yn_01.jpg",
                Power = 720,
                PricePerDay = 550,
                Year = 2017,
                OwnerId = user.Id,
            });

            context.Cars.Add(new Car
            {
                Make = "BMW",
                Model = "650i Grand Coupe",
                Color = "Blue",
                Engine = 4.4,
                EngineType = EngineType.Gasoline,
                ImageUrl = "https://res.cloudinary.com/carsguide/image/upload/f_auto,fl_lossy,q_auto,t_cg_hero_large/v1/editorial/bmw-650i-gran-coupe-2015-%282%29.jpg",
                Power = 580,
                PricePerDay = 840,
                Year = 2016,
                OwnerId = user.Id,
            });

            context.Cars.Add(new Car
            {
                Make = "BMW",
                Model = "650i",
                Color = "Brown",
                Engine = 4.4,
                EngineType = EngineType.Gasoline,
                ImageUrl = "http://www.autoguide.com/images/content/2013-BMW-6-Series-Gran-Coupe-13_rdax_646x396.jpg",
                Power = 445,
                PricePerDay = 740,
                Year = 2017,
                OwnerId = user.Id,
            });

            context.Cars.Add(new Car
            {
                Make = "Tesla",
                Model = "Model S P100D",
                Color = "Red",
                Engine = 0.0,
                EngineType = EngineType.Other,
                ImageUrl = "https://www.tesla.com/sites/default/files/images/blogs/p100d_social.jpg",
                Power = 1200,
                PricePerDay = 1040,
                Year = 2018,
                OwnerId = user.Id,
            });

            context.Cars.Add(new Car
            {
                Make = "Tesla",
                Model = "Model S P85D",
                Color = "Black",
                Engine = 0.0,
                EngineType = EngineType.Other,
                ImageUrl = "http://ecolodriver.com/wp-content/uploads/2016/01/Tesla-Model-s-Dual-Motor-P85D.jpg",
                Power = 420,
                PricePerDay = 440,
                Year = 2015,
                OwnerId = user.Id,
            });
        }
    }
}
