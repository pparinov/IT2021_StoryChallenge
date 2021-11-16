using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    interface IChallengeRepository : IGenericRepository<Challenge>
    {
        IEnumerable<Challenge> FindChallenges(string searchString);
        IEnumerable<Challenge> GetSubscribtions(Guid subscriberId); //челленджи на которые подписан пользователь
        IEnumerable<Challenge> GetChallenges(Guid userId); //челленджи в которых участвует/участвовал пользователь

    }
}
