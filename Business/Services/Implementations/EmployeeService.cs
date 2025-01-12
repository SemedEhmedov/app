using AutoMapper;
using Business.DTOs.Assignment;
using Business.DTOs.Employee;
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
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository _repo;
        readonly IMapper _mapper;

        public EmployeeService(IMapper mapper, IEmployeeRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
       async Task<GetEmployeeDto> IEmployeeService.CreateAsync(CreateEmployeeDto dto)
        {
            if (await _repo.IsExsist(x => x.Name == dto.Name))
            {
                throw new Exception();
            }
            var employee = _mapper.Map<Employee>(dto);
            var newEmployee = await _repo.Create(employee);
            await _repo.SaveChangesAsync();
            return _mapper.Map<GetEmployeeDto>(newEmployee);
        }

        public async Task<GetEmployeeDto> GetById(int id)
        {
            GetEmployeeDto dto = _mapper.Map<GetEmployeeDto>(await _repo.GetbyId(id));
            return dto;
        }

        List<GetEmployeeDto> IEmployeeService.GetAll()
        {
            List<GetEmployeeDto> dtos = new();
            var results = _repo.GetAll();
            foreach (var result in results)
            {
                GetEmployeeDto dto = _mapper.Map<GetEmployeeDto>(result);
                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task Update(UpdateEmployeeDto dto)
        {
            var oldEmployee = await GetById(dto.Id);
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            oldEmployee = _mapper.Map<GetEmployeeDto>(dto);
            _repo.Update(_mapper.Map<Employee>(oldEmployee));
            await _repo.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employee = await GetById(id);
            _repo.Delete(_mapper.Map<Employee>(employee));
            await _repo.SaveChangesAsync();
        }

        public async Task SoftDelete(int id)
        {
            var employee = await GetById(id);
            _repo.SoftDelete(_mapper.Map<Employee>(employee));
            await _repo.SaveChangesAsync();
        }
    }
}
