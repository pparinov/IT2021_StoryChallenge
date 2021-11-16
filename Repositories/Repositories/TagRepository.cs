using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Challenges
{
    public class TagRepository : ITagRepository
    {
        private ChallengesContext context;
        public TagRepository(ChallengesContext dbContext)
        {
            context = dbContext;
        }

        public void Delete(Guid id)
        {
            context.Tags.Remove(context.Tags.Where(t => t.Id == id).Single());
            Save();
        }

        public IEnumerable<Tag> FindTags(string name)
        {
            return context.Tags.Where<Tag>(t => t.Name.Contains(name)).ToList();
        }

        public IEnumerable<Tag> GetAll()
        {
            return context.Tags.ToList();
        }

        public Tag GetByID(Guid id)
        {
            return context.Tags.Where<Tag>(t => t.Id == id).Single();
        }

        public IEnumerable<Tag> GetChallengeTags(Guid challengeId)
        {
            return context.Tags.Where(t=>t.Challenges.Contains(context.ChallengeTags.Where(ct => (ct.ChallengeId == challengeId) && (ct.TagId == t.Id)).Single())).ToList();
        }

        public IEnumerable<Tag> GetSubscribtions(Guid userId)
        {
            return context.Tags.Where(t => t.Subscribers.Contains(context.TagSubscriptions.Where(ts => (ts.UserId == userId) && (ts.TagId == t.Id)).Single())).ToList();
        }

        public void Insert(Tag entity)
        {
            context.Tags.Add(entity);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Tag entity)
        {
            context.Tags.Update(entity);
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
