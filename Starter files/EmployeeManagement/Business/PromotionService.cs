using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.DataAccess.Services;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EmployeeManagement.Business
{
    public class PromotionService : IPromotionService
    {
        private readonly HttpClient _httpClient;
        private readonly IEmployeeManagementRepository _employeeManagementRepository;

        public PromotionService(
            HttpClient httpClient,
            IEmployeeManagementRepository employeeManagementRepository)
        {
            _httpClient = httpClient;
            _employeeManagementRepository = employeeManagementRepository;
        }

        /// <summary>
        /// Promote an internal employee if eligible for promotion
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<bool> PromoteInternalEmployeeAsync(InternalEmployee employee)
        {
            if (await CheckIfInternalEmployeeIsEligibleForPromotion(employee.Id))
            {
                employee.JobLevel++;
                await _employeeManagementRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calls into external API (containing a data source only
        /// the top level managers can manage) to check whether
        /// an internal employee is eligible for promotion
        /// </summary> 
        private async Task<bool> CheckIfInternalEmployeeIsEligibleForPromotion(
            Guid employeeId)
        {
            // call into API
            var apiRoot = "http://localhost:5057";

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"{apiRoot}/api/promotioneligibilities/{employeeId}");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            // deserialize content
            var content = await response.Content.ReadAsStringAsync();
            var promotionEligibility = JsonSerializer.Deserialize<PromotionEligibility>(content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            // return value
            return promotionEligibility == null ?
                false : promotionEligibility.EligibleForPromotion;
        }
    }
}