using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
    public partial class RecipeNote
    {
        public int recipeID { get; set; }
        public int userID { get; set; }
        public string noteBody { get; set; }
        public virtual Recipe Recipe { get; set; }
        public virtual UserID UserID1 { get; set; }
    }
}
