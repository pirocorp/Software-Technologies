namespace CarRentalSystem.Controllers
{
    using System.Web.Mvc;
    using CarRentalSystem.Data;
    using System.Linq;
    using CarRentalSystem.Models.Cars;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new CarsDbContext();

            var cars = db.Cars
                .Where(c => !c.IsRented)
                .OrderByDescending(c => c.Id)
                .Take(3)
                .Select(c => new HomeIndexCarModel
                {
                    Id = c.Id,
                    Make = c.Make,
                    Model = c.Model,
                    Year = c.Year,
                    ImageUrl = c.ImageUrl,
                })
                .ToList();

            return View(cars);
        }
    }
}