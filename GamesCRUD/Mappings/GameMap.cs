using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesCRUD.Mappings;

public class GameMap : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> entity)
    {
            entity.ToTable("games");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Category)
                .HasMaxLength(30)
                .HasColumnName("category");

            entity.Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd()
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at")
                .ValueGeneratedOnAdd().HasDefaultValueSql("now()");

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

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at")
                .ValueGeneratedOnUpdate();
        
    }
}
