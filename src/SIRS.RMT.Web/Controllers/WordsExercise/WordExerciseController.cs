using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIRS.RMT.ApplicationServices.DTO.Memory.WordsExercise;
using SIRS.RMT.ApplicationServices.Services.WordsExercise;
using SIRS.RMT.Domain.Memory.Word;
using System;
using System.Threading.Tasks;

namespace SIRS.RMT.Web.Controllers.WordsExercise
{
    [Route("api/bo/word")]
    [ApiController]
    public sealed class WordExerciseController : ControllerBase
    {
        private readonly WordExerciseService service;

        public WordExerciseController(WordExerciseService service)
        {
            this.service = service;
        }

        [HttpGet("{count:int}")]
        public IActionResult Get(int count)
        {
            if (count > ExerciseConstants.MAX_WORDS || count <= 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "The count word is not predefined");
            }

            return new JsonResult(service.GetWord(count));
        }

        [HttpGet("exercise-setup")]
        public IActionResult GetExerciseSetup()
        {
            return new JsonResult(service.GetExerciseSetup());
        }

        [HttpPost("for-exercise")]
        public async Task<IActionResult> GetWordsForExercise(ExerciseOrderWordsSetupDTO dto)
        {
            try
            {
                var words = await service.GetWordsForExerciseAsync(dto);
                return new JsonResult(words);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("sendAnswer")]
        public IActionResult UserAnswer(WordUserAnswerDTO dto)
        {
            // Так то должно работать.
            return new JsonResult(service.GetResult(dto));
        }
    }
}