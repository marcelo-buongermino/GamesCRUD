using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesCRUD.Mappings;

public class GameMap : IEntityTypeConfiguration<GameModel>
{
    public void Configure(EntityTypeBuilder<GameModel> builder)
    {
        builder.ToTable("Game");

        builder.Property(p => p.Nome)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(p => p.Categoria)
            .HasColumnType("varchar(50)");

        builder.Property(p => p.DataLancamento)
            .HasColumnType("date")
            .IsRequired();                ;


    }
}
