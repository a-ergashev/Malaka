using Malaka.Domain.Commons;
using Malaka.Domain.Entities.Courses;
using Malaka.Domain.Enums;
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
    }
}
