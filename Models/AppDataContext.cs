using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
 //criação do banco com os outros modelos sendo tabelas
namespace MeuProjetoMinimalAPI.Models
{
    public class AppDataContext : DbContext //classe que representa o banco de dados
    { //definir as classes que vão virar as tabelas do banco 
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}