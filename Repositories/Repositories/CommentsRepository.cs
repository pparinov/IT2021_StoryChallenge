using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    class CommentsRepository : ICommentsRepository
    {
        private ChallengesContext context;
        public CommentsRepository(ChallengesContext dbContext)
        {
            context = dbContext;
        }

        public void Delete(Guid id)
        {
            context.Comments.Remove(context.Comments.Where(c => c.Id == id).Single());
            Save();
        }

        public IEnumerable<Comment> GetAll()
        {
            return context.Comments.ToList();
        }

        public Comment GetByID(Guid id)
        {
            return context.Comments.Where(c => c.Id == id).Single();
        }

        public IEnumerable<Comment> GetChapterComments(Guid chapterId)
        {
            return context.Comments.Where(c => c.Chapter.Id == chapterId).ToList();
        }

        public IEnumerable<Comment> GetUserComments(Guid userId)
        {
            return context.Comments.Where(c => c.User.Id == userId).ToList();
        }

        public void Insert(Comment entity)
        {
            context.Comments.Add(entity);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            context.Comments.Update(entity);
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
