using System.Collections.Generic;

namespace LearningPlatformWebAPI.Models
{
    public class User : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<UserRole> Roles { get; set; }
        public virtual IEnumerable<Classroom> Classrooms { get; set; }
    }
}