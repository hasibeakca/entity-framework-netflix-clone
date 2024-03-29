﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Netflix.DAL.Context;

namespace Netflix.DAL.Migrations
{
    [DbContext(typeof(NetflixDbContext))]
    partial class NetflixDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NETFLIX.DAL.Entities.Dizi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeRange")
                        .HasColumnType("int");

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUser")
                        .HasColumnType("int");

                    b.Property<int>("DiziKategoriId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeNumber")
                        .HasColumnType("int");

                    b.Property<int>("Imdb")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SeasonNumber")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DiziKategoriId");

                    b.ToTable("Diziler");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.DiziKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUser")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MUser")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("DiziKategoriler");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeRange")
                        .HasColumnType("int");

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUser")
                        .HasColumnType("int");

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FilmKategoriId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmKategoriId");

                    b.ToTable("Filmler");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.FilmKategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUser")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("FilmKategoris");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUser")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MUser")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Paymentİnformation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("Netflix.DAL.Entities.KullaniciDizi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUser")
                        .HasColumnType("int");

                    b.Property<int>("DiziId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MUser")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiziId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("KullaniciDizis");
                });

            modelBuilder.Entity("Netflix.DAL.Entities.KullaniciFilm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CUser")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MUser")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.HasIndex("KullaniciId");

                    b.ToTable("KullaniciFilms");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.Dizi", b =>
                {
                    b.HasOne("NETFLIX.DAL.Entities.DiziKategori", "DiziKategoriFK")
                        .WithMany("Dizis")
                        .HasForeignKey("DiziKategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiziKategoriFK");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.Film", b =>
                {
                    b.HasOne("NETFLIX.DAL.Entities.FilmKategori", "FilmKategoriFK")
                        .WithMany("Films")
                        .HasForeignKey("FilmKategoriId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmKategoriFK");
                });

            modelBuilder.Entity("Netflix.DAL.Entities.KullaniciDizi", b =>
                {
                    b.HasOne("NETFLIX.DAL.Entities.Dizi", "DiziFK")
                        .WithMany("KullaniciDizis")
                        .HasForeignKey("DiziId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NETFLIX.DAL.Entities.Kullanici", "KullaniciFK")
                        .WithMany("KullaniciDizis")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiziFK");

                    b.Navigation("KullaniciFK");
                });

            modelBuilder.Entity("Netflix.DAL.Entities.KullaniciFilm", b =>
                {
                    b.HasOne("NETFLIX.DAL.Entities.Film", "FilmFK")
                        .WithMany("KullaniciFilms")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NETFLIX.DAL.Entities.Kullanici", "KullaniciFK")
                        .WithMany("KullaniciFilms")
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FilmFK");

                    b.Navigation("KullaniciFK");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.Dizi", b =>
                {
                    b.Navigation("KullaniciDizis");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.DiziKategori", b =>
                {
                    b.Navigation("Dizis");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.Film", b =>
                {
                    b.Navigation("KullaniciFilms");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.FilmKategori", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("NETFLIX.DAL.Entities.Kullanici", b =>
                {
                    b.Navigation("KullaniciDizis");

                    b.Navigation("KullaniciFilms");
                });
#pragma warning restore 612, 618
        }
    }
}
