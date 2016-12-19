using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hairstudio_DLL;
using Hairstudio_DLL.Entities;
using Hairstudio_MVC.Models;

namespace Hairstudio_MVC.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IGatewayService<Message> _mg = new Facade().GetMessageGateway();

        // GET: Messages
        [HttpGet]
        public ActionResult Index()
        {
            var messages = _mg.GetAll();
            return View(messages);
        }

        // GET: Messages/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = _mg.Get(id.Value);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Description")] Message message)
        {
            if (ModelState.IsValid)
            {
                _mg.Update(message);
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: ServicesOffered/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServicesOffered/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Description")] Message message)
        {
            if (ModelState.IsValid)
            {
                message.AreaMessageIsUsed = "imgcarousel";
                _mg.Create(message);
            }

            return RedirectToAction("Index");
        }

        // GET: ServicesOffered/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = _mg.Get(id.Value);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: ServicesOffered/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = _mg.Get(id);
            _mg.Remove(message);
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
