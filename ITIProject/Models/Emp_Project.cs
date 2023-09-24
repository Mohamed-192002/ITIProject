using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIProject.Models
{
    [PrimaryKey("EMP_Id", "Project_Id")]
    public class Emp_Project
    {
        [ForeignKey("employees")]
        public int EMP_Id { get; set; }
        public Employee? employees { get; set; }
        [ForeignKey("Projects")]
        public int Project_Id { get; set; }
        public Project? Projects { get; set; }
        public double WorkingHours { get; set;}
    }
}
