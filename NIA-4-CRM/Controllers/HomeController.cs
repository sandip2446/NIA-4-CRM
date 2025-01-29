using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NIA_4_CRM.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NIA_4_CRM.Data;
using NIA_4_CRM.ViewModel;

namespace NIA_4_CRM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CrmContext _context;

        public HomeController(ILogger<HomeController> logger, CrmContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var dashboardViewModel = new DashboardVM
            {
                TotalMembers = _context.Members.Count(),
                ActiveMembers = _context.Members.Count(m => m.Status == Status.Active),
                ExpiredMembers = _context.Members.Count(m => m.Status == Status.Expired),
                RecentMembers = _context.Members
                    .Include(m => m.Organization)
                    .Include(m => m.MembershipType)
                    .Include(m => m.Contact)
                    .OrderByDescending(m => m.MembershipStartDate)
                    .Take(5)
                    .ToList(),
                MembershipTypeCounts = _context.MembershipTypes
                    .Select(mt => new MembershipTypeCount
                    {
                        MembershipTypeName = mt.MembershipName,
                        MemberCount = mt.Members.Count()
                    })
                    .ToList()
            };

            return View(dashboardViewModel);
        }

        public IActionResult ActiveMembers()
        {
            var activeMembers = _context.Members
                .Include(m => m.Organization)
                .Include(m => m.MembershipType)
                .Include(m => m.Contact)
                .Where(m => m.Status == Status.Active)
                .ToList();

            return PartialView("_ActiveMembers", activeMembers);
        }

        public IActionResult ExpiredMembers()
        {
            var expiredMembers = _context.Members
                .Include(m => m.Organization)
                .Include(m => m.MembershipType)
                .Include(m => m.Contact)
                .Where(m => m.Status == Status.Expired)
                .ToList();

           // return View(expiredMembers);
            return PartialView("_ExpiredMembers", expiredMembers);
        }

        public IActionResult TotalMembers()
        {
            var totalMembers = _context.Members
                .Include(m => m.Organization)
                .Include(m => m.MembershipType)
                .Include(m => m.Contact)
                .ToList();

           // return View(totalMembers);
            return PartialView("_TotalMembers", totalMembers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MemberDetails(int id)
        {
            var member = _context.Members
                .Include(m => m.Organization)
                .Include(m => m.MembershipType)
                .Include(m => m.Contact)
                .FirstOrDefault(m => m.Id == id);

            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}