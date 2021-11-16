using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class Status
    {
        public Guid Id { get; set; }
        public string State { get; set; }

        public virtual List<ChallengeUser> ChallengeUsers { get; set; }
    }

    //отдельная таблица статусов
}
