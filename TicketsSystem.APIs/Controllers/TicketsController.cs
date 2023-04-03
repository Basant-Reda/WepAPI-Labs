using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsSystem.BL.Dots;
using TicketsSystem.BL;

namespace TicketsSystem.APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    private readonly ITicketsManager _ticketsManager;

    public TicketsController(ITicketsManager ticketsManager) 
    {
        _ticketsManager = ticketsManager;
    }

    [HttpGet]
    public ActionResult<List<TicketReadDto>> GetAll()
    {
        return _ticketsManager.GetALl();
    }

    [HttpPost]
    public ActionResult Add(TicketAddDto ticketDto)
    {
        _ticketsManager.Add(ticketDto);
        return NoContent();
    }
}
