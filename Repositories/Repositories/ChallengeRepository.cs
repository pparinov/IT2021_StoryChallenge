using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Challenges
{
    public class ChallengeRepository : IChallengeRepository
    {
        private ChallengesContext context;
        public ChallengeRepository(ChallengesContext dbContext)
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

        public async Task<ICollection<Challenge>> FindChallenges(string searchString)
        {
            return await context.Challenges.Where(c => c.Name.Contains(searchString)).ToListAsync();
        }

        public async Task<ICollection<Challenge>> GetSubscribtions(Guid subscriberId)
        {
            return await context.Challenges.Where(c => c.Subscribers.Contains(context.ChallengeSubscriptions.Where(cs => (cs.UserId == subscriberId) && (cs.ChallengeId == c.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<Challenge>> GetChallenges(Guid userId)
        {
            return await context.Challenges.Where(c => c.Challengers.Contains(context.ChallengeUsers.Where(cu => (cu.UserId == userId) && (cu.ChallengeId == c.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<Challenge>> GetAll()
        {
            return await context.Challenges.ToListAsync();
        }

        public async Task<Challenge> GetByID(Guid id)
        {
            return await context.Challenges.Where(c => c.Id == id).SingleAsync();
        }

        public async Task<Challenge> Insert(Challenge entity)
        {
            context.Challenges.Add(entity);
            await Save();
            return entity;
        }

        public async Task<int> Delete(Guid id)
        {
            context.Challenges.Remove(context.Challenges.Where(c => c.Id == id).Single());
            return await Save();
        }

        public async Task<Challenge> Update(Challenge entity)
        {
            if (entity == null)
                return null;
            Challenge exist = await context.Set<Challenge>().FindAsync(entity.Id);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entity);
                await Save();
            }
            return exist;
        }
    }
}
