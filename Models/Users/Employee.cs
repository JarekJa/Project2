using Project2.Models.Enums;

namespace Project2.Models.Users
{
    public class Employee : User
    {
        public DateTime DateWorkStarted { get; set; }
        public decimal Salary { get; set; }
        public int LeaveQuantityTotal { get; set; } = 0;
        public int LeaveQuantityThisYear { get; set; } = 0;
        public int SickLeaveQuantity { get; set; } = 0;
        public int MaxNumberLeave { get; set; } = 20;
        public StatusEmployeeEnum StatusEmployee { get; set; }
        public string? AddedByHRManagerId { get; set; }
        public virtual HRManager? AddedByHRManager { get; set; }
        public string BossId { get; set; }
        public virtual Boss boss { get; set; }

        public Employee()
        {
        }
       
    }

}
