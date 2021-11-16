using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    class StatusRepository : IStatusRepository
    {
        private ChallengesContext context;
        public StatusRepository(ChallengesContext dbContext)
        {
            context = dbContext;
        }

        public void Delete(Guid id)
        {
            context.Statuses.Remove(context.Statuses.Where(s => s.Id == id).Single());
            Save();
        }

        public IEnumerable<Status> GetAll()
        {
            return context.Statuses.ToList();
        }

        public Status GetByID(Guid id)
        {
            return context.Statuses.Where(s => s.Id == id).Single();
        }

        public Status GetStatus(Guid userId, Guid challengeId)
        {
            return context.Statuses.Where(s => s.ChallengeUsers.Contains(
                context.ChallengeUsers.Where(cu => (cu.ChallengeId == challengeId) && (cu.UserId == userId) && (cu.StatusId == s.Id)).Single())
            ).Single();
        }

        public void Insert(Status entity)
        {
            context.Statuses.Add(entity);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Status entity)
        {
            context.Statuses.Update(entity);
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
