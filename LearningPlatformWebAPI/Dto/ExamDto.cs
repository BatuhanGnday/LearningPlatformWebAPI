using System;
using System.Collections.Generic;
using NodaTime;

namespace LearningPlatformWebAPI.Dto
{
    public class ExamDto
    {
        public LocalDateTime Start { get; set; }
        public LocalDateTime End { get; set; }
        public Guid CreatedByGuid { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }
    }
}