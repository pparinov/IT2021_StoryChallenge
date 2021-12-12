using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Challenges
{
    public class UserRepository : IUserRepository
    {
        private ChallengesContext context;
        public UserRepository(ChallengesContext dbContext)
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

        public async Task<ICollection<User>> FindUsers(string searchString)
        {
            List<User> result = new List<User>(await context.Users.Where(u => u.Surname.Contains(searchString)).ToListAsync());

            result.AddRange(await context.Users.Where(u => u.UserName.Contains(searchString)).ToListAsync());

            return result;
        }

        public async Task<ICollection<User>> GetSubscribtions(Guid subscriberId)
        {
            return await context.Users.Where(u => u.UserSubscribtions.Contains(context.UsersSubscriptions.Where(us => (us.SubscribedOnId == u.Id) && (us.SubscriberId == subscriberId)).Single())).ToListAsync();
        }

        public async Task<ICollection<User>> GetSubscribers(Guid userId)
        {
            return await context.Users.Where(u => u.UserSubscribtions.Contains(context.UsersSubscriptions.Where(us => (us.SubscribedOnId == userId) && (us.SubscriberId == u.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<User>> GetChallengeAuthors(Guid challengeId)
        {
            return await context.Users.Where(u => u.Challenges.Contains(context.ChallengeUsers.Where(cu => (cu.ChallengeId == challengeId) && (cu.UserId == u.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<User>> GetChapterAuthors(Guid chapterId)
        {
            return await context.Users.Where(u => u.Chapters.Contains(context.ChapterUsers.Where(cu => (cu.ChapterId == chapterId) && (cu.UserId == u.Id)).Single())).ToListAsync();
        }

        public async Task<ICollection<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> GetByID(Guid id)
        {
            return await context.Users.Where(u => u.Id == id).SingleAsync();
        }

        public async Task<User> Insert(User entity)
        {
            context.Users.Add(entity);
            await Save();
            return entity;
        }

        public async Task<int> Delete(Guid id)
        {
            context.Users.Remove(context.Users.Where(u => u.Id == id).Single());
            return await Save();
        }

        public async Task<User> Update(User entity)
        {
            if (entity == null)
                return null;
            User exist = await context.Set<User>().FindAsync(entity.Id);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entity);
                await Save();
            }
            return exist;
        }
    }
}
