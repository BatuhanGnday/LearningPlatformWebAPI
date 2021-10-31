using System.Collections.Generic;
using System.Linq;
using LearningPlatformWebAPI.Database.Models;
using LearningPlatformWebAPI.Database.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatformWebAPI.Controllers
{

    [ApiController]
    [Route("users")]
    public class UserController
    {
        private readonly UnitOfWork _unitOfWork;

        public UserController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public ActionResult<User> SaveUser([FromBody] User user)
        {
            return new User();
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var dbcont = new AppContext();
            return dbcont.Users.ToList();
        }
    }
}