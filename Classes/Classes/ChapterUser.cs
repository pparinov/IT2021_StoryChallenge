using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class ChapterUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ChapterId { get; set; }

        public virtual User User { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}
