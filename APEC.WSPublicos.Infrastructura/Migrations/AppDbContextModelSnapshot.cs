﻿// <auto-generated />
using System;
using APEC.WS.Infrastructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APEC.WSPublicos.Infrastructura.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APEC.WS.Infrastructura.Modelos.Cliente", b =>
                {
                    b.Property<string>("CedulaRnc")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IndicadorSalud")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("MontoTotalAdeudado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CedulaRnc");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("APEC.WS.Infrastructura.Modelos.HistorialCrediticio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClienteCedulaRnc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConceptoDeuda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("MontoAdeudado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("RncEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteCedulaRnc");

                    b.ToTable("HistorialesCrediticios");
                });

            modelBuilder.Entity("APEC.WS.Infrastructura.Modelos.IndiceInflacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Periodo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("IndicesInflacion");
                });

            modelBuilder.Entity("APEC.WS.Infrastructura.Modelos.RegistroUsoServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaInvocacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreServicio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RegistrosUso");
                });

            modelBuilder.Entity("APEC.WS.Infrastructura.Modelos.TasaCambiaria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoMoneda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TasasCambiarias");
                });

            modelBuilder.Entity("APEC.WS.Infrastructura.Modelos.HistorialCrediticio", b =>
                {
                    b.HasOne("APEC.WS.Infrastructura.Modelos.Cliente", "Cliente")
                        .WithMany("Historiales")
                        .HasForeignKey("ClienteCedulaRnc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("APEC.WS.Infrastructura.Modelos.Cliente", b =>
                {
                    b.Navigation("Historiales");
                });
#pragma warning restore 612, 618
        }
    }
}
