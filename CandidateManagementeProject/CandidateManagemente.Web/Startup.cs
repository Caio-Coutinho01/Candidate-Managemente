using CandidateManagemente.Application.Commands.Authentication;
using CandidateManagemente.Application.Commands.Candidates;
using CandidateManagemente.Domain.Interface;
using CandidateManagemente.Infra.Data.Context;
using CandidateManagemente.Infra.Data.Repositories;
using CandidateManagemente.Web.Mapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CandidateManagemente.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace CandidateManagemente.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Home/Index"; 
                options.AccessDeniedPath = "/Home/Index";
                options.SlidingExpiration = true;  
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); 
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            services.AddAuthorization();

            #region MediatR
            services.AddMediatR(typeof(AddCandidateCommand));
            services.AddMediatR(typeof(Startup));
            services.AddMediatR(typeof(UserCommand));
            #endregion

            #region Repository
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            #endregion

            #region Mapper
            services.AddAutoMapper(typeof(CandidateProfile));
            #endregion

            #region dbConnect
            services.AddDbContext<MyCustomDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseRouting();

            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }

    }
}
