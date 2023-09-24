using System.ComponentModel.DataAnnotations.Schema;

namespace ITIProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public decimal Salary { get; set; }

        [ForeignKey(nameof(office))]
        public int Office_id { get; set; }
        public Office? office{ get; set; }

        public List<Emp_Project>? Emp_Projects { get; set; }
    }
}
