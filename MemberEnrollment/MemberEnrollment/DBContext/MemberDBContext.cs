using MemberEnrollment.Model;
using Microsoft.EntityFrameworkCore;

namespace MemberEnrollment.Data
{
    public class MemberDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        // Add other DbSet properties if needed

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MemberDB");
        }
    }
}