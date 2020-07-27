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
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoriaId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Estado = table.Column<bool>(nullable: false),
                    Marca = table.Column<string>(nullable: true),
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
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
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
                values: new object[] { 1, new DateTime(2020, 7, 26, 23, 33, 57, 895, DateTimeKind.Local).AddTicks(3714), "Celulares nuevos y usados.", true, "Celulares", new DateTime(2020, 7, 26, 23, 33, 57, 896, DateTimeKind.Local).AddTicks(1086) });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "CreatedAt", "Descripcion", "Estado", "Nombre", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2020, 7, 26, 23, 33, 57, 896, DateTimeKind.Local).AddTicks(1441), "Tenemos computadoras de ultima generacion.", true, "Computadoras", new DateTime(2020, 7, 26, 23, 33, 57, 896, DateTimeKind.Local).AddTicks(1450) });

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
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "Marca", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 1, 1, new DateTime(2020, 7, 26, 23, 33, 57, 897, DateTimeKind.Local).AddTicks(9184), "Los clientes empresariales han utilizado durante mucho tiempo la familia de portátiles empresariales de gama alta Lenovo, anteriormente IBM, ThinkPad", true, "Lenovo", "Thinkpad T440 - Nuevo", 55000.00m, 15, new DateTime(2020, 7, 26, 23, 33, 57, 897, DateTimeKind.Local).AddTicks(8887) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "Marca", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 2, 1, new DateTime(2020, 7, 26, 23, 33, 57, 897, DateTimeKind.Local).AddTicks(9519), null, true, "Dell", "Latitude E6540 - Nuevo", 44000.00m, 5, new DateTime(2020, 7, 26, 23, 33, 57, 897, DateTimeKind.Local).AddTicks(9512) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "Marca", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 3, 2, new DateTime(2020, 7, 26, 23, 33, 57, 897, DateTimeKind.Local).AddTicks(9528), null, true, "Huawei", "Honor 20 - Nuevo", 34000.00m, 10, new DateTime(2020, 7, 26, 23, 33, 57, 897, DateTimeKind.Local).AddTicks(9527) });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "CreatedAt", "Descripcion", "Estado", "Marca", "Nombre", "Precio", "Stock", "UpdatedAt" },
                values: new object[] { 4, 2, new DateTime(2020, 7, 26, 23, 33, 57, 897, DateTimeKind.Local).AddTicks(9531), null, true, "Lenovo", "Lenovo L34 - Nuevo", 40000.00m, 10, new DateTime(2020, 7, 26, 23, 33, 57, 897, DateTimeKind.Local).AddTicks(9530) });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 1, new DateTime(2020, 7, 26, 23, 33, 57, 900, DateTimeKind.Local).AddTicks(4299), "Sistema-Ventas/Laptops/Laptop%20Lenovo%20Thinkpad%20T440%20%E2%80%93%20Intel%20Core%20i5-4200U%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico%20%E2%80%93%20Lector%20De%20Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Num%C3%A9rico_Lector_De_Huellas_lenodiK59HL_bfzqjo.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816989/Sistema-Ventas/Laptops/Laptop Lenovo Thinkpad T440 – Intel Core i5-4200U – 8GB RAM – 500GB HDD – Teclado Numérico – Lector De Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Numérico_Lector_De_Huellas_lenodiK59HL_bfzqjo.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 2, new DateTime(2020, 7, 26, 23, 33, 57, 900, DateTimeKind.Local).AddTicks(4894), "Sistema-Ventas/Laptops/Laptop%20Lenovo%20Thinkpad%20T440%20%E2%80%93%20Intel%20Core%20i5-4200U%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico%20%E2%80%93%20Lector%20De%20Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Num%C3%A9rico_Lector_De_Huellas_81giqVlenosi_m4gfmm.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816989/Sistema-Ventas/Laptops/Laptop Lenovo Thinkpad T440 – Intel Core i5-4200U – 8GB RAM – 500GB HDD – Teclado Numérico – Lector De Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Numérico_Lector_De_Huellas_710c9klejuso_mn1uht.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 3, new DateTime(2020, 7, 26, 23, 33, 57, 900, DateTimeKind.Local).AddTicks(4994), "Sistema-Ventas/Laptops/Laptop%20Lenovo%20Thinkpad%20T440%20%E2%80%93%20Intel%20Core%20i5-4200U%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico%20%E2%80%93%20Lector%20De%20Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Num%C3%A9rico_Lector_De_Huellas_710c9klejuso_mn1uht.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816989/Sistema-Ventas/Laptops/Laptop Lenovo Thinkpad T440 – Intel Core i5-4200U – 8GB RAM – 500GB HDD – Teclado Numérico – Lector De Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Numérico_Lector_De_Huellas_81giqVlenosi_m4gfmm.jpg", null, 1 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 4, new DateTime(2020, 7, 26, 23, 33, 57, 900, DateTimeKind.Local).AddTicks(5076), "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_776540h7hdell_kwtv8a.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell Latitude E6540 – Full HD – Core i5 4th Gen – 16GB RAM – 500GB – Teclado Numérico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Numérico_776540h7hdell_kwtv8a.jpg", null, 2 });

            migrationBuilder.InsertData(
                table: "ProductoFotos",
                columns: new[] { "Id", "CreatedAt", "FotoPublicId", "FotoUrl", "IsPrincipal", "ProductoId" },
                values: new object[] { 5, new DateTime(2020, 7, 26, 23, 33, 57, 900, DateTimeKind.Local).AddTicks(5149), "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg", "https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei Honor 20/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg", null, 3 });

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
                name: "Clientes");
        }
    }
}
