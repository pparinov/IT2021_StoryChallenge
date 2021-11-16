using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    interface ISubscriptionRepository : IDisposable
    {
        void AddUserSubscription(UserSubscription entity);
        void AddTagSubscription(TagSubscription entity);
        void AddChallengeSubscription(ChallengeSubscription entity);
        void RemoveUserSubscription(Guid subscriberId, Guid subscribedOnId);
        void RemoveTagSubscription(Guid subscriberId, Guid tagId);
        void RemoveChallengeSubscription(Guid subscriberId, Guid challengeId);
    }
}
