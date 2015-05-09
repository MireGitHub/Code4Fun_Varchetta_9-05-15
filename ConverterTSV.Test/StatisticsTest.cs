using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace ConverterTSV.Test
{
    [TestFixture]
    public class StatisticsTest
    {
        private Statistics _statistics;
        private Dictionary<string, double> _result;

        [SetUp]
        public void Setup()
        {
            _statistics = new Statistics
            {
                SourceFolder = Path.GetFullPath(@"..\..\TestFolder"),
                FileTsvCollection = new FileTsvCollection()
            };
        }

        [Test]
        public void Average_of_two_values()
        {
            _statistics.FileTsvCollection.Clear();
            FileTsvCollection collection = new FileTsvCollection();
            collection.Add(new FileTsv { { "latency_ms", 1 } });
            collection.Add(new FileTsv { { "latency_ms", 2 } });
            collection.Add(new FileTsv { { "bandwidth", 1 } });
            collection.Add(new FileTsv { { "bandwidth", 2 } });
            _statistics.FileTsvCollection = collection;

            _result = _statistics.GetStatistics();

            Assert.That(_result["AverageLatency"], Is.Positive);
            Assert.That(_result["AverageLatency"], Is.EqualTo(1.5));

            Assert.That(_result["TotalBandwidth"], Is.Positive);
            Assert.That(_result["TotalBandwidth"], Is.EqualTo(3));
        }

        [Test]
        public void Average_of_zero_values()
        {
            _statistics.FileTsvCollection.Clear();
            FileTsvCollection collection = new FileTsvCollection();
            collection.Add(new FileTsv { { "bandwidth", 1 } });
            collection.Add(new FileTsv { { "bandwidth", 2 } });
            _statistics.FileTsvCollection = collection;

            Assert.Throws<InvalidOperationException>(
                    delegate { _result = _statistics.GetStatistics(); });

            Assert.That(_result["TotalBandwidth"], Is.Positive);
            Assert.That(_result["TotalBandwidth"], Is.EqualTo(3));
        }

        [Test]
        public void Sum_of_zero_values()
        {
            _statistics.FileTsvCollection.Clear();
            FileTsvCollection collection = new FileTsvCollection();
            collection.Add(new FileTsv { { "latency_ms", 1 } });
            collection.Add(new FileTsv { { "latency_ms", 2 } });
            _statistics.FileTsvCollection = collection;

            _result = _statistics.GetStatistics();

            Assert.That(_result["AverageLatency"], Is.Positive);
            Assert.That(_result["AverageLatency"], Is.EqualTo(1.5));

            Assert.That(_result["TotalBandwidth"], Is.EqualTo(0));
        }

        [Test]
        public void Statistics_with_no_values()
        {
            Assert.Throws<InvalidOperationException>(
                    delegate { _result = _statistics.GetStatistics(); });
        }

    }
}
