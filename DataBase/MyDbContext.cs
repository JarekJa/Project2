using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project2.Models.Users;

namespace Project2.DataBase
{
    public class MyDbContext : IdentityDbContext<User>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
           : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
    .HasDiscriminator<string>("UserType")
    .HasValue<User>("User")
    .HasValue<Admin>("Administrator")
    .HasValue<ProjectEmployee>("Boss")
    .HasValue<Employee>("Employee")
    .HasValue<HRManager>("HRManagerr")
    .HasValue<ProjectManager>("ProjectManager")
    .HasValue<ProjectEmployee>("ProjectEmployee")
    ;

            modelBuilder.Entity<Employee>()
               .HasOne(e => e.AddedByHRManager)
               .WithMany(hr => hr.AddedEmployees)
               .HasForeignKey(e => e.AddedByHRManagerId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
