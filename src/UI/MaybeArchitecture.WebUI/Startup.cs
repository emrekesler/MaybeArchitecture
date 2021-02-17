using MaybeArchitecture.Infrastructure.Data.EF;
using MaybeArchitecture.Infrastructure.IoC;
using MaybeArchitecture.Mapper.MapsterImp.IoC;
using MaybeArchitecture.Plugins.MovieProvider.TmdbJson.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace MaybeArchitecture.WebUI
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
            CheckRequiredEnvironmentVariables();

            string dbProvider = Environment.GetEnvironmentVariable("DB_PROVIDER");
            string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbUserPassword = Environment.GetEnvironmentVariable("DB_USER_PASS");

            services.AddDbContext<AppDbContext>(
                options => _ = dbProvider switch
                {
                    "Postgre" =>
                        options.UseNpgsql(Configuration.GetConnectionString("DatabaseConnectionPostgre")
                                                       .Replace("{Host}", dbHost)
                                                       .Replace("{User}", dbUser)
                                                       .Replace("{UserPassword}", dbUserPassword),
                            optionsBuilder => optionsBuilder.MigrationsAssembly("MaybeArchitecture.Migrations.Postgre")),

                    "SqlServer" =>
                        options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")
                                                          .Replace("{Host}", dbHost)
                                                          .Replace("{User}", dbUser)
                                                          .Replace("{UserPassword}", dbUserPassword),
                            optionsBuilder =>
                                optionsBuilder.MigrationsAssembly("MaybeArchitecture.Migrations.SqlServer")),

                    _ => throw new Exception($"Unsupported provider: {dbProvider}")

                });


            services.RegisterCoreServices();
            services.RegisterMovieProvider(Configuration);
            services.RegisterMapper();

            services.AddControllersWithViews();
        }

        private void CheckRequiredEnvironmentVariables()
        {
            string dbProvider = Environment.GetEnvironmentVariable("DB_PROVIDER");
            string dbHost = Environment.GetEnvironmentVariable("DB_HOST");
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbUserPassword = Environment.GetEnvironmentVariable("DB_USER_PASS");

            bool exitFlag = false;

            if (string.IsNullOrWhiteSpace(dbProvider))
            {
                Console.WriteLine("DB_PROVIDER Variable Is Required");
                exitFlag = true;
            }

            if (string.IsNullOrWhiteSpace(dbHost))
            {
                Console.WriteLine("DB_HOST Variable Is Required");
                exitFlag = true;
            }

            if (string.IsNullOrWhiteSpace(dbUser))
            {
                Console.WriteLine("DB_USER Variable Is Required");
                exitFlag = true;
            }

            if (string.IsNullOrWhiteSpace(dbUserPassword))
            {
                Console.WriteLine("DB_USER_PASS Variable Is Required");
                exitFlag = true;
            }

            if (exitFlag)
            {
                Environment.Exit(-1);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext appDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            appDbContext.Database.Migrate();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}