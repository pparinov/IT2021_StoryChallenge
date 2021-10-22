using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class CommentChapter
    {
        public Guid Id { get; set; }
        public Guid CommentId { get; set; }
        public Guid ChapterId { get; set; }

        public virtual Comment Comment { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}
