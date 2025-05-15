using pracLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace pracLogin.Controllers
{
    public class EquipmentController : Controller
    {
        // GET: Equipment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        
        
        public JsonResult GetEquipmentDetails(int equipmentId)
        {
            try
            {
                var model = new BaseEquipment();
                var equipment = model.GetEquipmentById(equipmentId);

                if (equipment == null || equipment.EquipmentId == 0)
                {
                    return Json(new { success = false, message = "Equipment not found" }, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    success = true,
                    equipment = new
                    {
                        EquipmentId = equipment.EquipmentId,
                        EquipmentName = equipment.EquipmentName,
                        ProductDescription = equipment.ProductDescription,
                        ImgUrl = equipment.ImgUrl,
                        EquipmentPrice = equipment.EquipmentPrice,
                        Stock = equipment.Stock
                    }
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}