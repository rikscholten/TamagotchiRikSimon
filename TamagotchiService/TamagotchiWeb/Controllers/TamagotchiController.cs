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
        

        
        // GET: Tamagotchi
        
        public ActionResult Index()
        {
            ServiceReference1.IService1 service = new ServiceReference1.Service1Client();
            

            Tamagot tam = new Tamagot();
            
            tam.Naam = "Rik";
            tam.Leeftijd = 0;
            tam.Gezondheid = 0;
            tam.Honger = 0;
            tam.Slaap = 0;
            tam.Verveling = 0;

            //service.AddTamagotchi(tam);
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
            ServiceReference1.IService1 service = new ServiceReference1.Service1Client();

            return View(new ViewModels.Tamagotchi(service.GetTamagotchi(id)));
        }

        // GET: Tamagotchi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamagotchi/Create
        [HttpPost]
        public ActionResult Create(ServiceReference1.Tamagotchi newtam)
        {

            
            try
            {
                ServiceReference1.IService1 service = new ServiceReference1.Service1Client();



                service.AddTamagotchi(newtam);
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
            ServiceReference1.IService1 service = new ServiceReference1.Service1Client();
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

            ServiceReference1.IService1 service = new ServiceReference1.Service1Client();
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
