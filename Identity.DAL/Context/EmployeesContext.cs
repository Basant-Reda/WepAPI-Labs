using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.DAL;

public class EmployeesContext : IdentityDbContext<Employee>
{
    public EmployeesContext(DbContextOptions<EmployeesContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Employee>().ToTable("Employees");
    }
}
