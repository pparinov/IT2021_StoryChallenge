using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class PictureChapter
    {
        public Guid Id { get; set; }
        public Guid ChapterId { get; set; }
        public Guid PictureId { get; set; }

        public virtual Chapter Chapter { get; set; }
        public virtual Picture Picture { get; set; }
        
    }
}
