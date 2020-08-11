using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Models;
using AutoNuoma.Repos;
using AutoNuoma.ViewModels;

namespace AutoNuoma.Controllers
{
    public class MiestasController : Controller
    {
        MiestasRepository miestasRepository = new MiestasRepository();
        // GET: Miestas
        public ActionResult Index()
        {
            //ModelState.Clear();
            return View(miestasRepository.getMiestai());
        }

        // GET: Miestas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Miestas/Create
        public ActionResult Create()
        {
            //Grazinama darbuotojo kūrimo forma
            MiestasEditViewModel miestas = new MiestasEditViewModel();
            return View(miestas);
        }

        // POST: Darbuotojas/Create
        [HttpPost]
        public ActionResult Create(MiestasEditViewModel collection)
        {
            try
            {
                // Patikrinama ar tokiod arbuotojo nėra duomenų bazėje
                MiestasEditViewModel tmpmiestas = miestasRepository.getMiestas(collection.id);

                //if (tmpmiestas.id != null)
                //{
                //    ModelState.AddModelError("id", "Miestas su tokiu id jau egzistuoja duomenų bazėje.");
                //    return View(collection);
                //}
                //Jei darbuotojo su tabelio nr neranda prideda naują
                if (ModelState.IsValid)
                {
                    miestasRepository.addMiestas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Miestas/Edit/5
        public ActionResult Edit(int id)
        {
            return View(miestasRepository.getMiestas(id));
        }

        // POST: Marke/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MiestasEditViewModel collection)
        {
            try
            {
                // atnajina markes informacija
                if (ModelState.IsValid)
                {
                    miestasRepository.updateMiestas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Miestas/Delete/5
        public ActionResult Delete(int id)
        {
            MiestasEditViewModel miestas = miestasRepository.getMiestas(id);
            return View(miestas);
        }

        // POST: Miestas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                MiestasEditViewModel modelis = miestasRepository.getMiestas(id);
                bool naudojama = false;

                if (miestasRepository.getMiestasCount(id) > 0)
                {
                    naudojama = true;
                    ViewBag.naudojama = "Negalima pašalinti miesto, yra sukurtų kompanijų su šiuo miestu.";
                    return View(modelis);
                }

                if (!naudojama)
                {
                    miestasRepository.deleteMiestas(id);
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
