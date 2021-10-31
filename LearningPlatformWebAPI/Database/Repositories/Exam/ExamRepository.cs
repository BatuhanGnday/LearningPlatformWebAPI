namespace LearningPlatformWebAPI.Database.Repositories.Exam
{
    public class ExamRepository : Repository<Models.Exam>, IExamRepository
    {
        public ExamRepository(AppContext appContext) : base(appContext)
        {
        }
    }
}