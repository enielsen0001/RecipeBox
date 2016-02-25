using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecipeBox.Models.Mapping
{
    public class RecipeMap : EntityTypeConfiguration<Recipe>
    {
        public RecipeMap()
        {
            // Primary Key
            this.HasKey(t => t.recipeID);

            // Properties
            this.Property(t => t.recipeName)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.recipeDescription)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Recipe");
            this.Property(t => t.recipeID).HasColumnName("recipeID");
            this.Property(t => t.recipeName).HasColumnName("recipeName");
            this.Property(t => t.recipeDescription).HasColumnName("recipeDescription");
            this.Property(t => t.userID).HasColumnName("userID");

            // Relationships
            this.HasOptional(t => t.UserID1)
                .WithMany(t => t.Recipes)
                .HasForeignKey(d => d.userID);

        }
    }
}
