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
                            new ProductoFoto // Dell Latitude E6540
                {
                                Id = 1,
                                ProductoId = 1,
                                FotoPublicId = "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_6540h7hdell2_uckxvb.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_6540h7hdell2_uckxvb.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 2,
                                ProductoId = 1,
                                FotoPublicId = "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_346540h7hdell_snunj0.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_346540h7hdell_snunj0.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 3,
                                ProductoId = 1,
                                FotoPublicId = "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_16540h7hdell_dhnsn9.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_16540h7hdell_dhnsn9.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 4,
                                ProductoId = 1,
                                FotoPublicId = "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_776540h7hdell_kwtv8a.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_776540h7hdell_kwtv8a.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 5,
                                ProductoId = 1,
                                FotoPublicId = "Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_566540h7hdell_yhzsr4.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Dell%20Latitude%20E6540%20%E2%80%93%20Full%20HD%20%E2%80%93%20Core%20i5%204th%20Gen%20%E2%80%93%2016GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Teclado%20Num%C3%A9rico/Dell_Latitude_E6540_Full_HD_Core_i5_4th_Gen_16GB_RAM_500GB_Teclado_Num%C3%A9rico_566540h7hdell_yhzsr4.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // ACER PREDATOR CORE I7
                {
                                Id = 6,
                                ProductoId = 2,
                                FotoPublicId = "Sistema-Ventas/Laptops/LAPTOP%20ACER%20PREDATOR%20CORE%20I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-gamer-acer-predator-helios-300-i7-9750h-gtx-ti-6gb-D_NQ_NP_853948-MPE32067580368_092019-F-scaled_uldpur.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP%20ACER%20PREDATOR%20CORE%20I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-gamer-acer-predator-helios-300-i7-9750h-gtx-ti-6gb-D_NQ_NP_853948-MPE32067580368_092019-F-scaled_uldpur.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 7,
                                ProductoId = 2,
                                FotoPublicId = "Sistema-Ventas/Laptops/LAPTOP%20ACER%20PREDATOR%20CORE%20I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-acer-predator-helios-300-i7-8va-gtx-1060-16gb-ram-D_NQ_NP_816622-MPE32377868369_092019-F-scaled_wmhgav.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/LAPTOP%20ACER%20PREDATOR%20CORE%20I7/LAPTOP_ACER_PREDATOR_CORE_I7_laptop-acer-predator-helios-300-i7-8va-gtx-1060-16gb-ram-D_NQ_NP_816622-MPE32377868369_092019-F-scaled_wmhgav.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // BLU G70
                {
                                Id = 8,
                                ProductoId = 3,
                                FotoPublicId = "Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_Precio-BLU-G70-en-Costa-Rica_pynkr4.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816936/Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_Precio-BLU-G70-en-Costa-Rica_pynkr4.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 9,
                                ProductoId = 3,
                                FotoPublicId = "Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_BLU-G70-en-Costa-Rica-433x559_t05hzt.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816935/Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_BLU-G70-en-Costa-Rica-433x559_t05hzt.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 10,
                                ProductoId = 3,
                                FotoPublicId = "Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_Comprar-BLU-G70-en-Costa-Rica-491x1024_o0bsan.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816935/Sistema-Ventas/Celulares/BLU%20G70/BLU_G70_Comprar-BLU-G70-en-Costa-Rica-491x1024_o0bsan.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Asus Q301L
                {
                                Id = 11,
                                ProductoId = 4,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Asus%20Q301L%20%E2%80%93%20Intel%20Core%20i5-4200u%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Pantalla%20Touch%20%E2%80%93%20Teclado%20Iluminado%20%E2%80%93%20Ultra%20Liviana/Laptop_Asus_Q301L_Intel_Core_i5-4200u_8GB_RAM_500GB_Pantalla_Touch_Teclado_Iluminado_Ultra_Liviana_asus1_qk5rzi.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816981/Sistema-Ventas/Laptops/Laptop%20Asus%20Q301L%20%E2%80%93%20Intel%20Core%20i5-4200u%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20%E2%80%93%20Pantalla%20Touch%20%E2%80%93%20Teclado%20Iluminado%20%E2%80%93%20Ultra%20Liviana/Laptop_Asus_Q301L_Intel_Core_i5-4200u_8GB_RAM_500GB_Pantalla_Touch_Teclado_Iluminado_Ultra_Liviana_asus1_qk5rzi.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto // LAPTOP DELL G3 15 3579
                {
                                Id = 12,
                                ProductoId = 5,
                                FotoPublicId = "Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_notebook-dell-g3-15-3579-156-intel-core-i7-8750h-220-ghz-8gb-ddr4-scaled_gsysxu.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_notebook-dell-g3-15-3579-156-intel-core-i7-8750h-220-ghz-8gb-ddr4-scaled_gsysxu.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 13,
                                ProductoId = 5,
                                FotoPublicId = "Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_laptop-dell-g3-3579-15-i5-8300h-video-4gb-1tb-8gb-p-D_NQ_NP_621638-MPE32062793856_092019-F-scaled_zvmdzz.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_laptop-dell-g3-3579-15-i5-8300h-video-4gb-1tb-8gb-p-D_NQ_NP_621638-MPE32062793856_092019-F-scaled_zvmdzz.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 14,
                                ProductoId = 5,
                                FotoPublicId = "Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_1-34-scaled_e4mqob.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP%20DELL%20G3%2015%203579%208Then%20GENERATION/LAPTOP_DELL_G3_15_3579_8Then_GENERATION_1-34-scaled_e4mqob.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Laptop DELL Inspiron 14-3459
                {
                                Id = 15,
                                ProductoId = 6,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20DELL%20Inspiron%2014-3459%20%E2%80%93%20Intel%20Core%20i5-6200U%20Sexta%20Gen%20%E2%80%93%206GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20AMD%20Radeon%20R5/Laptop_DELL_Inspiron_14-3459_Intel_Core_i5-6200U_Sexta_Gen_6GB_RAM_500GB_HDD_AMD_Radeon_R5_107607_71Tri1yZUCL_SL1500__i7j57w.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/Laptop%20DELL%20Inspiron%2014-3459%20%E2%80%93%20Intel%20Core%20i5-6200U%20Sexta%20Gen%20%E2%80%93%206GB%20RAM%20%E2%80%93%20500GB%20HDD%20%E2%80%93%20AMD%20Radeon%20R5/Laptop_DELL_Inspiron_14-3459_Intel_Core_i5-6200U_Sexta_Gen_6GB_RAM_500GB_HDD_AMD_Radeon_R5_107607_71Tri1yZUCL_SL1500__i7j57w.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto // Google Pixel 4
                {
                                Id = 16,
                                ProductoId = 7,
                                FotoPublicId = "Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_51jjGHHKixL._AC_SX425__dxkxdc.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_51jjGHHKixL._AC_SX425__dxkxdc.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 17,
                                ProductoId = 7,
                                FotoPublicId = "Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_149597-phones-news-this-is-the-google-pixel-4-xl-image1-ktsr2yozg6_dpm6jk.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_149597-phones-news-this-is-the-google-pixel-4-xl-image1-ktsr2yozg6_dpm6jk.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 18,
                                ProductoId = 7,
                                FotoPublicId = "Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_1366_2000_foaiqs.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Google%20Pixel%204/Google_Pixel_4_1366_2000_foaiqs.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Huawei Honor 20
                {
                                Id = 19,
                                ProductoId = 8,
                                FotoPublicId = "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_GKK-Detachable-Case-for-Huawei-Honor-20-Black-10072019-01-p_few99o.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_GKK-Detachable-Case-for-Huawei-Honor-20-Black-10072019-01-p_few99o.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 20,
                                ProductoId = 8,
                                FotoPublicId = "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_ef6g5t8x0aioqpg_cucvyh.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_ef6g5t8x0aioqpg_cucvyh.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 21,
                                ProductoId = 8,
                                FotoPublicId = "Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei%20Honor%2020/Huawei_Honor_20_funda_de_silicona_huawei_honor_20_02_transparente_ad_l_uyu1kx.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // LAPTOP DELL INSPIRON 15
                {
                                Id = 22,
                                ProductoId = 9,
                                FotoPublicId = "Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-156-fhd-intel-core-i5-825-D_NQ_NP_967204-MPE32061439156_092019-F-scaled_eitw4k.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-156-fhd-intel-core-i5-825-D_NQ_NP_967204-MPE32061439156_092019-F-scaled_eitw4k.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 23,
                                ProductoId = 9,
                                FotoPublicId = "Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-15-5570-156-core-i5-68fnp-D_NQ_NP_781655-MPE32061793687_092019-F-scaled_alicmc.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-5000-15-5570-156-core-i5-68fnp-D_NQ_NP_781655-MPE32061793687_092019-F-scaled_alicmc.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 24,
                                ProductoId = 9,
                                FotoPublicId = "Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-3581-156-fhd-intel-core-i3-7020-D_NQ_NP_660749-MPE31598311513_072019-F-scaled_yrnlhi.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816982/Sistema-Ventas/Laptops/LAPTOP%20DELL%20INSPIRON%2015%20SILVER/LAPTOP_DELL_INSPIRON_15_SILVER_notebook-dell-inspiron-15-3581-156-fhd-intel-core-i3-7020-D_NQ_NP_660749-MPE31598311513_072019-F-scaled_yrnlhi.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Laptop DELL INSPIRON 15-3558
                {
                                Id = 25,
                                ProductoId = 10,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_43558dell36689-1_cjqhsy.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_43558dell36689-1_cjqhsy.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 26,
                                ProductoId = 10,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_3558dell36689_ostn27.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_3558dell36689_ostn27.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 27,
                                ProductoId = 10,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_23558dell36689_wxdxod.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_23558dell36689_wxdxod.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 28,
                                ProductoId = 10,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_13558dell36689_qgimk8.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop%20DELL%20INSPIRON%2015-3558%20%E2%80%93%20Intel%20Core%20i3%20Quinta%20Generaci%C3%B3n%20%E2%80%93%204GB%20RAM%20%E2%80%93%201TB%20HDD/Laptop_DELL_INSPIRON_15-3558_Intel_Core_i3_Quinta_Generaci%C3%B3n_4GB_RAM_1TB_HDD_13558dell36689_qgimk8.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Laptop Dell Latitude 3350
                {
                                Id = 29,
                                ProductoId = 11,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%203350%20%E2%80%93%20Intel%20Core%20I5%20Quinta%20Generaci%C3%B3n/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generaci%C3%B3n_dell-latitude-3350-monsterlaptops_zcypyv.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%203350%20%E2%80%93%20Intel%20Core%20I5%20Quinta%20Generaci%C3%B3n/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generaci%C3%B3n_dell-latitude-3350-monsterlaptops_zcypyv.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 30,
                                ProductoId = 11,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%203350%20%E2%80%93%20Intel%20Core%20I5%20Quinta%20Generaci%C3%B3n/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generaci%C3%B3n_3dell-latitude-3350-monsterlaptops_yid0mm.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%203350%20%E2%80%93%20Intel%20Core%20I5%20Quinta%20Generaci%C3%B3n/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generaci%C3%B3n_3dell-latitude-3350-monsterlaptops_yid0mm.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto
                            {
                                Id = 31,
                                ProductoId = 11,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%203350%20%E2%80%93%20Intel%20Core%20I5%20Quinta%20Generaci%C3%B3n/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generaci%C3%B3n_1dell-latitude-3350-monsterlaptops_j1aoqx.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816983/Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%203350%20%E2%80%93%20Intel%20Core%20I5%20Quinta%20Generaci%C3%B3n/Laptop_Dell_Latitude_3350_Intel_Core_I5_Quinta_Generaci%C3%B3n_1dell-latitude-3350-monsterlaptops_j1aoqx.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Laptop Dell Latitude E5450
                {
                                Id = 32,
                                ProductoId = 12,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%20E5450%20%E2%80%93%20i5%20Quinta%20Generaci%C3%B3n%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD/Laptop_Dell_Latitude_E5450_i5_Quinta_Generaci%C3%B3n_8GB_RAM_500GB_HDD_delle51267_wodunh.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%20E5450%20%E2%80%93%20i5%20Quinta%20Generaci%C3%B3n%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD/Laptop_Dell_Latitude_E5450_i5_Quinta_Generaci%C3%B3n_8GB_RAM_500GB_HDD_delle51267_wodunh.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 33,
                                ProductoId = 12,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%20E5450%20%E2%80%93%20i5%20Quinta%20Generaci%C3%B3n%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD/Laptop_Dell_Latitude_E5450_i5_Quinta_Generaci%C3%B3n_8GB_RAM_500GB_HDD_0vnb125_hdadig.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop%20Dell%20Latitude%20E5450%20%E2%80%93%20i5%20Quinta%20Generaci%C3%B3n%20%E2%80%93%208GB%20RAM%20%E2%80%93%20500GB%20HDD/Laptop_Dell_Latitude_E5450_i5_Quinta_Generaci%C3%B3n_8GB_RAM_500GB_HDD_0vnb125_hdadig.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Huawei Y7p
                {
                                Id = 34,
                                ProductoId = 13,
                                FotoPublicId = "Sistema-Ventas/Celulares/Huawei%20Y7p/Huawei_Y7p_Precio-Huawei-Y7p-en-Costa-Rica_nfiokl.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Huawei%20Y7p/Huawei_Y7p_Precio-Huawei-Y7p-en-Costa-Rica_nfiokl.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 35,
                                ProductoId = 13,
                                FotoPublicId = "Sistema-Ventas/Celulares/Huawei%20Y7p/Huawei_Y7p_Comprar-Huawei-Y7p-en-Costa-Rica_at8yeh.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/Huawei%20Y7p/Huawei_Y7p_Comprar-Huawei-Y7p-en-Costa-Rica_at8yeh.jpg"),
                                CreatedAt = DateTime.Now,
                            },new ProductoFoto
                            {
                                Id = 36,
                                ProductoId = 13,
                                FotoPublicId = "Sistema-Ventas/Celulares/Huawei%20Y7p/Huawei_Y7p_Huawei-Y7p-en-Costa-Rica-1_mawrci.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816944/Sistema-Ventas/Celulares/Huawei%20Y7p/Huawei_Y7p_Huawei-Y7p-en-Costa-Rica-1_mawrci.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Laptop Dell Ultrabook E7240
                {
                                Id = 37,
                                ProductoId = 14,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Dell%20Ultrabook%20E7240%20%E2%80%93%2012GB%20Ram%20%E2%80%93%20Intel%20Core%20i5%20%E2%80%93%20128GB%20SSD%20%E2%80%93%20Teclado%20Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_delle72404433_tllnkp.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop%20Dell%20Ultrabook%20E7240%20%E2%80%93%2012GB%20Ram%20%E2%80%93%20Intel%20Core%20i5%20%E2%80%93%20128GB%20SSD%20%E2%80%93%20Teclado%20Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_delle72404433_tllnkp.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 38,
                                ProductoId = 14,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Dell%20Ultrabook%20E7240%20%E2%80%93%2012GB%20Ram%20%E2%80%93%20Intel%20Core%20i5%20%E2%80%93%20128GB%20SSD%20%E2%80%93%20Teclado%20Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_2delle72404433_gkbrxs.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop%20Dell%20Ultrabook%20E7240%20%E2%80%93%2012GB%20Ram%20%E2%80%93%20Intel%20Core%20i5%20%E2%80%93%20128GB%20SSD%20%E2%80%93%20Teclado%20Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_2delle72404433_gkbrxs.jpg"),
                                CreatedAt = DateTime.Now,
                            },new ProductoFoto
                            {
                                Id = 39,
                                ProductoId = 14,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20Dell%20Ultrabook%20E7240%20%E2%80%93%2012GB%20Ram%20%E2%80%93%20Intel%20Core%20i5%20%E2%80%93%20128GB%20SSD%20%E2%80%93%20Teclado%20Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_1delle72404433_ie14cu.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop%20Dell%20Ultrabook%20E7240%20%E2%80%93%2012GB%20Ram%20%E2%80%93%20Intel%20Core%20i5%20%E2%80%93%20128GB%20SSD%20%E2%80%93%20Teclado%20Iluminado/Laptop_Dell_Ultrabook_E7240_12GB_Ram_Intel_Core_i5_128GB_SSD_Teclado_Iluminado_1delle72404433_ie14cu.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Laptop HP 15-ba051wm
                {
                                Id = 40,
                                ProductoId = 15,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20HP%2015-ba051wm%20%E2%80%93%20Pantalla%20Touch%20%E2%80%93%20Quad-Core%20A10-9600P%20%E2%80%93%208GB%20RAM%20%E2%80%93%201TB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-ba051wm_Pantalla_Touch_Quad-Core_A10-9600P_8GB_RAM_1TB_HDD_Teclado_Num%C3%A9rico_d1bcb5c0-8ba3-4703-_do4ilh.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816984/Sistema-Ventas/Laptops/Laptop%20HP%2015-ba051wm%20%E2%80%93%20Pantalla%20Touch%20%E2%80%93%20Quad-Core%20A10-9600P%20%E2%80%93%208GB%20RAM%20%E2%80%93%201TB%20HDD%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-ba051wm_Pantalla_Touch_Quad-Core_A10-9600P_8GB_RAM_1TB_HDD_Teclado_Num%C3%A9rico_d1bcb5c0-8ba3-4703-_do4ilh.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto // iPhone 11 (128GB)
                {
                                Id = 41,
                                ProductoId = 16,
                                FotoPublicId = "Sistema-Ventas/Celulares/iPhone%2011%20%28128GB%29/iPhone_11_128GB_iPhone-11-precio-Costa-Rica_efrulu.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816946/Sistema-Ventas/Celulares/iPhone%2011%20%28128GB%29/iPhone_11_128GB_iPhone-11-precio-Costa-Rica_efrulu.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 42,
                                ProductoId = 16,
                                FotoPublicId = "Sistema-Ventas/Celulares/iPhone%2011%20%28128GB%29/iPhone_11_128GB_iphone-11-de-venta-en-Costa-Rica_gg3uib.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816946/Sistema-Ventas/Celulares/iPhone%2011%20%28128GB%29/iPhone_11_128GB_iphone-11-de-venta-en-Costa-Rica_gg3uib.jpg"),
                                CreatedAt = DateTime.Now,
                            },new ProductoFoto
                            {
                                Id = 43,
                                ProductoId = 16,
                                FotoPublicId = "Sistema-Ventas/Celulares/iPhone%2011%20%28128GB%29/iPhone_11_128GB_iPhone-11-en-costa-Rica_ooxbv5.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/iPhone%2011%20%28128GB%29/iPhone_11_128GB_iPhone-11-en-costa-Rica_ooxbv5.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // iPhone 8 Plus 64GB
                {
                                Id = 44,
                                ProductoId = 17,
                                FotoPublicId = "Sistema-Ventas/Celulares/iPhone%208%20Plus%2064GB/iPhone_8_Plus_64GB_precio-iphone-8-plus-en-costa-rica_pl8wtz.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816946/Sistema-Ventas/Celulares/iPhone%208%20Plus%2064GB/iPhone_8_Plus_64GB_precio-iphone-8-plus-en-costa-rica_pl8wtz.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 45,
                                ProductoId = 17,
                                FotoPublicId = "Sistema-Ventas/Celulares/iPhone%208%20Plus%2064GB/iPhone_8_Plus_64GB_comprar-iphone-8-plus-en-costa-rica_kyu29s.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/iPhone%208%20Plus%2064GB/iPhone_8_Plus_64GB_comprar-iphone-8-plus-en-costa-rica_kyu29s.jpg"),
                                CreatedAt = DateTime.Now,
                            },new ProductoFoto
                            {
                                Id = 46,
                                ProductoId = 17,
                                FotoPublicId = "Sistema-Ventas/Celulares/iPhone%208%20Plus%2064GB/iPhone_8_Plus_64GB_iphone-8-plus-en-costa-rica_h2hwur.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816945/Sistema-Ventas/Celulares/iPhone%208%20Plus%2064GB/iPhone_8_Plus_64GB_iphone-8-plus-en-costa-rica_h2hwur.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Laptop HP 15-f387wm
                {
                                Id = 47,
                                ProductoId = 18,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_b62ed24wmr_mzyzt4.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816985/Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_b62ed24wmr_mzyzt4.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 48,
                                ProductoId = 18,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_b3b5615cwmg_wnhba0.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816985/Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_b3b5615cwmg_wnhba0.jpg"),
                                CreatedAt = DateTime.Now,
                            },new ProductoFoto
                            {
                                Id = 49,
                                ProductoId = 18,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_a8-1wemk_psrtud.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816985/Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_a8-1wemk_psrtud.jpg"),
                                CreatedAt = DateTime.Now,
                            },new ProductoFoto
                            {
                                Id = 50,
                                ProductoId = 18,
                                FotoPublicId = "Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_2da6aa5wmol_jzvmjy.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816985/Sistema-Ventas/Laptops/Laptop%20HP%2015-f387wm%20%E2%80%93%20AMD%20A8-7410%20%E2%80%93%20500GB%20HDD%20%E2%80%93%204GB%20RAM%20%E2%80%93%20Radeon%20R5%20%E2%80%93%20Pantalla%20T%C3%A1ctil%20%E2%80%93%20Teclado%20Num%C3%A9rico/Laptop_HP_15-f387wm_AMD_A8-7410_500GB_HDD_4GB_RAM_Radeon_R5_Pantalla_T%C3%A1ctil_Teclado_Num%C3%A9rico_2da6aa5wmol_jzvmjy.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // LG Aristo 5
                {
                                Id = 51,
                                ProductoId = 19,
                                FotoPublicId = "Sistema-Ventas/Celulares/LG%20Aristo%205/LG_Aristo_5_LG-Aristo-5-Silver-frontimage_cvqajy.png",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/LG%20Aristo%205/LG_Aristo_5_LG-Aristo-5-Silver-frontimage_cvqajy.png"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 52,
                                ProductoId = 19,
                                FotoPublicId = "Sistema-Ventas/Celulares/LG%20Aristo%205/LG_Aristo_5_LG-Aristo-5_qgxdwn.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/LG%20Aristo%205/LG_Aristo_5_LG-Aristo-5_qgxdwn.jpg"),
                                CreatedAt = DateTime.Now,
                            },
                            new ProductoFoto // Samsung Galaxy A11
                {
                                Id = 53,
                                ProductoId = 20,
                                FotoPublicId = "Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Samsung-Galaxy-A11-en-Costa-Rica_ag1ltk.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Samsung-Galaxy-A11-en-Costa-Rica_ag1ltk.jpg"),
                                CreatedAt = DateTime.Now,
                },
                            new ProductoFoto
                            {
                                Id = 54,
                                ProductoId = 20,
                                FotoPublicId = "Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Venta-Samsung-Galaxy-A11-en-Costa-Rica_da7fjh.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Venta-Samsung-Galaxy-A11-en-Costa-Rica_da7fjh.jpg"),
                                CreatedAt = DateTime.Now,
                            },new ProductoFoto
                            {
                                Id = 55,
                                ProductoId = 20,
                                FotoPublicId = "Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Comprar-Samsung-Galaxy-A11-en-Costa-Rica_wdx6c3.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Comprar-Samsung-Galaxy-A11-en-Costa-Rica_wdx6c3.jpg"),
                                CreatedAt = DateTime.Now,
                            },new ProductoFoto
                            {
                                Id = 56,
                                ProductoId = 20,
                                FotoPublicId = "Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Precio-Samsung-Galaxy-A11-en-Costa-Rica_x9xdds.jpg",
                                FotoUrl = new Uri("https://res.cloudinary.com/alexander-damaso-26857/image/upload/v1595816947/Sistema-Ventas/Celulares/Samsung%20Galaxy%20A11/Samsung_Galaxy_A11_Precio-Samsung-Galaxy-A11-en-Costa-Rica_x9xdds.jpg"),
                                CreatedAt = DateTime.Now,
                            });
        }
    }
}
