using Microsoft.EntityFrameworkCore;
using Netflix.DAL.Entities;
using NETFLIX.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Context
{
    public class NetflixDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-M227QJH7\SQLEXPRESS;Database=NetflixDB;Trusted_Connection=True;");
        }
        public DbSet<DiziKategori> DiziKategoriler { get; set; }
        public DbSet<Dizi> Diziler { get; set; }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<FilmKategori> FilmKategoris { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<KullaniciFilm> KullaniciFilms { get; set; }
        public DbSet<KullaniciDizi> KullaniciDizis { get; set; }

        // junctıonlar eklenecek unutma

    }
}
