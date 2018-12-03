using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CSProfile.Models
{
	public class Seed
	{

		public static void Initialize(IServiceProvider serviceProvider)
		{
			const string imagePath = "../wwwroot/ProfileFiles/Images/anon.jpg";

			using (var context = new ProfileContext(
				serviceProvider.GetRequiredService<DbContextOptions<ProfileContext>>()))
			{
				//if there are profile items in the db
				if (context.ProfileItems.Any())
				{
					//then it is seeded
					return;
				}
				else
				{
					context.ProfileItems.AddRange(
						new Profile
						{
							ImgPath = imagePath,
							Name = "Stephen Sladek",
							Major = "Information Systems",
							Location = "Gordonville, MO",
							CollegeStatus = "Senior",
							Languages = "C, C++, C#, Java, JavaScript",
							Interests = "Virtual Reality, Biometrics",
							Organizations = "ACM-SEMO, CS Club, SIGAI"
						},

						new Profile
						{
							ImgPath = imagePath,
							Name = "Anonymous",
							Major = "Cybersecurity",
							Location = "---",
							CollegeStatus = "Freshman",
							Languages = "---",
							Interests = "---",
							Organizations = "---"
						},

						new Profile
						{
							ImgPath = "../../assets/images/Derek_Mandl.jpg",
							Name = "Derek Mandl",
							Major = "Computer Science",
							Location = "Manchester, MO",
							CollegeStatus = "Senior",
							Languages = "C, C++, Java, Python",
							Interests = "Compilers, Image Processing",
							Organizations = "ACM-SEMO, Camera Arts Association"
						},
						new Profile
						{
							ImgPath = imagePath,
							Name = "Anonymous",
							Major = "Computer Science",
							Location = "---",
							CollegeStatus = "Junior",
							Languages = "Java,Python,SQL",
							Interests = "none",
							Organizations = "none"
						},
						new Profile
						{
							ImgPath = imagePath,
							Name = "Anonymous",
							Major = "---",
							Location = "---",
							CollegeStatus = "---",
							Languages = "---",
							Interests = "---",
							Organizations = "---"
						},
						new Profile
						{
							ImgPath = imagePath,
							Name = "Anonymous",
							Major = "---",
							Location = "---",
							CollegeStatus = "---",
							Languages = "---",
							Interests = "---",
							Organizations = "---"
						},
						new Profile
						{
							ImgPath = imagePath,
							Name = "Anonymous",
							Major = "---",
							Location = "---",
							CollegeStatus = "---",
							Languages = "---",
							Interests = "---",
							Organizations = "---"
						},
						new Profile
						{
							ImgPath = imagePath,
							Name = "Anonymous",
							Major = "---",
							Location = "---",
							CollegeStatus = "---",
							Languages = "---",
							Interests = "---",
							Organizations = "---"
						}
					);
					context.SaveChanges();
				}
			}
		} // end Initialize

	} // end class
}
