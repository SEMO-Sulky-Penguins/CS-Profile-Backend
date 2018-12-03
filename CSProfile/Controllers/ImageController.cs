using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;


namespace CSProfile.Controllers
{
	[Route("api/images")]
	[EnableCors("AllowAllHeaders")]
	[ApiController]
	public class ImageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		private readonly IHostingEnvironment _appEnvironment;
		public ImageController(IHostingEnvironment appEnvironment)
		{
			_appEnvironment = appEnvironment;
		}

		[HttpPut()]
		[EnableCors("AllowAllHeaders")]
		public async Task<IActionResult> UploadImage([FromRoute] long id, [FromBody] IFormFile file)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if (file == null || file.Length == 0)
			{
				return BadRequest();
			}

			try
			{
				string rootPath = _appEnvironment.WebRootPath;
				string imagePath = rootPath + "\\ProfileFiles\\Images\\" + file.FileName;

				using (var stream = new FileStream(imagePath, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}
				//await _context.SaveChangesAsync();
			}
			catch
			{
				return NoContent();
			}

			return NoContent();
		}

	}
}