using BibliotekUppgift.Models;
using LibraryApplication.Interfaces;
using LibraryDomain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotekUppgift.Controllers
{
    public class LoanDetailsController : Controller
    {
        private readonly ILoanService loanService;
        private readonly IBookkService bookkService;
        private readonly IMemberService memberService;
        private readonly ICopiesService copiesService;

        public LoanDetailsController (ILoanService LoanService, IBookkService bookkService, IMemberService memberService, ICopiesService copiesService)
        {
            this.loanService = LoanService;
            this.bookkService = bookkService;
            this.memberService = memberService;
            this.copiesService = copiesService;
        }

        // GET: LoanDetails
        public async Task<IActionResult> Index()
        {
            var vm = new LoanIndexVm();

            vm.loans = loanService.GetAllLoans();

            for (int j = 0; j < vm.loans.Count(); j++)
            {
                for (int i = 14; i <= loanService.LoanDays(vm.loans[j].LoanDate, vm.loans[j].ReturnDate); i++)
                {
                    vm.avgift += 12;
                }
            }

            return View(vm);
        }

        // GET: LoanDetails/Details/5
        //public async Task <IActionResult> Details (int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var loanDetails = await _context.Loans.FirstOrDefaultAsync (m => m.ID == id);

        //    if (loanDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View (loanDetails);
        //}

        // GET: LoanDetails/Create
        public IActionResult Create (string? message)
        {
            var vm = new LoanCreateVm();

            vm.ErrorMessage = message;

            vm.MemberList = new SelectList(memberService.GetAllMembers(), "Id", "Name");
            vm.BookList = new SelectList(bookkService.GetAllBooks(), "Id", "Title");

            //foreach (var item in vm.BookList)
            //{
            //    var bookId = int.Parse(item.Value);

            //    var nrOfCopies = copiesService.GetAllCopies(bookId).Count();

            //    item.Text += $"({nrOfCopies})";

            //    if (nrOfCopies == 0)
            //    {
            //        item.Disabled = true;
            //    }
            //}

            vm.LoanDate = DateTime.Now;

            return View (vm);
        }

        public ActionResult OutOfCopies()
        {
            TempData["alertMessage"] = "There are no more copies left of this book";

            return RedirectToAction("Create");
        }

        // POST: LoanDetails/Create
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create (LoanCreateVm vm)
        {
            if (ModelState.IsValid)
            {

                //foreach (var item in vm.BookList)
                //{
                //    var bookid = int.Parse(item.Value);
                //    var nrCopies = copiesService.GetAllCopies(bookid).Count();

                //    if(nrCopies == 0)
                //    {
                //        vm.ErrorMessage = "There are no more copies of this book";
                //        return RedirectToAction("Create");
                //    }
                //}

                //if (!bookkService.doesBookExist(vm.BookDetailsID))
                //{
                //    vm.ErrorMessage = "There is no book with that ID";
                //    return RedirectToAction("Create");
                //}

                //if (!memberService.doesMemberExist(vm.MemberID))
                //{
                //    vm.ErrorMessage = "There is no member with that ID";
                //    return RedirectToAction("Create");
                //}

                var newLoan = new LoanDetails();

                newLoan.MemberDetailsId = vm.MemberID;

                try
                {
                    newLoan.BookCopyId = copiesService.GetAvailableCopy (vm.BookDetailsID);
                }

                catch (Exception ex)
                {
                    //return RedirectToAction("ThankYou");
                    return Redirect("OutOfCopies");
                }

                newLoan.LoanDate = DateTime.Now;
                newLoan.ReturnDate = null;

                loanService.AddLoan (newLoan);
            }

            return RedirectToAction (nameof(Index));
        }

        public IActionResult ReturnLoan (int Id)
        {
            //bookkService.ReturnBook(id);

            loanService.ReturnLoan (Id);

            return RedirectToAction (nameof(Index));
        }

        //public async Task <IActionResult> RemoveLoan (int? id)
        //{

        //}

        //GET: LoanDetails/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var loanDetails = await context.Loans.FindAsync(id);

        //    if (loanDetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(loanDetails);
        //}

            //// POST: LoanDetails/Edit/5
            //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public async Task <IActionResult> Edit (int id, [Bind("ID,LoanDate,ReturnDate,MemberID,BookDetailsID")] LoanDetails loanDetails)
            //{
            //    if (id != loanDetails.ID)
            //    {
            //        return NotFound();
            //    }

            //    if (ModelState.IsValid)
            //    {
            //        try
            //        {
            //            _context.Update(loanDetails);
            //            await _context.SaveChangesAsync();
            //        }

            //        catch (DbUpdateConcurrencyException)
            //        {
            //            if (!LoanDetailsExists(loanDetails.ID))
            //            {
            //                return NotFound();
            //            }

            //            else
            //            {
            //                throw;
            //            }
            //        }
            //        return RedirectToAction(nameof(Index));
            //    }

            //    return View(loanDetails);
            //}

            //// GET: LoanDetails/Delete/5
            //public async Task <IActionResult> Delete (int? id)
            //{
            //    if (id == null)
            //    {
            //        return NotFound();
            //    }

            //    var loanDetails = await _context.Loans.FirstOrDefaultAsync(m => m.ID == id);

            //    if (loanDetails == null)
            //    {
            //        return NotFound();
            //    }

            //    return View(loanDetails);
            //}

            //// POST: LoanDetails/Delete/5
            //[HttpPost, ActionName("Delete")]
            //[ValidateAntiForgeryToken]
            //public async Task<IActionResult> DeleteConfirmed(int id)
            //{
            //    var loanDetails = await _context.Loans.FindAsync(id);
            //    _context.Loans.Remove(loanDetails);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            //private bool LoanDetailsExists(int id)
            //{
            //    return _context.Loans.Any(e => e.ID == id);
            //}
        }
}
