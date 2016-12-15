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
    public class AppointmentsController : Controller
    {
        private readonly IGatewayService<Appointment> _ag = new Facade().GetAppointmentGateway();
        private readonly IGatewayService<Hairdresser> _hg = new Facade().GetHairdresserGateway();
        private readonly IGatewayService<Customer> _cg = new Facade().GetCustomerGateway();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = _ag.GetAll(); ;
            return View(appointments);
        }

        // GET: Appointments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = _ag.Get(id.Value);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            var appointment = new Appointment();
            appointment.TimeRange = new TimeRange();
            var model = new ViewModel_CreateAppointment();
            model.Appointment = appointment;
            model.Hairdressers = _hg.GetAll();
            model.Customers = _cg.GetAll();
            return View(model);
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Appointment appointment, int selectedHairdresserID, int selectedCustomerID)//[Bind(Include = "ID")]
        {
            appointment.Hairdresser = new Hairdresser();
            appointment.Hairdresser.ID = selectedHairdresserID;
            appointment.Customer = new Customer();
            appointment.Customer.ID = selectedCustomerID;
            if (ModelState.IsValid)
            {
                _ag.Create(appointment);
               
            }

            return RedirectToAction("Index");
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = _ag.Get(id.Value);
            var model = new ViewModel_CreateAppointment();
            model.Appointment = appointment;
            model.Hairdressers = _hg.GetAll();
            model.Customers = _cg.GetAll();

            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Appointment appointment, int selectedHairdresserID, int selectedCustomerID) //[Bind(Include = "ID")] 
        {
            appointment.Hairdresser = new Hairdresser();
            appointment.Hairdresser.ID = selectedHairdresserID;
            appointment.Customer = new Customer();
            appointment.Customer.ID = selectedCustomerID;
            if (ModelState.IsValid)
            {
                _ag.Update(appointment);
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = _ag.Get(id.Value);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = _ag.Get(id);
            _ag.Remove(appointment);
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

        #region Non-scaffolded
                // GET: Appointments/Edit/5
        public ActionResult ViewHairdressersAppointments(int? id)
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
            //var model = new ViewModel_AHairdressersAppointments();
            //model.HairdresserID = hairdresser.ID;
            //model.HairdresserName = hairdresser.Name;
            //model.Appointments = hairdresser.Appointments;
            //model.WorkingDays = hairdresser.WorkingDays;
            return null; //View();
        }
        #endregion
    }
}
