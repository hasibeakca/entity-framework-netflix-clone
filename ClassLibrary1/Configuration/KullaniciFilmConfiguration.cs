using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Netflix.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Configuration
{
    public class KullaniciFilmConfiguration : IEntityTypeConfiguration<KullaniciFilm>
    {
        public void Configure(EntityTypeBuilder<KullaniciFilm> builder)
        {
            builder.HasKey(p=> p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.KullaniciId).IsRequired();
            builder.Property(p => p.FilmId).IsRequired();

            builder.HasOne(p => p.KullaniciFK).WithMany(p => p.KullaniciFilms).HasForeignKey(p => p.KullaniciId);
            builder.HasOne(p => p.FilmFK).WithMany(p => p.KullaniciFilms).HasForeignKey(p => p.FilmId);


        }
    }
}
