using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MaterialsAPI.Dtos
{
    public class InputDto
    {
        [Required]
        [Range(0, double.MaxValue)]
        public double DuctLength { get; set; }

        [Range(0, int.MaxValue)]
        [DefaultValue(0)]
        public int AddedLength { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [DefaultValue(1)]
        public int ProfileLength { get; set; }
    }
}
