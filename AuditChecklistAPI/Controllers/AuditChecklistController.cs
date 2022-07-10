using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuditChecklistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditChecklistController : ControllerBase
    {
        private static List<AuditChecklist> InternalQues = new List<AuditChecklist>()
        {
            new AuditChecklist
            {
                Id = 1,Question = "Have all Change requests followed SDLC before PROD move?"
            },
            new AuditChecklist{
                Id = 2,Question = "Have all Change requests been approved by the application owner?"
            },
            new AuditChecklist{
                Id = 3, Question = "Are all artifacts like CR document, Unit test cases available?"
            },
            new AuditChecklist{
                Id = 4, Question = "Is the SIT and UAT sign-off available?"
            },
            new AuditChecklist{
                Id = 5, Question = "Is data deletion from the system done with application owner approval?"
            }
        };
        private static List<AuditChecklist> ExternalQues = new List<AuditChecklist>()
        {
            new AuditChecklist
            {
                Id = 1,Question = "Have all Change requests followed SDLC before PROD move?"
            },
            new AuditChecklist{
                Id = 2,Question = "Have all Change requests been approved by the application owner?"
            },
            new AuditChecklist{
                Id = 3, Question = "For a major change, was there a database backup taken before and after PROD move?"
            },
            new AuditChecklist{
                Id = 4, Question = "Has the application owner approval obtained while adding a user to the system?"
            },
            new AuditChecklist{
                Id = 5, Question = "Is data deletion from the system done with application owner approval?"
            }
        };
        [HttpGet]
        public async Task<ActionResult<List<AuditChecklist>>> Get(string AuditType)
        {
            if (AuditType == "Internal")
            {
                return Ok(InternalQues);
            }
            else if (AuditType == "External")
            {
                return Ok(ExternalQues);
            }
            else { 
                return BadRequest("Not Valid Audit Type"); 
            }
        }
    }

}
