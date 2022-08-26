using System.ComponentModel.DataAnnotations;

namespace MaterialsAPI.Models
{
    public class Wire
    {
        [Required]
        [Range(0, double.MaxValue)]
        public double Diameter { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public double DuctLength { get; set; }
    }
}
