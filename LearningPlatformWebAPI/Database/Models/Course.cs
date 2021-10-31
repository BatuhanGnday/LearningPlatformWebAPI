using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LearningPlatformWebAPI.Attributes;
using Newtonsoft.Json;
using NodaTime;

namespace LearningPlatformWebAPI.Models
{
    public class Course : ModelBase
    {
        [Required]
        public string Title { get; set; }
        
        public string MeetingUrl { get; set; }
        
        public Classroom Classroom { get; set; }
        
        [Required]
        public LocalTime StartTime { get; set; }

        [DataType(DataType.Time),Required]
        public LocalTime? EndTime { get; set; }

        [EnumDataType(typeof(IsoDayOfWeek))]
        public IsoDayOfWeek DayOfWeek { get; set; }
        
        public LocalDate? ValidAfter { get; set; }
        
        public LocalDate? ValidUntil { get; set; }
        
        public int Duration { get; set; }
    }
}