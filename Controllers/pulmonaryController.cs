using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientMaster.Controllers
{
    public class pulmonaryController : Controller
    {
        // GET: pulmonary
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult chestxray()

        {
            return View();
        }
        public ActionResult Sleep()

        {
            return View();
        }
        public ActionResult Clearance()
        {
            return View();
        }
        public ActionResult Functiontest()

        {
            return View();
        }
        // GET: pulmonary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: pulmonary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pulmonary/Create
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

        // GET: pulmonary/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: pulmonary/Edit/5
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

        // GET: pulmonary/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: pulmonary/Delete/5
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
