using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practica.Shared.Entities;

namespace Practica.Server.Data
{
    public class ApplicationDataContext : DbContext
    {
        // Constructor
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) 
            : base(options)
        {

        }

        // Mapear la base de datos

        public DbSet<Bodega> Bodegas { get; set; }

        public DbSet<Ciudad> Ciudades { get; set; }

        public DbSet<Comuna> Comunas { get; set; }

        public DbSet<Sucursal> Sucursales { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Ciudad>().HasData(new Ciudad { Id_Ciudad = 1, NombreCiudad = "Antofagasta" });

            builder.Entity<Ciudad>().HasData(new Ciudad { Id_Ciudad= 2, NombreCiudad = "Calama" });

        }
    }
}
