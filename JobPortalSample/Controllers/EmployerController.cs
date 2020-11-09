using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalSample.Models;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;

namespace JobPortalSample.Controllers
{
    public class EmployerController : Controller
    {
        JobPortalContext db = new JobPortalContext();
        // GET: Employer
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Employer employer)
        {
            employer.Password = encrypt(employer.Password);
            var emp = db.Employers.Where(u => u.EmployerId.Equals(employer.EmployerId) && u.Password.Equals(employer.Password)).FirstOrDefault();
            if(emp!=null)
            {
                FormsAuthentication.SetAuthCookie(employer.EmployerId, false);
                Session["UserId"] = emp.EmployerId.ToString();
                Session["UserName"] = (emp.FirstName).ToString();
                Session["Role"] = "Employer";
                return RedirectToAction("AppliedJob");

            }
            else
            {
                ModelState.AddModelError("", "Invalid Login Credentials");
            }
            return View(employer);
        }
        public string encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (System.IO.MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "EmployerId,FirstName,LastName,Password,ConfirmPassword,MobileNo,Organisation")] Employer emp)
        {
            emp.Password = encrypt(emp.Password);
            emp.ConfirmPassword = encrypt(emp.ConfirmPassword);
            var check = db.Employers.Find(emp.EmployerId);
            if (check == null)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Employers.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            else
            {
                ModelState.AddModelError("", "User already Exists");
                return View();
            }
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}