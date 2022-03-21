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
    public class DiziKategoriConfiguration : IEntityTypeConfiguration<DiziKategori>
    {
        public void Configure(EntityTypeBuilder<DiziKategori> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.CategoryName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Type).HasMaxLength(20).IsRequired();



        }
    }
}
