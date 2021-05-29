using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTOs.Input
{
    public class CreateMessageDto
    {
        public string RecipientUsername { get; set; }
        public string Content { get; set; }
    }
}
