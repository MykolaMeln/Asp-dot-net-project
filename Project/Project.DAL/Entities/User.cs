using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
        public int Index { get; set; }
        public float Kredyt { get; set; }
    }
}
