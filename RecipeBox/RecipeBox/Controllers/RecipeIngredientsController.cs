using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RecipeBox.Models;

namespace RecipeBox.Controllers
{
    public class RecipeIngredientsController : Controller
    {
        private RecipeBoxContext db = new RecipeBoxContext();

        // GET: RecipeIngredients
        public ActionResult Index(string recipeName)
        {

            ViewBag.recipeName = recipeName;
            var recipeIngredients = db.RecipeIngredients.Include(r => r.Ingredient).Include(r => r.Recipe);
            return View(recipeIngredients.ToList());
        }

        // GET: RecipeIngredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Find(id);
            if (recipeIngredient == null)
            {
                return HttpNotFound();
            }
            return View(recipeIngredient);
        }

        // GET: RecipeIngredients/Create
        public ActionResult Create()
        {
            ViewBag.ingredientID = new SelectList(db.Ingredients, "ingredientID", "groceryCode");
            ViewBag.recipeID = new SelectList(db.Recipes, "recipeID", "recipeName");
            return View();
        }

        // POST: RecipeIngredients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "recipeID,ingredientID,amount,amountUnits")] RecipeIngredient recipeIngredient)
        {
            if (ModelState.IsValid)
            {
                db.RecipeIngredients.Add(recipeIngredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ingredientID = new SelectList(db.Ingredients, "ingredientID", "groceryCode", recipeIngredient.ingredientID);
            ViewBag.recipeID = new SelectList(db.Recipes, "recipeID", "recipeName", recipeIngredient.recipeID);
            return View(recipeIngredient);
        }

        // GET: RecipeIngredients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Find(id);
            if (recipeIngredient == null)
            {
                return HttpNotFound();
            }
            ViewBag.ingredientID = new SelectList(db.Ingredients, "ingredientID", "groceryCode", recipeIngredient.ingredientID);
            ViewBag.recipeID = new SelectList(db.Recipes, "recipeID", "recipeName", recipeIngredient.recipeID);
            return View(recipeIngredient);
        }

        // POST: RecipeIngredients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "recipeID,ingredientID,amount,amountUnits")] RecipeIngredient recipeIngredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipeIngredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ingredientID = new SelectList(db.Ingredients, "ingredientID", "groceryCode", recipeIngredient.ingredientID);
            ViewBag.recipeID = new SelectList(db.Recipes, "recipeID", "recipeName", recipeIngredient.recipeID);
            return View(recipeIngredient);
        }

        // GET: RecipeIngredients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Find(id);
            if (recipeIngredient == null)
            {
                return HttpNotFound();
            }
            return View(recipeIngredient);
        }

        // POST: RecipeIngredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Find(id);
            db.RecipeIngredients.Remove(recipeIngredient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
