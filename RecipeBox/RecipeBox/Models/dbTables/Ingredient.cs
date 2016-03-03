using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            this.RecipeIngredients = new List<RecipeIngredient>();
        }

        public int ingredientID { get; set; }
        public string groceryCode { get; set; }
        public string ingredientName { get; set; }
        public virtual GroceryType GroceryType { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
