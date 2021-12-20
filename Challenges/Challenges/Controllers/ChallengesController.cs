using Challenges.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;




namespace Challenges
{
    public class ChallengesController : Controller
    {
        private readonly ChallengesContext _context;

        public ChallengesController(ChallengesContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> IndexAsync( int page = 1)
        {
            using (ChallengeRepository challengesRep = new ChallengeRepository(_context))
            {
                int pageSize = 3; // количество объектов на страницу
                IEnumerable<Challenge> challenges = await challengesRep.GetAll();
                PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = challenges.Count() };
                IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Challenges = challenges.Skip((page - 1) * pageSize).Take(pageSize)};
                return View(ivm);
            }
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
    }
}
