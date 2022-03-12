using CodeSS_Server.Authorization;
using CodeSS_Server.Helpers;
using CodeSS_Server.Models;
using CodeSS_Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using CodeSS_Server.Services.CodeCategoryService;
using CodeSS_Server.Services.CodeService;

namespace CodeSS_Server
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
            services.AddDbContext<DataContext>();
            services.AddCors();
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CodeSS_Server", Version = "v1" });
            });

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICodeCategoryService, CodeCategoryService>();
            services.AddScoped<ICodeService, CodeService>();

            services.AddScoped<IJwtUtils, JwtUtils>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            // migrate any database changes on startup (includes initial db creation)
            dataContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CodeSS_Server v1"));
            }

            app.UseRouting();

            // global cors policy
            app.UseCors(x => x
				//.WithOrigins("https://learn.javascript.ru")
				//.AllowAnyHeader()
				//.AllowAnyMethod()
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader()
				);
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
