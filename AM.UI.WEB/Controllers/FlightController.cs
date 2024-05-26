using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.UI.WEB.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight serviceFlight;
        IServicePlane servicePlane;
        public FlightController (IServiceFlight serviceFlight, IServicePlane servicePlane)
        {
            this.serviceFlight = serviceFlight;
            this.servicePlane = servicePlane;
        }
        // GET: FlightController_
        public ActionResult Index(DateTime? dateDepart)
        {
            if(dateDepart == null)
            {
                return View(serviceFlight.GetAll().ToList());
            }
            else
                return View(serviceFlight.
                    GetMany(f => f.FlightDate == dateDepart));
        }

        //sort
        public ActionResult Sort()
        {
            return View("Index", serviceFlight.SortFlights());
        }

        // GET: FlightController_/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController_/Create
        public ActionResult Create()
        {
            ViewBag.Planes = new SelectList(servicePlane.GetAll(), "PlaneId", "PlaneId");
            return View();
        }

        // POST: FlightController_/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight,IFormFile PiloteImage)
        {
            try
            {
                if(PiloteImage != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",PiloteImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PiloteImage.CopyTo(stream);
                    flight.Pilot = PiloteImage.FileName;
                }
                serviceFlight.Add(flight);
                serviceFlight.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController_/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController_/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController_/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController_/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
