namespace EmployeeManagement.Models
{
    public class InternalEmployeeDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public int YearsInService { get; set; }

        public decimal SuggestedBonus { get; set; }

        public decimal Salary { get; set; }

        public bool MinimumRaiseGiven { get; set; }

        public int JobLevel { get; set; }
    }
}
