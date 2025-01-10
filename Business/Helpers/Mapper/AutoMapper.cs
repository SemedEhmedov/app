using AutoMapper;
using Business.DTOs.Assignment;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Assignment,CreateAsignmentDto>().ReverseMap();
            CreateMap<Assignment, UpdateAssignmentDto>().ReverseMap();
            CreateMap<Assignment, GetAssignmentDto>().ReverseMap();
        }
    }
}
