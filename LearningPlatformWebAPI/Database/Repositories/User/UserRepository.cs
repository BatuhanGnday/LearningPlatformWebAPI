namespace LearningPlatformWebAPI.Database.Repositories.User
{
    public class UserRepository : Repository<Models.User>, IUserRepository
    {
        public UserRepository(AppContext appContext) : base(appContext)
        {
        }
    }
}