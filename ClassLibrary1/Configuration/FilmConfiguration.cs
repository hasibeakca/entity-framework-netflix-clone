using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NETFLIX.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netflix.DAL.Configuration
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Caption).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Time).IsRequired();
            builder.Property(p => p.AgeRange).IsRequired();

            builder.HasOne(p => p.FilmKategoriFK).WithMany(p => p.Films).HasForeignKey(p => p.FilmKategoriId);
        }
    }
}
