using pracLogin.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pracLogin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            BaseEquipment baseEquip = new BaseEquipment();
            List<BaseEquipment> equipmentList = baseEquip.LstEquipment();
            ViewBag.Equipment = equipmentList;
            return View();
        }
        /*public ActionResult About()
        {
            BaseEquipment equipment = new BaseEquipment();
            var equipmentList = equipment.LstEquipment(); // DB logic stays in model
            return View(equipmentList); // Pass list directly to the view
        }*/
        public ActionResult About()
        {
            
            return View();
        }
       /* public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }*/

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult CartDetails()
        {
            return View();
        }
        
    }
}