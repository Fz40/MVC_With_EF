using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using MVC.Models;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();


        // GET: Category
        public ActionResult Index()
        {

            return View(db.Category.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category cat = new Category();
            cat = db.Category.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Category cat = new Category();
                cat.CategoryID = (from c in db.Category select c).OrderByDescending(x => x.CategoryID).First().CategoryID + 1;
                cat.CategoryName = collection["CategoryName"];
                cat.Description = collection["Description"];
                db.Category.Add(cat);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category cat = new Category();
            cat = db.Category.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Category cat = new Category();
                cat.CategoryID = Convert.ToInt32(collection["CategoryID"]);
                cat.CategoryName = collection["CategoryName"];
                cat.Description = collection["Description"];
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetProduct()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return View();
        }

    }
}
