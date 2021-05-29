using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Output
{
    public class LikeDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string KnownAs { get; set; }
        public string PhotoUrl { get; set; }
        public string City { get; set; }
    }
}
