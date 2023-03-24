using GamesCRUD.Data.DatabaseMappings;
using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace GamesCRUD.Data;

public partial class GameCrudDBContext : DbContext
{
    public GameCrudDBContext()
    {
    }

    public GameCrudDBContext(DbContextOptions<GameCrudDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Game> Games { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GameMap());
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoryMap());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
