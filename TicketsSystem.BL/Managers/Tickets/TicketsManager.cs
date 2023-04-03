using TicketsSystem.BL.Dots;
using TicketsSystem.DAL;

namespace TicketsSystem.BL;

public class TicketsManager : ITicketsManager
{
    private readonly IUnitOfWork _unitOfWork;

    public TicketsManager(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<TicketReadDto> GetALl()
    {
        List<Ticket> ticketsFromDb = _unitOfWork.TicketsRepo.GetAll();

        return ticketsFromDb
            .Select(d => new TicketReadDto
            {
                Id = d.Id,
                Description = d.Description,
                Severity = d.Severity,
                EstimationCost = d.EstimationCost,
                DepartmentId = d.DepartmentId

            })
            .ToList();
    }
    public void Add(TicketAddDto ticketDto)
    {
        var ticket = new Ticket
        {
            Description = ticketDto.Description,
            Severity = ticketDto.Severity,
            EstimationCost = ticketDto.EstimationCost

        };

        _unitOfWork.TicketsRepo.Add(ticket);
        _unitOfWork.TicketsRepo.SaveChanges();
    }


}
