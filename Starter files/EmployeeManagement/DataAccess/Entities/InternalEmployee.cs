using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DataAccess.Entities
{
    public class InternalEmployee : Employee
    { 
        [Required]
        public int YearsInService { get; set; }

        [NotMapped]
        public decimal SuggestedBonus { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public bool MinimumRaiseGiven { get; set; }

        public List<Course> AttendedCourses { get; set; } = new List<Course>();

        [Required]
        public int JobLevel { get; set; }

        public InternalEmployee(
            string firstName,
            string lastName,
            int yearsInService,
            decimal salary,
            bool minimumRaiseGiven,
            int jobLevel)
            : base(firstName, lastName)
        {
            YearsInService = yearsInService;
            Salary = salary;
            MinimumRaiseGiven = minimumRaiseGiven;
            JobLevel = jobLevel;
        }

    }
}
