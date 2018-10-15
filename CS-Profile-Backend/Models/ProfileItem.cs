using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS_Profile_Backend.Models
{
    public class ProfileItem
    {
        public long Id { get; set; }
        public string ImgPath { get; set; }
        public string Name { get; set; }
        public string Major { get; set; }
        public string Location { get; set; }
        public string CollegeStatus { get; set; }
        public string[] Languages { get; set; }
        public string[] Interests { get; set; }
        public string[] Organizations { get; set; }
    }
}
