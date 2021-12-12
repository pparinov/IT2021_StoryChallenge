using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Challenges
{
    public class User : Microsoft.AspNetCore.Identity.IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        
        public virtual List<UserSubscription> UserSubscribtions { get; set; } // подписки на пользователей
        public virtual List<ChallengeSubscription> ChallengeSubscriptions { get; set; } //челледжи на которые подписан
        public virtual List<TagSubscription> TagSubscibtions { get; set; } //подписки на тэги
        public virtual List<ChallengeUser> Challenges { get; set; } //челледжи в которых участвует
        public virtual List<PictureUser> Pictures { get; set; } //его картинки
        public virtual List<Comment> Comments { get; set; } //комментарии
        public virtual List<ChapterUser> Chapters { get; set; } //главы



    }
}
