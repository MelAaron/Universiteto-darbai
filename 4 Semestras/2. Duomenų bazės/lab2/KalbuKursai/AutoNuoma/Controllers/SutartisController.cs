using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoNuoma.Repos;
using AutoNuoma.ViewModels;
using AutoNuoma.Models;

namespace AutoNuoma.Controllers
{
    public class SutartisController : Controller
    {
        SutartisRepository sutartisRepository = new SutartisRepository();
        MokyklaRepository mokyklaRepository = new MokyklaRepository();
        MokinysRepository mokinysRepository = new MokinysRepository();
        SaskaitosRepository saskaitosRepository = new SaskaitosRepository();

        public ActionResult Index()
        {
            return View(sutartisRepository.getSutartys());
        }

        public ActionResult Create()
        {
            SutartisEditViewModel sutartis = new SutartisEditViewModel();
            //uzpildo pasirinkimo sąrašus
            PopulateSelections(sutartis);
            //grazinama paslaugos kurimo puslapį
            return View(sutartis);
        }

        // POST: Sutartis/Create
        [HttpPost]
        public ActionResult Create(SutartisEditViewModel collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //išsaugo nauja sutarti
                    sutartisRepository.addSutartis(collection);
                    collection.nr = sutartisRepository.getMaxId();

                    //jei yra prideta paslaugų išųsaugojo ir paslaugas
                    if (collection.saskaitos != null)
                    {
                        foreach (var item in collection.saskaitos)
                        {
                            //html elemente sutarties id nenustatytas todel duomenis sutvarkome programiskai cia
                            if (item.fk_sutartis == 0)
                            {
                                item.fk_sutartis = collection.nr;
                                saskaitosRepository.insertSaskaita(item);
                                item.nr = saskaitosRepository.getMaxId();
                                //item.fk_paslauga = Convert.ToInt32(item.fk_key.Substring(0, item.fk_key.IndexOf("_"))); // fk_key elemente išsaugotas paslaugos id iki _ simbolio
                                //var ticks = item.fk_key.Substring(item.fk_key.IndexOf('_') + 1, item.fk_key.Length - (item.fk_key.IndexOf('_') + 1));
                                //item.fk_kainaGaliojaNuo = new DateTime(Convert.ToInt64(ticks)); // ticks paverciami į datos reikšmę
                                //item.fk_sutartis = collection.nr; // nustatomas sutarties nr
                            }
                        }

                        //kiekviena uzsakyta paslauga isaugojama duomenu bazeje
                        //foreach (var item in collection.saskaitos)
                        //{
                        //    saskaitosRepository.insertSaskaita(item);
                        //    //uzsakytaPaslaugaRepository.insertUzsakytaPaslauga(item);
                        //}
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                PopulateSelections(collection);
                return View(collection);
            }
        }

        public ActionResult Edit(int id)
        {
            SutartisEditViewModel sutartis = sutartisRepository.getSutartis(id);

            PopulateSelections(sutartis);

            return View(sutartis);
        }

        // POST: Sutartis/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SutartisEditViewModel collection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    sutartisRepository.updateSutartis(collection);
                    //PopulateSelections(collection);
                    if (collection.saskaitos != null)
                    {

                        foreach (var item in collection.saskaitos)
                        {
                            //naujoms pridetos paslaugos sutvarkomi duomenys 
                            if (item.fk_sutartis == 0)
                            {
                                item.fk_sutartis = collection.nr;
                                saskaitosRepository.insertSaskaita(item);
                                //item.fk_paslauga = Convert.ToInt32(item.fk_key.Substring(0, item.fk_key.IndexOf("_"))); // fk_key elemente išsaugotas paslaugos id iki _ simbolio
                                //var ticks = item.fk_key.Substring(item.fk_key.IndexOf('_') + 1, item.fk_key.Length - (item.fk_key.IndexOf('_') + 1));
                                //item.fk_kainaGaliojaNuo = new DateTime(Convert.ToInt64(ticks)); // ticks paverciami į datos reikšmę
                                //item.fk_sutartis = collection.nr; // nustatomas sutarties nr
                            }
                        }

                        // istrina visas sutarties uzsakytas paslaugas
                        saskaitosRepository.deleteSaskaitos(collection.nr);

                        //per nauja prideda visas sutarties uzsakytas paslaugas
                        foreach (var item in collection.saskaitos)
                        {
                            saskaitosRepository.insertSaskaita(item);
                        }
                    }
                    else
                    {
                        saskaitosRepository.deleteSaskaitos(collection.nr);
                    }
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
            SutartisEditViewModel sutartis = sutartisRepository.getSutartis(id);
            return View(sutartis);
        }

