using Finall_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finall_project.Controllers
{
    public class ProjController : Controller
    {
        // GET: Proj
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            string uname = collection["txtuname"].ToString();
            string passwd = collection["txtpwd"].ToString();
            LIBRARYDBEntities1 ent = new LIBRARYDBEntities1();
            string role = ent.LoginProc(uname, passwd).FirstOrDefault<string>();
            if (role == "Customer")
            {
                return RedirectToAction(actionName: "Index", controllerName: "Customer");
            }
            else
            {
                return RedirectToAction(actionName: "Index", controllerName: "Admin");
            }
            //return View();
        }
    }
}