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
    public class BookDetailsController : Controller
    {
        private readonly BibliotekUppgiftContext _context;

        private readonly IBookkService bookservice;
        private readonly IAuthorService authorService;

        //  public BookDetailsController(BibliotekUppgiftContext context)
        public BookDetailsController (IBookkService bookservice, IAuthorService authorService, BibliotekUppgiftContext context)
        {
            _context = context;
            this.authorService = authorService;
            this.bookservice = bookservice;
        }

        //GET: BookDetails
        public IActionResult Index()
        {
            //  return View(await _context.BookDetails.ToListAsync());
            var vm = new BookIndexVm();
            vm.books = bookservice.GetAllBooks();

            return View (vm);
        }

        // GET: BookDetails/Details/5
        public async Task <IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  var bookDetails = await _context.BookDetails.FirstOrDefaultAsync (m => m.AuthorId == id);

            var bookDetails = await _context.BookDetails.FirstOrDefaultAsync(m => m.Id == id);

            if (bookDetails == null)
            {
                return NotFound();
            }

            return View (bookDetails);
        }

        // GET: BookDetails/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: BookDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,ISBN,Title,AuthorID,Description")] BookDetails bookDetails)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(bookDetails);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(bookDetails);
        //} 

        public IActionResult Create()
        {
            var vm = new BookCreateVm();

            vm.AuthorList = new SelectList (authorService.GetAllAuthors(), "Id", "Name");

            return View (vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create (BookCreateVm vm)
        {
            if (ModelState.IsValid)
            {
                //var books = new List<BookCopy>();

                //for (int i = 0; i < vm.Copies; i++)
                //{
                //    books.Add (new BookCopy { ID = i, BookDetailsID = vm.ID });

                //}

                //_context.Add(vm);

                //await _context.SaveChangesAsync();

                //return RedirectToAction(nameof(Index));

                var newBook = new BookDetails();
                newBook.AuthorId = vm.AuthorID;
                newBook.Description = vm.Description;
                newBook.ISBN = vm.ISBN;
                newBook.Title = vm.Title;
                // newBook.NumberOfCopies = vm.NumberOfCopies;
                newBook.Copies = new List <BookCopy>();

                for (int i = 0; i < vm.NumberOfCopies; i++)
                {
                    var thecopy = new BookCopy();
                    thecopy.BookDetailsId = newBook.Id;

                    newBook.Copies.Add(thecopy);
                }

                bookservice.AddBook(newBook);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Error", "Home", "");
        }

        // GET: BookDetails/Edit/5
        public async Task <IActionResult> Edit (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDetails = await _context.BookDetails.FindAsync(id);

            if (bookDetails == null)
            {
                return NotFound();
            }

            return View (bookDetails);
        }

        // POST: BookDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit (int id, [Bind("ID,ISBN,Title,AuthorID,Description")] BookDetails bookDetails)
        {
            if (id != bookDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookDetails);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!BookDetailsExists(bookDetails.Id))
                    {
                        return NotFound();
                    }

                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction (nameof(Index));
            }

            return View (bookDetails);
        }

        //    // GET: BookDetails/Delete/5
        public async Task <IActionResult> Delete (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookDetails = await _context.BookDetails.FirstOrDefaultAsync (m => m.Id == id);

            if (bookDetails == null)
            {
                return NotFound();
            }

            return View (bookDetails);
        }

        // POST: BookDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookDetails = await _context.BookDetails.FindAsync(id);

            //     var bookDetails = await _context.BookDetails.FirstOrDefaultAsync(x => x.Id == id);

            _context.BookDetails.Remove(bookDetails);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public bool BookDetailsExists (int id)
        {
            return _context.BookDetails.Any (e => e.Id == id);
        }
    }
}
