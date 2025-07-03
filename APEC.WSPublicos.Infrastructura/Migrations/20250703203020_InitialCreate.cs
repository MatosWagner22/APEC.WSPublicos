﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APEC.WSPublicos.Infrastructura.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CedulaRnc = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IndicadorSalud = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MontoTotalAdeudado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CedulaRnc);
                });

            migrationBuilder.CreateTable(
                name: "IndicesInflacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Periodo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndicesInflacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosUso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreServicio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInvocacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosUso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasasCambiarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoMoneda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasasCambiarias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialesCrediticios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RncEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConceptoDeuda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MontoAdeudado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClienteCedulaRnc = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialesCrediticios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialesCrediticios_Clientes_ClienteCedulaRnc",
                        column: x => x.ClienteCedulaRnc,
                        principalTable: "Clientes",
                        principalColumn: "CedulaRnc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialesCrediticios_ClienteCedulaRnc",
                table: "HistorialesCrediticios",
                column: "ClienteCedulaRnc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialesCrediticios");

            migrationBuilder.DropTable(
                name: "IndicesInflacion");

            migrationBuilder.DropTable(
                name: "RegistrosUso");

            migrationBuilder.DropTable(
                name: "TasasCambiarias");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
