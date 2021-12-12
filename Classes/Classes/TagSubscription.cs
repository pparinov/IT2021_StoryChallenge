using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class TagSubscription
    {
        public Guid Id { get; set; }
        public Guid TagId { get; set; }
        public Guid UserId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual User User { get; set; }
    }
}
