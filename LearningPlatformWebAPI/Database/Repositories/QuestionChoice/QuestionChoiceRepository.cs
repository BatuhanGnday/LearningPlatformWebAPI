namespace LearningPlatformWebAPI.Database.Repositories.QuestionChoice
{
    public class QuestionChoiceRepository : Repository<Models.QuestionChoice>, IQuestionChoiceRepository
    {
        public QuestionChoiceRepository(AppContext appContext) : base(appContext)
        {
        }
    }
}