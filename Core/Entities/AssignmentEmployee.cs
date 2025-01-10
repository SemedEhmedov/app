using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AssignmentEmployee : BaseEntity
    {
        public int AssignmentId { get; set; }
        [JsonIgnore]
        public Assignment Assignment { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
