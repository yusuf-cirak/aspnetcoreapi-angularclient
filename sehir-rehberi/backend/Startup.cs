using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SehirRehberi.Business.Abstract;
using SehirRehberi.Business.Concrete;
using SehirRehberi.DataAccess;
using SehirRehberi.Helpers;
using System.Text;

namespace SehirRehberi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Appsettings:Token").Value);
            services.AddMvc().AddNewtonsoftJson(opt=> // Nesneler arasýnda baðlantý var. Ýstek gönderildiðinde sonsuz döngüye girmemeleri için yazdýðýmýz kod.
                opt.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<DataContext>(x => // Bu appsettings.json kontrol et. Database-program iliþkisi kuruldu
                x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(Startup).Assembly); // AutoMapper

            services.AddScoped<IAppRepositoryService, AppRepositoryManager>(); //Dependency injection, her controller isteðinde bu nesnelerden oluþacak.

            services.AddScoped<IAuthRepositoryService, AuthRepositoryManager>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=>
                opt.TokenValidationParameters= new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                });
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings")); // appsettings.jsondaki CloudinarySettingsi oku ve CloudinarySettings nesnelerine map etme iþlemi.

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SehirRehberi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SehirRehberi v1"));
            }
            

            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            //Header= Request headerlarý kabul eder (authorization), post , //Method=Get,post, Origin= Ýstek nereden gelirse gelsin kabul eder. Credential= Credential policyleri kabul eder.
            app.UseCors(options => options.
                AllowAnyHeader().
                AllowAnyMethod().
                SetIsOriginAllowed(origin => true).
                AllowCredentials());

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
