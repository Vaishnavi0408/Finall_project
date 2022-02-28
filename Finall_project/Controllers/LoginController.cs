using Finall_project.Models;
using System.Linq;
using System.Web.Mvc;

namespace Student_Mangement_system.Controllers
{
    public class LoginController : Controller
    {
        LIBRARYDBEntities1 db = new LIBRARYDBEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginTab objchk)
        {
            if (ModelState.IsValid)
            {
                using (LIBRARYDBEntities1 db = new LIBRARYDBEntities1())
                {
                    var obj = db.users.Where(a =>{ return a.uname.Equals(objchk.uname) && a.pass.Equals(objchk.pass);}).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "The username or password is incorrect");
                    }
                }
            }
            return View(objchk);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}