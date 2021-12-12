using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class ChallengeSubscription
    {
        public Guid Id { get; set; }
        public Guid ChallengeId { get; set; }
        public Guid UserId { get; set; }

        public virtual Challenge Challenge { get; set; }
        public virtual User User { get; set; }
    }
}
