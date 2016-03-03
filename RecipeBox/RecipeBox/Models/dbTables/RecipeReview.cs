using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
    public partial class RecipeReview
    {
        public int reviewID { get; set; }
        public int userID { get; set; }
        public int recipeID { get; set; }
        public string reviewBody { get; set; }
        public Nullable<int> rating { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
