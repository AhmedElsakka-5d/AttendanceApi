using AttendanceApp.Models;
using Microsoft.EntityFrameworkCore;

public class EmployeeService
{
    private readonly ApplicationDbContext _context;

    public EmployeeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> RegisterAsync(string email, string name, string department)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        if (employee != null)
            return false; // Already registered

        var newEmployee = new Employee
        {
            Name = name,
            Department = department,
            Email = email,
            Blocked = false
        };
        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AssignKeyAsync(string email, string keyAddress)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        if (employee == null)
            return false; // Employee not found

        if (string.IsNullOrEmpty(employee.KeyAddress))
        {
            employee.KeyAddress = keyAddress;
            employee.Blocked = false;
        }
        else
        {
            employee.Blocked = true;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SignInAsync(string email)
    {
        var attend = new Attend
        {
            Email = email,
            SignIn = DateTime.Now
        };
        _context.Attends.Add(attend);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SignOutAsync(string email)
    {
        var today = DateTime.Now.Date;
        var attend = await _context.Attends
            .FirstOrDefaultAsync(a => a.Email == email && a.SignIn.Date == today);

        if (attend == null)
            return false; // No signin record found

        attend.SignOut = DateTime.Now;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> LoginAsync(string email, string keyAddress)
    {
        var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
        if (employee == null || employee.KeyAddress != keyAddress)
        {
            if (employee != null)
                employee.Blocked = true;
            await _context.SaveChangesAsync();
            return false; // Login failed
        }
        return true;
    }
}
