using DAL.Repositories.Implementations;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DALServiceRegistration
    {
        public static void AddDALServices(this IServiceCollection services)
        {
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITopicRepository, TopicRepository>();
        }
    }
}
