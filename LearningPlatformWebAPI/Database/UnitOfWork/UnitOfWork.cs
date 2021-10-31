using LearningPlatformWebAPI.Database.Repositories.Course;
using LearningPlatformWebAPI.Models;

namespace LearningPlatformWebAPI.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _appContext;
        
        public ICourseRepository Courses { get; }

        public UnitOfWork(AppContext appContext)
        {
            _appContext = appContext;
            Courses = new CourseRepository(_appContext);
        }

        
        public void Dispose()
        {
            _appContext.Dispose();
        }


        public int Complete()
        {
            return _appContext.SaveChanges();
        }
    }
}