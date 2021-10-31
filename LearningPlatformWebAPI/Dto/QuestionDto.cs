using System.Collections.Generic;

namespace LearningPlatformWebAPI.Dto
{
    public class QuestionDto
    {
        public string Description { get; set; }
        public int? Grade { get; set; }
        public bool Status { get; set; }
        public IEnumerable<QuestionChoiceDto> Options { get; set; }
    }
}