using JobPortalSample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;



namespace JobPortalSample.Controllers
{
    public class UserController : Controller
    {
        JobPortalContext db = new JobPortalContext();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            user.Password = Encrypt(user.Password);
            var usr = db.Users.Where(u => u.Email.Equals(user.Email) && u.Password.Equals(user.Password)).FirstOrDefault();
            if(usr!=null)
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                Session["UserID"] = usr.Email.ToString();
                Session["UserName"] = (usr.Firstname).ToString();
                Session["Role"] = "user";
                return RedirectToAction("JobList");
            }
            else
            {
                ModelState.AddModelError("", "LoginCredentials Entered are Invalid");
            }
            return View(user);
        }
        public string Encrypt(string clearText)
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
        public ActionResult Register([Bind(Include = "Email,Password,ConfirmPassword,Firstname,Lastname,Address,ContactNumber,Qualification,Year,Experience,YearofExperience,Employer,EmployerDetails")] User usr)
        {
            usr.Password = Encrypt(usr.Password);
            usr.ConfirmPassword =Encrypt(usr.ConfirmPassword);
            var check = db.Users.Find(usr.Email);
            if (check == null)
            {
                db.Configuration.ValidateOnSaveEnabled = false;
                db.Users.Add(usr);
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