using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vehiculos.API.Data.Entities;

namespace Vehiculos.API.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }


        public DbSet<VehiculoTipo> VehiculosTipo { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehiculoTipo>().HasIndex(x => x.Descripcion).IsUnique();

            modelBuilder.Entity<Procedimiento>().HasIndex(x => x.Descripcion).IsUnique();


            modelBuilder.Entity<Marca>().HasIndex(x => x.Descripcion).IsUnique();

            modelBuilder.Entity<TipoDocumento>().HasIndex(x => x.Descripcion).IsUnique();



        }
    }
}
