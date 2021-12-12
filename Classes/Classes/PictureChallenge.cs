using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class PictureChallenge
    {
        public Guid Id { get; set; }
        public Guid ChallengeId { get; set; }
        public Guid PictureId { get; set; }

        public virtual Challenge Challenge { get; set; }
        public virtual Picture Picture { get; set; }
        
    }
}
