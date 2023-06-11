using SIRS.RMT.ApplicationServices.DTO.Memory.ColorsExercise;
using SIRS.RMT.Domain.EntityFramework;
using SIRS.RMT.Domain.Memory.Colors;
using System;
using System.Linq;

namespace SIRS.RMT.ApplicationServices.Services.ColorsExercise
{
    public class ColorsService
    {
        private readonly ReadingMemoryThinkingDbContext dbContext;

        public ColorsService(ReadingMemoryThinkingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool IsValidColorsSet(int countColors)
        {
            return ((int[])Enum.GetValues(typeof(ColorsSet))).Any(x => x == countColors);
        }

        public ColorsSet GetColorsSetByAmount(int countColors)
        {
            return Enum.GetValues(typeof(ColorsSet)).Cast<ColorsSet>().First(x => (int)x == countColors);
        }

        public ColorsDTO GetAvailableColors()
        {
            return new ColorsDTO
            {
                Colors = dbContext.Set<ColorsDictionary>().Select(x => x.HexColor).ToArray()
            };
        }
    }
}