using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.ViewModels;

namespace AutoNuoma.Controllers
{
    public class KompanijaController : Controller
    {
        KompanijaRepository kompanijaRepository = new KompanijaRepository();
        MiestasRepository miestasRepository = new MiestasRepository();

        public ActionResult Index()
        {
            ModelState.Clear();
            return View(kompanijaRepository.getKompanijos());
        }

        public ActionResult Create()
        {
            KompanijaEditViewModel kompanija = new KompanijaEditViewModel();
            PopulateSelections(kompanija);
            return View(kompanija);
        }

        // POST: Modelis/Create
        [HttpPost]
        public ActionResult Create(KompanijaEditViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    kompanijaRepository.addKompanija(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }
        public void PopulateSelections(KompanijaEditViewModel kompanija)
        {
            var miestai = miestasRepository.getMiestai();
            List<SelectListItem> selectListmiestai = new List<SelectListItem>();

            foreach (var item in miestai)
            {
                selectListmiestai.Add(new SelectListItem() { Value = Convert.ToString(item.id), Text = item.pavadinimas });
            }

            kompanija.MiestaiList = selectListmiestai;
        }

        public ActionResult Edit(int id)
        {
            KompanijaEditViewModel kompaija = kompanijaRepository.getKompanija(id);
            PopulateSelections(kompaija);
            return View(kompaija);
        }

        // POST: Modelis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, KompanijaEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    kompanijaRepository.updateKompanija(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }
        public ActionResult Delete(int id)
        {
            KompanijaEditViewModel modelis = kompanijaRepository.getKompanija(id);
            return View(modelis);
        }

        // POST: Modelis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                KompanijaEditViewModel modelis = kompanijaRepository.getKompanija(id);
                bool naudojama = false;

                if (kompanijaRepository.getModelisCount(id) > 0)
                {
                    naudojama = true;
                    ViewBag.naudojama = "Negalima pašalinti kompanijos, yra sukurtų mokyklų su šia kompanija.";
                    return View(modelis);
                }

                if (!naudojama)
                {
                    kompanijaRepository.deleteKompanija(id);
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