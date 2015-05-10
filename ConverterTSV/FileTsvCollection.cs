using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConverterTSV
{
    public class FileTsvCollection : Collection<FileTsv>
    {
        public double Average(string key)
        {
            return TryGetAndParseDoubleCollection(key).Average();
        }

        public double Sum(string key)
        {
            return TryGetAndParseDoubleCollection(key).Sum();
        }

        private IEnumerable<double> TryGetAndParseDoubleCollection(string key)
        {
            IEnumerable<double> result;
            try
            {
                result = from item in Items
                         where item.ContainsKey(key)
                         select double.Parse(item[key]);
            }
            catch (FormatException e)
            {
                throw new FormatException(String.Format("Cannot parse as double some value for label '{0}'", key));
            }

            return result;
        }
    }
}
