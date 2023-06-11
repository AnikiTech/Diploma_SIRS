using System.ComponentModel.DataAnnotations;

namespace SIRS.RMT.Domain.Memory.Colors
{
    public enum ColorsExerciseType
    {
        [Display(Name = "Диагностика")]
        Diagnostic = 0,

        [Display(Name = "Тренинг")]
        Training = 1
    }
}