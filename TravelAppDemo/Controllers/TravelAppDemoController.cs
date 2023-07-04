using Microsoft.AspNetCore.Mvc;
using TravelAppDataAccess.Context;
using TravelAppDataAccess.Model;
using TravelAppDemo.Models;
using static Azure.Core.HttpHeader;

namespace TravelAppDemo.Controllers
{
    public class TravelAppDemoController : Controller
    {
        private readonly TravelAppDemoContext _context;

        public TravelAppDemoController(TravelAppDemoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            TravelAppDemoViewModel model = new TravelAppDemoViewModel(_context);
            return View(model);
        }
        

        [HttpPost]
        public IActionResult Index(int travelId, string activity, bool hasDone,
            bool mandatory, string description, string companion,
            string destination, DateTime appointment,string notes)
        {
            TravelAppDemoViewModel model = new TravelAppDemoViewModel(_context);

            TravelAppDemoModel travelAppDemo = new( travelId,  activity,  hasDone,
             mandatory,  description,  companion,
             destination,  appointment,notes);

            model.SaveAppointment(travelAppDemo);
            model.IsActionSuccess = true;
            model.ActionMessage = "Appointment has been saved successfully";

            return View(model);
        }
        public IActionResult Update(int id)
        {
            TravelAppDemoViewModel model = new TravelAppDemoViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            TravelAppDemoViewModel model = new TravelAppDemoViewModel(_context);

            if (id > 0)
            {
                model.RemoveAppoinment(id);
            }

            model.IsActionSuccess = true;
            model.ActionMessage = "Appoinment has been deleted successfully";
            return View("Index", model);
        }
        public IActionResult Completed()
        {
            TravelAppDemoViewModel model = new TravelAppDemoViewModel(_context);
            model.CurrentTravelAppDemo.HasDone = true;
            return View(model);
        }
        public IActionResult UnCompleted()
        {
            TravelAppDemoViewModel model = new TravelAppDemoViewModel(_context);
            model.CurrentTravelAppDemo.HasDone = false;
            return View(model);
        }
    }
}
