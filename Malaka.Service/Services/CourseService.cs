using AutoMapper;
using Malaka.Data.IRepositories;
using Malaka.Domain.Commons;
using Malaka.Domain.Configurations;
using Malaka.Domain.Entities.Courses;
using Malaka.Domain.Enums;
using Malaka.Service.DTOs.Courses;
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
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IWebHostEnvironment env;
        private readonly IConfiguration config;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env, IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }

        public async Task<BaseResponse<Course>> CreateAsync(CourseForCreationDto CourseDto)
        {
            var response = new BaseResponse<Course>();

            var mappedCourse = mapper.Map<Course>(CourseDto);

            var result = await unitOfWork.Courses.CreateAsync(mappedCourse);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Course, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist Course
            var existCourse = await unitOfWork.Courses.GetAsync(expression);
            if (existCourse is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existCourse.Delete();

            var result = await unitOfWork.Courses.UpdateAsync(existCourse);

            await unitOfWork.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Course>>> GetAllAsync(PaginationParams @params, Expression<Func<Course, bool>> expression = null)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var response = new BaseResponse<IEnumerable<Course>>();

            var Courses = await unitOfWork.Courses.GetAllAsync(expression);

            response.Data = Courses.ToPagedList(@params);

            return response;
        }

        public async Task<BaseResponse<Course>> GetAsync(Expression<Func<Course, bool>> expression)
        {
            var response = new BaseResponse<Course>();

            var Course = await unitOfWork.Courses.GetAsync(expression);
            if (Course is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = Course;

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

        public async Task<BaseResponse<Course>> UpdateAsync(Guid id, CourseForCreationDto CourseDto)
        {
            var response = new BaseResponse<Course>();

            // check for exist Course
            var Course = await unitOfWork.Courses.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (Course is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            Course.Name = CourseDto.Name;
            Course.Price = CourseDto.Price;
            Course.Duration = CourseDto.Duration;

            Course.Update();

            var result = await unitOfWork.Courses.UpdateAsync(Course);

            await unitOfWork.SaveChangesAsync();

            response.Data = result;

            return response;
        }

    }
}
