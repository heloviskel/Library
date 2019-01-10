using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyLibrary.Models;
using MyLibrary.Filter;

namespace MyLibrary.Controllers
{
    public class BooksController : Controller
    {
        private DataContext db = new DataContext();
        public static int bookid;

        // GET: Books
        public async Task<ActionResult> Index(string option, string search)
        {
            ViewBag.Condition = User.IsInRole("admin");//additional action buttons for admin(see Index.cshtml)
            switch (option)//filter
            {
                case "Title":
                    return View(db.Books.Where(x => x.Title.StartsWith(search) || search == null).ToList());
                case "Author":
                    return View(db.Books.Where(x => x.Author == search || search == null).ToList());
                case "Release_year":
                    return View(db.Books.Where(x => x.Release_year.ToString() == search || search == null).ToList());
                case "Genre":
                    return View(db.Books.Where(x => x.Genre == search || search == null).ToList());
            }
            return View(await db.Books.ToListAsync());
        }

        // GET: Books/Details
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        [MyAuthorizeAttribute(Roles = "admin", Users = "Oleh,Bohdan")]//permission to admins(AuthorizeAttribute)
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Book_ID,Cover,Title,Author,Release_year,Publishment,Content,Price,Genre,Date_of_coming,Amount_of_coming,Inventary_number,Availability")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit
        [MyAuthorizeAttribute(Roles = "admin", Users = "Oleh,Bohdan")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Book_ID,Cover,Title,Author,Release_year,Publishment,Content,Price,Genre,Date_of_coming,Amount_of_coming,Inventary_number,Availability")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete
        [MyAuthorizeAttribute(Roles = "admin", Users = "Oleh,Bohdan")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Book book = await db.Books.FindAsync(id);
            db.Books.Remove(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Order(int id)//Order a Book
        {
            ViewBag.Book_ID = id;
            bookid = id;
            return View();
        }

        // POST: Customers/Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Order([Bind(Include = "Customer_ID,Giveaway_date,Name,Adress,Birth_year,Tel__number,Returning_date")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Books_Customers b_c = new Books_Customers { Books_ID = bookid, Customers_ID = customer.Customer_ID };
                db.Customers.Add(customer);
                b_c.Customers_ID = customer.Customer_ID;
                db.Books_Customers.Add(b_c);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customer);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
