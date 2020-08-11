using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.Models;

namespace AutoNuoma.Controllers
{
    public class KursasController : Controller
    {
        KursasRepository kursasRepository = new KursasRepository();
        MokytojasRepository mokytojasRepository = new MokytojasRepository();
        public ActionResult Index()
        {
            //grazinamas markiu sarašas
            return View(kursasRepository.getKursai());
        }

        // GET: Marke/Create
        public ActionResult Create()
        {
            Kursas kursas = new Kursas();
            PopulateSelections(kursas);
            return View(kursas);
        }
        [HttpPost]
        public ActionResult Create(Kursas collection)
        {
            try
            {
                // išsaugo nauja markę duomenų bazėje
                if (ModelState.IsValid)
                {
                    kursasRepository.addKursas(collection);
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
            Kursas kursas = kursasRepository.getKursas(id);
            return View(kursasRepository.getKursas(id));
        }

        // POST: Marke/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Kursas kursas = kursasRepository.getKursas(id);
                bool naudojama = false;
                if (kursasRepository.getKursasCount(id) > 0)
                {
                    naudojama = true;
                    ViewBag.naudojama = "Negalima pašalinti yra sukurtų modelių su šia marke.";
                    return View(kursasRepository.getKursas(id));
                }

                if (!naudojama)
                {
                    kursasRepository.deleteKursas(id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            Kursas kursas = kursasRepository.getKursas(id);
            PopulateSelections(kursas);
            return View(kursas);
        }

        // POST: Marke/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Kursas collection)
        {
            try
            {
                // atnajina markes informacija
                if (ModelState.IsValid)
                {
                    kursasRepository.updateKursas(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }
        public void PopulateSelections(Kursas kursas)
        {

            List<SelectListItem> selectListLygiai = new List<SelectListItem>();
            selectListLygiai.Add((new SelectListItem { Value = "A1", Text = "A1" }));
            selectListLygiai.Add((new SelectListItem { Value = "A2", Text = "A2" }));
            selectListLygiai.Add((new SelectListItem { Value = "B1", Text = "B1" }));
            selectListLygiai.Add((new SelectListItem { Value = "B2", Text = "B2" }));
            selectListLygiai.Add((new SelectListItem { Value = "C1", Text = "C1" }));
            selectListLygiai.Add((new SelectListItem { Value = "C2", Text = "C2" }));
            //priskiria sarašus vaizdo objektui
            kursas.lygiai = selectListLygiai;

            List<SelectListItem> selectListMokMedz = new List<SelectListItem>();
            selectListMokMedz.Add((new SelectListItem { Value = "internetas", Text = "internetas" }));
            selectListMokMedz.Add((new SelectListItem { Value = "paskaitos", Text = "paskaitos" }));
            //priskiria sarašus vaizdo objektui
            kursas.mokMedz = selectListMokMedz;

            List<SelectListItem> selectListsavDien = new List<SelectListItem>();
            selectListsavDien.Add((new SelectListItem { Value = "pirmadienis", Text = "pirmadienis" }));
            selectListsavDien.Add((new SelectListItem { Value = "antradienis", Text = "antradienis" }));
            selectListsavDien.Add((new SelectListItem { Value = "treciadienis", Text = "treciadienis" }));
            selectListsavDien.Add((new SelectListItem { Value = "ketvirtadienis", Text = "ketvirtadienis" }));
            selectListsavDien.Add((new SelectListItem { Value = "penktadienis", Text = "penktadienis" }));
            selectListsavDien.Add((new SelectListItem { Value = "sestadienis", Text = "sestadienis" }));
            //priskiria sarašus vaizdo objektui
            kursas.savDien = selectListsavDien;
            var mokytojai = mokytojasRepository.getMokytojai();
            List<SelectListItem> selectListMokytojai = new List<SelectListItem>();
            foreach (var item in mokytojai)
            {
                selectListMokytojai.Add(new SelectListItem() { Value = Convert.ToString(item.asmens_kodas), Text = item.vardas + " " + item.pavarde });
            }
            kursas.MokytojaiList = selectListMokytojai;
        }
    }
}