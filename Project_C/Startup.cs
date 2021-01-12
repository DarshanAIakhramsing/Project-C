using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project_C.Areas.Identity;
using Project_C.Data;
using Project_C.Services;
using Microsoft.Extensions.Options;
using Project_C.Models;
using System.Threading;

namespace Project_C
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<SessionCRUD>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddScoped<SessionService>();
            services.AddScoped<NotificationCreate>();
            services.AddScoped<UserService>();

            services.Configure<AppSettings>(Configuration.GetSection("MySettings"));

            services.AddDefaultIdentity<User>(config =>
            {
                config.Password.RequireDigit = true;
                config.Password.RequireLowercase = false;
                config.Password.RequiredLength = 0;
                config.Password.RequireUppercase = true;
                config.Password.RequireNonAlphanumeric = true;
            })
                .AddRoles<Role>()
                .AddRoleStore<CustomRoleStore>()
                .AddUserStore<CustomUserStore>();

            services.AddHostedService<Yeet>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<SessionService>();
            services.AddScoped<SessionCRUD>();
            services.AddScoped<UserService>();
        }

        class Yeet : IHostedService
        {
            public Yeet(IServiceProvider serviceProvider) => ServiceProvider = serviceProvider;

            public IServiceProvider ServiceProvider { get; }

            public async Task StartAsync(CancellationToken cancellationToken)
            {
                using (var scope = ServiceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var settings = scope.ServiceProvider.GetRequiredService<IOptions<AppSettings>>().Value;

                    var sessions = await dbContext.Session.ToListAsync();
                }
            }

            public Task StopAsync(CancellationToken cancellationToken)
            {
                return Task.CompletedTask;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
