// <auto-generated />
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
    [Migration("20220102201625_V1")]
    partial class V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Partner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JMBG")
                        .HasColumnType("int")
                        .HasColumnName("JMBG");

                    b.Property<string>("ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.Property<string>("prezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prezime");

                    b.Property<int?>("vezbacID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("vezbacID");

                    b.ToTable("Partneri");
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

            modelBuilder.Entity("Models.Trening", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojZauzetihMesta")
                        .HasColumnType("int")
                        .HasColumnName("BrojZauzetihMesta");

                    b.Property<DateTime>("DatumIsteka")
                        .HasColumnType("datetime2")
                        .HasColumnName("DatumIsteka");

                    b.Property<DateTime>("DatumUplate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DatumUplate");

                    b.Property<int>("MaxBrojMesta")
                        .HasColumnType("int")
                        .HasColumnName("MaxBrojMesta");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Slika");

                    b.Property<string>("Tip")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tip");

                    b.Property<int>("clanarina")
                        .HasColumnType("int")
                        .HasColumnName("Clanarina");

                    b.Property<string>("naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<int?>("teretanaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("teretanaID");

                    b.ToTable("Treninzi");
                });

            modelBuilder.Entity("Models.Vezbac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojPartnera")
                        .HasColumnType("int")
                        .HasColumnName("BrojPartnera");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2")
                        .HasColumnName("DatumRodjenja");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ime");

                    b.Property<int>("JMBG")
                        .HasColumnType("int")
                        .HasColumnName("JMBG");

                    b.Property<string>("KontaktTelefon")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("KontaktTelefon");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prezime");

                    b.Property<int?>("TreningID")
                        .HasColumnType("int");

                    b.Property<int?>("teretanaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TreningID");

                    b.HasIndex("teretanaID");

                    b.ToTable("Vezbaci");
                });

            modelBuilder.Entity("Models.Partner", b =>
                {
                    b.HasOne("Models.Vezbac", "vezbac")
                        .WithMany("partneri")
                        .HasForeignKey("vezbacID");

                    b.Navigation("vezbac");
                });

            modelBuilder.Entity("Models.Trening", b =>
                {
                    b.HasOne("Models.Teretana", "teretana")
                        .WithMany("treninzi")
                        .HasForeignKey("teretanaID");

                    b.Navigation("teretana");
                });

            modelBuilder.Entity("Models.Vezbac", b =>
                {
                    b.HasOne("Models.Trening", null)
                        .WithMany("vezbaci")
                        .HasForeignKey("TreningID");

                    b.HasOne("Models.Teretana", "teretana")
                        .WithMany()
                        .HasForeignKey("teretanaID");

                    b.Navigation("teretana");
                });

            modelBuilder.Entity("Models.Teretana", b =>
                {
                    b.Navigation("treninzi");
                });

            modelBuilder.Entity("Models.Trening", b =>
                {
                    b.Navigation("vezbaci");
                });

            modelBuilder.Entity("Models.Vezbac", b =>
                {
                    b.Navigation("partneri");
                });
#pragma warning restore 612, 618
        }
    }
}
