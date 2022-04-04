using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Malaka.Service.DTOs.Students
{
    public class StudentForCreationDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Phone { get; set; }

        public IFormFile Image { get; set; }
    }
}
