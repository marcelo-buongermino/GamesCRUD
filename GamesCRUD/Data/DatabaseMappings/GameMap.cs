using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesCRUD.Data.DatabaseMappings;

public class GameMap : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> entity)
    {
        entity.ToTable("games");

        entity.Property(e => e.Id).HasColumnName("id").IsRequired();

        entity.Property(e => e.Description)
            .HasMaxLength(300)
            .HasColumnName("description");

        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");

        entity.Property(e => e.Platform)
            .HasMaxLength(20)
            .HasColumnName("platform");

        entity.Property(e => e.Price)
            .HasPrecision(6, 2)
            .HasColumnName("price");

        entity.Property(e => e.ReleaseDate).HasColumnName("release_date");

        entity.Property(e => e.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created_at");

        entity.Property(e => e.UpdatedAt)
            .ValueGeneratedOnUpdate()
            .HasColumnType("timestamp without time zone")
            .HasColumnName("updated_at");

        entity.Property(e => e.CategoryId).HasColumnName("category_id");
        entity.HasOne(e => e.Category).WithMany(e => e.Games).HasForeignKey(e => e.CategoryId);


    }
}
