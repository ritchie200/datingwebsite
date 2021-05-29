using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class UserLike
    {
        public AppUser SourceUser { get; set; }
        public int SourceUserId { get; set; }

        public AppUser LikedUser { get; set; }
        public int LikedUserId { get; set; }
    }
}
