using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
    public partial class RecipeMenu
    {
        public int recipeMenuID { get; set; }
        public Nullable<int> recipeID { get; set; }
        public Nullable<int> menuID { get; set; }
        public virtual MenuType MenuType { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
