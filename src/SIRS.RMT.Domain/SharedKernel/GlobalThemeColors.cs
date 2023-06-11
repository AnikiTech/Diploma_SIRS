using System.ComponentModel.DataAnnotations;

namespace SIRS.RMT.Domain.SharedKernel
{
    public enum GlobalThemeColors
    {
        [Display(Name = "Night theme", Description = "#000")]
        Night = 0,
        [Display(Name = "Light theme", Description = "#FFFFFF")]
        Light = 1
    }
}