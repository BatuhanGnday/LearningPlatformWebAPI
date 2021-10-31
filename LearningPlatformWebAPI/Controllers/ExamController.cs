using LearningPlatformWebAPI.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatformWebAPI.Controllers
{
    [Route("exams")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public ExamController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}