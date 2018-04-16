using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Models
{
    public enum StatusTypes
    {
        Open,
        [Display(Name = "In Progress")]
        InProgress,
        Finished,
    }
}