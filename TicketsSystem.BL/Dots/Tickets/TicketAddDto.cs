﻿using TicketsSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsSystem.BL.Dots;

public class TicketAddDto
{
    public string Description { get; set; } = string.Empty;
    public Severity? Severity { get; set; }
    public decimal EstimationCost { get; set; }

}
