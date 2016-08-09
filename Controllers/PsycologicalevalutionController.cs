using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientMaster.Controllers
{
    public class PsycologicalevalutionController : Controller
    {
        // GET: Psycologicalevalution
        public ActionResult Index()
        {
            return View();
        }

        // GET: Psycologicalevalution/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Psycologicalevalution/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Psycologicalevalution/Create
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

        // GET: Psycologicalevalution/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Psycologicalevalution/Edit/5
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

        // GET: Psycologicalevalution/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Psycologicalevalution/Delete/5
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
