namespace LearningPlatformWebAPI.Database.Repositories.UserRole
{
    public class UserRoleRepository : Repository<Models.UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(AppContext appContext) : base(appContext)
        {
        }
    }
}