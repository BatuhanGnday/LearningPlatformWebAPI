namespace LearningPlatformWebAPI.Database.Repositories.Course
{
    public class CourseRepository : Repository<Models.Course>, ICourseRepository
    {
        public CourseRepository(AppContext appContext) : base(appContext)
        {
        }
    }
}