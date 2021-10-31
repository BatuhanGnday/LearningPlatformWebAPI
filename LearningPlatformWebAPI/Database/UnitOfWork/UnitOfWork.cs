using LearningPlatformWebAPI.Database.Repositories.Classroom;
using LearningPlatformWebAPI.Database.Repositories.Course;
using LearningPlatformWebAPI.Database.Repositories.Exam;
using LearningPlatformWebAPI.Database.Repositories.Question;
using LearningPlatformWebAPI.Database.Repositories.QuestionChoice;
using LearningPlatformWebAPI.Database.Repositories.User;
using LearningPlatformWebAPI.Database.Repositories.UserRole;

namespace LearningPlatformWebAPI.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppContext _appContext;

        public UnitOfWork(AppContext appContext)
        {
            _appContext = appContext;
            
            // Configure Repositories
            Classrooms = new ClassroomRepository(_appContext);
            Courses = new CourseRepository(_appContext);
            Exams = new ExamRepository(_appContext);
            Questions = new QuestionRepository(_appContext);
            QuestionChoices = new QuestionChoiceRepository(_appContext);
            Users = new UserRepository(_appContext);
            UserRoles = new UserRoleRepository(_appContext);
        }

        public IClassroomRepository Classrooms { get; }
        public ICourseRepository Courses { get; }
        public IExamRepository Exams { get; }
        public IQuestionRepository Questions { get; }
        public IQuestionChoiceRepository QuestionChoices { get; }
        public IUserRepository Users { get; }
        public IUserRoleRepository UserRoles { get; }


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