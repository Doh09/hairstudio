using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hairstudio_DLL;
using HSRestAPI_DLL.Entities;
using Hairstudio_MVC.Models;

namespace Hairstudio_MVC.Controllers
{
    public class ServicesOfferedController : Controller
    {
        private readonly IGatewayService<ServiceOffered> _sog = new Facade().GetServiceOfferedGateway();

        // GET: ServicesOffered
        public ActionResult Index()
        {
            var ServicesOffered = _sog.GetAll();
            return View(ServicesOffered);
        }

        // GET: ServicesOffered/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOffered serviceOffered = _sog.Get(id.Value);
            if (serviceOffered == null)
            {
                return HttpNotFound();
            }
            return View(serviceOffered);
        }

        // GET: ServicesOffered/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesOffered/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Price")] ServiceOffered serviceOffered)
        {
            if (ModelState.IsValid)
            {
                _sog.Create(serviceOffered);
                return RedirectToAction("Index");
            }

            return View(serviceOffered);
        }

        // GET: ServicesOffered/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOffered serviceOffered = _sog.Get(id.Value);
            if (serviceOffered == null)
            {
                return HttpNotFound();
            }
            return View(serviceOffered);
        }

        // POST: ServicesOffered/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Price")] ServiceOffered serviceOffered)
        {
            if (ModelState.IsValid)
            {
                _sog.Update(serviceOffered);
                return RedirectToAction("Index");
            }
            return View(serviceOffered);
        }

        // GET: ServicesOffered/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOffered serviceOffered = _sog.Get(id.Value);
            if (serviceOffered == null)
            {
                return HttpNotFound();
            }
            return View(serviceOffered);
        }

        // POST: ServicesOffered/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceOffered serviceOffered = _sog.Get(id);
            _sog.Remove(serviceOffered);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
