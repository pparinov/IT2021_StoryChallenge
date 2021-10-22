using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class CommentUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
        
        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
        
    }
}
