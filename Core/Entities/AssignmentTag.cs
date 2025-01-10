using Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class AssignmentTag:BaseEntity
    {
        public int AssignmentId { get; set; }
        [JsonIgnore]
        public Assignment Assignment { get; set; }
        public int TagId  { get; set; }
        public Tag Tag { get; set; }
    }
}
