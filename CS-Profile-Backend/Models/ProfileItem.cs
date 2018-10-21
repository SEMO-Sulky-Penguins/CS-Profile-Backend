using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS_Profile_Backend.Models
{
    public class ProfileItem
    {
        public long id { get; set; }
        public string img_path { get; set; }
        public string name { get; set; }
        public string major { get; set; }
        public string location { get; set; }
        public string college_status { get; set; }
        public string languages { get; set; }
        public string interests { get; set; }
        public string organizations { get; set; }
    }
}
