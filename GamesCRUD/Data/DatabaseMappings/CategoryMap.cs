using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesCRUD.Data.DatabaseMappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.ToTable("categories");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
          .HasMaxLength(30)
          .HasColumnName("name");

            entity.Property(e => e.CreatedAt)
          .ValueGeneratedOnAdd()
          .HasColumnType("timestamp without time zone")
          .HasColumnName("created_at");
        }
    }
}
