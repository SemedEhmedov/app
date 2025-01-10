using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTOs.Assignment
{
    public class GetAssignmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int TopicId { get; set; }
        public List<AssignmentTag> assignmentTags { get; set; }
        public List<AssignmentEmployee> assignmentEmployees { get; set; }
    }
}
