using System;
using LearningPlatformWebAPI.Database.Repositories.Classroom;
using LearningPlatformWebAPI.Database.Repositories.Course;
using LearningPlatformWebAPI.Database.Repositories.Exam;
using LearningPlatformWebAPI.Database.Repositories.Question;
using LearningPlatformWebAPI.Database.Repositories.QuestionChoice;
using LearningPlatformWebAPI.Database.Repositories.User;
using LearningPlatformWebAPI.Database.Repositories.UserRole;

namespace LearningPlatformWebAPI.Database.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IClassroomRepository Classrooms { get; }
        ICourseRepository Courses { get; }
        IExamRepository Exams { get; }
        IQuestionRepository Questions { get; }
        IQuestionChoiceRepository QuestionChoices { get; }
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }
        int Complete();
    }
}