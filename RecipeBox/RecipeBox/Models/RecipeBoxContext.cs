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

        public DbSet<GroceryType> GroceryTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeMenu> RecipeMenus { get; set; }
        public DbSet<RecipeNote> RecipeNotes { get; set; }
        public DbSet<RecipeReview> RecipeReviews { get; set; }
        public DbSet<UserID> UserIDs { get; set; }

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
            modelBuilder.Configurations.Add(new UserIDMap());
        }
    }
}
