using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MemberEnrollment.Repositories;

namespace MemberEnrollment
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // Add this line to enable controller-based routing
            services.AddScoped<MemberRepository>();
            services.AddTransient<MemberRepository>();
            //services.AddScoped();// Add other services your application requires
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Map controller routes
                // Add other endpoints if needed
            });
        }
    }
}
