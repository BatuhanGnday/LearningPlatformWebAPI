using System.Collections.Generic;
using LearningPlatformWebAPI.Database.Models;
using LearningPlatformWebAPI.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatformWebAPI.Controllers
{
    [ApiController]
    [Route("courses")]
    public class CourseController
    {
        private readonly UnitOfWork _unitOfWork;

        public CourseController()
        {
            _unitOfWork = new UnitOfWork(new AppContext());
        }

        [HttpPost]
        public ActionResult<Course> AddCourse([FromBody] Course course)
        {
            _unitOfWork.Courses.Add(course);
            _unitOfWork.Complete();
            
            return course;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> GetAllCourses()
        {
            return new ActionResult<IEnumerable<Course>>(_unitOfWork.Courses.GetAll());
        }
    }
}