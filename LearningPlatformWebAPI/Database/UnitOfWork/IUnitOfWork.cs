using System;
using LearningPlatformWebAPI.Database.Repositories.Course;

namespace LearningPlatformWebAPI.Database
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        int Complete();
    }
}