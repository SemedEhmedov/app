using Business.DTOs.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Intefaces
{
    public interface IAssignmentService
    {
        Task<GetAssignmentDto> CreateAsync(CreateAsignmentDto dto);
        Task<GetAssignmentDto> GetById(int id);
        List<GetAssignmentDto> GetAll();
        Task Update(UpdateAssignmentDto dto);
        Task Delete(int id);
        Task SoftDelete(int id);
    }
}
