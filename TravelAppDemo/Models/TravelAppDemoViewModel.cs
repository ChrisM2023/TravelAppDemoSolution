
using TravelAppDataAccess.Context;
using TravelAppDataAccess.Model;
using TravelAppDataAccess.Repositories;

namespace TravelAppDemo.Models
{
    public class TravelAppDemoViewModel
    {
        public int TravelId { get; set; }
        public string Activity { get; set; }
        public bool HasDone { get; set; }
        public bool Mandatory { get; set; }
        public string Description { get; set; }
        public string Companion { get; set; }
        public string Message { get; set; }
        public string Destination { get; set; }
        public DateTime Appointment { get; set; }
        public string Notes { get; set; }
        public List<TravelAppDemoModel> TravelAppDemosList { get; set; }
        public TravelAppDemoModel CurrentTravelAppDemo { get; set; }
<<<<<<< Updated upstream
        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }
        public TravelAppDemoViewModel(TravelAppDemoContext configuration,bool completed)
        {
            _configuration = new TravelAppDemoRepositories(configuration);
            TravelAppDemosList = GetAllTravelAppDemoByCompleted(completed);
            CurrentTravelAppDemo = TravelAppDemosList.FirstOrDefault();
        }  public TravelAppDemoViewModel(TravelAppDemoContext configuration)
=======
        

/*
        public TravelAppDemoViewModel(TravelAppDemoContext configuration)
>>>>>>> Stashed changes
        {
            _configuration = new TravelAppDemoRepositories(configuration);
            TravelAppDemosList = GetAllTravelAppDemo();
            CurrentTravelAppDemo = TravelAppDemosList.FirstOrDefault();
        }

        public List<TravelAppDemoModel>? GetAllTravelAppDemo()
        {
            return _configuration.GetAllAppointments();
        }

        public TravelAppDemoViewModel(TravelAppDemoContext configuration, int TravelId)
        {
            _configuration = new TravelAppDemoRepositories(configuration);
            TravelAppDemosList = new List<TravelAppDemoModel>();
            if (TravelId > 0)
            {
                CurrentTravelAppDemo = GetTravelAppDemo(TravelId);

            }
            else
            {
                CurrentTravelAppDemo = new TravelAppDemoModel();
            }
             List<TravelAppDemoModel> GetAllTravelAppDemo()
            {
                return _configuration.GetAllAppointments();

            }
            TravelAppDemoModel GetTravelAppDemo(int TravelId)
            {
                return _configuration.GetAppointmentByID(TravelId);
            }
        }

        public void RemoveAppoinment(int id)
        {
            _configuration.Delete(id);
            TravelAppDemosList = GetAllTravelAppDemo();
            CurrentTravelAppDemo = TravelAppDemosList.FirstOrDefault();
        }

        public void SaveAppointment(TravelAppDemoModel models)
        {
            if (models.TravelId > 0)
            {
                _configuration.Update(models);
            }
            else
            {
                models.TravelId = _configuration.Create(models);
            }
            TravelAppDemosList = GetAllTravelAppDemo();
            CurrentTravelAppDemo = GetTravelAppDemo(models.TravelId);
        }


        public TravelAppDemoModel GetTravelAppDemo(int travelId)
        {
            return _configuration.GetAppointmentByID(travelId);   
        }
<<<<<<< Updated upstream
        IQueryable<TravelAppDemoModel> GetAllTravelAppDemoByCompleted(bool isCompleted)
=======

        public List<TravelAppDemoModel> GetAllTravelAppDemoByCompleted(bool isCompleted)
>>>>>>> Stashed changes
        {
            return _configuration.GetAll(isCompleted).ToList();

        }
*/
    }
}
