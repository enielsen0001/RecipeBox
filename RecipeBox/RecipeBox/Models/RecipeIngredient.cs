using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
    public partial class RecipeIngredient
    {
        public int recipeID { get; set; }
        public int ingredientID { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string amountUnits { get; set; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
