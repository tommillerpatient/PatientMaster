using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientMaster.Controllers
{
    public class BloodworkController : Controller
    {
        // GET: Bloodwork
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bloodwork/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bloodwork/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bloodwork/Create
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

        // GET: Bloodwork/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bloodwork/Edit/5
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

        // GET: Bloodwork/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bloodwork/Delete/5
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
