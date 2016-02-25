using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RecipeBox.Models.Mapping
{
    public class RecipeReviewMap : EntityTypeConfiguration<RecipeReview>
    {
        public RecipeReviewMap()
        {
            // Primary Key
            this.HasKey(t => t.reviewID);

            // Properties
            this.Property(t => t.reviewBody)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("RecipeReview");
            this.Property(t => t.reviewID).HasColumnName("reviewID");
            this.Property(t => t.userID).HasColumnName("userID");
            this.Property(t => t.recipeID).HasColumnName("recipeID");
            this.Property(t => t.reviewBody).HasColumnName("reviewBody");
            this.Property(t => t.rating).HasColumnName("rating");

            // Relationships
            this.HasRequired(t => t.Recipe)
                .WithMany(t => t.RecipeReviews)
                .HasForeignKey(d => d.recipeID);
            this.HasRequired(t => t.UserID1)
                .WithMany(t => t.RecipeReviews)
                .HasForeignKey(d => d.userID);

        }
    }
}
