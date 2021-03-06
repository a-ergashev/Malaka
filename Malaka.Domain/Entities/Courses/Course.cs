using Malaka.Domain.Commons;
using Malaka.Domain.Entities.Instructors;
using Malaka.Domain.Entities.Students;
using Malaka.Domain.Enums;
using Malaka.ViewModels.Courses;
using System;
using System.Collections.Generic;

namespace Malaka.Domain.Entities.Courses
{
    public class Course : IAuditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ushort Duration { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }

        public Instructor Instructor { get; set; }
        public ICollection<Student> Students { get; set; }

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

        public static explicit operator Course(CourseForCreationDto courseDto)
        {
            return new Course()
            {
                Name = courseDto.Name,
                Price = courseDto.Price,
                Duration = courseDto.Duration,
            };
        }
    }
}
