using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Finall_project.Models;

namespace Finall_project.Controllers
{
    public class LibraryHistoriesController : Controller
    {
        private LIBRARYDBEntities1 db = new LIBRARYDBEntities1();

        // GET: LibraryHistories
        public ActionResult Index()
        {
            var libraryHistories = db.LibraryHistories.Include(l => l.Book).Include(l => l.MEMBERINFO);
            return View(libraryHistories.ToList());
        }

        // GET: LibraryHistories/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryHistory libraryHistory = db.LibraryHistories.Find(id);
            if (libraryHistory == null)
            {
                return HttpNotFound();
            }
            return View(libraryHistory);
        }

        // GET: LibraryHistories/Create
        public ActionResult Create()
        {
            ViewBag.BOOK_ID = new SelectList(db.Books, "BOOK_ID", "BOOK_NAME");
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERINFOes, "MEMBER_ID", "MEMBER_NAME");
            return View();
        }

        // POST: LibraryHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOOK_ID,MEMBER_ID,ISSUE_DATE,RETURN_DATE")] LibraryHistory libraryHistory)
        {
            if (ModelState.IsValid)
            {
                db.LibraryHistories.Add(libraryHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BOOK_ID = new SelectList(db.Books, "BOOK_ID", "BOOK_NAME", libraryHistory.BOOK_ID);
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERINFOes, "MEMBER_ID", "MEMBER_NAME", libraryHistory.MEMBER_ID);
            return View(libraryHistory);
        }

        // GET: LibraryHistories/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryHistory libraryHistory = db.LibraryHistories.Find(id);
            if (libraryHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.BOOK_ID = new SelectList(db.Books, "BOOK_ID", "BOOK_NAME", libraryHistory.BOOK_ID);
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERINFOes, "MEMBER_ID", "MEMBER_NAME", libraryHistory.MEMBER_ID);
            return View(libraryHistory);
        }

        // POST: LibraryHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOK_ID,MEMBER_ID,ISSUE_DATE,RETURN_DATE")] LibraryHistory libraryHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libraryHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BOOK_ID = new SelectList(db.Books, "BOOK_ID", "BOOK_NAME", libraryHistory.BOOK_ID);
            ViewBag.MEMBER_ID = new SelectList(db.MEMBERINFOes, "MEMBER_ID", "MEMBER_NAME", libraryHistory.MEMBER_ID);
            return View(libraryHistory);
        }

        // GET: LibraryHistories/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryHistory libraryHistory = db.LibraryHistories.Find(id);
            if (libraryHistory == null)
            {
                return HttpNotFound();
            }
            return View(libraryHistory);
        }

        // POST: LibraryHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            LibraryHistory libraryHistory = db.LibraryHistories.Find(id);
            db.LibraryHistories.Remove(libraryHistory);
            db.SaveChanges();
            return RedirectToAction("Index");
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
