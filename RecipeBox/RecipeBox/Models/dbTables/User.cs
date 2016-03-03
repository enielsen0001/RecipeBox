using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeBox.Models
{
    public partial class User
    {
        public User()
        {
            this.Recipes = new List<Recipe>();
            this.RecipeNotes = new List<RecipeNote>();
            this.RecipeReviews = new List<RecipeReview>();
        }
        
        public int userID { get; set; }
        public string screenName { get; set; }
        public string userEmail { get; set; }
        public string password { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<RecipeNote> RecipeNotes { get; set; }
        public virtual ICollection<RecipeReview> RecipeReviews { get; set; }
    }
}
