using System.Collections.Generic;
using System.IO;

namespace ConverterTSV
{
    public class Statistics
    {
        public string SourceFolder { get; set; }

        private FileTsvCollection _fileTsvCollection;
        public FileTsvCollection FileTsvCollection
        {
            set { this._fileTsvCollection = value; }
            get
            {
                if (_fileTsvCollection == null)
                {
                    this._fileTsvCollection = LoadTsvCollection();
                }
                return this._fileTsvCollection;
            }
        }

        public void BinToTSV(string filePath)
        {
            throw new System.NotImplementedException();
        }

        public Dictionary<string, double> GetStatistics()
        {
            var statistics = new Dictionary<string, double>();
            statistics.Add("AverageLatency", FileTsvCollection.Average("latency_ms"));
            statistics.Add("TotalBandwidth", FileTsvCollection.Sum("bandwidth"));
            return statistics;
        }

        private FileTsvCollection LoadTsvCollection()
        {
            var collection = new FileTsvCollection();

            var parser = new TsvParser
            {
                ValuesToKeep = new List<string> { "latency_ms", "bandwidth" }
            };

            foreach (var file in GetFilesInTsvDirectory(SourceFolder))
            {
                collection.Add(parser.ParseTsvFile(file));
            }
            return collection;
        }

        private IEnumerable<string> GetFilesInTsvDirectory(string folder)
        {
            return Directory.GetFiles(folder, "*.tsv");
        }
    }
}