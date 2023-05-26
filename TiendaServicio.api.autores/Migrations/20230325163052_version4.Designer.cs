﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TiendaServicio.api.autores.Persistencia;

namespace TiendaServicio.api.autores.Migrations
{
    [DbContext(typeof(ContextoAutor))]
    [Migration("20230325163052_version4")]
    partial class version4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TiendaServicio.api.autores.Modelo.AutorLibro", b =>
                {
                    b.Property<int>("AutorLibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AutorLibroGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AutorLibroId");

                    b.ToTable("AutorLibros");
                });

            modelBuilder.Entity("TiendaServicio.api.autores.Modelo.GradoAcademico", b =>
                {
                    b.Property<int>("GradoAcademicoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AutorLibroId")
                        .HasColumnType("int");

                    b.Property<string>("CentroAcademico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaGrado")
                        .HasColumnType("datetime2");

                    b.Property<string>("GradoAcademicoGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradoAcademicoId");

                    b.HasIndex("AutorLibroId");

                    b.ToTable("GradosAcademicos");
                });

            modelBuilder.Entity("TiendaServicio.api.autores.Modelo.GradoAcademico", b =>
                {
                    b.HasOne("TiendaServicio.api.autores.Modelo.AutorLibro", "AutorLibro")
                        .WithMany("GradosAcademicos")
                        .HasForeignKey("AutorLibroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AutorLibro");
                });

            modelBuilder.Entity("TiendaServicio.api.autores.Modelo.AutorLibro", b =>
                {
                    b.Navigation("GradosAcademicos");
                });
#pragma warning restore 612, 618
        }
    }
}
