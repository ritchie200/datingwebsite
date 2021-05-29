using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Output
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}
