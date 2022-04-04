using AutoMapper;
using Malaka.Data.IRepositories;
using Malaka.Domain.Commons;
using Malaka.Domain.Configurations;
using Malaka.Domain.Entities.Instructors;
using Malaka.Domain.Enums;
using Malaka.Service.DTOs.Instructors;
using Malaka.Service.Extensions;
using Malaka.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malaka.Service.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration config;

        public InstructorService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }

        public async Task<BaseResponse<Instructor>> CreateAsync(InstructorForCreationDto instructorDto)
        {
            var response = new BaseResponse<Instructor>();

            var mappedInstructor = mapper.Map<Instructor>(instructorDto);

            var result = await unitOfWork.Instructors.CreateAsync(mappedInstructor);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Instructor, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist Instructor
            var existInstructor = await unitOfWork.Instructors.GetAsync(expression);
            if (existInstructor is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existInstructor.Delete();

            var result = await unitOfWork.Instructors.UpdateAsync(existInstructor);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Instructor>>> GetAllAsync(PaginationParams @params, Expression<Func<Instructor, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<Instructor>>();

            var Instructors = await unitOfWork.Instructors.GetAllAsync(expression);

            response.Data = Instructors.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Instructor>> GetAsync(Expression<Func<Instructor, bool>> expression)
        {
            var response = new BaseResponse<Instructor>();

            var Instructor = await unitOfWork.Instructors.GetAsync(expression);
            if (Instructor is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = Instructor;

            return response;
        }

        public async Task<string> SaveFileAsync(Stream file, string fileName)
        {
            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;
            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream mainFile = File.Create(filePath);
            await file.CopyToAsync(mainFile);
            mainFile.Close();

            return fileName;
        }

        public async Task<BaseResponse<Instructor>> UpdateAsync(Guid id, InstructorForCreationDto InstructorDto)
        {
            var response = new BaseResponse<Instructor>();

            // check for exist Instructor
            var Instructor = await unitOfWork.Instructors.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (Instructor is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            Instructor.FirstName = InstructorDto.FirstName;
            Instructor.LastName = InstructorDto.LastName;
            Instructor.Update();

            var result = await unitOfWork.Instructors.UpdateAsync(Instructor);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
