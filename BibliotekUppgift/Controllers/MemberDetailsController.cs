using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotekUppgift.Data;
using LibraryDomain;
using BibliotekUppgift.Models;
using LibraryApplication.Interfaces;

namespace BibliotekUppgift.Controllers
{
    public class MemberDetailsController : Controller
    {
        private readonly BibliotekUppgiftContext _context;
        private readonly IMemberService memberService;

        public MemberDetailsController (BibliotekUppgiftContext context, IMemberService MemberService)
        {
            this.memberService = MemberService;
            _context = context;
        }

        // GET: MemberDetails
        public IActionResult Index()
        {
            //return View (await _context.MemberDetails.ToListAsync());

            var members = memberService.GetAllMembers();
            return View(members);
        }

        // GET: MemberDetails/Details/5
        public async Task <IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await _context.MemberDetails.FirstOrDefaultAsync (m => m.Id == id);

            if (memberDetails == null)
            {
                return NotFound();
            }

            return View (memberDetails);
        }

        // GET: MemberDetails/Create
        public IActionResult Create()
        {
            var vm = new MemberCreateVm();

            return View (vm);
        }

        // POST: MemberDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create (MemberCreateVm vm)
        {
            if (ModelState.IsValid)
            {
                var newmember = new MemberDetails();
                
                newmember.PNR = vm.PNR;
                newmember.Name = vm.Name;

                this.memberService.AddMember (newmember);
            }

            return RedirectToAction (nameof(Index));
        }

        // GET: MemberDetails/Edit/5
        public async Task <IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await _context.MemberDetails.FindAsync (id);

            if (memberDetails == null)
            {
                return NotFound();
            }

            return View (memberDetails);
        }
        
        // POST: MemberDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit (int id, MemberDetails memberDetails)
        {
            if (id != memberDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberDetails);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberDetailsExists(memberDetails.Id))
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

            return View (memberDetails);
        }

        // GET: MemberDetails/Delete/5
        public async Task <IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var memberDetails = await _context.MemberDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (memberDetails == null)
            {
                return NotFound();
            }

            return View(memberDetails);
        }

        // POST: MemberDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteConfirmed (int id)
        {
            var memberDetails = await _context.MemberDetails.FindAsync(id);
            _context.MemberDetails.Remove(memberDetails);
            await _context.SaveChangesAsync();

            return RedirectToAction (nameof(Index));
        }

        //public async Task <IActionResult> ShowAllLoans (int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var member = await _context.MemberDetails.Where()
        //}

        public bool MemberDetailsExists (int id)
        {
            return _context.MemberDetails.Any(e => e.Id == id);
        }
    }
}
