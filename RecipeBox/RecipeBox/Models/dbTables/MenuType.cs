using System;
using System.Collections.Generic;

namespace RecipeBox.Models
{
    public partial class MenuType
    {
        public MenuType()
        {
            this.RecipeMenus = new List<RecipeMenu>();
        }

        public int menuID { get; set; }
        public string menuDescription { get; set; }
        public virtual ICollection<RecipeMenu> RecipeMenus { get; set; }
    }
}
