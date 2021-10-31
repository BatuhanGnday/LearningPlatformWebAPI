using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LearningPlatformWebAPI.Models
{
    public class Classroom : ModelBase
    {
        [Required]
        public string Name { get; set; }
        public int? Capacity { get; set; }
        
        public virtual IEnumerable<User> Participants { get; set; }
        public virtual IEnumerable<Course> Courses { get; set; }
    }
}