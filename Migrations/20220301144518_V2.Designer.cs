﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace ProjekatWEB.Migrations
{
    [DbContext(typeof(TeretanaContext))]
    [Migration("20220301144518_V2")]
    partial class V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.Property<string>("KorisnickoIme")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("KorisnickoIme");

                    b.Property<string>("Lozinka")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Lozinka");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prezime");

                    b.Property<int?>("teretanaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("teretanaID");

                    b.ToTable("Clan");
                });

            modelBuilder.Entity("Models.Teretana", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Adresa");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("KontakTelefon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("KontakTelefon");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<string>("Vlasnik")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Vlasnik");

                    b.HasKey("ID");

                    b.ToTable("Teretana");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrZauzetih")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("BrZauzetih");

                    b.Property<int?>("ClanID")
                        .HasColumnType("int");

                    b.Property<string>("Dan")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Dan");

                    b.Property<int>("MaxBrMesta")
                        .HasColumnType("int")
                        .HasColumnName("MaxBrMesta");

                    b.Property<DateTime>("Vreme")
                        .HasColumnType("datetime2")
                        .HasColumnName("Vreme");

                    b.Property<int?>("teretanaID")
                        .HasColumnType("int");

                    b.Property<int?>("trenerID")
                        .HasColumnType("int");

                    b.Property<int?>("treningID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClanID");

                    b.HasIndex("teretanaID");

                    b.HasIndex("trenerID");

                    b.HasIndex("treningID");

                    b.ToTable("Termin");
                });

            modelBuilder.Entity("Models.Trener", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prezime");

                    b.HasKey("ID");

                    b.ToTable("Trener");
                });

            modelBuilder.Entity("Models.Trening", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<int?>("vrstaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("vrstaID");

                    b.ToTable("Trening");
                });

            modelBuilder.Entity("Models.Vrsta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<int?>("TeretanaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TeretanaID");

                    b.ToTable("Vrsta");
                });

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.HasOne("Models.Teretana", "teretana")
                        .WithMany("clanovi")
                        .HasForeignKey("teretanaID");

                    b.Navigation("teretana");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.HasOne("Models.Clan", null)
                        .WithMany("termini")
                        .HasForeignKey("ClanID");

                    b.HasOne("Models.Teretana", "teretana")
                        .WithMany()
                        .HasForeignKey("teretanaID");

                    b.HasOne("Models.Trener", "trener")
                        .WithMany()
                        .HasForeignKey("trenerID");

                    b.HasOne("Models.Trening", "trening")
                        .WithMany("termini")
                        .HasForeignKey("treningID");

                    b.Navigation("teretana");

                    b.Navigation("trener");

                    b.Navigation("trening");
                });

            modelBuilder.Entity("Models.Trening", b =>
                {
                    b.HasOne("Models.Vrsta", "vrsta")
                        .WithMany("treninzi")
                        .HasForeignKey("vrstaID");

                    b.Navigation("vrsta");
                });

            modelBuilder.Entity("Models.Vrsta", b =>
                {
                    b.HasOne("Models.Teretana", null)
                        .WithMany("vrste")
                        .HasForeignKey("TeretanaID");
                });

            modelBuilder.Entity("Models.Clan", b =>
                {
                    b.Navigation("termini");
                });

            modelBuilder.Entity("Models.Teretana", b =>
                {
                    b.Navigation("clanovi");

                    b.Navigation("vrste");
                });

            modelBuilder.Entity("Models.Trening", b =>
                {
                    b.Navigation("termini");
                });

            modelBuilder.Entity("Models.Vrsta", b =>
                {
                    b.Navigation("treninzi");
                });
#pragma warning restore 612, 618
        }
    }
}
