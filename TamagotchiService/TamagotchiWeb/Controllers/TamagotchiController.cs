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



            //service.AddTamagotchi(tam);
            List<ViewModels.Tamagotchi> tamagotchis = service.GetTamagotchis()
                .Select(t => new ViewModels.Tamagotchi(t))
                .ToList();

            tamagotchis.ForEach(t => t.Status = service.GetStatus(t.Id));
            foreach (var t in tamagotchis)
            {
                Debug.WriteLine(t.Id + " -naam: " + t.Naam + " -age: " + t.Leeftijd + " -health " + t.Gezondheid);
            }

            return View(tamagotchis);
        }



        // GET: Tamagotchi/Details/5
        //public ActionResult Details(int id)
        //{
        //    if (!id.Equals(""))
        //    {
        //        ViewModels.Tamagotchi DetailVM = new ViewModels.Tamagotchi(service.GetTamagotchi(id));
        //        DetailVM.Status = service.GetStatus(id);
        //        return View(DetailVM);
        //    }
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        public ActionResult Details(int id, string actie = "")
        {

            if (id != 0 && !actie.Equals(""))
            {
                service.PerformAction(id, actie);
                ViewModels.Tamagotchi DetailVM = new ViewModels.Tamagotchi(service.GetTamagotchi(id));
                DetailVM.Status = service.GetStatus(id);
                return View(DetailVM);
            }

            if (!id.Equals("") && (actie.Equals("") || actie == null))
            {
                ViewModels.Tamagotchi DetailVM = new ViewModels.Tamagotchi(service.GetTamagotchi(id));
                DetailVM.Status = service.GetStatus(id);
                return View(DetailVM);
            }





            return View();

        }

        // GET: Tamagotchi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tamagotchi/Create
        [HttpPost]
        public ActionResult Create(string[] Naam)
        {
            ViewBag.NaamList = Naam;
            var nowtime = DateTime.Now; //zodat ze allemaal dezelfde tijd hebben als je er meer tegelijk aan maakt 
            foreach (string s in Naam)
            {
                if (s.Equals(""))
                {
                    return View();
                }
            }
            foreach (string s in Naam)
            {
                if (!s.Equals(""))
                {
                    Tamagot tam = new Tamagot()
                    {
                        Id = 0,
                        Naam = s,
                        Leeftijd = nowtime,
                        Honger = 0,
                        Slaap = 0,
                        Verveling = 0,
                        Gezondheid = 100
                    };
                    service.AddTamagotchi(tam);
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Tamagotchi/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new ViewModels.Tamagotchi(service.GetTamagotchi(id)));
        }

        // POST: Tamagotchi/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ViewModels.Tamagotchi edittam)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            service.EditTamagotchi(id, edittam.Naam);

            return RedirectToAction("Index");

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
