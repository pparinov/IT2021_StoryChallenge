using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Challenges
{
    public class StatusRepository : IStatusRepository
    {
        private ChallengesContext context;
        public StatusRepository(ChallengesContext dbContext)
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

        public async Task<Status> GetStatus(Guid userId, Guid challengeId)
        {
            return await context.Statuses.Where<Status>(s => s.ChallengeUsers.Contains(context.ChallengeUsers.Where(cu => (cu.ChallengeId == challengeId) && (cu.UserId == userId) && (cu.StatusId == s.Id)).Single())).SingleAsync();
        }

        public async Task<ICollection<Status>> GetAll()
        {
            return await context.Statuses.ToListAsync();
        }

        public async Task<Status> GetByID(Guid id)
        {
            return await context.Statuses.Where(s => s.Id == id).SingleAsync();
        }

        public async Task<Status> Insert(Status entity)
        {
            context.Statuses.Add(entity);
            await Save();
            return entity;
        }

        public async Task<int> Delete(Guid id)
        {
            context.Statuses.Remove(context.Statuses.Where(s => s.Id == id).Single());
            return await Save();
        }

        public async Task<Status> Update(Status entity)
        {
            if (entity == null)
                return null;
            Status exist = await context.Set<Status>().FindAsync(entity.Id);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entity);
                await Save();
            }
            return exist;
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }
    }
}
