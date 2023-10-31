using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics;
using System;
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

        }

        public IActionResult Create()
        {
            return View();
        }
     
        [HttpPost]
        public IActionResult Completed(TravelAppDemoViewModel model)
        {
            var id = model.TravelId;

            bool hasDone = false;

            if (model.HasDone.ToLower() == "yes" || model.HasDone.ToLower() == "true")
                hasDone = true;

            if (id > 0)
            {
                var updateRecord = new TravelAppDemoModel()
                {
                    TravelId = model.TravelId,
                    Activity = model.Activity,
                    HasDone = hasDone,
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
                    HasDone = hasDone,
                    Mandatory = model.Mandatory,
                    Description = model.Description,
                    Companion = model.Companion,
                    Destination = model.Destination,
                    Appointment = model.Appointment,
                    Notes = model.Notes
                };
                _repo.Create(newRecord);
            }
            return RedirectToAction("Index");

           
        }
       

     

        public IActionResult Completed()
        {
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

            return View(model);
        }

        public IActionResult UnCompleted()
        {
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
            
            return View(model);
        }
         
        public IActionResult Update(int id)
        {
            TravelAppDemoModel eventDetail = new TravelAppDemoModel();

            if (id > 0)
            {
                 eventDetail = _repo.GetAppointmentByID(id);
            }

            TravelAppDemoViewModel model = new TravelAppDemoViewModel();
            model.CurrentTravelAppDemo = eventDetail;

            return View(model);

        }
        
        public IActionResult DeleteFutureEvents(int id)
        {
           
            if (id > 0)
            {
                _repo.Delete(id);
            }

            return RedirectToAction("UnCompleted");
        }

        public IActionResult Delete(int id)
        {

            return View("Completed");
        }

        public IActionResult DeletePastEvents(int id)
        {
            //var id = model.TravelId;
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
