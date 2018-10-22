using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using CSProfile.Models;

namespace CSProfile.Controllers
{
    [Route("api/profiles")]
	[EnableCors("AllowAllHeaders")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfileContext _context;

        public ProfilesController(ProfileContext context)
        {
            _context = context;

			if(_context.ProfileItems.Count() == 0)
			{	
				_context.ProfileItems.Add(new Profile {
                    Id = 1,
                    ImgPath = "../../assets/images/anon.jpg",
                    Name = "Stephen Sladek",
                    Major = "Information Systems",
                    Location = "Gordonville, MO",
                    CollegeStatus = "Senior",
                    Languages =  "C, C++, C#, Java, JavaScript" ,
                    Interests =  "Virtual Reality, Biometrics" ,
                    Organizations =  "ACM-SEMO, CS Club, SIGAI" 
                });
                _context.ProfileItems.Add(new Profile  {
                    Id = 2,
                    ImgPath = "../../assets/images/anon.jpg",
                    Name = "Anonymous",
                    Major = "Cybersecurity",
                    Location = "---",
                    CollegeStatus = "Freshman",
                    Languages =  "---" , 
                    Interests = "---", 
                    Organizations =  "---" 
                 });
                _context.ProfileItems.Add(new Profile {
                    Id = 3,
                    ImgPath = "../../assets/images/Derek_Mandl.jpg", 
                    name = "Derek Mandl",
                    major = "Computer Science",
                    location = "Manchester, MO",
                    CollegeStatus = "Senior",
                    languages = "C, C++, Java, Python",
                    interests = "Compilers, Static Languages",
                    organizations = "ACM-SEMO, Camera Arts Association"
                });
				_context.ProfileItems.Add(new Profile {
					Id = 4,
					ImgPath = "../../assets/images/anon.jpg",
					Name = "Anonymous",
					Major = "Computer Science",
					Location = "---",
					CollegeStatus = "Junior",
					Languages = "Java,Python,SQL",
					Interests = "none",
					Organizations = "none"
				});
                _context.ProfileItems.Add(new Profile {
                    Id = 5,
                    ImgPath = "../../assets/images/anon.jpg", 
                    Name = "Anonymous",
                    Major = "---",
                    Location = "---",
                    CollegeStatus = "---",
                    Languages = "---",
                    Interests = "---",
                    Organizations = "---"
                });
                _context.ProfileItems.Add(new Profile {
                    Id = 6,
                    ImgPath = "../../assets/images/anon.jpg", 
                    Name = "Anonymous",
                    Major = "---",
                    Location = "---",
                    CollegeStatus = "---",
                    Languages = "---",
                    Interests = "---",
                    Organizations = "---"
                });
                _context.ProfileItems.Add(new Profile {
                    Id = 7,
                    ImgPath = "../../assets/images/anon.jpg", 
                    Name = "Anonymous",
                    Major = "---",
                    Location = "---",
                    CollegeStatus = "---",
                    Languages = "---",
                    Interests = "---",
                    Organizations = "---"
                });
                _context.ProfileItems.Add(new Profile {
                    Id = 8,
                    ImgPath = "../../assets/images/anon.jpg", 
                    Name = "Anonymous",
                    Major = "---",
                    Location = "---",
                    CollegeStatus = "---",
                    Languages = "---",
                    Interests = "---",
                    Organizations = "---"
                });
				
				_context.SaveChanges();
				
			}
        }

		[HttpGet]
		[EnableCors("AllowAllHeaders")]
		public ActionResult<List<Profile>> GetAll()
		{
			return _context.ProfileItems.ToList();
		}

		[HttpGet("{id}", Name = "getProfile")]
		[EnableCors("AllowAllHeaders")]
		public ActionResult<Profile> GetById(long id)
		{
			var item = _context.ProfileItems.Find(id);
			if(item == null)
			{
				return NotFound();
			}
			return item;
		}

		[HttpPost]
		[EnableCors("AllowAllHeaders")]
		public IActionResult Create(Profile item)
		{
			_context.ProfileItems.Add(item);
			_context.SaveChanges();
			return CreatedAtRoute("getProfile", new { id = item.Id }, item);
		}

		[HttpPut("{id}")]
		[EnableCors("AllowAllHeaders")]
		public IActionResult Update(long id, Profile item)
		{
			var profile = _context.ProfileItems.Find(id);

			if(profile == null)
			{
				return NotFound();
			}

			profile.ImgPath = item.ImgPath;
			profile.Name = item.Name;
			profile.Major = item.Major;
			profile.Location = item.Location;
			profile.CollegeStatus = item.CollegeStatus;
			profile.Languages = item.Languages;
			profile.Interests = item.Interests;
			profile.Organizations = item.Organizations;

			_context.ProfileItems.Update(profile);
			_context.SaveChanges();
			return NoContent();
		}

		[HttpDelete("{id}")]
		[EnableCors("AllowAllHeaders")]
		public IActionResult Delete(long id)
		{
			var profile = _context.ProfileItems.Find(id);
			if(profile == null)
			{
				return NotFound();
			}

			_context.ProfileItems.Remove(profile);
			_context.SaveChanges();
			return NoContent();
		}
		/*
		// GET: api/Profiles
		[HttpGet]
		[EnableCors("AllowAllHeaders")]
        public IEnumerable<Profile> GetProfileItems()
        {
            return _context.ProfileItems;
        }

        // GET: api/Profiles/5
        [HttpGet("{id}")]
		[EnableCors("AllowAllHeaders")]
		public async Task<IActionResult> GetProfile([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profile = await _context.ProfileItems.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return Ok(profile);
        }

        // PUT: api/Profiles/5
        [HttpPut("{id}")]
		[EnableCors("AllowAllHeaders")]
		public async Task<IActionResult> PutProfile([FromRoute] long id, [FromBody] Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profile.Id)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Profiles
        [HttpPost]
		[EnableCors("AllowAllHeaders")]
		public async Task<IActionResult> PostProfile([FromBody] Profile profile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProfileItems.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = profile.Id }, profile);
        }

        // DELETE: api/Profiles/5
        [HttpDelete("{id}")]
		[EnableCors("AllowAllHeaders")]
		public async Task<IActionResult> DeleteProfile([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profile = await _context.ProfileItems.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.ProfileItems.Remove(profile);
            await _context.SaveChangesAsync();

            return Ok(profile);
        }

        private bool ProfileExists(long id)
        {
            return _context.ProfileItems.Any(e => e.Id == id);
        }
		*/
    }
}