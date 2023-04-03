using Microsoft.AspNetCore.Identity;

namespace Identity.DAL;

public class Employee : IdentityUser
{
    public int PerformanceRate { get; set; }
}
