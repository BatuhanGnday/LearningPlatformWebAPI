namespace LearningPlatformWebAPI.Dto
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRoleDto Roles { get; set; }
    }
}