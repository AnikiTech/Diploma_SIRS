using System;

namespace SIRS.RMT.ApplicationServices.DTO.Memory.WordsExercise
{
    public sealed class ExerciseOrderWordsSetupDTO
    {
        public int AmountWords { get; set; }
        public bool IsRandomSequenceWords { get; set; }
        public TimeSpan TimeToRemember { get; set; }
    }
}