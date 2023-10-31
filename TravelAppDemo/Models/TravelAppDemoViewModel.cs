
using TravelAppDataAccess.Context;
using TravelAppDataAccess.Model;
using TravelAppDataAccess.Repositories;

namespace TravelAppDemo.Models
{
    public class TravelAppDemoViewModel
    {
        public int TravelId { get; set; }
        public string Activity { get; set; }
        public string HasDone { get; set; }
        public bool Mandatory { get; set; }
        public string Description { get; set; }
        public string Companion { get; set; }
        public string Message { get; set; }
        public string Destination { get; set; }
        public DateTime Appointment { get; set; }
        public string Notes { get; set; }
        public List<TravelAppDemoModel> TravelAppDemosList { get; set; }
        public TravelAppDemoModel CurrentTravelAppDemo { get; set; }

        public bool IsActionSuccess { get; set; }
        public string ActionMessage { get; set; }
      

       
    }
}
