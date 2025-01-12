using Business.DTOs.Employee;
using Business.DTOs.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Intefaces
{
    public interface ITagService
    {
        Task<GetTagDto> CreateAsync(CreateTagDto dto);
        Task<GetTagDto> GetById(int id);
        List<GetTagDto> GetAll();
        Task Update(UpdateTagDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
        Task<GetEmployeeDto> CreateAsync(CreateEmployeeDto dto);
        Task<GetTagDto> CreateAsync(GetTagDto dto);
    }
}
