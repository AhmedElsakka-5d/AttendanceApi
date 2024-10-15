using System.ComponentModel.DataAnnotations;

namespace AttendanceApp.Models
{
    public class Attend
    {
        [Key]
        public int Id { get; set; }
        public DateTime SignIn { get; set; }
        public DateTime SignOut { get; set; }
        public string Email { get; set; }
    }
}
