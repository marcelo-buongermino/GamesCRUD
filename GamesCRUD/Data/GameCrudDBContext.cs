using GamesCRUD.Data.DatabaseMappings;
using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<Game> Games { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseNpgsql("User ID=postgres; Password=postgres; Server=localhost; Port=5432; Database=crud_games_api; Integrated Security=true; Pooling=true");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GameMap());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
