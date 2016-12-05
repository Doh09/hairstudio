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
    public class HairdressersController : Controller
    {
        private readonly IGatewayService<Hairdresser> _hg = new Facade().GetHairdresserGateway();

        // GET: Hairdressers
        public ActionResult Index()
        {
            var hairdressers = _hg.GetAll();
            return View(hairdressers);
        }

        // GET: Hairdressers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hairdresser hairdresser = _hg.Get(id.Value);
            if (hairdresser == null)
            {
                return HttpNotFound();
            }
            return View(hairdresser);
        }

        // GET: Hairdressers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hairdressers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Username,Password,Name,PhoneNumber,Email,UserType")] Hairdresser hairdresser)
        {
            if (ModelState.IsValid)
            {
                _hg.Create(hairdresser);
                return RedirectToAction("Index");
            }

            return View(hairdresser);
        }

        // GET: Hairdressers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hairdresser hairdresser = _hg.Get(id.Value);
            if (hairdresser == null)
            {
                return HttpNotFound();
            }
            return View(hairdresser);
        }

        // POST: Hairdressers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]//TODO Skal nok være "put" ikke "post"
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Password,Name,PhoneNumber,Email,UserType")] Hairdresser hairdresser)
        {
            if (ModelState.IsValid)
            {
                _hg.Update(hairdresser);
                return RedirectToAction("Index");
            }
            return View(hairdresser);
        }

        // GET: Hairdressers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hairdresser hairdresser = _hg.Get(id.Value);
            if (hairdresser == null)
            {
                return HttpNotFound();
            }
            return View(hairdresser);
        }

        // POST: Hairdressers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hairdresser hairdresser = _hg.Get(id);

            _hg.Remove(hairdresser);
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
