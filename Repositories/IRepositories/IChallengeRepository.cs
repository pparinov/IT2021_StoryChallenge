using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    interface IChallengeRepository : IGenericRepository<Challenge>
    {
        Task<ICollection<Challenge>> FindChallenges(string searchString);
        Task<ICollection<Challenge>> GetSubscribtions(Guid subscriberId); //челленджи на которые подписан пользователь
        Task<ICollection<Challenge>> GetChallenges(Guid userId); //челленджи в которых участвует/участвовал пользователь

    }
}
