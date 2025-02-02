﻿// <auto-generated />
using System;
using LogicaDatos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaDatos.Migrations
{
    [DbContext(typeof(OlimpiadasContext))]
    [Migration("20241013212838_Atletas-migration")]
    partial class Atletasmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Atleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaisNombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PaisNombre");

                    b.ToTable("Atletas");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AtletaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AtletaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Pais", b =>
                {
                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("cantHabitantes")
                        .HasColumnType("int");

                    b.Property<int>("telDelegado")
                        .HasColumnType("int");

                    b.HasKey("Nombre");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Atleta", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesDominio.Pais", "Pais")
                        .WithMany()
                        .HasForeignKey("PaisNombre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Disciplina", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesDominio.Atleta", null)
                        .WithMany("_disciplinas")
                        .HasForeignKey("AtletaId");

                    b.OwnsOne("LogicaNegocio.ValueObjects.Anio", "Anio", b1 =>
                        {
                            b1.Property<int>("DisciplinaId")
                                .HasColumnType("int");

                            b1.Property<int>("Valor")
                                .HasColumnType("int");

                            b1.HasKey("DisciplinaId");

                            b1.ToTable("Disciplinas");

                            b1.WithOwner()
                                .HasForeignKey("DisciplinaId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.Codigo", "Codigo", b1 =>
                        {
                            b1.Property<int>("DisciplinaId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DisciplinaId");

                            b1.ToTable("Disciplinas");

                            b1.WithOwner()
                                .HasForeignKey("DisciplinaId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.NombreDisciplina", "nombreDisciplina", b1 =>
                        {
                            b1.Property<int>("DisciplinaId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("DisciplinaId");

                            b1.ToTable("Disciplinas");

                            b1.WithOwner()
                                .HasForeignKey("DisciplinaId");
                        });

                    b.Navigation("Anio")
                        .IsRequired();

                    b.Navigation("Codigo")
                        .IsRequired();

                    b.Navigation("nombreDisciplina")
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Usuario", b =>
                {
                    b.HasOne("LogicaNegocio.EntidadesDominio.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("LogicaNegocio.ValueObject.Contrasenia", "Contrasenia", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("LogicaNegocio.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<int>("UsuarioId")
                                .HasColumnType("int");

                            b1.Property<string>("Valor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("Usuarios");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Contrasenia")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("LogicaNegocio.EntidadesDominio.Atleta", b =>
                {
                    b.Navigation("_disciplinas");
                });
#pragma warning restore 612, 618
        }
    }
}
