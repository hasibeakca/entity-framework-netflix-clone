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
    public class KullaniciDiziConfiguration : IEntityTypeConfiguration<KullaniciDizi>
    {
        public void Configure(EntityTypeBuilder<KullaniciDizi> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.KullaniciId).IsRequired();
            builder.Property(p => p.DiziId).IsRequired();

            builder.HasOne(p => p.KullaniciFK).WithMany(p => p.KullaniciDizis).HasForeignKey(p => p.KullaniciId);
            builder.HasOne(p => p.DiziFK).WithMany(P => P.KullaniciDizis).HasForeignKey(p=> p.DiziId);
        }
    }
}
