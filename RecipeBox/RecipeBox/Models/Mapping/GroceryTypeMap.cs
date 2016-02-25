using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecipeBox.Models.Mapping
{
    public class GroceryTypeMap : EntityTypeConfiguration<GroceryType>
    {
        public GroceryTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.groceryCode);

            // Properties
            this.Property(t => t.groceryCode)
                .IsRequired()
                .HasMaxLength(2);

            this.Property(t => t.groceryName)
                .IsRequired()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("GroceryType");
            this.Property(t => t.groceryCode).HasColumnName("groceryCode");
            this.Property(t => t.groceryName).HasColumnName("groceryName");
        }
    }
}
