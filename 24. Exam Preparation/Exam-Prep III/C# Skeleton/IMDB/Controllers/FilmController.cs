using System;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMDB.Models;
using Microsoft.Ajax.Utilities;

namespace IMDB.Controllers
{
    //[ValidateInput(false)]
    public class FilmController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Index()
        {
            using (var db = new IMDBDbContext())
            {
                var movies = db.Films.ToList();

                return View(movies);
            }
        }

        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            if (film == null)
            {
                return RedirectToAction("Create");
            }

            if (string.IsNullOrWhiteSpace(film.Name))
            {
                return RedirectToAction("Create");
            }

            if (string.IsNullOrWhiteSpace(film.Genre))
            {
                return RedirectToAction("Create");
            }

            if (string.IsNullOrWhiteSpace(film.Director))
            {
                return RedirectToAction("Create");
            }

            using (var db = new IMDBDbContext())
            {
                db.Films.Add(film);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Find(id);

                if (film == null)
                {
                    return HttpNotFound();
                }

                return View(film);
            }
        }

        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Find(id);

                if (film == null)
                {
                    return HttpNotFound();
                }

                //Set film parameters
                film.Name = filmModel.Name;
                film.Director = filmModel.Director;
                film.Genre = filmModel.Genre;
                film.Year = filmModel.Year;

                //Save film to DB
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Find(id);

                if (film == null)
                {
                    return HttpNotFound();
                }

                return View(film);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int? id, Film filmModel)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var db = new IMDBDbContext())
            {
                var film = db.Films.Find(id);

                if (film == null)
                {
                    return RedirectToAction("Index");
                }

                db.Films.Remove(film);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}