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
                            });
        }
    }
}
