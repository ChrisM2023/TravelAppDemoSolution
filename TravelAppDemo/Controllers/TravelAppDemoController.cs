using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using TravelAppDataAccess.Context;
using TravelAppDataAccess.Model;
using TravelAppDataAccess.Repositories;
using TravelAppDemo.Models;
using static Azure.Core.HttpHeader;

namespace TravelAppDemo.Controllers
{
    public class TravelAppDemoController : Controller
    {
        private readonly TravelAppDemoRepositories _repo;

        public TravelAppDemoController()
        {
            _repo = new TravelAppDemoRepositories();
        }

        public IActionResult Index()
        {
            return View();
<<<<<<< Updated upstream
=======
        }

        public IActionResult Create()
        {
            return View();
>>>>>>> Stashed changes
        }

        [HttpPost]
        public IActionResult CreateOrUpdate(TravelAppDemoViewModel model)
        {
<<<<<<< Updated upstream
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
            TravelAppDemoViewModel model = new TravelAppDemoViewModel(_context,id);

            if (id > 0)
=======
            var id = model.TravelId;
            if(id > 0)
>>>>>>> Stashed changes
            {
                var updateRecord = new TravelAppDemoModel()
                {
                    TravelId = model.TravelId,
                    Activity = model.Activity,
                    HasDone = model.HasDone,
                    Mandatory = model.Mandatory,
                    Description = model.Description,
                    Companion = model.Companion,
                    Destination = model.Destination,
                    Appointment = model.Appointment,
                    Notes = model.Notes
                };
                _repo.Update(updateRecord);
            }
            else
            {
                var newRecord = new TravelAppDemoModel()
                {
                    Activity = model.Activity,
                    HasDone = model.HasDone,
                    Mandatory = model.Mandatory,
                    Description = model.Description,
                    Companion = model.Companion,
                    Destination = model.Destination,
                    Appointment = model.Appointment,
                    Notes = model.Notes
                };
                _repo.Create(newRecord);
            }
            return RedirectToAction("UnCompleted");
        }

        public IActionResult Completed()
        {
<<<<<<< Updated upstream
            TravelAppDemoViewModel model = new TravelAppDemoViewModel(_context,true);
=======
            TravelAppDemoViewModel model = new TravelAppDemoViewModel();
            if (model.Mandatory)
            {
                model.Message = "Yes";
            }
            else
            {
                model.Message = "No";
            }
            model.TravelAppDemosList = GetAllPastRecords();
            model.CurrentTravelAppDemo = model.TravelAppDemosList.FirstOrDefault();
>>>>>>> Stashed changes
            return View(model);
        }

        public IActionResult UnCompleted()
        {
<<<<<<< Updated upstream
            TravelAppDemoViewModel model = new TravelAppDemoViewModel(_context,false);
=======
            TravelAppDemoViewModel model = new TravelAppDemoViewModel();
            if (model.Mandatory)
            {
                model.Message = "Yes";
            }
            else
            {
                model.Message = "No";
            }
            model.TravelAppDemosList = GetAllFutureRecords();
            model.CurrentTravelAppDemo = model.TravelAppDemosList.FirstOrDefault();
            
>>>>>>> Stashed changes
            return View(model);
        }

        public IActionResult Update(int id)
        {
            var eventDetail = _repo.GetAppointmentByID(id);
            TravelAppDemoViewModel model = new TravelAppDemoViewModel();
            model.CurrentTravelAppDemo = eventDetail;

            return View(model);
        }

        public IActionResult DeleteFutureEvents(TravelAppDemoViewModel model)
        {
            var id = model.TravelId;
            if (id > 0)
            {
                _repo.Delete(id);
            }

            return RedirectToAction("UnCompleted");
        }

        public IActionResult DeletePastEvents(TravelAppDemoViewModel model)
        {
            var id = model.TravelId;
            if (id > 0)
            {
                _repo.Delete(id);
            }

            return RedirectToAction("Completed");
        }

        public List<TravelAppDemoModel> GetAllPastRecords()
        {
            TravelAppDemoModel model = new TravelAppDemoModel();
            model.HasDone = true;
            return _repo.GetAll(model).ToList();
        }

        public List<TravelAppDemoModel> GetAllFutureRecords()
        {
            TravelAppDemoModel model = new TravelAppDemoModel();
            model.HasDone = false;
            return _repo.GetAll(model).ToList();
        }
    }
}
