using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    class ChapterReposytory : IChapterRepository
    {
        private ChallengesContext context;
        public ChapterReposytory(ChallengesContext dbContext)
        {
            context = dbContext;
        }

        public void Delete(Guid id)
        {
            context.Chapters.Remove(context.Chapters.Where(c => c.Id == id).Single());
            Save();
        }

        public IEnumerable<Chapter> GetAll()
        {
            return context.Chapters.ToList();
        }

        public Chapter GetByID(Guid id)
        {
            return context.Chapters.Where(c => c.Id == id).Single();
        }

        public IEnumerable<Chapter> GetChapters(Guid challengeId)
        {
            return context.Chapters.Where(c => c.Challenge.ChallengeId == challengeId).ToList();
        }

        public void Insert(Chapter entity)
        {
            context.Chapters.Add(entity);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Chapter entity)
        {
            context.Chapters.Update(entity);
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
