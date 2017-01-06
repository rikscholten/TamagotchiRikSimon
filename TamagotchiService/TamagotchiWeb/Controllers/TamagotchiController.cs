using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TamagotchiDomain;


namespace TamagotchiWeb.Controllers
{
    public class TamagotchiController : Controller
    {

        private ServiceReference1.IService1 service;

        public TamagotchiController()
        {
            service = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
        }
        // GET: Tamagotchi

        public ActionResult Index()
        {
            

            Tamagot tam = new Tamagot();
            
            tam.Naam = "Rik";
            tam.Leeftijd = 0;
            tam.Gezondheid = 0;
            tam.Honger = 0;
            tam.Slaap = 0;
            tam.Verveling = 0;

            service.AddTamagotchi(tam);
            List<ViewModels.Tamagotchi> tamagotchis = service.GetTamagotchis()
                .Select(t => new ViewModels.Tamagotchi(t))
                .ToList();
            foreach( var t in tamagotchis)
            {
                Debug.WriteLine(t.Id+" -naam: " + t.Naam +" -age: " +t.Leeftijd +" -health " +t.Gezondheid);
            }

                return View(tamagotchis);
        }

       

        // GET: Tamagotchi/Details/5
        public ActionResult Details(int id)
        {

            return View(new ViewModels.Tamagotchi(service.GetTamagotchi(id)));
        }

        // GET: Tamagotchi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamagotchi/Create
        [HttpPost]
        public ActionResult Create(ViewModels.Tamagotchi newtam)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


                Tamagot tam = new Tamagot()
                {
                Id = newtam.Id,
                Naam = newtam.Naam,
                Leeftijd = newtam.Leeftijd,
                Honger = newtam.Honger,
                Slaap = newtam.Slaap,
                Verveling = newtam.Verveling,
                Gezondheid = newtam.Gezondheid
            };
            tam.Id = 1;
            Debug.WriteLine(" -ID: " + tam.Id + " -naam: " + tam.Naam + " -age: " + tam.Leeftijd + " -honger: " + tam.Honger + " -slaap: " + tam.Slaap + " -verveling: " + tam.Verveling + " -gezondehid: " + tam.Gezondheid);
            service.AddTamagotchi(tam);

                return RedirectToAction("Index");
            
        }

        // GET: Tamagotchi/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new ViewModels.Tamagotchi(service.GetTamagotchi(id)));
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
            
            return View(new ViewModels.Tamagotchi(service.GetTamagotchi(id)));
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
