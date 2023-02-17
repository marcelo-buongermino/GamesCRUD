using GamesCRUD.Mappings;
using GamesCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesCRUD.Data
{
    public class GameCrudDBContext : DbContext
    {
        public GameCrudDBContext(DbContextOptions<GameCrudDBContext> options): base(options) 
        {

        }

        //DB Sets
        public DbSet<GameModel> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //aplica as configuracoes definidas no na classe GameMap
            modelBuilder.ApplyConfiguration(new GameMap());

        }
    }
}
