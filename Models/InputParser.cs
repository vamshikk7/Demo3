using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.Models
{
    internal class InputParser
    {
        public static Tuple<TemperatureType, List<int>> Parse(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Invalid inputs");
            }
            TemperatureType temperatureType = Enum.Parse<TemperatureType>(args[0], true);
            List<int> commandsList = args[1].Split(',').Select(x => int.Parse(x)).ToList();

            return new Tuple<TemperatureType, List<int>>(temperatureType, commandsList);
        }
    }
}