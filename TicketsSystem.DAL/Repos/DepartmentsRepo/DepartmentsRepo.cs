

using Microsoft.EntityFrameworkCore;

namespace TicketsSystem.DAL;

public class DepartmentsRepo : GenericRepo<Department>, IDepartmentsRepo
{
    private readonly TicketsSystemContext _context;

    public DepartmentsRepo(TicketsSystemContext context) : base(context)
    {
        _context = context;
    }

    public Department? GetByIdWithTickets(int id)
    {
        return _context.Departments
            .Include(d => d.Tickets)
                .ThenInclude(t => t.Developers)
            .FirstOrDefault(d=> d.Id == id);
    }

    public List<Department> GetDepartmentsByName(string name)
    {
        return _context.Departments
            .Where(d => d.Name == name)
            .ToList();
    }
}
