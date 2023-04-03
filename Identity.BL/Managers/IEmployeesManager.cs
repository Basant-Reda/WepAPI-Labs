using Identity.BL.DTOs;
using Identity.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.BL;

public interface IEmployeesManager
{
     Task<OperationResult<Employee>> RegisterEmployee(RegisterDto registerDto, string role);
    string GenerateToken(IList<Claim> claimsList, DateTime exp);
    Task<OperationResult<TokenDto>> Login(LoginDto credentials);
}
