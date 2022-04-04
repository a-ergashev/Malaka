using System.ComponentModel.DataAnnotations;

namespace Malaka.ViewModels.Courses
{
    public class CourseForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public ushort Duration { get; set; }
    }
}
