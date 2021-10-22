using Microsoft.EntityFrameworkCore;
using System;

namespace Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            ChallengesContext db = new ChallengesContext();
            Console.WriteLine("Hello World!");
        }
    }
}
