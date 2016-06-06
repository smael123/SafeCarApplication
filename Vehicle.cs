using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeCarApplication
{
    class Vehicle
    {
        public string OverallRating { get; set; }
        public string OverallFrontCrashRating { get; set; }
        public string FrontCrashDriversideRating { get; set; }
        public string FrontCrashPassengersideRating { get; set; }
        public string OverallSideCrashRating { get; set; }
        public string SideCrashDriversideRating { get; set; }
        public string SideCrashPassengersideRating { get; set; }
        public string RolloverRating { get; set; }
        public string RolloverRating2 { get; set; }
        public float RolloverPossibility { get; set; }
        public float RolloverPossibility2 { get; set; }
        public string SidePoleCrashRating { get; set; }
        public string NHTSAElectronicStabilityControl { get; set; }
        public int ComplaintsCount { get; set; }
        public int RecallsCount { get; set; }
        public int InvestigationCount { get; set; }
        public int ModelYear { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string VehicleDescription { get; set; }
        public int VehicleId { get; set; }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder(); //faster appending operations

            str.AppendFormat("Year: {0}\nMake: {1}\nModel: {2}\nVehicle ID: {3}\n\n", ModelYear, Make, Model, VehicleId);

            str.AppendFormat("Overall Rating: {0}\n", OverallRating);
            str.AppendFormat("Overall Front Crash Rating: {0}\n", OverallFrontCrashRating);
            str.AppendFormat("Front Crash driver side Rating: {0}\n", FrontCrashDriversideRating);
            str.AppendFormat("Overall Side Crash Rating: {0}\n", OverallSideCrashRating);
            str.AppendFormat("Side Crash Driverside Rating: {0}\n", SideCrashDriversideRating);
            str.AppendFormat("Side Crash passenger side Rating: {0}\n", SideCrashPassengersideRating);
            str.AppendFormat("Rollover Rating 1: {0}\n", RolloverRating);
            str.AppendFormat("Rollover Rating 2: {0}\n", RolloverRating2);
            str.AppendFormat("Rollover Possibility 1: {0}\n", RolloverPossibility);
            str.AppendFormat("Rollover Possibility 2: {0}\n", RolloverPossibility2);
            str.AppendFormat("Side Pole Crash Rating: {0}\n", SidePoleCrashRating);
            str.AppendFormat("NHTSA Electronic Stability Control: {0}\n", NHTSAElectronicStabilityControl);
            str.AppendFormat("Complaints count: {0}\n", ComplaintsCount);
            str.AppendFormat("Recalls Count: {0}\n", RecallsCount);
            str.AppendFormat("Investigation Count: {0}\n", InvestigationCount);

            return str.ToString();
        }
    }
}
