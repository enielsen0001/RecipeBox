using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecipeBox.Models.Mapping
{
    public class RecipeIngredientMap : EntityTypeConfiguration<RecipeIngredient>
    {
        public RecipeIngredientMap()
        {
            // Primary Key
            this.HasKey(t => new { t.recipeID, t.ingredientID });

            // Properties
            this.Property(t => t.recipeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ingredientID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.amountUnits)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("RecipeIngredients");
            this.Property(t => t.recipeID).HasColumnName("recipeID");
            this.Property(t => t.ingredientID).HasColumnName("ingredientID");
            this.Property(t => t.amount).HasColumnName("amount");
            this.Property(t => t.amountUnits).HasColumnName("amountUnits");

            // Relationships
            this.HasRequired(t => t.Ingredient)
                .WithMany(t => t.RecipeIngredients)
                .HasForeignKey(d => d.ingredientID);
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.RecipeIngredients)
                .HasForeignKey(d => d.recipeID);

        }
    }
}
