namespace TicketsSystem.DAL;

public class TicketsRepo : GenericRepo<Ticket> , ITicketsRepo
{
    private readonly TicketsSystemContext _context;

    public TicketsRepo(TicketsSystemContext context) : base(context)
    {
        _context = context;
    }

    public List<Ticket> GetTicketsByDepartmentId(int departmentId)
    {
        return _context.Tickets
            .Where(t=>t.DepartmentId== departmentId)
            .ToList();
            }
}
