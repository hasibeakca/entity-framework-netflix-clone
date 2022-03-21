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
    public class DiziConfiguration : IEntityTypeConfiguration<Dizi>
    {
        public void Configure(EntityTypeBuilder<Dizi> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Type).HasMaxLength(100).IsRequired();
            builder.Property(p => p.AgeRange).IsRequired();
            builder.Property(p => p.EpisodeNumber).IsRequired();
            builder.Property(p => p.SeasonNumber).IsRequired();
            builder.Property(p => p.Imdb).IsRequired();

            builder.HasOne(p => p.DiziKategoriFK).WithMany(p => p.Dizis).HasForeignKey(p => p.DiziKategoriId);




    }
    }
}
