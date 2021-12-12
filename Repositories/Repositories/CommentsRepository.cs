using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Challenges
{
    public class CommentsRepository : ICommentsRepository
    {
        private ChallengesContext context;
        public CommentsRepository(ChallengesContext dbContext)
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

        public async Task<ICollection<Comment>> GetChapterComments(Guid chapterId)
        {
            return await context.Comments.Where(c => c.Chapter.Id == chapterId).ToListAsync();
        }

        public async Task<ICollection<Comment>> GetUserComments(Guid userId)
        {
            return await context.Comments.Where(c => c.User.Id == userId).ToListAsync();
        }

        public async Task<ICollection<Comment>> GetAll()
        {
            return await context.Comments.ToListAsync();
        }

        public async Task<Comment> GetByID(Guid id)
        {
            return await context.Comments.Where(c => c.Id == id).SingleAsync();
        }

        public async Task<Comment> Insert(Comment entity)
        {
            context.Comments.Add(entity);
            await Save();
            return entity;
        }

        public async Task<int> Delete(Guid id)
        {
            context.Comments.Remove(context.Comments.Where(c => c.Id == id).Single());
            return await Save();
        }

        public async Task<Comment> Update(Comment entity)
        {
            if (entity == null)
                return null;
            Comment exist = await context.Set<Comment>().FindAsync(entity.Id);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entity);
                await Save();
            }
            return exist;
        }
    }
}
