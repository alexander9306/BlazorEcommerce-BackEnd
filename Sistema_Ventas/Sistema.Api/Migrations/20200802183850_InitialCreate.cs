using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Api.Migrations
{
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
                    Email = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Telefono = table.Column<int>(nullable: false)
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
                    Estado = table.Column<bool>(nullable: false)
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
                values: new object[] { 1, new DateTime(2020, 8, 2, 14, 38, 50, 594, DateTimeKind.Local).AddTicks(6749), "Celulares nuevos y usados.", true, "Celulares", new DateTime(2020, 8, 2, 14, 38, 50, 595, DateTimeKind.Local).AddTicks(3869) });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CreatedAt", "Descripcion", "Estado", "Nombre", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2020, 8, 2, 14, 38, 50, 595, DateTimeKind.Local).AddTicks(4214), "Tenemos computadoras de ultima generacion.", true, "Computadoras", new DateTime(2020, 8, 2, 14, 38, 50, 595, DateTimeKind.Local).AddTicks(4222) });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 1, new DateTime(2020, 8, 2, 14, 38, 50, 596, DateTimeKind.Local).AddTicks(8254), "Dell" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 2, new DateTime(2020, 8, 2, 14, 38, 50, 596, DateTimeKind.Local).AddTicks(8636), "Acer" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 3, new DateTime(2020, 8, 2, 14, 38, 50, 596, DateTimeKind.Local).AddTicks(8644), "BLU" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 4, new DateTime(2020, 8, 2, 14, 38, 50, 596, DateTimeKind.Local).AddTicks(8646), "Asus" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 5, new DateTime(2020, 8, 2, 14, 38, 50, 596, DateTimeKind.Local).AddTicks(8648), "Google" });

            migrationBuilder.InsertData(
                table: "Marcas",
                columns: new[] { "Id", "CreatedAt", "Nombre" },
                values: new object[] { 6, new DateTime(2020, 8, 2, 14, 38, 50, 596, DateTimeKind.Local).AddTicks(8649), "Huawei" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "Estado", "Nombre" },
                values: new object[] { 1, "Acceso máximo del sistema.", false, "Administrador" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Descripcion", "Estado", "Nombre" },
                values: new object[] { 2, "Acceso a las ordenes del sistema.", false, "Organizador" });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 1, 2, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(702), "Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico", true, 1, "Laptop Dell Latitude E6540", 30000.00m, 15, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(415) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 5, 2, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1073), "LAPTOP DELL G3 15 3579 8va GENERACION", true, 1, "LAPTOP DELL G3 15 3579", 45000.00m, 15, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1072) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 6, 2, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1076), "Laptop DELL Inspiron 14-3459 – Intel Core i5-6200U Sexta Gen – 6GB RAM – 500GB HDD – AMD Radeon R5", true, 1, "Laptop DELL Inspiron 14-3459", 29000.00m, 20, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1075) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 9, 2, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1085), "LAPTOP DELL INSPIRON 15 SILVER", true, 1, "LAPTOP DELL INSPIRON 15", 35000.00m, 10, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1084) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 10, 2, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1088), "Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD", true, 1, "Laptop DELL INSPIRON 15-3558", 40000.00m, 16, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1087) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 2, 2, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1051), "LAPTOP ACER PREDATOR CORE I7", true, 2, "LAPTOP ACER PREDATOR", 44000.00m, 5, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1018) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 3, 1, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1067), null, true, 3, "BLU G70", 7000.00m, 10, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1066) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 4, 2, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1070), "Laptop Asus Q301L – Intel Core i5 - 4200u – 8GB RAM – 500GB – Pantalla Touch – Teclado Iluminado – Ultra Liviana", true, 4, "Laptop Asus Q301L", 25000.00m, 10, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1069) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 7, 1, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1079), null, true, 5, "Google Pixel 4", 10000.00m, 12, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1078) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "MarcaId", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 8, 1, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1082), null, true, 6, "Huawei Honor 20", 15000.00m, 14, new DateTime(2020, 8, 2, 14, 38, 50, 598, DateTimeKind.Local).AddTicks(1081) });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 1, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(7546), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_6540h7hdell2_uckxvb.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_6540h7hdell2_uckxvb.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 19, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8781), "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_GKK-Detachable-Case-for-Huawei-Honor-20-Black-10072019-01-p_few99o.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Huawei Honor 20/Huawei_Honor_20_GKK-Detachable-Case-for-Huawei-Honor-20-Black-10072019-01-p_few99o.jpg", null, 8 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 18, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8773), "Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_1366_2000_foaiqs.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Google Pixel 4/Google_Pixel_4_1366_2000_foaiqs.jpg", null, 7 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 17, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8766), "Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_149597-phones-news-this-is-the-google-pixel-4-xl-image1-ktsr2yozg6_dpm6jk.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Google Pixel 4/Google_Pixel_4_149597-phones-news-this-is-the-google-pixel-4-xl-image1-ktsr2yozg6_dpm6jk.jpg", null, 7 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 16, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8723), "Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_51jjGHHKixL._AC_SX425__dxkxdc.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Google Pixel 4/Google_Pixel_4_51jjGHHKixL._AC_SX425__dxkxdc.jpg", null, 7 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 11, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8589), "Sistema-Ventas/Laptops/Laptop%20Asus%20Q301L%20%E2%80%93%20Intel%20Core%20i5-4200u%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Pantalla%20Touch%20%E2%80%93%20Teclado%20Iluminado%20%E2%80%93%20Ultra%20Liviana/Laptop_Asus_Q301L_Intel_Core_i5-4200u_8GB_RAM_500GB_Pantalla_Touch_Teclado_Iluminado_Ultra_Liviana_asus1_qk5rzi.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Laptop Asus Q301L – Intel Core i5-4200u – 8GB RAM – 500GB – Pantalla Touch – Teclado Iluminado – Ultra Liviana/Laptop_Asus_Q301L_Intel_Core_i5-4200u_8GB_RAM_500GB_Pantalla_Touch_Teclado_Iluminado_Ultra_Liviana_asus1_qk5rzi.jpg", null, 4 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 10, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8520), "Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_Comprar-BLU-G70-en-Costa-Rica-491x1024_o0bsan.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816935/Sistema-Ventas/Celulares/BLU G70/BLU_G70_Comprar-BLU-G70-en-Costa-Rica-491x1024_o0bsan.jpg", null, 3 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 9, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8513), "Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_BLU-G70-en-Costa-Rica-433x559_t05hzt.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816935/Sistema-Ventas/Celulares/BLU G70/BLU_G70_BLU-G70-en-Costa-Rica-433x559_t05hzt.jpg", null, 3 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 8, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8481), "Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_Precio-BLU-G70-en-Costa-Rica_pynkr4.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816936/Sistema-Ventas/Celulares/BLU G70/BLU_G70_Precio-BLU-G70-en-Costa-Rica_pynkr4.jpg", null, 3 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 7, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8474), "Sistema-Ventas/Laptops/LAPTOP%20ACER%20PREDATOR%20CORE%20I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-acer-predator-helios-300-i7-8va-gtx-1060-16gb-ram-D_NQ_NP_816622-MPE32377868369_092019-F-scaled_wmhgav.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/LAPTOP ACER PREDATOR CORE I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-acer-predator-helios-300-i7-8va-gtx-1060-16gb-ram-D_NQ_NP_816622-MPE32377868369_092019-F-scaled_wmhgav.jpg", null, 2 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 6, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8463), "Sistema-Ventas/Laptops/LAPTOP%20ACER%20PREDATOR%20CORE%20I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-gamer-acer-predator-helios-300-i7-9750h-gtx-ti-6gb-D_NQ_NP_853948-MPE32067580368_092019-F-scaled_uldpur.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP ACER PREDATOR CORE I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-gamer-acer-predator-helios-300-i7-9750h-gtx-ti-6gb-D_NQ_NP_853948-MPE32067580368_092019-F-scaled_uldpur.jpg", null, 2 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 28, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(9147), "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_13558dell36689_qgimk8.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generación_4GB_RAM_1TB_HDD_13558dell36689_qgimk8.jpg", null, 10 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 27, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(9043), "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_23558dell36689_wxdxod.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generación_4GB_RAM_1TB_HDD_23558dell36689_wxdxod.jpg", null, 10 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 26, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8990), "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_3558dell36689_ostn27.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generación_4GB_RAM_1TB_HDD_3558dell36689_ostn27.jpg", null, 10 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 25, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8918), "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_43558dell36689-1_cjqhsy.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop DELL INSPIRON 15-3558 – Intel Core i3 Quinta Generación – 4GB RAM – 1TB HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generación_4GB_RAM_1TB_HDD_43558dell36689-1_cjqhsy.jpg", null, 10 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 24, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8824), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-3581-156-fhd-intel-core-i3-7020-D_NQ_NP_660749-MPE31598311513_072019-F-scaled_yrnlhi.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP DELL INSPIRON 15 SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-3581-156-fhd-intel-core-i3-7020-D_NQ_NP_660749-MPE31598311513_072019-F-scaled_yrnlhi.jpg", null, 9 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 23, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8815), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-15-5570-156-core-i5-68fnp-D_NQ_NP_781655-MPE32061793687_092019-F-scaled_alicmc.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/LAPTOP DELL INSPIRON 15 SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-15-5570-156-core-i5-68fnp-D_NQ_NP_781655-MPE32061793687_092019-F-scaled_alicmc.jpg", null, 9 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 22, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8806), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-156-fhd-intel-core-i5-825-D_NQ_NP_967204-MPE32061439156_092019-F-scaled_eitw4k.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/LAPTOP DELL INSPIRON 15 SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-156-fhd-intel-core-i5-825-D_NQ_NP_967204-MPE32061439156_092019-F-scaled_eitw4k.jpg", null, 9 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 15, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8714), "Sistema-Ventas/Laptops/Laptop%20DELL%20Inspiron%2014-3459%20%E2%80%93%20Intel%20Core%20i5-6200U%20Sexta%20Gen%20%E2%80%93%206GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20AMD%20Radeon%20R5/Laptop_DELL_Inspiron_14-3459_Intel_Core_i5-6200U_Sexta_Gen_6GB_RAM_500GB_HDD_AMD_Radeon_R5_107607_71Tri1yZUCL_SL1500__i7j57w.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/Laptop DELL Inspiron 14-3459 – Intel Core i5-6200U Sexta Gen – 6GB RAM – 500GB HDD – AMD Radeon R5/Laptop_DELL_Inspiron_14-3459_Intel_Core_i5-6200U_Sexta_Gen_6GB_RAM_500GB_HDD_AMD_Radeon_R5_107607_71Tri1yZUCL_SL1500__i7j57w.jpg", null, 6 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 14, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8619), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_1-34-scaled_e4mqob.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP DELL G3 15 3579 8Then GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_1-34-scaled_e4mqob.jpg", null, 5 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 13, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8609), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_laptop-dell-g3-3579-15-i5-8300h-video-4gb-1tb-8gb-p-D_NQ_NP_621638-MPE32062793856_092019-F-scaled_zvmdzz.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP DELL G3 15 3579 8Then GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_laptop-dell-g3-3579-15-i5-8300h-video-4gb-1tb-8gb-p-D_NQ_NP_621638-MPE32062793856_092019-F-scaled_zvmdzz.jpg", null, 5 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 12, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8600), "Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_notebook-dell-g3-15-3579-156-intel-core-i7-8750h-220-ghz-8gb-ddr4-scaled_gsysxu.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP DELL G3 15 3579 8Then GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_notebook-dell-g3-15-3579-156-intel-core-i7-8750h-220-ghz-8gb-ddr4-scaled_gsysxu.jpg", null, 5 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 5, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8386), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_566540h7hdell_yhzsr4.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_566540h7hdell_yhzsr4.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 4, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8324), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_776540h7hdell_kwtv8a.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_776540h7hdell_kwtv8a.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 3, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8217), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_16540h7hdell_dhnsn9.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_16540h7hdell_dhnsn9.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 2, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8085), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_346540h7hdell_snunj0.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_346540h7hdell_snunj0.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 20, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8789), "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_ef6g5t8x0aioqpg_cucvyh.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei Honor 20/Huawei_Honor_20_ef6g5t8x0aioqpg_cucvyh.jpg", null, 8 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 21, new DateTime(2020, 8, 2, 14, 38, 50, 600, DateTimeKind.Local).AddTicks(8796), "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei Honor 20/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg", null, 8 });

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
