using Microsoft.EntityFrameworkCore;
using Senai.InLocl.WebApi.CodeFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLocl.WebApi.CodeFirst.Contexts
{
    public class InLockContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Estudios> Estudios { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV3\\SQLEXPRESS; initial catalog=InLock_Games_CodeFirst; user Id=sa; pwd=sa@132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposUsuario>().HasData(
                new TiposUsuario
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TiposUsuario
                {
                    IdTipoUsuario = 2,
                    Titulo = "Cliente"
                });

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    IdUsuario = 1,
                    Email = "admin@admin.com",
                    Senha = "admin",
                    IdTipoUsuario = 1
                },
                new Usuarios
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente.com",
                    Senha = "cliente",
                    IdTipoUsuario = 2
                });

            modelBuilder.Entity<Estudios>().HasData(
                    new Estudios { IdEstudio = 1, NomeEstudio = "Blizzard" },
                    new Estudios{IdEstudio = 2, NomeEstudio = "Square Enix"},
                    new Estudios{IdEstudio = 3, NomeEstudio = "Blizzard"});

            modelBuilder.Entity<Jogos>().HasData(
                new Jogos
                {
                    IdJogo = 1,
                    NomeJogo = "Diablo 3",
                    Descricao = "é um jogo que contém bastante ação e é viciante,seja você um novato ou um fã",
                    DataLancamento = Convert.ToDateTime("15/05/2012"),
                    Valor = Convert.ToDecimal("99.00"),
                    IdEstudio = 1
                },
                new Jogos
                {
                    IdJogo = 2,
                    NomeJogo = "Red Dead Redemption II",
                    Descricao = "jogo eletrônico de ação-aventura westen",
                    DataLancamento = Convert.ToDateTime("26/09/2018"),
                    Valor = Convert.ToDecimal("120.00"),
                    IdEstudio = 2

                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
