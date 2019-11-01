using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Project.Models
{ 
    public class User : IdentityUser
    {
        public int Year { get; set; }
        public int Index { get; set; }
        public float Kredyt { get; set; }
    }
}
