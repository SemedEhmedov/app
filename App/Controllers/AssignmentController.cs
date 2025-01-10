using Business.DTOs.Assignment;
using Business.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        readonly IAssignmentService assignmentService;

        public AssignmentController(IAssignmentService assignmentService)
        {
            this.assignmentService = assignmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(assignmentService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await assignmentService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateAsignmentDto dto)
        {
            return Ok(await assignmentService.CreateAsync(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateAssignmentDto dto)
        {
            await assignmentService.Update(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await assignmentService.Delete(id);
            return NoContent();
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await assignmentService.SoftDelete(id);
            return NoContent();
        }
    }
}
