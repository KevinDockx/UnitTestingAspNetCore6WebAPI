using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Business
{
    public interface IPromotionService
    {
        Task<bool> PromoteInternalEmployeeAsync(InternalEmployee employee);
    }
}