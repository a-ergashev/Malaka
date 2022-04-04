using Malaka.Domain.Commons;
using Malaka.Domain.Entities.Courses;
using Malaka.Domain.Enums;
using Malaka.ViewModels.Instructors;
using System;
using System.Collections.Generic;

namespace Malaka.Domain.Entities.Instructors
{
    public class Instructor : IAuditable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public void Update()
        {
            UpdatedAt = DateTime.Now;
            State = ItemState.Updated;
        }

        public void Create()
        {
            CreatedAt = DateTime.Now;
            State = ItemState.Created;
        }

        public void Delete()
        {
            State = ItemState.Deleted;
        }

        public static explicit operator Instructor(InstructorForCreationDto instructorDto)
        {
            return new Instructor()
            {
                FirstName = instructorDto.FirstName,
                LastName = instructorDto.LastName,
            };
        }
    }
}
