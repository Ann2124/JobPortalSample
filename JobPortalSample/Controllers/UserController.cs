using JobPortalSample.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace JobPortalSample.Controllers
{
    public class UserController : Controller
    {
        private JobPortalContext db = new JobPortalContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            user.Password=Encrypt(user.Password);
            var usr = db.Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if(usr!=null)
            {
                Session["UserId"] = usr.Email.ToString();
                Session["UserName"] = usr.Firstname.ToString();
                return RedirectToAction("");
            }
            else
            {
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(user);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User usr)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(usr);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }
        public static string Encrypt(string clearText)
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