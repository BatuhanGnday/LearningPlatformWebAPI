namespace LearningPlatformWebAPI.Database.Repositories.Classroom
{
    public class ClassroomRepository : Repository<Models.Classroom>, IClassroomRepository
    {
        public ClassroomRepository(AppContext appContext) : base(appContext)
        {
        }
    }
}