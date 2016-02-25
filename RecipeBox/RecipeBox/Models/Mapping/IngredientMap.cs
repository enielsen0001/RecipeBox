using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecipeBox.Models.Mapping
{
    public class IngredientMap : EntityTypeConfiguration<Ingredient>
    {
        public IngredientMap()
        {
            // Primary Key
            this.HasKey(t => t.ingredientID);

            // Properties
            this.Property(t => t.groceryCode)
                .HasMaxLength(2);

            this.Property(t => t.ingredientName)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Ingredients");
            this.Property(t => t.ingredientID).HasColumnName("ingredientID");
            this.Property(t => t.groceryCode).HasColumnName("groceryCode");
            this.Property(t => t.ingredientName).HasColumnName("ingredientName");

            // Relationships
            this.HasOptional(t => t.GroceryType)
                .WithMany(t => t.Ingredients)
                .HasForeignKey(d => d.groceryCode);

        }
    }
}
