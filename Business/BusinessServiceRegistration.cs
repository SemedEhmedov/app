using Business.Services.Implementations;
using Business.Services.Intefaces;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class BusinessServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BusinessServiceRegistration));
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITopicService, TopicService>();
        }
    }
}
