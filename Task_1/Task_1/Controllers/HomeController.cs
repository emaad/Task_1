using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.DAL;
using Task_1.Hubs;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? ID)
        {
            DevTest model = new DevTest();
            if (ID != null)
            {
                using (var context = new MyDbContext())
                {
                    model = context.DevTest.FirstOrDefault(x => x.ID == ID);
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult GetAllEmployeeRecords()
        {
            List<DevTest> lst;
            using (var context = new MyDbContext())
            {
                lst = context.DevTest.ToList();
            }
            return PartialView("_DevTestList", lst);
        }


        //Insert Employee Record
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(DevTest devTest)
        {
            if (ModelState.IsValid)
            {
                //Insert into Employee table 
                using (var context = new MyDbContext())
                {
                    devTest.Date = DateTime.Now;
                    context.DevTest.Add(devTest);
                    context.SaveChanges();
                }
            }

            //Once the record is inserted , then notify all the subscribers (Clients)
            DevTestHub.NotifyCurrentUserInformationToAllClients();
            return RedirectToAction("Index");
        }

        //Update Employee Record
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(DevTest devTest)
        {
            using (var context = new MyDbContext())
            {
                var userRecord = context.DevTest.Find(devTest.ID);

                userRecord.AffiliateName = devTest.AffiliateName;
                userRecord.CampaignName = devTest.CampaignName;
                userRecord.Clicks = devTest.Clicks;
                userRecord.Conversions = devTest.Conversions;
                userRecord.Date = DateTime.Now;
                userRecord.Impressions = devTest.Impressions;



                context.DevTest.Add(userRecord);

                context.Entry(userRecord).State = EntityState.Modified;
                context.SaveChanges();
            }

            //Once the record is inserted , then notify all the subscribers (Clients)
            DevTestHub.NotifyCurrentUserInformationToAllClients();
            return RedirectToAction("Index");
        }

        //Delete Employee Record
        [HttpPost]
        public ActionResult Delete(DevTest devTest)
        {
            using (var context = new MyDbContext())
            {
                var empRecord = context.DevTest.Find(devTest.ID);
                context.DevTest.Remove(empRecord);
                context.SaveChanges();
            }

            //Once the record is inserted , then notify all the subscribers (Clients)
            DevTestHub.NotifyCurrentUserInformationToAllClients();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult GetRecord(DevTest devTest)
        {
            DevTest record;
            using (var context = new MyDbContext())
            {
                record = context.DevTest.FirstOrDefault(x => x.ID == devTest.ID);
            }


            return Json(record, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}