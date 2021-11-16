using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    class SubscriptionRepository : ISubscriptionRepository
    {
        private ChallengesContext context;
        public SubscriptionRepository(ChallengesContext dbContext)
        {
            context = dbContext;
        }
        public void AddChallengeSubscription(ChallengeSubscription entity)
        {
            context.ChallengeSubscriptions.Add(entity);
            Save();

        }

        public void AddTagSubscription(TagSubscription entity)
        {
            context.TagSubscriptions.Add(entity);
            Save();
        }

        public void AddUserSubscription(UserSubscription entity)
        {
            context.UsersSubscriptions.Add(entity);
            Save();
        }

        public void RemoveChallengeSubscription(Guid subscriberId, Guid challengeId)
        {
            context.ChallengeSubscriptions.Remove(context.ChallengeSubscriptions.Where(cs => (cs.UserId == subscriberId) && (cs.ChallengeId == challengeId)).Single());
            Save();
        }

        public void RemoveTagSubscription(Guid subscriberId, Guid tagId)
        {
            context.TagSubscriptions.Remove(context.TagSubscriptions.Where(ts => (ts.UserId == subscriberId) && (ts.TagId == tagId)).Single());
            Save();
        }

        public void RemoveUserSubscription(Guid subscriberId, Guid subscribedOnId)
        {
            context.UsersSubscriptions.Remove(context.UsersSubscriptions.Where(us => (us.SubscriberId == subscriberId) && (us.SubscribedOnId == subscribedOnId)).Single());
            Save();
        }

        void Save()
        {
            context.SaveChanges();
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
    }
}
