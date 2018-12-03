using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using CSProfile.Models;
using Microsoft.AspNetCore.Authorization;

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
        }

		[HttpGet]
		[EnableCors("AllowAllHeaders")]
		public IEnumerable<Profile> GetAll()
		{
            return _context.ProfileItems;
		}

		[HttpGet("{id}", Name = "getProfile")]
		[EnableCors("AllowAllHeaders")]
		public async Task<IActionResult> GetById([FromRoute] long id)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var profile = await _context.ProfileItems.FindAsync(id);

            if(profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
		}

		[HttpPost, Authorize]
		[EnableCors("AllowAllHeaders")]
		public async Task<IActionResult> Create([FromBody] Profile item)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProfileItems.Add(item);
            await _context.SaveChangesAsync();
			return CreatedAtRoute("getProfile", new { id = item.Id }, item);
		}

		[HttpPut("{id}"), Authorize]
		[EnableCors("AllowAllHeaders")]
		public async Task<IActionResult> Update([FromRoute] long id, [FromBody] Profile item)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id!= item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;

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

		[HttpDelete("{id}"), Authorize]
		[EnableCors("AllowAllHeaders")]
		public async Task<IActionResult> Delete([FromRoute] long id)
		{
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var profile = await _context.ProfileItems.FindAsync(id);
            if(profile == null)
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