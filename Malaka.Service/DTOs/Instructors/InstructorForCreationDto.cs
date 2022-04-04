using System.ComponentModel.DataAnnotations;

namespace Malaka.Service.DTOs.Instructors
{
    public class InstructorForCreationDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
