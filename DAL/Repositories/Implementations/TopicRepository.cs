using Core.Entities;
using DAL.Context;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementations
{
    public class TopicRepository : Repository<Topic>, ITopicRepository
    {
        public TopicRepository(AppDBContext context) : base(context)
        {
        }
    }
}
