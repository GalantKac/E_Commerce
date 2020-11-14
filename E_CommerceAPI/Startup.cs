using AutoMapper;
using E_CommerceAPI.Data;
using E_CommerceAPI.Data.Repository;
using E_CommerceAPI.Extensions;
using E_CommerceAPI.Helpers;
using E_CommerceAPI.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;

namespace E_CommerceAPI
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // zarejestrowanie klasy mapujacej klasy
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers().AddNewtonsoftJson(options => 
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            services.AddDbContext<DB_E_CommerceContext>(option =>
                option.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var config = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(config);
            });

            services.AddApplicationServices();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    //Zabezpieczenia przegl�darki uniemo�liwiaj� stronom sieci Web wykonywanie ��da� do innej domeny ni� ta, kt�ra by�a obs�ugiwana przez stron� sieci Web. 
                    //To ograniczenie jest nazywane zasadami tego samego �r�d�a.
                    //Zasady tego samego �r�d�a uniemo�liwiaj� z�o�liwej lokacji odczytywanie poufnych danych z innej lokacji. 
                    //Czasami mo�esz chcie� zezwoli� innym lokacjom na wykonywanie ��da� mi�dzy �r�d�ami do aplikacji. 
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200", "http://localhost:4200");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
