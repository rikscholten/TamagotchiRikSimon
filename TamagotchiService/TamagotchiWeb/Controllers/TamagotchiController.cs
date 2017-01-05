using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TamagotchiWeb.Controllers
{
    public class TamagotchiController : Controller
    {
        private TamagotchiService.IService1 _service;

        public TamagotchiController()
        {
            //kan dit slimmer?
            this._service = new TamagotchiService.Service1Client("BasicHttpBinding_ITamagotchiService");
        }
        // GET: Tamagotchi
        public ActionResult Index()
        {
            List<ViewModels.Tamagotchi> tamagotchis = _service.GetTamagotchis()
                .Select(t => new ViewModels.Tamagotchi(t))
                .ToList();

            return View(tamagotchis);
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
