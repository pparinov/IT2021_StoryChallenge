using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Challenges
{
    public class ChapterRepository : IChapterRepository
    {
        private ChallengesContext context;
        public ChapterRepository(ChallengesContext dbContext)
        {
            context = dbContext;
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
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

        public async Task<ICollection<Chapter>> GetChapters(Guid challengeId)
        {
            return await context.Chapters.Where(c => c.Challenge.ChallengeId == challengeId).ToListAsync();
        }

        public async Task<ICollection<Chapter>> GetAll()
        {
            return await context.Chapters.ToListAsync();
        }

        public async Task<Chapter> GetByID(Guid id)
        {
            return await context.Chapters.Where(c => c.Id == id).SingleAsync();
        }

        public async Task<Chapter> Insert(Chapter entity)
        {
            context.Chapters.Add(entity);
            await Save();
            return entity;
        }

        public async Task<int> Delete(Guid id)
        {
            context.Chapters.Remove(context.Chapters.Where(c => c.Id == id).Single());
            return await Save();
            
        }

        public async Task<Chapter> Update(Chapter entity)
        {
            if (entity == null)
                return null;
            Chapter exist = await context.Set<Chapter>().FindAsync(entity.Id);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entity);
                await Save();
            }
            return exist;
        }
    }
}
