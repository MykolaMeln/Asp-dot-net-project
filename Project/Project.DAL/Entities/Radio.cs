using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Entities
{
    public class Radio
    {
        public int RadioId { get; set; }
        public string Name { get; set; }
        public float Frequency { get; set; }
        public int Rating { get; set; }
    }
}
