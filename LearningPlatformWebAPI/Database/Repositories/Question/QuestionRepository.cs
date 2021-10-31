namespace LearningPlatformWebAPI.Database.Repositories.Question
{
    public class QuestionRepository : Repository<Models.Question>, IQuestionRepository
    {
        public QuestionRepository(AppContext appContext) : base(appContext)
        {
        }
    }
}