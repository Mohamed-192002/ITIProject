namespace ITIProject.Models
{
    public class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Employee> employees{ get; set; }
    }
}
