using AutoMapper;
using LearningPlatformWebAPI.Database.Models;
using LearningPlatformWebAPI.Dto;
using LearningPlatformWebAPI.Dto.Classroom;

namespace LearningPlatformWebAPI.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Exam, ExamDto>();
            CreateMap<Question, QuestionDto>();
            CreateMap<UserRole, UserRoleDto>();
            CreateMap<Classroom, ClassroomDto>();
            CreateMap<CreateExamRequest, Exam>();
            
        }
    }
}