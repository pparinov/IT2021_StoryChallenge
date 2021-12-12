using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    interface ISubscriptionRepository : IDisposable
    {
        Task<UserSubscription> AddUserSubscription(UserSubscription entity);
        Task<TagSubscription> AddTagSubscription(TagSubscription entity);
        Task<ChallengeSubscription> AddChallengeSubscription(ChallengeSubscription entity);
        Task<int> RemoveUserSubscription(Guid subscriberId, Guid subscribedOnId);
        Task<int> RemoveTagSubscription(Guid subscriberId, Guid tagId);
        Task<int> RemoveChallengeSubscription(Guid subscriberId, Guid challengeId);
    }
}
