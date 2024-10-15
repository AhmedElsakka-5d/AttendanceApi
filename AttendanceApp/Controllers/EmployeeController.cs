using AttendanceApp.Dtos;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService _service;

    public EmployeeController(EmployeeService service)
    {
        _service = service;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        var result = await _service.RegisterAsync(dto.Email, dto.Name, dto.Department);
        if (!result)
            return Conflict("Email is already registered.");
        return Ok("Registration successful.");
    }

    [HttpPost("AssignKey")]
    public async Task<IActionResult> AssignKey([FromBody] AssignKeyDto dto)
    {
        var result = await _service.AssignKeyAsync(dto.Email, dto.KeyAddress);
        if (!result)
            return NotFound("Employee not found.");
        return Ok("Key assigned.");
    }

    [HttpPost("Signin")]
    public async Task<IActionResult> Signin([FromBody] SigninDto dto)
    {
        var result = await _service.SignInAsync(dto.Email);
        return result ? Ok("Signed in.") : NotFound("Email not found.");
    }

    [HttpPost("Signout")]
    public async Task<IActionResult> Signout([FromBody] SignoutDto dto)
    {
        var result = await _service.SignOutAsync(dto.Email);
        return result ? Ok("Signed out.") : NotFound("Sign-in record not found.");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var result = await _service.LoginAsync(dto.Email, dto.KeyAddress);
        return result ? Ok("Login successful.") : Unauthorized("Invalid credentials.");
    }
}

