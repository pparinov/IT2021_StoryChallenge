using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    class PicturesRepository : IPucturesRepository
    {
        private ChallengesContext context;
        public PicturesRepository(ChallengesContext dbContext)
        {
            context = dbContext;
        }

        public void Delete(Guid id)
        {
            context.Pictures.Remove(context.Pictures.Where(p => p.Id == id).Single());
            Save();
        }

        public IEnumerable<Picture> GetAll()
        {
            return context.Pictures.ToList();
        }

        public Picture GetByID(Guid id)
        {
            return context.Pictures.Where(p => p.Id == id).Single();
        }

        public IEnumerable<Picture> GetChallengePictures(Guid challengeId)
        {
            return context.Pictures.Where(p => p.Challenges.Contains(context.ChallengePictures.Where(cp => (cp.ChallengeId == challengeId) && (cp.PictureId == p.Id)).Single())).ToList();
        }

        public IEnumerable<Picture> GetChapterPictures(Guid chapterId)
        {
            return context.Pictures.Where(p => p.Chapters.Contains(context.ChapterPictures.Where(cp => (cp.ChapterId == chapterId) && (cp.PictureId == p.Id)).Single())).ToList();
        }

        public IEnumerable<Picture> GetUserPictures(Guid userId)
        {
            return context.Pictures.Where(p => p.PictureOwner == (context.UserPictures.Where(po => (po.UserId == userId) && (po.PictureId == p.Id)).Single())).ToList();
        }

        public void Insert(Picture entity)
        {
            context.Pictures.Add(entity);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Picture entity)
        {
            context.Pictures.Update(entity);
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
