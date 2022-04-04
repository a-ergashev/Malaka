using System.ComponentModel.DataAnnotations;

namespace Malaka.ViewModels.Instructors
{
    public class InstructorForCreationDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
