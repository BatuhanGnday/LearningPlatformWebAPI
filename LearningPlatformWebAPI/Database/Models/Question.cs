using System.Collections.Generic;

namespace LearningPlatformWebAPI.Database.Models
{
    public class Question : ModelBase
    {
        public string Description { get; set; }
        public int? Grade { get; set; }
        public bool Status { get; set; }

        public virtual IEnumerable<QuestionChoice> Options { get; set; }
    }
}