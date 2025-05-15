using pracLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pracLogin.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoLogin(string txtUserName, string txtPassword)
        {
            Session["UserName"] = "";
            string Message = "Unauthorized";

            BaseAccount baseAccount = new BaseAccount();
            if (baseAccount.VerifyUser(txtUserName, txtPassword))
            {
                Message = "Authorized";
                Session["UserName"] = txtUserName;
                //return Redirect("www.google.com"); 
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = Message;
            //return RedirectToAction("Dashboard", "Inventory");
            return View("Login");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            Session.Remove("UserName");
            return View("Login");
        }
        [HttpGet]
        public ActionResult ResetPassword()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult DoReset(string txtUserName, string newPassword, string confirmPassword)
        {
            Session["UserName"] = "";
            string Message = "Unauthorized";
            if (newPassword != confirmPassword)
            {
                ViewBag.Message = "Passwords do not match!";
                return View("ResetPassword");
            }
            ResetAccount resetAccount = new ResetAccount();
            if (resetAccount.VerifyUser2(txtUserName, newPassword))
            {
                Message = "Authorized";
                Session["UserName"] = txtUserName;
                //return Redirect("www.google.com"); 
                return RedirectToAction("About", "Home");
            }
            ViewBag.Message = Message;
            //return RedirectToAction("Dashboard", "Inventory");
            return View("Login");
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoSignUp(FormCollection frmColl)
        {
            Session["UserName"] = "";
            string Message = "Unauthorized";
            String Password = frmColl["Password"]; 
            String ConfirmPassword = frmColl["ConfirmPassword"];
            // Simple password match check
            if (Password != ConfirmPassword)
            {
                ViewBag.Message = "Password and Confirm Password do not match.";
                return View("SignUp");
            }

            // Example: Save user to database (replace this with actual logic)
            // You can create a model and save the user data accordingly.
            // This is just a placeholder for demonstration:
            
            BaseEquipment baseEquipment = new BaseEquipment();
            bool isSaved = baseEquipment.SaveUserToDatabase(frmColl);

            if (isSaved)
            {
                Session["UserName"] = frmColl["Username"];
                Message = "Authorized";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = Message;
            return View("SignUp");
        }


    }
}