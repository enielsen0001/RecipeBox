using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecipeBox.Models.Mapping
{
    public class RecipeMenuMap : EntityTypeConfiguration<RecipeMenu>
    {
        public RecipeMenuMap()
        {
            // Primary Key
            this.HasKey(t => t.recipeMenuID);

            // Properties
            // Table & Column Mappings
            this.ToTable("RecipeMenu");
            this.Property(t => t.recipeMenuID).HasColumnName("recipeMenuID");
            this.Property(t => t.recipeID).HasColumnName("recipeID");
            this.Property(t => t.menuID).HasColumnName("menuID");

            // Relationships
            this.HasOptional(t => t.MenuType)
                .WithMany(t => t.RecipeMenus)
                .HasForeignKey(d => d.menuID);
            this.HasOptional(t => t.Recipe)
                .WithMany(t => t.RecipeMenus)
                .HasForeignKey(d => d.recipeID);

        }
    }
}
