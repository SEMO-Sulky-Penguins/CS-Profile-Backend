using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;

namespace CSProfile.Models
{
	public class Seed
	{

		public static void Initialize(IServiceProvider serviceProvider)
		{
			//string imagePath = "../wwwroot/ProfileFiles/Images/anon.jpg";

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
							ImgPath = "../../assets/images/anon.jpg",
							Name = "Stephen Sladek",
							Major = "Information Systems",
							Location = "Gordonville, MO",
							CollegeStatus = "Senior",
							Languages = "C, C++, C#, Java, JavaScript",
							Interests = "Virtual Reality, Biometrics",
							Organizations = "ACM-SEMO, CS Club, SIGAI",
                            Email = "none"
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
							Organizations = "ACM-SEMO, Camera Arts Association",
                            Email="homeses@gmail.com"
						},
						new Profile
						{
							ImgPath = "../../assets/images/anon.jpg",
							Name = "Anonymous",
							Major = "Computer Science",
							Location = "---",
							CollegeStatus = "Junior",
							Languages = "Java,Python,SQL",
							Interests = "none",
							Organizations = "none",
                            Email = "none"
                        },
						new Profile
						{
							ImgPath = "../../assets/images/anon.jpg",
							Name = "Emily Cieslewicz",
							Major = "Computer Information Systems",
							Location = "Cape Girardeau, MO",
							CollegeStatus = "Senior",
							Languages = "Java, HTML, C++",
							Interests = "Anime",
							Organizations = "ACM-W, PHI",
                            Email = "emily.ciesleqicz@gmail.com"
                        },
						new Profile
						{
							ImgPath = "../../assets/images/anon.jpg",
							Name = "Jon Renn",
							Major = "Commercial Multimedia",
							Location = "Scott City",
							CollegeStatus = "Junior",
							Languages = "C++, C#, Python",
							Interests = "Video Games, Anime, Science Fiction, Japanese",
							Organizations = "ACM",
                            Email = "jon.renn@gmail.com"
                        },
						new Profile
						{
							ImgPath = "../../assets/images/anon.jpg",
							Name = "---",
							Major = "---",
							Location = "---",
							CollegeStatus = "---",
							Languages = "---",
							Interests = "---",
							Organizations = "---",
                            Email = "none"
                        }
					);
					context.SaveChanges();
				}
			}
		} // end Init

	} //end class
}
