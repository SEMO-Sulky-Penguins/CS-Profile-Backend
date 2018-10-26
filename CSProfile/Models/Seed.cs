using System;
using System.Collections.Generic;
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
            using (var context = new ProfileContext(
                serviceProvider.GetRequiredService<DbContextOptions<ProfileContext>>()))
            {
                //if there are profile items in the db
                if (context.ProfileItems.Any())
                {
                    //then it is seeded
                    return;
                }
                context.ProfileItems.AddRange(
                    new Profile
                    {
                        Id = 1,
                        ImgPath = "../../assets/images/anon.jpg",
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
                    Id = 2,
                    ImgPath = "../../assets/images/anon.jpg",
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
                    Id = 3,
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
                    Id = 4,
                    ImgPath = "../../assets/images/anon.jpg",
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
                    Id = 5,
                    ImgPath = "../../assets/images/anon.jpg",
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
                    Id = 6,
                    ImgPath = "../../assets/images/anon.jpg",
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
                    Id = 7,
                    ImgPath = "../../assets/images/anon.jpg",
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
                    Id = 8,
                    ImgPath = "../../assets/images/anon.jpg",
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
    }
}
