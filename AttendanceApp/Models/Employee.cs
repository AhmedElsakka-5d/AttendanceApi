using System.ComponentModel.DataAnnotations;

namespace AttendanceApp.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public string KeyAddress { get; set; }
        public bool Blocked { get; set; }
        public int ManagerId { get; set; }

    }
}
