using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Challenges
{
    interface IStatusRepository : IGenericRepository<Status>
    {
        Task<Status> GetStatus(Guid userId, Guid challengeId);
    }
}
