using Malaka.Domain.Commons;
using Malaka.Domain.Entities.Courses;
using Malaka.Domain.Enums;
using Malaka.ViewModels.Students;
using System;
using System.Collections.Generic;

namespace Malaka.Domain.Entities.Students
{
    public class Student : IAuditable
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public ItemState State { get; set; }
        public string Image { get; set; }

        public ICollection<Course> Courses { get; set; }
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

        public static explicit operator Student(StudentForCreationDto v)
        {
            return new Student()
            {
                FirstName = v.FirstName,
                LastName = v.LastName,
                Phone = v.Phone
            };
        }
    }
}
