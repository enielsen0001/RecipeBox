using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            this.RecipeNotes = new List<RecipeNote>();
            this.RecipeIngredients = new List<RecipeIngredient>();
            this.RecipeMenus = new List<RecipeMenu>();
            this.RecipeReviews = new List<RecipeReview>();
        }

        public int recipeID { get; set; }
        public string recipeName { get; set; }
        public string recipeDescription { get; set; }
        public Nullable<int> userID { get; set; }
        public virtual ICollection<RecipeNote> RecipeNotes { get; set; }
        public virtual UserID UserID1 { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<RecipeMenu> RecipeMenus { get; set; }
        public virtual ICollection<RecipeReview> RecipeReviews { get; set; }
    }
}
