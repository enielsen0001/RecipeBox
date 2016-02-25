using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecipeBox.Models.Mapping
{
    public class UserIDMap : EntityTypeConfiguration<UserID>
    {
        public UserIDMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.screenName)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.userEmail)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.password)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UserID");
            this.Property(t => t.ID).HasColumnName("userID");
            this.Property(t => t.screenName).HasColumnName("screenName");
            this.Property(t => t.userEmail).HasColumnName("userEmail");
            this.Property(t => t.password).HasColumnName("password");
        }
    }
}
