using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace ConverterTSV.Test
{
    [TestFixture]
    public class StatisticsFunctionalTest
    {

        private Statistics _statistics;
        private Dictionary<string, double> _result;


        [Test]
        public void Folder_with_correct_files()
        {
            _statistics = new Statistics
            {
                SourceFolder = Path.GetFullPath(@"..\..\TestFolder\OnlyCorrectFiles")
            };

            _result = _statistics.GetStatistics();

            Assert.That(_result["AverageLatency"], Is.Positive);
            Assert.That(_result["AverageLatency"], Is.EqualTo(70));

            Assert.That(_result["TotalBandwidth"], Is.Positive);
            Assert.That(_result["TotalBandwidth"], Is.EqualTo(45));
        }

        [Test]
        public void Folder_with_no_correct_files()
        {
            _statistics = new Statistics
            {
                SourceFolder = Path.GetFullPath(@"..\..\TestFolder\FilesForTest")
            };

            Assert.Throws<FormatException>(
                    delegate { _result = _statistics.GetStatistics(); });
        }

    }
}