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
    public class LoginTabsController : Controller
    {
        private LIBRARYDBEntities1 db = new LIBRARYDBEntities1();

        // GET: LoginTabs
        public ActionResult Index()
        {
            return View(db.users.ToList());
        }

        // GET: LoginTabs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginTab loginTab = db.users.Find(id);
            if (loginTab == null)
            {
                return HttpNotFound();
            }
            return View(loginTab);
        }

        // GET: LoginTabs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "uname,pass,role")] LoginTab loginTab)
        {
            if (ModelState.IsValid)
            {
                object p = db.user.Add(loginTab);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginTab);
        }

        // GET: LoginTabs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginTab loginTab = db.LoginTabs.Find(id);
            if (loginTab == null)
            {
                return HttpNotFound();
            }
            return View(loginTab);
        }

        // POST: LoginTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "uname,pass,role")] LoginTab loginTab)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginTab).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginTab);
        }

        // GET: LoginTabs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginTab loginTab = db.users.Find(id);
            if (loginTab == null)
            {
                return HttpNotFound();
            }
            return View(loginTab);
        }

        // POST: LoginTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LoginTab loginTab = db.LoginTab.Find(id);
            db.LoginTabs.Remove(loginTab);
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
