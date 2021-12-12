using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Challenges
{
    public class PicturesRepository : IPucturesRepository
    {
        private ChallengesContext context;
        public PicturesRepository(ChallengesContext dbContext)
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

        public async Task<ICollection<Picture>> GetUserPictures(Guid userId)
        {
            return await context.Pictures.Where(p => p.PictureOwner == (context.UserPictures.Where(po => (po.UserId == userId) && (po.PictureId == p.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<Picture>> GetChallengePictures(Guid challengeId)
        {
            return await context.Pictures.Where(p => p.Challenges.Contains(context.ChallengePictures.Where(cp => (cp.ChallengeId == challengeId) && (cp.PictureId == p.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<Picture>> GetChapterPictures(Guid chapterId)
        {
            return await context.Pictures.Where(p => p.Chapters.Contains(context.ChapterPictures.Where(cp => (cp.ChapterId == chapterId) && (cp.PictureId == p.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<Picture>> GetAll()
        {
            return await context.Pictures.ToListAsync();
        }

        public async Task<Picture> GetByID(Guid id)
        {
            return await context.Pictures.Where(p => p.Id == id).SingleAsync();
        }

        public async Task<Picture> Insert(Picture entity)
        {
            context.Pictures.Add(entity);
            await Save();
            return entity;
        }

        public async Task<int> Delete(Guid id)
        {
            context.Pictures.Remove(context.Pictures.Where(p => p.Id == id).Single());
            return await Save();
        }

        public async Task<Picture> Update(Picture entity)
        {
            if (entity == null)
                return null;
            Picture exist = await context.Set<Picture>().FindAsync(entity.Id);
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
