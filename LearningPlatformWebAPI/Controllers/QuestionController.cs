using LearningPlatformWebAPI.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatformWebAPI.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionController
    {
        private readonly UnitOfWork _unitOfWork;

        public QuestionController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}