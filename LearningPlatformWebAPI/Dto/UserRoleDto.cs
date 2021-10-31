using LearningPlatformWebAPI.Database.Models;

namespace LearningPlatformWebAPI.Dto
{
    public class UserRoleDto
    {
        public string Name { get; set; }
        public RolePermission[] Permissions { get; set; }
    }
}