namespace ITIProject.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Emp_Project>? Emp_Projects{ get; set; }
    }
}
