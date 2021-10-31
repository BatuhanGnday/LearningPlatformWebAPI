using System.Collections.Generic;
using NodaTime;

namespace LearningPlatformWebAPI.Models
{
    public class Exam : ModelBase
    {
        public Classroom Classroom { get; set; }
        public LocalDateTime Start { get; set; }
        public LocalDateTime End { get; set; }
        public User CreatedBy { get; set; }
        
        public virtual IEnumerable<Question> Questions { get; set; }
    }
}