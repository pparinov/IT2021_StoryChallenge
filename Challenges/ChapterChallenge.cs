using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class ChapterChallenge
    {
        public Guid Id { get; set; }
        public Guid ChallengeId { get; set; }
        public Guid ChapterId { get; set; }

        public virtual Challenge Challenge { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}
