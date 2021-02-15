using API.Extensions;
using API.Helpers;
using API.Middleware;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace API
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
            services.AddControllers();
            services.AddDbContext<DB_E_CommerceContext>(option =>
                option.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("IdentityConnection"));
            });

            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var config = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(config);
            });

            services.AddApplicationServices();
            services.AddIdentityServices(_configuration);
            services.AddSwaggerDocumentation();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    //Zabezpieczenia przegl�darki uniemo�liwiaj� stronom sieci Web wykonywanie ��da� do innej domeny ni� ta, kt�ra by�a obs�ugiwana przez stron� sieci Web. 
                    //To ograniczenie jest nazywane zasadami tego samego �r�d�a.
                    //Zasady tego samego �r�d�a uniemo�liwiaj� z�o�liwej lokacji odczytywanie poufnych danych z innej lokacji. 
                    //Czasami mo�esz chcie� zezwoli� innym lokacjom na wykonywanie ��da� mi�dzy �r�d�ami do aplikacji. 
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200", "http://localhost:4200", "http://localhost:44349/", "https://localhost:44349/");
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwaggerDocumention();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
