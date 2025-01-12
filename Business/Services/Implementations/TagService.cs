using AutoMapper;
using Business.DTOs.Employee;
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
    public class TagService : ITagService
    {
        readonly ITagRepository _repo;
        readonly IMapper _mapper;

        public TagService(IMapper mapper, ITagRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        async Task<GetTagDto> ITagService.CreateAsync(GetTagDto dto)
        {
            if (await _repo.IsExsist(x => x.Name == dto.Name))
            {
                throw new Exception();
            }
            var tag = _mapper.Map<Tag>(dto);
            var newTag = await _repo.Create(tag);
            await _repo.SaveChangesAsync();
            return _mapper.Map<GetTagDto>(newTag);
        }

        public async Task<GetTagDto> GetById(int id)
        {
            GetTagDto dto = _mapper.Map<GetTagDto>(await _repo.GetbyId(id));
            return dto;
        }

        List<GetTagDto> ITagService.GetAll()
        {
            List<GetTagDto> dtos = new();
            var results = _repo.GetAll();
            foreach (var result in results)
            {
                GetTagDto dto = _mapper.Map<GetTagDto>(result);
                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task Update(UpdateTagDto dto)
        {
            var oldTag = await GetById(dto.Id);
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            oldTag = _mapper.Map<GetTagDto>(dto);
            _repo.Update(_mapper.Map<Tag>(oldTag));
            await _repo.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var tag = await GetById(id);
            _repo.Delete(_mapper.Map<Tag>(tag));
            await _repo.SaveChangesAsync();
        }

        public async Task SoftDelete(int id)
        {
            var tag = await GetById(id);
            _repo.SoftDelete(_mapper.Map<Tag>(tag));
            await _repo.SaveChangesAsync();
        }
    }
}
