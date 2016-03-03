using RecipeBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecipeBox.Controllers
{
    public class RecipesController : Controller
    {
        private RecipeBoxContext _db = new RecipeBoxContext();


    // GET: Recipes
    public ActionResult Index()
    {

        return View(_db.Recipes.ToList());
    }

    // GET: Recipes/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: Recipes/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: Recipes/Create
    [HttpPost]
    public ActionResult Create(Recipe recipe)
    {
        try
        {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    _db.Recipes.Add(recipe);
                    _db.SaveChanges();
                    return Redirect("~/RecipeIngredients/Create?");
                }

            return View(recipe);
        }
        catch
        {
            return View();
        }
    }

    // GET: Recipes/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: Recipes/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection)
    {
        try
        {
            // TODO: Add update logic here

            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // GET: Recipes/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: Recipes/Delete/5
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
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
