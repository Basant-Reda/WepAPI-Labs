﻿using TicketsSystem.BL.Dots;

namespace TicketsSystem.BL;

public interface IDepartmentsManager
{
    List<DepartmentReadDto> GetAll();
    int Add(DepartmentAddDto department);
    DepartmentWithTicketsReadDto? GetByIdWithTickets(int id);
    void Edit(int id, DepartmentsEditDto departmentDpo);

    void Delete(int id);

}
