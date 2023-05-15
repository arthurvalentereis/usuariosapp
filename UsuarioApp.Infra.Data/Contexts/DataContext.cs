using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Models;
using UsuarioApp.Infra.Data.Configurations;

namespace UsuarioApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        /*Antes utilizava banco de dados em memória para teste */
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseInMemoryDatabase(databaseName: "UsuariosApp");
        //}

        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        public DbSet<Usuario>? Usuarios { get; set; }
    }
}



