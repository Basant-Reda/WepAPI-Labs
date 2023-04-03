﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Identity.BL;
using Identity.BL.DTOs;
using Identity.DAL;
using System.Security.Claims;

namespace Identity.APIs.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IEmployeesManager _employeesManager;

    public UsersController(IEmployeesManager employeesManager)
    {
        _employeesManager = employeesManager;
    }

    #region Register

    [HttpPost]
    [Route("User-Register")]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        var result = await _employeesManager.RegisterEmployee(registerDto, "User");

        if (result.Success)
        {
            return NoContent();
        }
        
        return BadRequest();
        
    }

    [HttpPost]
    [Route("Admin-Register")]
    public async Task<ActionResult> RegisterAdmin(RegisterDto registerDto)
    {
        var result = await _employeesManager.RegisterEmployee(registerDto, "Admin");

        if (result.Success)
        {
            var employee = result.Data;
            return NoContent();
        }

        return BadRequest();
        
    }


    #endregion

    #region Login
    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<TokenDto>> Login(LoginDto credentials)
    {
        var result = await _employeesManager.Login(credentials);
        if (!result.Success)
        {
            return BadRequest(new { Message = result.ErrorMessage });
        }

        return result.Data!;
    }
    #endregion

}
