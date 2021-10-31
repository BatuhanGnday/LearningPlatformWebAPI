using System.Collections.Generic;

namespace LearningPlatformWebAPI.Database.Models
{
    public class User : ModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<UserRole> Roles { get; set; }
        public IEnumerable<Classroom> Classrooms { get; set; }
    }
}