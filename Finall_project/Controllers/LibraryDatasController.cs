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
    public class LibraryDatasController : Controller
    {
        private LIBRARYDBEntities1 db = new LIBRARYDBEntities1();

        // GET: LibraryDatas
        public ActionResult Index()
        {
            var libraryDatas = db.LibraryDatas.Include(l => l.Book);
            return View(libraryDatas.ToList());
        }

        // GET: LibraryDatas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryData libraryData = db.LibraryDatas.Find(id);
            if (libraryData == null)
            {
                return HttpNotFound();
            }
            return View(libraryData);
        }

        // GET: LibraryDatas/Create
        public ActionResult Create()
        {
            ViewBag.BOOK_ID = new SelectList(db.Books, "BOOK_ID", "BOOK_NAME");
            return View();
        }

        // POST: LibraryDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BOOK_ID,BOOK_NAME,NUM_OF_BOOK")] LibraryData libraryData)
        {
            if (ModelState.IsValid)
            {
                db.LibraryDatas.Add(libraryData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BOOK_ID = new SelectList(db.Books, "BOOK_ID", "BOOK_NAME", libraryData.BOOK_ID);
            return View(libraryData);
        }

        // GET: LibraryDatas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LIBRARYDBEntities1 libraryData = new LIBRARYDBEntities1(id);
            if (libraryData == null)
            {
                return HttpNotFound();
            }
            ViewBag.BOOK_ID = new SelectList(libraryData.Books, "BOOK_ID", "BOOK_NAME", libraryData.BOOK_ID);
            return View(libraryData);
        }

        // POST: LibraryDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BOOK_ID,BOOK_NAME,NUM_OF_BOOK")] LibraryData libraryData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libraryData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BOOK_ID = new SelectList(db.Books, "BOOK_ID", "BOOK_NAME", libraryData.BOOK_ID);
            return View(libraryData);
        }

        // GET: LibraryDatas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryData libraryData = db.LibraryDatas.Find(id);
            if (libraryData == null)
            {
                return HttpNotFound();
            }
            return View(libraryData);
        }

        // POST: LibraryDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            LibraryData libraryData = db.LibraryDatas.Find(id);
            db.LibraryDatas.Remove(libraryData);
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
