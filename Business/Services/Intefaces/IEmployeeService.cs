using Business.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Intefaces
{
    public interface IEmployeeService
    {
        Task<GetEmployeeDto> CreateAsync(CreateEmployeeDto dto);
        Task<GetEmployeeDto> GetById(int id);
        List<GetEmployeeDto> GetAll();
        Task Update(UpdateEmployeeDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
    }
}
