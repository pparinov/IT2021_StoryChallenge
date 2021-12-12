using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class TagChallenge
    {
        public Guid Id { get; set; }
        public Guid TagId { get; set; }
        public Guid ChallengeId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Challenge Challenge { get; set; }
    }
}
