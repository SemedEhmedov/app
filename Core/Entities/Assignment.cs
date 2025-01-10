using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Assignment : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public List<AssignmentTag> assignmentTags { get; set; }
        public List<AssignmentEmployee> assignmentEmployees { get; set; }
    }
}
