using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Challenges
{
    public class TagRepository : ITagRepository
    {
        private ChallengesContext context;

        public TagRepository(ChallengesContext dbcontext)
        {
            context = dbcontext;
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

        public async Task<ICollection<Tag>> FindTags(string searchString)
        {
            return await context.Tags.Where<Tag>(t => t.Name.Contains(searchString)).ToListAsync();
        }

        public async Task<ICollection<Tag>> GetSubscribtions(Guid userId)
        {
            return await context.Tags.Where(t => t.Subscribers.Contains(context.TagSubscriptions.Where(ts => (ts.UserId == userId) && (ts.TagId == t.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<Tag>> GetChallengeTags(Guid challengeId)
        {
            return await context.Tags.Where(t => t.Challenges.Contains(context.ChallengeTags.Where(ct => (ct.ChallengeId == challengeId) && (ct.TagId == t.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<Tag>> GetAll()
        {
            return await context.Tags.ToListAsync();
        }

        public async Task<Tag> GetByID(Guid id)
        {
            return await context.Tags.Where<Tag>(t => t.Id == id).SingleAsync();
        }

        public async Task<Tag> Insert(Tag entity)
        {
            context.Tags.Add(entity);
            await Save();
            return entity;
        }

        public async Task<int> Delete(Guid id)
        {
            context.Tags.Remove(context.Tags.Where(t => t.Id == id).Single());
            return await Save();

        }

        public async Task<Tag> Update(Tag entity)
        {
            if (entity == null)
                return null;
            Tag exist = await context.Set<Tag>().FindAsync(entity.Id);
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
