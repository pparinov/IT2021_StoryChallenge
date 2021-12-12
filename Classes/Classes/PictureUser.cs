using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class PictureUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PictureId { get; set; }

        public virtual User User { get; set; }
        public virtual Picture Picture { get; set; }
        
    }
}
