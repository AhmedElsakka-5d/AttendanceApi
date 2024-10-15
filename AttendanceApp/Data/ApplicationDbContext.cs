using AttendanceApp.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Attend> Attends { get; set; }
    public DbSet<CalendarData> CalendarDatas { get; set; }
}
