using Microsoft.AspNetCore.Mvc;
using SIRS.RMT.ApplicationServices.Services.ColorsExercise;
using SIRS.RMT.Domain.Memory.Word.Statistics;
using System.Linq;
using System.Threading.Tasks;

namespace SIRS.RMT.Web.Controllers.ColorsExercise
{
    [ApiController]
    [Route("api/bo/statistics/words")]
    public sealed class WordStatisticController : ControllerBase
    {
        private readonly WordsStatisticService service;

        public WordStatisticController(WordsStatisticService service)
        {
            this.service = service;
        }

        [HttpGet("get-statistic")]
        public IQueryable<object> Get()
        {
            return service.Select();
        }

        [HttpPost("save-result")]
        public async Task<IActionResult> Save(StatisticWordsLog dto)
        {
            await service.Save(dto);
            return Ok();
        }
    }
}