﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiFlashMobi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdRemetente = table.Column<string>(type: "TEXT", nullable: false),
                    DataPostagem = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EnderecoDestinatario = table.Column<string>(type: "TEXT", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TamanhoPacote = table.Column<double>(type: "REAL", nullable: false),
                    Preco = table.Column<double>(type: "REAL", nullable: false),
                    IdVeiculo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
