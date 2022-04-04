using Malaka.Domain.Commons;
using Malaka.Domain.Configurations;
using Malaka.Domain.Entities.Instructors;
using Malaka.Service.DTOs.Instructors;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malaka.Service.Interfaces
{
    public interface IInstructorService
    {
        Task<BaseResponse<Instructor>> CreateAsync(InstructorForCreationDto studentDto);
        Task<BaseResponse<Instructor>> GetAsync(Expression<Func<Instructor, bool>> expression);
        Task<BaseResponse<IEnumerable<Instructor>>> GetAllAsync(PaginationParams @params, Expression<Func<Instructor, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Instructor, bool>> expression);
        Task<BaseResponse<Instructor>> UpdateAsync(Guid id, InstructorForCreationDto studentDto);
    }
}
