using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vaago.Models;

namespace Vaago.Controllers
{
    public class ReservationsController : Controller
    {

        VaagoProjectEntities DB = new VaagoProjectEntities();
        // GET: Reservations
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Make_Reservation(Reservation reserve)
        {
            if (ModelState.IsValid)
            {
            Reservation obj = new Reservation();
                obj.byName = reserve.byName;
                obj.byEmail = reserve.byEmail;
                obj.byContact = reserve.byContact;
                obj.numberOfPersons = reserve.numberOfPersons;
                obj.reserveDateTime = reserve.reserveDateTime;
                obj.eventType = reserve.eventType;
                obj.byMessage = reserve.byMessage;

                DB.Reservations.Add(obj);
                DB.SaveChanges();
            }
            else
            {
                Console.WriteLine("RESERVATION ERROR!");
            }

                ModelState.Clear(); 

             return View("Index");
        }


    }
}