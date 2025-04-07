namespace Project2.Models.Users
{
    public class HRManager:Employee
    {
        public virtual ICollection<Employee> AddedEmployees { get; set; }
        public HRManager()
        {
                
        }
    }
}
