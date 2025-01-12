using Business.DTOs.Topic;
using Business.Services.Intefaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        readonly ITopicService topicService;

        public TopicController(ITopicService topicService)
        {
            this.topicService = topicService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(topicService.GetAll());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await topicService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] CreateTopicDto dto)
        {
            return Ok(await topicService.CreateAsync(dto));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateTopicDto dto)
        {
            await topicService.Update(dto);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await topicService.Delete(id);
            return NoContent();
        }
        [HttpDelete("SoftDelete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            await topicService.SoftDelete(id);
            return NoContent();
        }
    }
}
