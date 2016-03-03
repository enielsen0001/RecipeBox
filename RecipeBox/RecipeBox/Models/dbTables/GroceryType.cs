using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
    public partial class GroceryType
    {
        public GroceryType()
        {
            this.Ingredients = new List<Ingredient>();
        }

        public string groceryCode { get; set; }
        public string groceryName { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
