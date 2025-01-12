using Business.DTOs.Assignment;
using Business.DTOs.Employee;
using Business.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        readonly IEmployeeService employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(employeeService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await employeeService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateEmployeeDto dto)
        {
            return Ok(await employeeService.CreateAsync(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateEmployeeDto dto)
        {
            await employeeService.Update(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await employeeService.Delete(id);
            return NoContent();
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await employeeService.SoftDelete(id);
            return NoContent();
        }
    }
}
