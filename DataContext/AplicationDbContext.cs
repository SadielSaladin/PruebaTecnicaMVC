using Fifa2022.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fifa2022.DataContext
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Estado> Estados { get; set; }
        public DbSet<Jugador> Jugadores { get; set; }
        public DbSet<Equipo> Equipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Write Fluent API configurations here

            //Property Configurations
            var jugadores = modelBuilder.Entity<Jugador>();

            jugadores.Property(b => b.Nombre).IsRequired();
            jugadores.HasKey(b => b.Id);
            jugadores.Property(b => b.Apellido).IsRequired();
            jugadores.Property(b => b.Sexo).IsRequired();

            var estados = modelBuilder.Entity<Estado>();

            estados.Property(b => b.Nombre_Estado).IsRequired();
            estados.HasKey(b => b.Id);

            var equipos = modelBuilder.Entity<Equipo>();

            equipos.HasKey(b => b.Id);
            equipos.Property(b => b.Nombre).IsRequired();
            equipos.Property(b => b.Pais).IsRequired();
            

        }
    }
}
