using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NodaTime;

namespace LearningPlatformWebAPI.Database.Models
{
    public abstract class ModelBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }

        public LocalDateTime CreatedAt { get; set; }
        public LocalDateTime UpdatedAt { get; set; }

        public LocalDateTime? DeletedAt { get; set; }
    }
}