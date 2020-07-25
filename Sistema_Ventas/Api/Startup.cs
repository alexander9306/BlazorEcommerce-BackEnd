namespace Api
{
    using Api.Datos;
    using Api.Helpers;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            _tokenHelper = new TokenHelper(configuration);
        }

        public IConfiguration Configuration { get; }

        private static TokenHelper _tokenHelper;

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContextSistema>(options =>
                options.UseSqlite("Data Source=Sistema.db"));
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "Todos",
                    builder => builder
                        .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials().Build());
                //builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => _tokenHelper.GetTokenOptions(options));
            services.AddControllers();
            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
