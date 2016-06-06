using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeCarApplication
{
    class JSON_Root
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public Vehicle[] results { get; set; }

        public List<int> getYears()
        {
            List<int> yearList = new List<int>();

            foreach (Vehicle obj in results)
            {
                yearList.Add(obj.ModelYear);
            }

            return yearList;
        }
        public List<string> getMakes()
        {
            List<string> makeList = new List<string>();

            foreach (Vehicle obj in results)
            {
                makeList.Add(obj.Make);
            }

            return makeList;
        }
        public List<string> getModels()
        {
            List<string> modelList = new List<string>();

            foreach (Vehicle obj in results)
            {
                modelList.Add(obj.Model);
            }

            return modelList;
        }

        public Dictionary<string, int> getVariants()
        {
            Dictionary<string, int> variantDict = new Dictionary<string, int>();

            foreach (Vehicle obj in results)
            {
                variantDict.Add(obj.VehicleDescription, obj.VehicleId);
            }

            return variantDict;
        }

        public Vehicle getResult()
        {
            return results[0];
        }
    }
}
