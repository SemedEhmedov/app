using AutoMapper;
using Business.DTOs.Assignment;
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
    public class AssignmentService : IAssignmentService
    {
        readonly IAssignmentRepository _repo;
        readonly IMapper _mapper;

        public AssignmentService(IMapper mapper, IAssignmentRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<GetAssignmentDto> CreateAsync(CreateAsignmentDto dto)
        {
            if (dto == null)
            {
               throw new ArgumentNullException(nameof(dto));
            }
            var assignment = _mapper.Map<Assignment>(dto);
            var newassignment = await _repo.Create(assignment);
            await _repo.SaveChangesAsync();
            return _mapper.Map<GetAssignmentDto>(newassignment);
        }

        public async Task Delete(int id)
        {
            var assignment = await GetById(id);
            _repo.Delete(_mapper.Map<Assignment>(assignment));
            await _repo.SaveChangesAsync();
        }

        public List<GetAssignmentDto> GetAll()
        {
            var Assignments = _repo.GetAll("Author", "AssignmentTag", "AssignmentTag.Tags", "AssignmentEmployee", "AssignmentEmployee.Employees");
            var returnAssignments = _mapper.Map<List<GetAssignmentDto>>(Assignments);
            return returnAssignments;
        }

        public async Task<GetAssignmentDto> GetById(int id)
        {
            GetAssignmentDto dto = _mapper.Map<GetAssignmentDto>(await _repo.GetbyId(id));
            return dto;
        }

        public async Task SoftDelete(int id)
        {
            var assignment = await GetById(id);
            _repo.SoftDelete(_mapper.Map<Assignment>(assignment));
            await _repo.SaveChangesAsync();
        }

        public async Task Update(UpdateAssignmentDto dto)
        {
            var oldAssignment = await GetById(dto.Id);
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            oldAssignment = _mapper.Map<GetAssignmentDto>(dto);
            _repo.Update(_mapper.Map<Assignment>(oldAssignment));
            await _repo.SaveChangesAsync();
        }
    }
}
