using System.ComponentModel;

namespace LearningPlatformWebAPI.Models
{
    public class QuestionChoice : ModelBase
    {
        public string Content { get; set; }
        
        [DefaultValue(false)]
        public bool IsTrue { get; set; } 
    }
}