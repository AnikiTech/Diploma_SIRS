using Microsoft.AspNetCore.Mvc;
using SIRS.RMT.ApplicationServices.Services.ColorsExercise;

namespace SIRS.RMT.Web.Controllers.ColorsExercise
{
    [ApiController]
    [Route("api/bo/colors")]
    public sealed class ColorsController : ControllerBase
    {
        private readonly ColorsService service;

        public ColorsController(ColorsService service)
        {
            this.service = service;
        }

        [HttpGet("available")]
        public IActionResult Get()
        {
            return new JsonResult(service.GetAvailableColors());
        }
    }
}