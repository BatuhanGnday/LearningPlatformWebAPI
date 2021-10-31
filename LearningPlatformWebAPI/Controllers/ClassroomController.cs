using System;
using System.Diagnostics;
using LearningPlatformWebAPI.Database.UnitOfWork;
using LearningPlatformWebAPI.Dto;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatformWebAPI.Controllers
{
    [ApiController]
    [Route("classrooms")]
    public class ClassroomController
    {
        private readonly UnitOfWork _unitOfWork;

        public ClassroomController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("{classroomGuid}/exam")]
        public ActionResult<ExamDto> AddExam([FromBody] ExamDto exam, Guid classroomGuid)
        {
            Debug.WriteLine(classroomGuid);
            return new ExamDto();
        }
    }
}