using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientMaster.Controllers
{
    public class UpperEndoscopyController : Controller
    {
        // GET: UpperEndoscopy
        public ActionResult Index()
        {
            return View();
        }

        // GET: UpperEndoscopy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UpperEndoscopy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UpperEndoscopy/Create
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

        // GET: UpperEndoscopy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UpperEndoscopy/Edit/5
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

        // GET: UpperEndoscopy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UpperEndoscopy/Delete/5
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
