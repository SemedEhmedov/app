using AutoMapper;
using Business.DTOs.Account;
using Business.DTOs.Assignment;
using Business.DTOs.Employee;
using Business.DTOs.Topic;
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
            CreateMap<RegisterDto, AppUser>().ReverseMap();

            CreateMap<Assignment,CreateAsignmentDto>().ReverseMap();
            CreateMap<Assignment, UpdateAssignmentDto>().ReverseMap();
            CreateMap<Assignment, GetAssignmentDto>().ReverseMap();

            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, GetEmployeeDto>().ReverseMap();

            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagDto>().ReverseMap();
            CreateMap<Tag, GetTagDto>().ReverseMap();

            CreateMap<Topic, CreateTopicDto>().ReverseMap();
            CreateMap<Topic, UpdateTopicDto>().ReverseMap();
            CreateMap<Topic, GetTopicDto>().ReverseMap();
        }
    }
}