        // POST: Sutartis/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                SutartisEditViewModel sutartis = sutartisRepository.getSutartis(id);
                if (sutartis.busena == "nutraukta" || sutartis.busena == "uzbaigta")
                {
                    saskaitosRepository.deleteSaskaitos(id);
                    sutartisRepository.deleteSutartis(id);
                }
                else
                {
                    ViewBag.naudojama = "Sutartis yra patvirtinta arba užbaigta, pašalinti negalima.";
                    return View(sutartis);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public void PopulateSelections(SutartisEditViewModel sutartis)
        {
            //surenka sarasu informacija is duomenu bazes
            var mokyklos = mokyklaRepository.getMokyklos();
            var mokiniai = mokinysRepository.getMokiniai();
            List<SelectListItem> selectListMokyklos = new List<SelectListItem>();
            List<SelectListItem> selectListMokiniai = new List<SelectListItem>();
            List<SelectListItem> selectListBusenos = new List<SelectListItem>();

            //sukuria selectlistitem sarašus

            foreach (var item in mokyklos)
            {
                selectListMokyklos.Add(new SelectListItem { Value = Convert.ToString(item.id), Text = item.pavadinimas });
            }

            foreach (var item in mokiniai)
            {
                selectListMokiniai.Add(new SelectListItem { Value = Convert.ToString(item.asmens_kodas), Text = item.vardas + " " + item.pavarde });
            }
            selectListBusenos.Add((new SelectListItem { Value = "uzsakyta", Text = "uzsakyta" }));
            selectListBusenos.Add((new SelectListItem { Value = "patvirtinta", Text = "patvirtinta" }));
            selectListBusenos.Add((new SelectListItem { Value = "nutraukta", Text = "nutraukta" }));
            selectListBusenos.Add((new SelectListItem { Value = "uzbaigta", Text = "uzbaigta" }));
            //priskiria sarašus vaizdo objektui
            sutartis.MokyklosList = selectListMokyklos;
            sutartis.MokiniaiList = selectListMokiniai;
            sutartis.busenos = selectListBusenos;

            sutartis.saskaitos = saskaitosRepository.getUzsakytosSaskaitos(sutartis.nr);

            //uzsakytose paslaugose sukuria fk_key raktini elementą kuris naudojamas pasirinkime
            //for (int i = 0; i < sutartis.saskaitos.Count; i++)
            //{
            //    sutartis.paslaugos[i].fk_key = sutartis.paslaugos[i].fk_paslauga + "_" + sutartis.paslaugos[i].fk_kainaGaliojaNuo.Ticks;
            //}

            //List<SelectListItem> selectListItems = new List<SelectListItem>();
            //List<SelectListGroup> groups = new List<SelectListGroup>();

            //var paslaugos = paslaugaRepository.getPaslaugos();

            //List<PaslaugaEditViewModel> paslaugosViewModel = new List<PaslaugaEditViewModel>();

            //foreach (var item in paslaugos)
            //{
            //    paslaugosViewModel.Add(new PaslaugaEditViewModel { paslauga = item, paslaugosKainos = paslaugosKainaRepository.getPaslaugosKainos2(item.id) });
            //}

            //bool yra = false;
            ////sukuriamos paslaugu kainu grupes
            //foreach (var item in paslaugosViewModel)
            //{
            //    yra = false;
            //    foreach (var i in groups)
            //    {
            //        if (i.Name.Equals(item.paslauga.pavadinimas))
            //        {
            //            yra = true;
            //        }
            //    }
            //    if (!yra)
            //    {
            //        groups.Add(new SelectListGroup() { Name = item.paslauga.pavadinimas });
            //    }
            //}

            ////sudaromas pasirinkimo sarašas pagal paslaugu grupes
            //foreach (var x in paslaugosViewModel)
            //{
            //    foreach (var item in x.paslaugosKainos)
            //    {
            //        var optGroup = new SelectListGroup() { Name = "--------" };
            //        foreach (var i in groups)
            //        {
            //            if (i.Name.Equals(x.paslauga.pavadinimas))
            //            {
            //                optGroup = i;
            //            }
            //        }

            //        selectListItems.Add(
            //            new SelectListItem()
            //            {
            //                Value = Convert.ToString(item.fk_paslauga + "_" + item.galiojaNuo.Ticks),
            //                Text = x.paslauga.pavadinimas + " " + item.kaina + " EUR (" + item.galiojaNuo + ")",
            //                Group = optGroup
            //            }
            //            );
            //    }
            //}

            ////paslaugu kainu sarašas pagal paslaugu grupes priskiriamas vaizdo objektui
            //sutartis.UzsPaslaugosList = selectListItems;
        }
    }
}
