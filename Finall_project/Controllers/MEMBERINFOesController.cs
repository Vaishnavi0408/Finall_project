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
    public class MEMBERINFOesController : Controller
    {
        private LIBRARYDBEntities1 db = new LIBRARYDBEntities1();

        // GET: MEMBERINFOes
        public ActionResult Index()
        {
            return View(db.MEMBERINFOes.ToList());
        }

        // GET: MEMBERINFOes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERINFO mEMBERINFO = db.MEMBERINFOes.Find(id);
            if (mEMBERINFO == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERINFO);
        }

        // GET: MEMBERINFOes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MEMBERINFOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MEMBER_ID,MEMBER_NAME,EMAIL,MOBILE_NO")] MEMBERINFO mEMBERINFO)
        {
            if (ModelState.IsValid)
            {
                db.MEMBERINFOes.Add(mEMBERINFO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mEMBERINFO);
        }

        // GET: MEMBERINFOes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERINFO mEMBERINFO = db.MEMBERINFOes.Find(id);
            if (mEMBERINFO == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERINFO);
        }

        // POST: MEMBERINFOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MEMBER_ID,MEMBER_NAME,EMAIL,MOBILE_NO")] MEMBERINFO mEMBERINFO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mEMBERINFO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mEMBERINFO);
        }

        // GET: MEMBERINFOes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MEMBERINFO mEMBERINFO = db.MEMBERINFOes.Find(id);
            if (mEMBERINFO == null)
            {
                return HttpNotFound();
            }
            return View(mEMBERINFO);
        }

        // POST: MEMBERINFOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            MEMBERINFO mEMBERINFO = db.MEMBERINFOes.Find(id);
            db.MEMBERINFOes.Remove(mEMBERINFO);
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
