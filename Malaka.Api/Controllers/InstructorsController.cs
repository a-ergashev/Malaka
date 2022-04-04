using Malaka.Domain.Commons;
using Malaka.Domain.Configurations;
using Malaka.Domain.Entities.Instructors;
using Malaka.Domain.Enums;
using Malaka.Service.DTOs.Instructors;
using Malaka.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Malaka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService InstructorService;
        private readonly IWebHostEnvironment env;
        public InstructorsController(IInstructorService InstructorService, IWebHostEnvironment env)
        {
            this.InstructorService = InstructorService;
            this.env = env;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Instructor>>> Create(InstructorForCreationDto InstructorDto)
        {
            var result = await InstructorService.CreateAsync(InstructorDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Instructor>>>> GetAll([FromQuery] PaginationParams @params)
        {
            var result = await InstructorService.GetAllAsync(@params);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Instructor>>> Get([FromRoute] Guid id)
        {
            var result = await InstructorService.GetAsync(p => p.Id == id);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Instructor>>> Update(Guid id, InstructorForCreationDto InstructorDto)
        {
            var result = await InstructorService.UpdateAsync(id, InstructorDto);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(Guid id)
        {
            var result = await InstructorService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
