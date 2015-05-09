using System.Collections.ObjectModel;
using System.Linq;

namespace ConverterTSV
{
    public class FileTsvCollection : Collection<FileTsv>
    {
        public double Average(string key)
        {
            var result = (from item in Items
                          where item.ContainsKey(key)
                          select item[key]).Average();
            return result;
        }

        public int Sum(string key)
        {
            var result = (from item in Items
                          where item.ContainsKey(key)
                          select item[key]).Sum();
            return result;
        }
    }
}
