using Microsoft.AspNetCore.Mvc;
using SIRS.RMT.ApplicationServices.Services.ColorsExercise;
using SIRS.RMT.Domain.Memory.Colors.Statistics;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SIRS.RMT.Web.Controllers.WordsExercise
{
    [ApiController]
    [Route("api/bo/statistics/colors")]
    public sealed class ColorsStatisticController : ControllerBase
    {
        private readonly ColorsStatisticService service;

        public ColorsStatisticController(ColorsStatisticService service)
        {
            this.service = service;
        }

        [HttpGet("get-statistic")]
        public IQueryable<object> Get()
        {
            return service.Select();
        }

        [HttpPost("save-result")]
        public async Task<IActionResult> Save(StatisticColorLog dto)
        {
            dto.SetUser(service.GetUser("F9821756-6A60-4092-9905-6A6A95956ED8"));
            dto.Date = DateTime.Now;
            await service.Save(dto);
            return Ok();
        }
    }
}