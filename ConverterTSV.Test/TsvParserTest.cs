using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace ConverterTSV.Test
{
    [TestFixture]
    public class TsvParserTest
    {
        private TsvParser _parser;
        private FileTsv _result;
        private string _folder;

        [SetUp]
        public void Setup()
        {
            _parser = new TsvParser();
            _folder = Path.GetFullPath(@"..\..\TestFolder\FilesForTest\");
        }

        [Test]
        public void File_exists_with_values_to_keep()
        {
            _parser.ValuesToKeep = new List<string> { "latency_ms", "bandwidth" };
            string fileToParse = _folder + "CorrectFile.tsv";
            _result = _parser.ParseTsvFile(fileToParse);

            Assert.That(_result["latency_ms"], Is.Not.Null);
            Assert.That(_result["latency_ms"], Is.EqualTo(70));

            Assert.That(_result["bandwidth"], Is.Not.Null);
            Assert.That(_result["bandwidth"], Is.EqualTo(20));
        }

        [Test]
        public void Take_values_without_values_to_keep()
        {
            _parser.ValuesToKeep = null;
            string fileToParse = _folder + "CorrectFile.tsv";
            _result = _parser.ParseTsvFile(fileToParse);

            Assert.That(_result["latency_ms"], Is.Not.Null);
            Assert.That(_result["latency_ms"], Is.EqualTo(70));

            Assert.That(_result["bandwidth"], Is.Not.Null);
            Assert.That(_result["bandwidth"], Is.EqualTo(20));
        }

        [Test]
        public void File_does_not_exists()
        {
            string fileToParse = _folder + "InexistentFile.tsv";

            Assert.Throws<IOException>(
                    delegate { _result = _parser.ParseTsvFile(fileToParse); });
        }

        [Test]
        public void File_without_label_to_keep()
        {
            string fileToParse = _folder + "WrongLabel.tsv";
            _result = _parser.ParseTsvFile(fileToParse);

            Assert.That(_result.ContainsKey("latency_ms"), Is.False);
            Assert.That(_result.ContainsKey("bandwidth"), Is.False);
        }

        [Test]
        public void File_with_value_not_parsable()
        {
            string fileToParse = _folder + "WrongValue.tsv";

            Assert.Throws<FormatException>(
                    delegate { _result = _parser.ParseTsvFile(fileToParse); });
        }

       
    }
}
