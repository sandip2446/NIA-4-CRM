using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NIA_4_CRM.Data;
using NIA_4_CRM.Models;

namespace NIA_4_CRM.Controllers
{
    public class MemberController : Controller
    {
        private readonly CrmContext _context;

        public MemberController(CrmContext context)
        {
            _context = context;
        }

        // GET: Member
        public async Task<IActionResult> Index()
        {
            var crmContext = _context.Members.Include(m => m.Contact).Include(m => m.MembershipType).Include(m => m.Organization);
            return View(await crmContext.ToListAsync());
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.Contact)
                .Include(m => m.MembershipType)
                .Include(m => m.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "FullName");
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipTypes, "MembershipTypeId", "MembershipName");
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "OrgName");
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrganizationId,MembershipStartDate,Status,MembershipRenewDate,MembershipTypeId,ContactID")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "FullName", member.ContactID);
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipTypes, "MembershipTypeId", "MembershipName", member.MembershipTypeId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "OrgName", member.OrganizationId);
            return View(member);
        }

        // GET: Member/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "FullName", member.ContactID);
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipTypes, "MembershipTypeId", "MembershipName", member.MembershipTypeId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "OrgName", member.OrganizationId);
            return View(member);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrganizationId,MembershipStartDate,Status,MembershipRenewDate,MembershipTypeId,ContactID")] Member member)
        {
            if (id != member.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContactID"] = new SelectList(_context.Contacts, "ID", "FullName", member.ContactID);
            ViewData["MembershipTypeId"] = new SelectList(_context.MembershipTypes, "MembershipTypeId", "MembershipName", member.MembershipTypeId);
            ViewData["OrganizationId"] = new SelectList(_context.Organizations, "Id", "OrgName", member.OrganizationId);
            return View(member);
        }

        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .Include(m => m.Contact)
                .Include(m => m.MembershipType)
                .Include(m => m.Organization)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
}
