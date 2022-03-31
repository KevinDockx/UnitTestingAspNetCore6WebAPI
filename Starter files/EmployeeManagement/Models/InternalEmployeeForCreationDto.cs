using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class InternalEmployeeForCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;           
    }
}
