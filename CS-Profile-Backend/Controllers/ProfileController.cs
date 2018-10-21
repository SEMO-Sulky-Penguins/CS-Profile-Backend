using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using CS_Profile_Backend.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS_Profile_Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowAllHeaders")]//CORS error No 'Access-Control-Allow-Origin' header
    [ApiController]
public class ProfileController : ControllerBase
{
    private readonly ProfileContext _context;

    public ProfileController(ProfileContext context)
    {
         _context = context;

            if (_context.ProfileItems.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.ProfileItems.Add(new ProfileItem {
                    id = 1,
                    img_path = "../../assets/images/anon.jpg",
                    name = "Stephen Sladek",
                    major = "Information Systems",
                    location = "Gordonville, MO",
                    college_status = "Senior",
                    languages =  "C, C++, C#, Java, JavaScript" ,
                    interests =  "Virtual Reality, Biometrics" ,
                    organizations =  "ACM-SEMO, CS Club, SIGAI" 
                });
                _context.ProfileItems.Add(new ProfileItem  {
                    id = 2,
                    img_path = "../../assets/images/anon.jpg",
                    name = "Anonymous",
                    major = "Cybersecurity",
                    location = "---",
                    college_status = "Freshman",
                    languages =  "---" , 
                    interests = "---", 
                    organizations =  "---" 
                 });
                _context.ProfileItems.Add(new ProfileItem {
                    id = 3,
                    img_path = "../../assets/images/Derek_Mandl.jpg", 
                    name = "Derek Mandl",
                    major = "Computer Science",
                    location = "Manchester, MO",
                    college_status = "Senior",
                    languages = "C, C++, Java, Python",
                    interests = "Compilers, Static Languages",
                    organizations = "ACM-SEMO, Camera Arts Association"
                });
                _context.ProfileItems.Add(new ProfileItem {
                    id = 4,
                    img_path = "../../assets/images/anon.jpg", 
                    name = "Anonymous",
                    major = "---",
                    location = "---",
                    college_status = "---",
                    languages = "---",
                    interests = "---",
                    organizations = "---"
                });
                _context.ProfileItems.Add(new ProfileItem {
                    id = 5,
                    img_path = "../../assets/images/anon.jpg", 
                    name = "Anonymous",
                    major = "---",
                    location = "---",
                    college_status = "---",
                    languages = "---",
                    interests = "---",
                    organizations = "---"
                });
                _context.ProfileItems.Add(new ProfileItem {
                    id = 6,
                    img_path = "../../assets/images/anon.jpg", 
                    name = "Anonymous",
                    major ="---",
                    location = "---",
                    college_status = "---",
                    languages = "---",
                    interests = "---",
                    organizations = "---"
                });
                _context.ProfileItems.Add(new ProfileItem {
                    id = 7,
                    img_path = "../../assets/images/anon.jpg",
                    name = "Anonymous",
                    major = "---",
                    location = "---",
                    college_status = "---",
                    languages =  "---" ,
                    interests =  "---" ,
                    organizations =  "---" 
                });
                _context.ProfileItems.Add(new ProfileItem {
                    id = 8,
                    img_path = "../../assets/images/anon.jpg", 
                    name = "Anonymous",
                    major = "---",
                    location = "---",
                    college_status = "---",
                    languages = "---",
                    interests = "---",
                    organizations = "---"
                });
                //_context.ProfileItems.Add(new ProfileItem { Id = 19, Name = "Magma" });
                //_context.ProfileItems.Add(new ProfileItem { Id = 20, Name = "Tornado" });

                _context.SaveChanges();
            }
    }

        // GET: api/<controller>
        [HttpGet]
        [EnableCors("AllowAllHeaders")]//CORS error No 'Access-Control-Allow-Origin' header
        public ActionResult<List<ProfileItem>> GetAll()
        {
            return _context.ProfileItems.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<ProfileItem> GetById(long id)
        {
            var item = _context.ProfileItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/<controller>
        [HttpPost]
    public void Post([FromBody]string value)
    {
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
}
