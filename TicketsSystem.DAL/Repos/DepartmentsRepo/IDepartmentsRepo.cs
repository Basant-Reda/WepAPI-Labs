namespace TicketsSystem.DAL;

public interface IDepartmentsRepo : IGenericRepo<Department>
{
    List<Department> GetDepartmentsByName(string name);

    Department? GetByIdWithTickets(int id);
}
