using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFforDbFirst.Models;

namespace EFforDbFirst.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult ClientSelectAll()
        {
            var db = new 客戶資料Entities();

            var clients = db.客戶資料;

            return View(clients);
        }

        public ActionResult ClientSelectOne(int? id)
        {
            if (id.HasValue)
            {
                var db = new 客戶資料Entities();
                var all = db.客戶資料;
                var client = all.Find(id.Value);
                //var client = all.FirstOrDefault(p => p.Id == id.Value);
                //var client = all.Where(p => p.Id == id.Value).FirstOrDefault();
                return View(client);
            }

            return RedirectToAction("ClientSelectAll");
        }

        public ActionResult ClientCreate()
        {
            客戶資料 client = new 客戶資料();
            client.客戶名稱 = "Ray";
            client.統一編號 = "12341234";
            client.電話 = "042258648";

            var db = new 客戶資料Entities();
            db.客戶資料.Add(client);

            db.SaveChanges();

            return RedirectToAction("ClientSelectAll");
        }

        public ActionResult ClientEdit(int? id)
        {
            if (id.HasValue)
            {
                var db = new 客戶資料Entities();
                var client = db.客戶資料.Find(id.Value);
                if (client != null)
                {
                    client.Email = "ray@test.com";
                    db.SaveChanges();
                }
            }

            return RedirectToAction("ClientSelectAll");
        }


        public ActionResult ClientDelete(int? id)
        {
            if (id.HasValue)
            {
                var db = new 客戶資料Entities();
                var client = db.客戶資料.Find(id.Value);
                if (client != null)
                {
                    db.客戶資料.Remove(client);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("ClientSelectAll");
        }


        public ActionResult ClientSelectOneBySP(int? id)
        {
            if (id.HasValue)
            {
                var db = new 客戶資料Entities();
                var client = db.Get_Client(id).FirstOrDefault();
                return View(client);
            }

            return RedirectToAction("ClientSelectAll");
        }

        public ActionResult ClientAndContactCreate()
        {
            客戶資料 client = new 客戶資料();
            client.客戶名稱 = "RayContact";
            client.統一編號 = "12341234";
            client.電話 = "042258648";

            client.客戶聯絡人.Add(new 客戶聯絡人
            {
                職稱 = "PG",
                姓名 = "Raymond",
                Email = "1122@xxxx.com"
            });

            var db = new 客戶資料Entities();
            db.客戶資料.Add(client);

            db.SaveChanges();

            return View(db.客戶聯絡人.ToList());
        }

        public ActionResult ClientAndContactDelete(int? id)
        {
            if (id.HasValue)
            {
                var db = new 客戶資料Entities();
                var client = db.客戶資料.Find(id.Value);
                if (client != null)
                {
                    db.客戶聯絡人.RemoveRange(client.客戶聯絡人);
                    db.客戶資料.Remove(client);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("ClientSelectAll");
        }
    }
}