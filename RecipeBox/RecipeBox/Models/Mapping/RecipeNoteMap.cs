using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecipeBox.Models.Mapping
{
    public class RecipeNoteMap : EntityTypeConfiguration<RecipeNote>
    {
        public RecipeNoteMap()
        {
            // Primary Key
            this.HasKey(t => new { t.recipeID, t.userID });

            // Properties
            this.Property(t => t.recipeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.userID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.noteBody)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("RecipeNotes");
            this.Property(t => t.recipeID).HasColumnName("recipeID");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.noteBody).HasColumnName("noteBody");

            // Relationships
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.RecipeNotes)
                .HasForeignKey(d => d.recipeID);
            this.HasRequired(t => t.UserID1)
                .WithMany(t => t.RecipeNotes)
                .HasForeignKey(d => d.userID);

        }
    }
}
