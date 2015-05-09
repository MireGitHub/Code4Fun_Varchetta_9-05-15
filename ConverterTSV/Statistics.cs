using System.Collections.Generic;

namespace ConverterTSV
{
    public class Statistics
    {
        public string SourceFolder { get; set; }
        public FileTsvCollection FileTsvCollection { get; set; }

        public void BinToTSV(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, double> GetStatistics()
        {
            throw new System.NotImplementedException();
        }
    }
}
