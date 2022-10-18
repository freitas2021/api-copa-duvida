using ApiCopaStone.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiCopaStone.Data
{
    public class DataContext : DbContext
    {
  
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admins {get; set; }
        public DbSet<FaseCopa> FaseCopas {get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Selecao> Selecaos {get; set; } 

    }   
}