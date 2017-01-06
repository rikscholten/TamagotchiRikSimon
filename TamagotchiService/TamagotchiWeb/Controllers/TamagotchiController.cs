using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamagotchiWeb.Controllers
{
    public class TamagotchiController : Controller
    {
        

        
        // GET: Tamagotchi
        [HttpGet]
        public ActionResult Index()
        {
            TamagotchiService.IService1 client = new TamagotchiService.Service1Client();

            var list = client.GetTamagotchis();

            ViewBag.List = list;

            int invoer = 0;
            int uitkomst;
            uitkomst = client.HugTamagotchi(invoer);

            Debug.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxx");
            Debug.WriteLine(uitkomst);
            //client.Naam = "Rik";
            //client.Leeftijd = 0;
            //client.Gezondheid = 0;
            //client.Honger = 0;
            //client.Slaap = 0;
            //client.Verveling = 0;
            //Debug.WriteLine(client.Naam);
            Debug.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxx");

            //Debug.WriteLine(_service.GetTamagotchis());
            //List<TamagotchiService.Tamagotchi> tamagotchis = _service.GetTamagotchis()
            //    .Select(t => new TamagotchiService.Tamagotchi())
            //    .ToList();

            return View();
        }

        // GET: Tamagotchi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tamagotchi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamagotchi/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tamagotchi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tamagotchi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tamagotchi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tamagotchi/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
