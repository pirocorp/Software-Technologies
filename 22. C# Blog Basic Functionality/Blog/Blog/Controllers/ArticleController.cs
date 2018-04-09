using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Microsoft.AspNet.Identity;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: Article
        public ActionResult List()
        {
            using (var database = new BlogDbContext())
            {
                //Get Articles form database
                var articles = database.Articles.Include(a => a.Author).ToList();

                return View(articles);
            }
        }

        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                //Get Article from Database
                var article = database.Articles.Include(a => a.Author).ToList().Find(a => a.Id == id);
                

                if (article == null)
                {
                    return HttpNotFound();
                }

                return View(article);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                //Insert Article in DB
                using (var database = new BlogDbContext())
                {
                    //Get author id
                    var authorId = this.User.Identity.GetUserId();

                    //Set article author
                    article.AuthorId = authorId;

                    //Save article in db
                    database.Articles.Add(article);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

            return View(article);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                //Get article from db
                var article = database.Articles.Include(a => a.Author).ToList().Find(a => a.Id == id);

                //Check if user is author or admin
                if (!IsAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                //Check if article exist
                if (article == null)
                {
                    return HttpNotFound();
                }

                //Pass article to the View
                return View(article);
            }
        }

        [HttpPost]
        [Authorize]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                //Get article from the database
                var article = database.Articles.Include(a => a.Author).ToList().Find(a => a.Id == id);

                //Check if user is author or admin
                if (!IsAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                //Check if article exist
                if (article == null)
                {
                    return HttpNotFound();
                }

                //Delete artcile from db (persist changes)
                database.Articles.Remove(article);
                database.SaveChanges();

                //Redirect to index page
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                //Get article from the database
                var article = database.Articles.Include(a => a.Author).ToList().Find(a => a.Id == id);

                //Check if user is author or admin
                if (!IsAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

                //Check if article exist
                if (article == null)
                {
                    return HttpNotFound();
                }

                //Create the view model
                var model = new ArticleViewModel();
                model.Id = article.Id;
                model.Title = article.Title;
                model.Content = article.Content;

                //Pass the view model to view
                return View(model);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(ArticleViewModel model)
        {
            //Check if model state is valid
            if (ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
                    //Get article from database
                    var article = database.Articles.Include(a => a.Author).ToList().Find(a => a.Id == model.Id);

                    //Check if user is author or admin
                    if (!IsAuthorizedToEdit(article))
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                    }

                    //Set article properties
                    article.Title = model.Title;
                    article.Content = model.Content;
                    article.DateAdded = DateTime.Now;

                    //Save article in database
                    database.Entry(article).State = EntityState.Modified;
                    database.SaveChanges();

                    //Redirect to index page
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        private bool IsAuthorizedToEdit(Article article)
        {
            var isAdmin = this.User.IsInRole("Admin");
            var isAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }
    }
}