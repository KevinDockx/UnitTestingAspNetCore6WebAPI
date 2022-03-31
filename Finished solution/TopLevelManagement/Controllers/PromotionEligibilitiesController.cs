using Microsoft.AspNetCore.Mvc;

namespace TopLevelManagement.Controllers
{
    [ApiController]
    [Route("api/promotioneligibilities")]
    public class PromotionEligibilitiesController : ControllerBase
    { 
        [HttpGet("{employeeId}")]
        public IActionResult EmployeeIsEligibleForPromotion(Guid employeeId)
        {
            // For demo purposes, Megan (id = 72f2f5fe-e50c-4966-8420-d50258aefdcb)
            // is eligible for promotion, other employees aren't
            if (employeeId == Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"))
            {
                return Ok(new { EligibleForPromotion = true });
            }

            return Ok(new { EligibleForPromotion = false });
        }
    }
}