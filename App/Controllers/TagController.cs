using Business.DTOs.Employee;
using Business.DTOs.Topic;
using Business.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        readonly ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(tagService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await tagService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateTagDto dto)
        {
            return Ok(await tagService.CreateAsync(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateTagDto dto)
        {
            await tagService.Update(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await tagService.Delete(id);
            return NoContent();
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await tagService.SoftDelete(id);
            return NoContent();
        }
    }
}
