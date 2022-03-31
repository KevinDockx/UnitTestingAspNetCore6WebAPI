using AutoMapper;
using Microsoft.AspNetCore.Http.Features;

namespace EmployeeManagement.MapperProfiles
{
    public class StatisticsProfile : Profile
    {
        public StatisticsProfile()
        {
            CreateMap<IHttpConnectionFeature, Models.StatisticsDto>();
        }
    }
}
