namespace Sistema.Api.Datos.Mapping.Almacen
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Sistema.Api.Entidades.Almacen;

    public class ProductoFotoMap : IEntityTypeConfiguration<ProductoFoto>
    {
        public void Configure(EntityTypeBuilder<ProductoFoto> builder)
        {
            builder.HasData(
                new ProductoFoto
                {
                    Id = 1,
                    ProductoId = 1,
                    FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Lenovo%20Thinkpad%20T440%20%E2%80%93%20Intel%20Core%20i5-4200U%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico%20%E2%80%93%20Lector%20De%20Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Num%C3%A9rico_Lector_De_Huellas_lenodiK59HL_bfzqjo.jpg",
                    FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816989/Sistema-Ventas/Laptops/Laptop%20Lenovo%20Thinkpad%20T440%20%E2%80%93%20Intel%20Core%20i5-4200U%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico%20%E2%80%93%20Lector%20De%20Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Num%C3%A9rico_Lector_De_Huellas_lenodiK59HL_bfzqjo.jpg"),
                    CreatedAt = DateTime.Now,
                },
                new ProductoFoto
                {
                    Id = 2,
                    ProductoId = 1,
                    FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Lenovo%20Thinkpad%20T440%20%E2%80%93%20Intel%20Core%20i5-4200U%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico%20%E2%80%93%20Lector%20De%20Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Num%C3%A9rico_Lector_De_Huellas_81giqVlenosi_m4gfmm.jpg",
                    FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816989/Sistema-Ventas/Laptops/Laptop%20Lenovo%20Thinkpad%20T440%20%E2%80%93%20Intel%20Core%20i5-4200U%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico%20%E2%80%93%20Lector%20De%20Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Num%C3%A9rico_Lector_De_Huellas_710c9klejuso_mn1uht.jpg"),
                    CreatedAt = DateTime.Now,
                },
                new ProductoFoto
                {
                    Id = 3,
                    ProductoId = 1,
                    FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Lenovo%20Thinkpad%20T440%20%E2%80%93%20Intel%20Core%20i5-4200U%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico%20%E2%80%93%20Lector%20De%20Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Num%C3%A9rico_Lector_De_Huellas_710c9klejuso_mn1uht.jpg",
                    FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816989/Sistema-Ventas/Laptops/Laptop%20Lenovo%20Thinkpad%20T440%20%E2%80%93%20Intel%20Core%20i5-4200U%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico%20%E2%80%93%20Lector%20De%20Huellas/Laptop_Lenovo_Thinkpad_T440_Intel_Core_i5-4200U_8GB_RAM_500GB_HDD_Teclado_Num%C3%A9rico_Lector_De_Huellas_81giqVlenosi_m4gfmm.jpg"),
                    CreatedAt = DateTime.Now,
                },
                new ProductoFoto
                {
                    Id = 4,
                    ProductoId = 2,
                    FotoPublicId = "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_776540h7hdell_kwtv8a.jpg",
                    FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_776540h7hdell_kwtv8a.jpg"),
                    CreatedAt = DateTime.Now,
                },
                new ProductoFoto
                {
                    Id = 5,
                    ProductoId = 3,
                    FotoPublicId = "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg",
                    FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg"),
                    CreatedAt = DateTime.Now,
                }
            );
        }
    }
}
