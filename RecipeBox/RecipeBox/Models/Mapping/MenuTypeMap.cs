using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecipeBox.Models.Mapping
{
    public class MenuTypeMap : EntityTypeConfiguration<MenuType>
    {
        public MenuTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.menuID);

            // Properties
            this.Property(t => t.menuDescription)
                .IsRequired()
                .HasMaxLength(75);

            // Table & Column Mappings
            this.ToTable("MenuType");
            this.Property(t => t.menuID).HasColumnName("menuID");
            this.Property(t => t.menuDescription).HasColumnName("menuDescription");
        }
    }
}
