using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAppDataAccess.Context;
using TravelAppDataAccess.Model;

namespace TravelAppDataAccess.Repositories
{
    public class TravelAppDemoRepositories
    {
        private readonly TravelAppDemoContext _context;
        public TravelAppDemoRepositories()
        {
            _context = new TravelAppDemoContext();
        }
        public int Create(TravelAppDemoModel travelAppDemoModels)
        {
            _context.Add(travelAppDemoModels);
            _context.SaveChanges();
            return travelAppDemoModels.TravelId;
        }
        public void Update(TravelAppDemoModel travelAppDemoModel)
        {
            TravelAppDemoModel existingAppointment = _context.TravelAppDemoModel.Find(travelAppDemoModel.TravelId)!;

            existingAppointment.Activity = travelAppDemoModel.Activity;
            existingAppointment.HasDone = travelAppDemoModel.HasDone;
            existingAppointment.Mandatory = travelAppDemoModel.Mandatory;
            existingAppointment.Description = travelAppDemoModel.Description;
            existingAppointment.Companion = travelAppDemoModel.Companion;
            existingAppointment.Destination = travelAppDemoModel.Destination;
            existingAppointment.Appointment = travelAppDemoModel.Appointment;
          
            _context.SaveChanges();
        }
        public void Delete(int travelId)
        {
            TravelAppDemoModel existingAppointment = _context.TravelAppDemoModel.Find(travelId)!;
            _context.Remove(existingAppointment);
            _context.SaveChanges();

        }
        public List<TravelAppDemoModel> GetAllAppointments()
        {
            return _context.TravelAppDemoModel.ToList();
        }
        public TravelAppDemoModel GetAppointmentByID(int id)
        {
            return _context.TravelAppDemoModel.Find(id)!;
        }
        public IQueryable<TravelAppDemoModel> GetAll(TravelAppDemoModel model)
        {
            return _context.Set<TravelAppDemoModel>()
                .Where(x =>
                                x.HasDone == model.HasDone

                             );
        }
    } 
}
