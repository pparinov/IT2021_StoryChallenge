using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    class ChallengeRepository : IChallengeRepository
    {
        private ChallengesContext context;
        public ChallengeRepository(ChallengesContext dbContext)
        {
            context = dbContext;
        }

        public void Delete(Guid id)
        {
            context.Challenges.Remove(context.Challenges.Where(c => c.Id == id).Single());
            Save();
        }

        public IEnumerable<Challenge> FindChallenges(string searchString)
        {
            return context.Challenges.Where(c => c.Name.Contains(searchString)).ToList();
        }

        public IEnumerable<Challenge> GetAll()
        {
            return context.Challenges.ToList();
        }

        public Challenge GetByID(Guid id)
        {
            return context.Challenges.Where(c => c.Id == id).Single();
        }

        public IEnumerable<Challenge> GetChallenges(Guid userId)
        {
            return context.Challenges.Where(c => c.Challengers.Contains(context.ChallengeUsers.Where(cu => (cu.UserId == userId) && (cu.ChallengeId == c.Id)).Single())).ToList();
        }

        public IEnumerable<Challenge> GetSubscribtions(Guid subscriberId)
        {
            return context.Challenges.Where(c => c.Subscribers.Contains(context.ChallengeSubscriptions.Where(cs => (cs.UserId == subscriberId) && (cs.ChallengeId == c.Id)).Single())).ToList();
        }

        public void Insert(Challenge entity)
        {
            context.Challenges.Add(entity);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Challenge entity)
        {
            context.Challenges.Update(entity);
            Save();
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
