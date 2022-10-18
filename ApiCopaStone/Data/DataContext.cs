using ApiCopaStone.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiCopaStone.Data
{
    public class DataContext : DbContext
    {
        //Representação do Banco de Dados
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        //}
        //Representação das Tabelas do Banco de dados 
        public DbSet<Admin> Admins {get; set; }
        public DbSet<FaseCopa> FaseCopas {get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Selecao> Selecaos {get; set; } 

    }   
}