using Microsoft.Extensions.DependencyInjection;
using MemberEnrollment.Data;
using MemberEnrollment.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MemberEnrollment
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add other service configurations as needed
            services.AddControllers();

            // Register your database context
            //services.MemberDbContext<MemberDbContext>(opt => opt.UseInMemoryDatabase("MemberEnrollmentDB"));

            // Register your repository with the appropriate lifetime (e.g., AddScoped)
            services.AddScoped<MemberRepository, MemberRepository>();
            //services.ValidateResolvedServices();
        }
    }
}