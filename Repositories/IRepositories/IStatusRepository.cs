using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    interface IStatusRepository : IGenericRepository<Status>
    {
        Status GetStatus(Guid userId, Guid challengeId);
    }
}
