using GamesCRUD.Data.DatabaseMappings;
using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesCRUD.Data;

public partial class GameCrudDBContext : DbContext
{
    public GameCrudDBContext()
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public GameCrudDBContext(DbContextOptions<GameCrudDBContext> options)
        : base(options)
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }

    public virtual DbSet<Game> Games { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        //=> optionsBuilder
        //    .UseLazyLoadingProxies();
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GameMap());
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.ApplyConfiguration(new CategoryMap());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
