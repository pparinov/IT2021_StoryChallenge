using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            ChallengesContext db = new ChallengesContext();
            User user = new User { Name = "paul", Surname = "otc", UserName = "otc" , Id = Guid.NewGuid()};
            //Console.WriteLine(user.Id);
            using (UserRepository userRepository = new UserRepository(db))
            {
                
                var users = userRepository.FindUsers("otc");
                foreach (User u in users)
                { Console.WriteLine(u.Id + "  " + u.Name + "  " + u.UserName); }
            }


        }
    }
}
