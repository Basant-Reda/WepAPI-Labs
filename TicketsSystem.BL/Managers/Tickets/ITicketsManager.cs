using TicketsSystem.BL.Dots;

namespace TicketsSystem.BL;

public interface ITicketsManager
{
    List<TicketReadDto> GetALl();
    void Add(TicketAddDto department);
}
