using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Console.Parsers
{
    public static class PositionParser
    {
        public static string RawPositionParser(string rawPosition)
        {
            // TODO: maybe use patern matching to check the data types of each part of the input
            if (string.IsNullOrEmpty(rawPosition)) return "";

            if (rawPosition.Length == 5)
            {
                if (rawPosition[0] == '1' &&  rawPosition[2] == '2' && rawPosition[4] == 'N')
                {
                    return rawPosition;
                }
            }

            return "";
        }
    }
}