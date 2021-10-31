using System.Collections.Generic;

namespace LearningPlatformWebAPI.Models
{
    public class UserRole : ModelBase
    {
        public string Name { get; set; }
        
        public virtual RolePermission[] Permissions { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}