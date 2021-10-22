using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual List<TagChallenge> Challenges { get; set; } //челленджи
        public virtual List<TagSubscription> Subscribers { get; set; } //подписчики



    }
}
