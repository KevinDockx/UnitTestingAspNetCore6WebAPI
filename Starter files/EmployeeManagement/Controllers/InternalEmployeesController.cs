using AutoMapper;
using EmployeeManagement.Business;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/internalemployees")]
    [ApiController]
    public class InternalEmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public InternalEmployeesController(IEmployeeService employeeService, 
            IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InternalEmployeeDto>>> GetInternalEmployees()
        {
            var internalEmployees = await _employeeService.FetchInternalEmployeesAsync();

            // with manual mapping
            var internalEmployeeDtos =
                internalEmployees.Select(e => new InternalEmployeeDto()
                {
                    Id = e.Id,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Salary = e.Salary,
                    SuggestedBonus = e.SuggestedBonus,
                    YearsInService = e.YearsInService
                });

            // with AutoMapper
            //var internalEmployeeDtos =
            //    _mapper.Map<IEnumerable<InternalEmployeeDto>>(internalEmployees);

            return Ok(internalEmployeeDtos);
        }

        [HttpGet("{employeeId}", Name = "GetInternalEmployee")]
        public async Task<ActionResult<InternalEmployeeDto>> GetInternalEmployee(
            Guid? employeeId)
        {
            if (!employeeId.HasValue)
            { 
                return NotFound(); 
            }

            var internalEmployee = await _employeeService.FetchInternalEmployeeAsync(employeeId.Value);
            if (internalEmployee == null)
            { 
                return NotFound();
            }             

            return Ok(_mapper.Map<InternalEmployeeDto>(internalEmployee));
        }


        [HttpPost]
        public async Task<ActionResult<InternalEmployeeDto>> CreateInternalEmployee(
            InternalEmployeeForCreationDto internalEmployeeForCreation)
        { 
            // create an internal employee entity with default values filled out
            // and the values inputted via the POST request
            var internalEmployee =
                    await _employeeService.CreateInternalEmployeeAsync(
                        internalEmployeeForCreation.FirstName, internalEmployeeForCreation.LastName);

            // persist it
            await _employeeService.AddInternalEmployeeAsync(internalEmployee);
 
            // return created employee after mapping to a DTO
            return CreatedAtAction("GetInternalEmployee",
                _mapper.Map<InternalEmployeeDto>(internalEmployee),
                new { employeeId = internalEmployee.Id } );
        }
    }
}
