using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Azure.Core.HttpHeader;


namespace TravelAppDataAccess.Model
{
    public class TravelAppDemoModel
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
        public  string Notes { get; set; }

        public TravelAppDemoModel(int travelId, string activity, bool hasDone, 
            bool mandatory, string description, string companion,
            string destination, DateTime appointment,string notes)
        {
            this.TravelId = travelId;
            this.Activity = activity;
            this.HasDone = hasDone;
            this.Mandatory = mandatory;
            this.Description = description;
            this.Companion = companion;
            
            this.Destination = destination;
            this.Appointment = appointment;
            this.Notes = notes;



        }
        public TravelAppDemoModel()
        {

        }
    }
}
