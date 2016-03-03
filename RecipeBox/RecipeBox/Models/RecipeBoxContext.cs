using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using RecipeBox.Models.Mapping;

namespace RecipeBox.Models
{
    public partial class RecipeBoxContext : DbContext
    {
        static RecipeBoxContext()
        {
            Database.SetInitializer<RecipeBoxContext>(null);
        }

        public RecipeBoxContext()
            : base("Name=RecipeBoxContext")
        {
        }

        public IDbSet<GroceryType> GroceryTypes { get; set; }
        public IDbSet<Ingredient> Ingredients { get; set; }
        public IDbSet<MenuType> MenuTypes { get; set; }
        public IDbSet<Recipe> Recipes { get; set; }
        public IDbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public IDbSet<RecipeMenu> RecipeMenus { get; set; }
        public IDbSet<RecipeNote> RecipeNotes { get; set; }
        public IDbSet<RecipeReview> RecipeReviews { get; set; }
        //public IDbSet<User> UserIDs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GroceryTypeMap());
            modelBuilder.Configurations.Add(new IngredientMap());
            modelBuilder.Configurations.Add(new MenuTypeMap());
            modelBuilder.Configurations.Add(new RecipeMap());
            modelBuilder.Configurations.Add(new RecipeIngredientMap());
            modelBuilder.Configurations.Add(new RecipeMenuMap());
            modelBuilder.Configurations.Add(new RecipeNoteMap());
            modelBuilder.Configurations.Add(new RecipeReviewMap());
            //modelBuilder.Configurations.Add(new UserIDMap());
        }

        public System.Data.Entity.DbSet<RecipeBox.Models.User> Users
        {
            get; set;
        }
    }
}
