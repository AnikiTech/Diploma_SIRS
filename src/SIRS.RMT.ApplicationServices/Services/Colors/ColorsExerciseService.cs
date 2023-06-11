using Microsoft.Extensions.Logging;
using SIRS.RMT.ApplicationServices.DTO.Memory.ColorsExercise;
using SIRS.RMT.Domain.EntityFramework;
using SIRS.RMT.Domain.Memory.Colors;
using SIRS.RMT.Domain.Tools;
using System.Linq;

namespace SIRS.RMT.ApplicationServices.Services.ColorsExercise
{
    public class ColorsExerciseService
    {
        private readonly ReadingMemoryThinkingDbContext dbContext;
        private readonly ILogger<ColorsExerciseService> logger;

        public ColorsExerciseService(ReadingMemoryThinkingDbContext dbContext, ILogger<ColorsExerciseService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public ColorsExerciseDTO Get(ColorsSet set, ColorsExerciseType type)
        {
            var colors = dbContext.Set<ColorsDictionary>().Select(x => x.HexColor).ToArray();
            colors.Shuffle();

            switch (set)
            {
                case ColorsSet.VeryEasy:
                    System.Array.Resize(ref colors, (int)ColorsSet.VeryEasy);
                    break;
                case ColorsSet.Easy:
                    System.Array.Resize(ref colors, (int)ColorsSet.Easy);
                    break;
                case ColorsSet.Simple:
                    System.Array.Resize(ref colors, (int)ColorsSet.Simple);
                    break;
                case ColorsSet.Normal:
                    System.Array.Resize(ref colors, (int)ColorsSet.Normal);
                    break;
                case ColorsSet.Hard:
                    System.Array.Resize(ref colors, (int)ColorsSet.Hard);
                    break;
                case ColorsSet.VeryHard:
                    System.Array.Resize(ref colors, (int)ColorsSet.VeryHard);
                    break;
                default:
                    break;
            }

            return new ColorsExerciseDTO
            {
                Colors = colors,
                TimeRemembering = type == ColorsExerciseType.Training ? ExerciseTimeConstants.TRAINING_TIME_REMEMBERING : ExerciseTimeConstants.DIAGNOSTIC_TIME_REMEMBERING
            };
        }

        public bool IsValidUserColors(ColorsUserAnswersDTO dto)
        {
            return ArrayExtensions.CompareArrays(dto.UserColors, dto.Colors);
        }

        public int CalculateMark(double percent)
        {
            int mark = 1;
            if (percent >= 90)
            {
                mark = 5;
            }
            else if (percent >= 75)
            {
                mark = 4;
            }
            else if (percent >= 60)
            {
                mark = 3;
            }
            else if (percent >= 40)
            {
                mark = 2;
            }
            return mark;
        }

        public int CountValidAnswers(ColorsUserAnswersDTO dto)
        {
            string[] colors = dto.Colors;
            string[] user_colors = dto.UserColors;

            int CountValid = 0;

            if (dto.UserColors.Length < dto.Colors.Length)
            {
                System.Array.Resize(ref colors, dto.UserColors.Length);
            }

            if (dto.UserColors.Length > dto.Colors.Length)
            {
                System.Array.Resize(ref user_colors, dto.Colors.Length);
            }

            if (user_colors.Length == 0)
            {
                return CountValid;
            }

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == user_colors[i])
                {
                    CountValid++;
                }
            }

            logger.LogDebug("Total valid colors '{total}'", CountValid);

            return CountValid;
        }
    }
}