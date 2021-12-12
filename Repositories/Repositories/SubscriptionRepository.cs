using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Challenges
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private ChallengesContext context;
        public SubscriptionRepository(ChallengesContext dbContext)
        {
            context = dbContext;
        }
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<UserSubscription> AddUserSubscription(UserSubscription entity)
        {
            context.UsersSubscriptions.Add(entity);
            await Save();
            return entity;
        }

        public async Task<TagSubscription> AddTagSubscription(TagSubscription entity)
        {
            context.TagSubscriptions.Add(entity);
            await Save();
            return entity;
        }

        public async Task<ChallengeSubscription> AddChallengeSubscription(ChallengeSubscription entity)
        {
            context.ChallengeSubscriptions.Add(entity);
            await Save();
            return entity;
        }

        public async Task<int> RemoveUserSubscription(Guid subscriberId, Guid subscribedOnId)
        {
            context.UsersSubscriptions.Remove(context.UsersSubscriptions.Where(us => (us.SubscriberId == subscriberId) && (us.SubscribedOnId == subscribedOnId)).Single());
            return await Save();
        }

        public async Task<int> RemoveTagSubscription(Guid subscriberId, Guid tagId)
        {
            context.TagSubscriptions.Remove(context.TagSubscriptions.Where(ts => (ts.UserId == subscriberId) && (ts.TagId == tagId)).Single());
            return await Save();
        }

        public async Task<int> RemoveChallengeSubscription(Guid subscriberId, Guid challengeId)
        {
            context.ChallengeSubscriptions.Remove(context.ChallengeSubscriptions.Where(cs => (cs.UserId == subscriberId) && (cs.ChallengeId == challengeId)).Single());
            return await Save();
        }
    }
}
