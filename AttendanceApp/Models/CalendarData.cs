using System.ComponentModel.DataAnnotations;

namespace AttendanceApp.Models
{
    public class CalendarData
    {

        [Key]
        public int Id { get; set; }
        public string TheDay { get; set; }

        public DateTime Dt { get; set; }
        public bool WorkingDay { get; set; }
    }
}
