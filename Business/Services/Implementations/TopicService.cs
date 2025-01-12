using AutoMapper;
using Business.DTOs.Topic;
using Business.Services.Intefaces;
using Core.Entities;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class TopicService:ITopicService
    {
        readonly ITopicRepository _repo;
        readonly IMapper _mapper;

        public TopicService(IMapper mapper, ITopicRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        async Task<GetTopicDto> ITopicService.CreateAsync(GetTopicDto dto)
        {
            if (await _repo.IsExsist(x => x.Name == dto.Name))
            {
                throw new Exception();
            }
            var topic = _mapper.Map<Topic>(dto);
            var newTopic = await _repo.Create(topic);
            await _repo.SaveChangesAsync();
            return _mapper.Map<GetTopicDto>(newTopic);
        }

        public async Task<GetTopicDto> GetById(int id)
        {
            GetTopicDto dto = _mapper.Map<GetTopicDto>(await _repo.GetbyId(id));
            return dto;
        }

        List<GetTopicDto> ITopicService.GetAll()
        {
            List<GetTopicDto> dtos = new();
            var results = _repo.GetAll();
            foreach (var result in results)
            {
                GetTopicDto dto = _mapper.Map<GetTopicDto>(result);
                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task Update(UpdateTopicDto dto)
        {
            var oldTopic = await GetById(dto.Id);
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            oldTopic = _mapper.Map<GetTopicDto>(dto);
            _repo.Update(_mapper.Map<Topic>(oldTopic));
            await _repo.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var topic = await GetById(id);
            _repo.Delete(_mapper.Map<Topic>(topic));
            await _repo.SaveChangesAsync();
        }

        public async Task SoftDelete(int id)
        {
            var topic = await GetById(id);
            _repo.SoftDelete(_mapper.Map<Topic>(topic));
            await _repo.SaveChangesAsync();
        }
    }
}
