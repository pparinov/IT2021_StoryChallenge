using System;
using System.Collections.Generic;
using System.Text;

namespace Challenges
{
    public class UserSubscription
    {
        public Guid Id { get; set; }        
        public Guid SubscriberId { get; set; } //тот чья подписка
        public Guid SubscribedOnId { get; set; } //на кого подписан

        public virtual User Subscriber { get; set; } //тот чья подписка
        

    }
}
