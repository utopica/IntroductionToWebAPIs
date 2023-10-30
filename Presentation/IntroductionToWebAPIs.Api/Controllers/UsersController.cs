using IntroductionToWebAPIs.Api.Models;
using IntroductionToWebAPIs.Domain.Entities;
using IntroductionToWebAPIs.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToWebAPIs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IntroductionToWebAPIsDbContext _context;

        public UsersController()
        {
            _context = new();
        }

        [HttpGet]
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        [HttpPost]
        public void CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            User user = new()
            {
                FirstName = createUserRequest.FirstName,
                LastName = createUserRequest.LastName,
                Email = createUserRequest.Email,
                PhoneNumber = createUserRequest.PhoneNumber,
                CreatedOn = DateTime.UtcNow,
                CreatedByUserId = createUserRequest.FirstName,
                Id = Guid.NewGuid(), 

     
            };

            _context.Users.Add(user);

            _context.SaveChanges();
        }


    }
}
