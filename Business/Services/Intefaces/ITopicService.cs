using Business.DTOs.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Intefaces
{
    public interface ITopicService
    {
        Task<GetTopicDto> CreateAsync(CreateTopicDto dto);
        Task<GetTopicDto> GetById(int id);
        List<GetTopicDto> GetAll();
        Task Update(UpdateTopicDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<GetTopicDto> CreateAsync(GetTopicDto dto);
    }
}
