<<<<<<< HEAD
﻿namespace Sistema.Api.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

=======
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Api.Migrations
{
>>>>>>> origin/Reynaldo
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    FechaNac = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: true),
                    ClienteGuid = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carritos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoriaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    MarcaId = table.Column<int>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Productos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RolId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administradores_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    CarritoId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Latitud = table.Column<double>(nullable: false),
                    Longitud = table.Column<double>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleCarritos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CarritoId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleCarritos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalleCarritos_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleCarritos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoFotos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductoId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    IsPrincipal = table.Column<bool>(nullable: true),
                    FotoUrl = table.Column<string>(nullable: true),
                    FotoPublicId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoFotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoFotos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    OrdenId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrdenId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CreatedAt", "Descripcion", "Estado", "Nombre", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2020, 8, 4, 6, 33, 3, 685, DateTimeKind.Local).AddTicks(7442), "Celulares nuevos y usados.", true, "Celulares", new DateTime(2020, 8, 4, 6, 33, 3, 686, DateTimeKind.Local).AddTicks(5825) });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CreatedAt", "Descripcion", "Estado", "Nombre", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2020, 8, 4, 6, 33, 3, 686, DateTimeKind.Local).AddTicks(6189), "Tenemos computadoras de ultima generacion.", true, "Computadoras", new DateTime(2020, 8, 4, 6, 33, 3, 686, DateTimeKind.Local).AddTicks(6196) });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 1, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(1741), "Dell" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 2, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(2111), "Acer" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 3, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(2120), "BLU" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 4, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(2121), "Asus" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 5, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(2123), "Google" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 6, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(2124), "Huawei" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 7, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(2126), "Apple" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 8, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(2127), "LG" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 9, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(2129), "Samsung" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 10, new DateTime(2020, 8, 4, 6, 33, 3, 688, DateTimeKind.Local).AddTicks(2130), "HP" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "Estado", "Nombre" },
                values: new object[] { 1, "Acceso máximo del sistema.", true, "Administrador" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "Estado", "Nombre" },
                values: new object[] { 2, "Acceso a las ordenes del sistema.", true, "Organizador" });

            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "CreatedAt", "Email", "Estado", "PasswordHash", "RolId", "UpdatedAt", "Username" },
                values: new object[] { 1, new DateTime(2020, 8, 4, 6, 33, 3, 693, DateTimeKind.Local).AddTicks(8884), "ADMIN@GMAIL.COM", true, new byte[] { 179, 168, 87, 201, 124, 215, 81, 53, 38, 10, 111, 241, 243, 29, 228, 135, 151, 140, 87, 25, 27, 162, 63, 145, 202, 173, 43, 146, 20, 5, 63, 65 }, 1, new DateTime(2020, 8, 4, 6, 33, 3, 693, DateTimeKind.Local).AddTicks(8350), "ADMIN01" });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 15, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(614), "Laptop HP 15-ba051wm – Pantalla Touch – Quad-Core A10-9600P – 8GB RAM – 1TB HDD", true, 10, "Laptop HP 15-ba051wm", 40000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(612) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 20, 1, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(629), null, true, 9, "Samsung Galaxy A11", 25000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(628) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 19, 1, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(626), null, true, 8, "LG Aristo 5", 15000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(625) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 17, 1, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(620), null, true, 7, "iPhone 8 Plus 64GB", 20000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(619) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 16, 1, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(617), null, true, 7, "iPhone 11 (128GB)", 86000.00m, 20, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(615) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 13, 1, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(607), null, true, 6, "Huawei Y7p", 13000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(606) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 8, 1, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(509), null, true, 6, "Huawei Honor 20", 15000.00m, 14, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(508) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 7, 1, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(506), null, true, 5, "Google Pixel 4", 10000.00m, 12, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(504) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 18, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(623), "Laptop HP 15-f387wm – AMD A8-7410 – 500GB HDD – 4GB RAM – Radeon R5 – Pantalla Táctil – Teclado Numérico", true, 10, "Laptop HP 15-f387wm", 40000.00m, 15, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(622) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 4, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(496), "Laptop Asus Q301L – Intel Core i5 - 4200u – 8GB RAM – 500GB – Pantalla Touch – Teclado Iluminado – Ultra Liviana", true, 4, "Laptop Asus Q301L", 25000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(495) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 2, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(471), "LAPTOP ACER PREDATOR CORE I7", true, 2, "LAPTOP ACER PREDATOR", 44000.00m, 5, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(463) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 14, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(610), "Laptop Dell Ultrabook E7240 – 12GB Ram – Intel Core i5 – 128GB SSD", true, 1, "Laptop Dell Ultrabook E7240", 50000.00m, 15, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(609) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 12, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(604), "Laptop Dell Latitude E5450 – i5 Quinta Generación – 8GB RAM – 500GB HDD", true, 1, "Laptop Dell Latitude E5450", 25000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(603) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 11, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(601), "Laptop Dell Latitude 3350 – Intel Core I5 Quinta Generacion 500GB - 6GB RAM", true, 1, "Laptop Dell Latitude 3350", 30000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(600) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 10, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(597), "Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD", true, 1, "Laptop DELL INSPIRON 15-3558", 40000.00m, 16, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(596) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 9, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(512), "LAPTOP DELL INSPIRON 15 SILVER", true, 1, "LAPTOP DELL INSPIRON 15", 35000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(511) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 6, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(502), "Laptop DELL Inspiron 14-3459 – Intel Core i5-6200U Sexta Gen – 6GB RAM – 500GB HDD – AMD Radeon R5", true, 1, "Laptop DELL Inspiron 14-3459", 29000.00m, 20, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(501) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 5, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(499), "LAPTOP DELL G3 15 3579 8va GENERACION", true, 1, "LAPTOP DELL G3 15 3579", 45000.00m, 15, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(498) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 3, 1, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(493), null, true, 3, "BLU G70", 7000.00m, 10, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(492) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 1, 2, new DateTime(2020, 8, 4, 6, 33, 3, 690, DateTimeKind.Local).AddTicks(126), "Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico", true, 1, "Laptop Dell Latitude E6540", 30000.00m, 15, new DateTime(2020, 8, 4, 6, 33, 3, 689, DateTimeKind.Local).AddTicks(9778) });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 1, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(3401), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_6540h7hdell2_uckxvb.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_6540h7hdell2_uckxvb.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 16, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4650), "Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_51jjGHHKixL._AC_SX425__dxkxdc.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Google Pixel 4/Google_Pixel_4_51jjGHHKixL._AC_SX425__dxkxdc.jpg", null, 7 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 17, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4698), "Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_149597-phones-news-this-is-the-google-pixel-4-xl-image1-ktsr2yozg6_dpm6jk.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Google Pixel 4/Google_Pixel_4_149597-phones-news-this-is-the-google-pixel-4-xl-image1-ktsr2yozg6_dpm6jk.jpg", null, 7 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 18, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4706), "Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_1366_2000_foaiqs.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Google Pixel 4/Google_Pixel_4_1366_2000_foaiqs.jpg", null, 7 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 19, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4714), "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_GKK-Detachable-Case-for-Huawei-Honor-20-Black-10072019-01-p_few99o.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Huawei Honor 20/Huawei_Honor_20_GKK-Detachable-Case-for-Huawei-Honor-20-Black-10072019-01-p_few99o.jpg", null, 8 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 20, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4721), "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_ef6g5t8x0aioqpg_cucvyh.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei Honor 20/Huawei_Honor_20_ef6g5t8x0aioqpg_cucvyh.jpg", null, 8 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 21, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4729), "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei Honor 20/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg", null, 8 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 34, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5399), "Sistema-Ventas/Celulares/Huawei%20Y7p/Huawei_Y7p_Precio-Huawei-Y7p-en-Costa-Rica_nfiokl.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Huawei Y7p/Huawei_Y7p_Precio-Huawei-Y7p-en-Costa-Rica_nfiokl.jpg", null, 13 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 35, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5407), "Sistema-Ventas/Celulares/Huawei%20Y7p/Huawei_Y7p_Comprar-Huawei-Y7p-en-Costa-Rica_at8yeh.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Huawei Y7p/Huawei_Y7p_Comprar-Huawei-Y7p-en-Costa-Rica_at8yeh.jpg", null, 13 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 36, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5414), "Sistema-Ventas/Celulares/Huawei%20Y7p/Huawei_Y7p_Huawei-Y7p-en-Costa-Rica-1_mawrci.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei Y7p/Huawei_Y7p_Huawei-Y7p-en-Costa-Rica-1_mawrci.jpg", null, 13 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 41, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5724), "Sistema-Ventas/Celulares/iPhone%2011%20%28128GB%29/iPhone_11_128GB_iPhone-11-precio-Costa-Rica_efrulu.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816946/Sistema-Ventas/Celulares/iPhone 11 %28128GB%29/iPhone_11_128GB_iPhone-11-precio-Costa-Rica_efrulu.jpg", null, 16 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 42, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5732), "Sistema-Ventas/Celulares/iPhone%2011%20%28128GB%29/iPhone_11_128GB_iphone-11-de-venta-en-Costa-Rica_gg3uib.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816946/Sistema-Ventas/Celulares/iPhone 11 %28128GB%29/iPhone_11_128GB_iphone-11-de-venta-en-Costa-Rica_gg3uib.jpg", null, 16 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 11, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4554), "Sistema-Ventas/Laptops/Laptop%20Asus%20Q301L%20%E2%80%93%20Intel%20Core%20i5-4200u%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Pantalla%20Touch%20%E2%80%93%20Teclado%20Iluminado%20%E2%80%93%20Ultra%20Liviana/Laptop_Asus_Q301L_Intel_Core_i5-4200u_8GB_RAM_500GB_Pantalla_Touch_Teclado_Iluminado_Ultra_Liviana_asus1_qk5rzi.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Laptop Asus Q301L – Intel Core i5-4200u – 8GB RAM – 500GB – Pantalla Touch – Teclado Iluminado – Ultra Liviana/Laptop_Asus_Q301L_Intel_Core_i5-4200u_8GB_RAM_500GB_Pantalla_Touch_Teclado_Iluminado_Ultra_Liviana_asus1_qk5rzi.jpg", null, 4 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 43, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5741), "Sistema-Ventas/Celulares/iPhone%2011%20%28128GB%29/iPhone_11_128GB_iPhone-11-en-costa-Rica_ooxbv5.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/iPhone 11 %28128GB%29/iPhone_11_128GB_iPhone-11-en-costa-Rica_ooxbv5.jpg", null, 16 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 45, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5758), "Sistema-Ventas/Celulares/iPhone%208%20Plus%2064GB/iPhone_8_Plus_64GB_comprar-iphone-8-plus-en-costa-rica_kyu29s.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/iPhone 8 Plus 64GB/iPhone_8_Plus_64GB_comprar-iphone-8-plus-en-costa-rica_kyu29s.jpg", null, 17 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 46, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5766), "Sistema-Ventas/Celulares/iPhone%208%20Plus%2064GB/iPhone_8_Plus_64GB_iphone-8-plus-en-costa-rica_h2hwur.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/iPhone 8 Plus 64GB/iPhone_8_Plus_64GB_iphone-8-plus-en-costa-rica_h2hwur.jpg", null, 17 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 51, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(6219), "Sistema-Ventas/Celulares/LG%20Aristo%205/LG_Aristo_5_LG-Aristo-5-Silver-frontimage_cvqajy.png", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/LG Aristo 5/LG_Aristo_5_LG-Aristo-5-Silver-frontimage_cvqajy.png", null, 19 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 52, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(6226), "Sistema-Ventas/Celulares/LG%20Aristo%205/LG_Aristo_5_LG-Aristo-5_qgxdwn.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/LG Aristo 5/LG_Aristo_5_LG-Aristo-5_qgxdwn.jpg", null, 19 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 53, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(6234), "Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Samsung-Galaxy-A11-en-Costa-Rica_ag1ltk.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/Samsung Galaxy A11/Samsung_Galaxy_A11_Samsung-Galaxy-A11-en-Costa-Rica_ag1ltk.jpg", null, 20 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 54, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(6242), "Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Venta-Samsung-Galaxy-A11-en-Costa-Rica_da7fjh.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/Samsung Galaxy A11/Samsung_Galaxy_A11_Venta-Samsung-Galaxy-A11-en-Costa-Rica_da7fjh.jpg", null, 20 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 55, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(6268), "Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Comprar-Samsung-Galaxy-A11-en-Costa-Rica_wdx6c3.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/Samsung Galaxy A11/Samsung_Galaxy_A11_Comprar-Samsung-Galaxy-A11-en-Costa-Rica_wdx6c3.jpg", null, 20 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 56, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(6276), "Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Precio-Samsung-Galaxy-A11-en-Costa-Rica_x9xdds.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/Samsung Galaxy A11/Samsung_Galaxy_A11_Precio-Samsung-Galaxy-A11-en-Costa-Rica_x9xdds.jpg", null, 20 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 40, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5714), "Sistema-Ventas/Laptops/Laptop%20HP%2015-ba051wm%20%E2%80%93%20Pantalla%20Touch%20%E2%80%93%20Quad-Core%20A10-9600P%20%E2%80%93%208GB%20RAM%20%E2%80%93%201TB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-ba051wm_Pantalla_Touch_Quad-Core_A10-9600P_8GB_RAM_1TB_HDD_Teclado_Num%C3%A9rico_d1bcb5c0-8ba3-4703-_do4ilh.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop HP 15-ba051wm – Pantalla Touch – Quad-Core A10-9600P – 8GB RAM – 1TB HDD – Teclado Numérico/Laptop_HP_15-ba051wm_Pantalla_Touch_Quad-Core_A10-9600P_8GB_RAM_1TB_HDD_Teclado_Numérico_d1bcb5c0-8ba3-4703-_do4ilh.jpg", null, 15 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 47, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5913), "Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_b62ed24wmr_mzyzt4.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816985/Sistema-Ventas/Laptops/Laptop HP 15-f387wm – AMD A8-7410 – 500GB HDD – 4GB RAM – Radeon R5 – Pantalla Táctil – Teclado Numérico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_Táctil_Teclado_Numérico_b62ed24wmr_mzyzt4.jpg", null, 18 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 48, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(6011), "Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_b3b5615cwmg_wnhba0.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816985/Sistema-Ventas/Laptops/Laptop HP 15-f387wm – AMD A8-7410 – 500GB HDD – 4GB RAM – Radeon R5 – Pantalla Táctil – Teclado Numérico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_Táctil_Teclado_Numérico_b3b5615cwmg_wnhba0.jpg", null, 18 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 44, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5750), "Sistema-Ventas/Celulares/iPhone%208%20Plus%2064GB/iPhone_8_Plus_64GB_precio-iphone-8-plus-en-costa-rica_pl8wtz.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816946/Sistema-Ventas/Celulares/iPhone 8 Plus 64GB/iPhone_8_Plus_64GB_precio-iphone-8-plus-en-costa-rica_pl8wtz.jpg", null, 17 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 10, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4447), "Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_Comprar-BLU-G70-en-Costa-Rica-491x1024_o0bsan.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816935/Sistema-Ventas/Celulares/BLU G70/BLU_G70_Comprar-BLU-G70-en-Costa-Rica-491x1024_o0bsan.jpg", null, 3 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 9, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4440), "Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_BLU-G70-en-Costa-Rica-433x559_t05hzt.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816935/Sistema-Ventas/Celulares/BLU G70/BLU_G70_BLU-G70-en-Costa-Rica-433x559_t05hzt.jpg", null, 3 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 8, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4432), "Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_Precio-BLU-G70-en-Costa-Rica_pynkr4.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816936/Sistema-Ventas/Celulares/BLU G70/BLU_G70_Precio-BLU-G70-en-Costa-Rica_pynkr4.jpg", null, 3 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 2, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4017), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_346540h7hdell_snunj0.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_346540h7hdell_snunj0.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 3, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4134), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_16540h7hdell_dhnsn9.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_16540h7hdell_dhnsn9.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 4, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4215), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_776540h7hdell_kwtv8a.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_776540h7hdell_kwtv8a.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 5, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4308), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_566540h7hdell_yhzsr4.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_566540h7hdell_yhzsr4.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 12, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4565), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_notebook-dell-g3-15-3579-156-intel-core-i7-8750h-220-ghz-8gb-ddr4-scaled_gsysxu.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP DELL G3 15 3579 8Then GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_notebook-dell-g3-15-3579-156-intel-core-i7-8750h-220-ghz-8gb-ddr4-scaled_gsysxu.jpg", null, 5 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 13, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4575), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_laptop-dell-g3-3579-15-i5-8300h-video-4gb-1tb-8gb-p-D_NQ_NP_621638-MPE32062793856_092019-F-scaled_zvmdzz.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP DELL G3 15 3579 8Then GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_laptop-dell-g3-3579-15-i5-8300h-video-4gb-1tb-8gb-p-D_NQ_NP_621638-MPE32062793856_092019-F-scaled_zvmdzz.jpg", null, 5 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 14, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4584), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_1-34-scaled_e4mqob.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP DELL G3 15 3579 8Then GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_1-34-scaled_e4mqob.jpg", null, 5 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 15, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4641), "Sistema-Ventas/Laptops/Laptop%20DELL%20Inspiron%2014-3459%20%E2%80%93%20Intel%20Core%20i5-6200U%20Sexta%20Gen%20%E2%80%93%206GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20AMD%20Radeon%20R5/Laptop_DELL_Inspiron_14-3459_Intel_Core_i5-6200U_Sexta_Gen_6GB_RAM_500GB_HDD_AMD_Radeon_R5_107607_71Tri1yZUCL_SL1500__i7j57w.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/Laptop DELL Inspiron 14-3459 – Intel Core i5-6200U Sexta Gen – 6GB RAM – 500GB HDD – AMD Radeon R5/Laptop_DELL_Inspiron_14-3459_Intel_Core_i5-6200U_Sexta_Gen_6GB_RAM_500GB_HDD_AMD_Radeon_R5_107607_71Tri1yZUCL_SL1500__i7j57w.jpg", null, 6 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 22, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4738), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-156-fhd-intel-core-i5-825-D_NQ_NP_967204-MPE32061439156_092019-F-scaled_eitw4k.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/LAPTOP DELL INSPIRON 15 SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-156-fhd-intel-core-i5-825-D_NQ_NP_967204-MPE32061439156_092019-F-scaled_eitw4k.jpg", null, 9 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 23, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4748), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-15-5570-156-core-i5-68fnp-D_NQ_NP_781655-MPE32061793687_092019-F-scaled_alicmc.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/LAPTOP DELL INSPIRON 15 SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-15-5570-156-core-i5-68fnp-D_NQ_NP_781655-MPE32061793687_092019-F-scaled_alicmc.jpg", null, 9 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 24, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4757), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-3581-156-fhd-intel-core-i3-7020-D_NQ_NP_660749-MPE31598311513_072019-F-scaled_yrnlhi.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP DELL INSPIRON 15 SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-3581-156-fhd-intel-core-i3-7020-D_NQ_NP_660749-MPE31598311513_072019-F-scaled_yrnlhi.jpg", null, 9 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 25, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4812), "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_43558dell36689-1_cjqhsy.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generación_4GB_RAM_1TB_HDD_43558dell36689-1_cjqhsy.jpg", null, 10 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 26, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4933), "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_3558dell36689_ostn27.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generación_4GB_RAM_1TB_HDD_3558dell36689_ostn27.jpg", null, 10 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 27, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5016), "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_23558dell36689_wxdxod.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generación_4GB_RAM_1TB_HDD_23558dell36689_wxdxod.jpg", null, 10 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 28, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5075), "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_13558dell36689_qgimk8.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generación_4GB_RAM_1TB_HDD_13558dell36689_qgimk8.jpg", null, 10 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 29, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5145), "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%203350%20%E2%80%93%20Intel%20Core%20I5%20Quinta%20Generaci%C3%B3n/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generaci%C3%B3n_dell-latitude-3350-monsterlaptops_zcypyv.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop Dell Latitude 3350 – Intel Core I5 Quinta Generación/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generación_dell-latitude-3350-monsterlaptops_zcypyv.jpg", null, 11 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 30, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5194), "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%203350%20%E2%80%93%20Intel%20Core%20I5%20Quinta%20Generaci%C3%B3n/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generaci%C3%B3n_3dell-latitude-3350-monsterlaptops_yid0mm.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop Dell Latitude 3350 – Intel Core I5 Quinta Generación/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generación_3dell-latitude-3350-monsterlaptops_yid0mm.jpg", null, 11 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 31, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5258), "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%203350%20%E2%80%93%20Intel%20Core%20I5%20Quinta%20Generaci%C3%B3n/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generaci%C3%B3n_1dell-latitude-3350-monsterlaptops_j1aoqx.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop Dell Latitude 3350 – Intel Core I5 Quinta Generación/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generación_1dell-latitude-3350-monsterlaptops_j1aoqx.jpg", null, 11 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 32, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5316), "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%20E5450%20%E2%80%93%20i5%20Quinta%20Generaci%C3%B3n%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD/Laptop_Dell_Latitude_E5450_i5_Quinta_Generaci%C3%B3n_8GB_RAM_500GB_HDD_delle51267_wodunh.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop Dell Latitude E5450 – i5 Quinta Generación – 8GB RAM – 500GB HDD/Laptop_Dell_Latitude_E5450_i5_Quinta_Generación_8GB_RAM_500GB_HDD_delle51267_wodunh.jpg", null, 12 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 33, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5390), "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%20E5450%20%E2%80%93%20i5%20Quinta%20Generaci%C3%B3n%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD/Laptop_Dell_Latitude_E5450_i5_Quinta_Generaci%C3%B3n_8GB_RAM_500GB_HDD_0vnb125_hdadig.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop Dell Latitude E5450 – i5 Quinta Generación – 8GB RAM – 500GB HDD/Laptop_Dell_Latitude_E5450_i5_Quinta_Generación_8GB_RAM_500GB_HDD_0vnb125_hdadig.jpg", null, 12 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 37, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5473), "Sistema-Ventas/Laptops/Laptop%20Dell%20Ultrabook%20E7240%20%E2%80%93%2012GB%20Ram%20%E2%80%93%20Intel%20Core%20i5%20%E2%80%93%20128GB%20SSD%20%E2%80%93%20Teclado%20Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_delle72404433_tllnkp.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop Dell Ultrabook E7240 – 12GB Ram – Intel Core i5 – 128GB SSD – Teclado Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_delle72404433_tllnkp.jpg", null, 14 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 38, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5567), "Sistema-Ventas/Laptops/Laptop%20Dell%20Ultrabook%20E7240%20%E2%80%93%2012GB%20Ram%20%E2%80%93%20Intel%20Core%20i5%20%E2%80%93%20128GB%20SSD%20%E2%80%93%20Teclado%20Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_2delle72404433_gkbrxs.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop Dell Ultrabook E7240 – 12GB Ram – Intel Core i5 – 128GB SSD – Teclado Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_2delle72404433_gkbrxs.jpg", null, 14 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 39, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(5623), "Sistema-Ventas/Laptops/Laptop%20Dell%20Ultrabook%20E7240%20%E2%80%93%2012GB%20Ram%20%E2%80%93%20Intel%20Core%20i5%20%E2%80%93%20128GB%20SSD%20%E2%80%93%20Teclado%20Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_1delle72404433_ie14cu.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop Dell Ultrabook E7240 – 12GB Ram – Intel Core i5 – 128GB SSD – Teclado Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_1delle72404433_ie14cu.jpg", null, 14 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 6, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4414), "Sistema-Ventas/Laptops/LAPTOP%20ACER%20PREDATOR%20CORE%20I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-gamer-acer-predator-helios-300-i7-9750h-gtx-ti-6gb-D_NQ_NP_853948-MPE32067580368_092019-F-scaled_uldpur.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP ACER PREDATOR CORE I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-gamer-acer-predator-helios-300-i7-9750h-gtx-ti-6gb-D_NQ_NP_853948-MPE32067580368_092019-F-scaled_uldpur.jpg", null, 2 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 7, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(4425), "Sistema-Ventas/Laptops/LAPTOP%20ACER%20PREDATOR%20CORE%20I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-acer-predator-helios-300-i7-8va-gtx-1060-16gb-ram-D_NQ_NP_816622-MPE32377868369_092019-F-scaled_wmhgav.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/LAPTOP ACER PREDATOR CORE I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-acer-predator-helios-300-i7-8va-gtx-1060-16gb-ram-D_NQ_NP_816622-MPE32377868369_092019-F-scaled_wmhgav.jpg", null, 2 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 49, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(6110), "Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_a8-1wemk_psrtud.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816985/Sistema-Ventas/Laptops/Laptop HP 15-f387wm – AMD A8-7410 – 500GB HDD – 4GB RAM – Radeon R5 – Pantalla Táctil – Teclado Numérico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_Táctil_Teclado_Numérico_a8-1wemk_psrtud.jpg", null, 18 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 50, new DateTime(2020, 8, 4, 6, 33, 3, 697, DateTimeKind.Local).AddTicks(6210), "Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_2da6aa5wmol_jzvmjy.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816985/Sistema-Ventas/Laptops/Laptop HP 15-f387wm – AMD A8-7410 – 500GB HDD – 4GB RAM – Radeon R5 – Pantalla Táctil – Teclado Numérico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_Táctil_Teclado_Numérico_2da6aa5wmol_jzvmjy.jpg", null, 18 });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Email",
                table: "Administradores",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_RolId",
                table: "Administradores",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Username",
                table: "Administradores",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_ClienteId",
                table: "Carritos",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Nombre",
                table: "Categorias",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Email",
                table: "Clientes",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarritos_CarritoId",
                table: "DetalleCarritos",
                column: "CarritoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleCarritos_ProductoId",
                table: "DetalleCarritos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Marcas_Nombre",
                table: "Marcas",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_CarritoId",
                table: "Ordenes",
                column: "CarritoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_ClienteId",
                table: "Ordenes",
                column: "ClienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_OrdenId",
                table: "Pagos",
                column: "OrdenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_OrdenId",
                table: "Pedidos",
                column: "OrdenId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFotos_ProductoId",
                table: "ProductoFotos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_MarcaId",
                table: "Productos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Nombre",
                table: "Productos",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Nombre",
                table: "Roles",
                column: "Nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "DetalleCarritos");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "ProductoFotos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
