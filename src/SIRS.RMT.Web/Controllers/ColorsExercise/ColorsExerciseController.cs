using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIRS.RMT.ApplicationServices.DTO.Memory.ColorsExercise;
using SIRS.RMT.ApplicationServices.Services.ColorsExercise;
using SIRS.RMT.Domain.Memory.Colors;
using System;

namespace SIRS.RMT.Web.Controllers.ColorsExercise
{
    [ApiController]
    [Route("api/bo/exercises")]
    public sealed class ColorsExerciseController : ControllerBase
    {
        private readonly ColorsExerciseService exerciseService;
        private readonly ColorsService colorsService;

        public ColorsExerciseController(ColorsExerciseService exerciseService, ColorsService colorsService)
        {
            this.exerciseService = exerciseService;
            this.colorsService = colorsService;
        }


        [HttpGet("levels")]
        public IActionResult GetAvailableLevels()
        {
            return new JsonResult((int[])Enum.GetValues(typeof(ColorsSet)));
        }

        [HttpGet("training/{countColors:int}")]
        public IActionResult GetForTraining(int countColors)
        {
            if (!colorsService.IsValidColorsSet(countColors)) return StatusCode(StatusCodes.Status500InternalServerError, "The count colors is not predefined");
            var colorsSet = colorsService.GetColorsSetByAmount(countColors);

            return new JsonResult(exerciseService.Get(colorsSet, ColorsExerciseType.Training));
        }

        [HttpGet("diagnostic")]
        public IActionResult GetForDiagnostic()
        {
            return new JsonResult(exerciseService.Get(ColorsSet.VeryHard, ColorsExerciseType.Diagnostic));
        }

        // TODO maybe move to separate controller - StatisticController...
        [HttpPost("user-answer")]
        public IActionResult GetResult(ColorsUserAnswersDTO dto)
        {
            int CountValidAnswer = exerciseService.CountValidAnswers(dto);
            double percent = (double)CountValidAnswer / dto.UserColors.Length * 100;

            return new JsonResult(new ColorsExerciseResultDTO
            {
                CountValidAnswer = CountValidAnswer,
                CountInvalidAnswer = dto.UserColors.Length - CountValidAnswer,
                Mark = exerciseService.CalculateMark(percent),
                //UserName = exerciseService.GetUserLogin("F9821756-6A60-4092-9905-6A6A95956ED8"),
                Message = exerciseService.IsValidUserColors(dto).ToString()
            });
        }
    }
}