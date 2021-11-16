using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Challenges
{
    class UserRepository : IUserRepository
    {
        private ChallengesContext context;
        public UserRepository(ChallengesContext dbContext)
        {
            context = dbContext;
        }

        public void Delete(Guid id)
        {
            context.Users.Remove(context.Users.Where(u => u.Id == id).Single());
            Save();
        }

        public IEnumerable<User> FindUsers(string searchString)
        {
            List<User> result = new List<User>(context.Users.Where(u => u.Surname.Contains(searchString)).ToList());
            
            result.AddRange(context.Users.Where(u => u.UserName.Contains(searchString)).ToList());
            
            return result;
            
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetByID(Guid id)
        {
            return context.Users.Where(u => u.Id == id).Single();
        }

        public IEnumerable<User> GetChallengeAuthors(Guid challengeId)
        {
            return context.Users.Where(u => u.Challenges.Contains(context.ChallengeUsers.Where(cu => (cu.ChallengeId == challengeId) && (cu.UserId == u.Id)).Single())).ToList();
        }

        public IEnumerable<User> GetChapterAuthors(Guid chapterId)
        {
            return context.Users.Where(u => u.Chapters.Contains(context.ChapterUsers.Where(cu => (cu.ChapterId == chapterId) && (cu.UserId == u.Id)).Single())).ToList();
        }

        public IEnumerable<User> GetSubscribers(Guid userId) //список подписчиков
        {
            return context.Users.Where(u => u.UserSubscribtions.Contains(context.UsersSubscriptions.Where(us => (us.SubscribedOnId == userId) && (us.SubscriberId == u.Id)).Single())).ToList();
        }

        public IEnumerable<User> GetSubscribtions(Guid subscriberId) //список подписок
        {
            return context.Users.Where(u => u.UserSubscribtions.Contains(context.UsersSubscriptions.Where(us => (us.SubscribedOnId == u.Id) && (us.SubscriberId == subscriberId)).Single())).ToList();
        }

        public void Insert(User entity)
        {
            context.Users.Add(entity);
            Save();
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(User entity)
        {
            context.Users.Update(entity);
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
