using EmployeeManagement.Business.EventArguments;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Business
{
    public interface IEmployeeService
    {
        event EventHandler<EmployeeIsAbsentEventArgs>? EmployeeIsAbsent;
        Task AddInternalEmployeeAsync(InternalEmployee internalEmployee);
        Task AttendCourseAsync(InternalEmployee employee, Course attendedCourse);
        ExternalEmployee CreateExternalEmployee(string firstName, 
            string lastName, string company);
        InternalEmployee CreateInternalEmployee(string firstName, 
            string lastName);
        Task<InternalEmployee> CreateInternalEmployeeAsync(string firstName, 
            string lastName);
        InternalEmployee? FetchInternalEmployee(Guid employeeId);
        Task<InternalEmployee?> FetchInternalEmployeeAsync(Guid employeeId);
        Task<IEnumerable<InternalEmployee>> FetchInternalEmployeesAsync();
        Task GiveMinimumRaiseAsync(InternalEmployee employee);
        Task GiveRaiseAsync(InternalEmployee employee, int raise);
        void NotifyOfAbsence(Employee employee);
    }
}