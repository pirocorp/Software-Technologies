﻿using System;

namespace CarRentalSystem.Controllers
{
    using System.Web.Mvc;
    using CarRentalSystem.Models.Cars;
    using Microsoft.AspNet.Identity;
    using CarRentalSystem.Data;
    using System.Net;
    using System.Linq;
    using CarRentalSystem.Models.Renting;


    public class CarsController : Controller
    {
        public ActionResult All(int page = 1, string user = null, string search = null)
        {
            var db = new CarsDbContext();

            var pageSize = 5;

            var carsQuery = db.Cars.AsQueryable();

            if (search != null)
            {
                carsQuery = carsQuery
                    .Where(c => c.Make.ToLower().Contains(search.ToLower()) ||
                                c.Model.ToLower().Contains(search.ToLower()) ||
                                c.Year.ToString().Contains(search) ||
                                c.Color.ToLower().Contains(search.ToLower()));
            }

            if (user != null && user != string.Empty)
            {
                carsQuery = carsQuery
                    .Where(c => c.Owner.Email == user);
            }

            var cars = carsQuery
                .OrderByDescending(c => c.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(c => new CarListingModel()
                {
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl,
                    Id = c.Id,
                    PricePerDay = c.PricePerDay,
                    IsRented = c.IsRented,
                })
                .ToList();

            ViewBag.CurrentPage = page;

            return View(cars);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateCarModel carModel)
        {
            if (this.ModelState.IsValid)
            {
                var ownerId = this.User.Identity.GetUserId();

                var car = new Car
                {
                    Make = carModel.Make,
                    Model = carModel.Model,
                    Color = carModel.Color,
                    Engine = carModel.Engine,
                    EngineType = carModel.EngineType,
                    ImageUrl = carModel.ImageUrl,
                    Power = carModel.Power,
                    PricePerDay = carModel.PricePerDay,
                    Year = carModel.Year,
                    OwnerId = ownerId,
                };

                var db = new CarsDbContext();

                db.Cars.Add(car);
                db.SaveChanges();

                return RedirectToAction("Details", new {id = car.Id});
            }

            return View(carModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var db = new CarsDbContext();

            var car = db.Cars
                .Where(c => c.Id == id)
                .Select(c => new CarDetailsModel()
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    EngineType = c.EngineType,
                    ImageUrl = c.ImageUrl,
                    Year = c.Year,
                    Color = c.Color,
                    Power = c.Power,
                    PricePerDay = c.PricePerDay,
                    Engine = c.Engine,
                    IsRented = c.IsRented,
                    TotalRents = c.Rentings.Count,
                    ContactInformation = c.Owner.Email,
                })
                .FirstOrDefault();

            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Rent(RentCarModel rentCarModel)
        {
            if (rentCarModel.Days < 1 || rentCarModel.Days > 10)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var db = new CarsDbContext();

            var car = db.Cars
                .Where(c => c.Id == rentCarModel.CarId)
                .Select(c => new
                {
                    c.IsRented,
                    FullName = c.Make + " " + c.Model + " (" + c.Year + ")",
                    c.PricePerDay,
                    c.ImageUrl
                })
                .FirstOrDefault();

            if (car == null || car.IsRented)
            {
                return HttpNotFound();
            }

            rentCarModel.CarImageUrl = car.ImageUrl;
            rentCarModel.CarName = car.FullName;
            rentCarModel.PricePerDay = car.PricePerDay;
            rentCarModel.TotalPrice = car.PricePerDay * rentCarModel.Days;

            return View(rentCarModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Rent(int carId, int days)
        {
            var db = new CarsDbContext();

            var car = db.Cars
                .Where(c => c.Id == carId)
                .FirstOrDefault();

            var userId = this.User.Identity.GetUserId();

            if (car == null || car.IsRented || car.OwnerId == userId)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var renting = new Renting
            {
                CarId = carId,
                Days = days,
                RentedOn = DateTime.Now,
                UserId = userId,
                TotalPrice = days * car.PricePerDay
            };

            car.IsRented = true;

            db.Rentings.Add(renting);
            db.SaveChanges();

            return RedirectToAction("Details", new {id = car.Id});
        }
    }
}