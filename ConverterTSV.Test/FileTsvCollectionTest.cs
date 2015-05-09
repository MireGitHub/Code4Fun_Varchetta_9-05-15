using NUnit.Framework;

namespace ConverterTSV.Test
{
    [TestFixture]
    public class FileTsvCollectionTest
    {
        private FileTsvCollection _collection;
        private int _resultSum;
        private double _resultAverage;

        [SetUp]
        public void Setup()
        {
            _collection = new FileTsvCollection();
        }

        [Test]
        public void Average_of_two_values()
        {
            _collection.Clear();
            _collection.Add(new FileTsv { { "latency_ms", 1 } });
            _collection.Add(new FileTsv { { "latency_ms", 2 } });
            _resultAverage = _collection.Average("latency_ms");

            Assert.That(_resultAverage, Is.Positive);
            Assert.That(_resultAverage, Is.EqualTo(1.5));
        }

        [Test]
        public void Sum_of_two_values()
        {
            _collection.Clear();
            _collection.Add(new FileTsv { { "bandwidth", 1 } });
            _collection.Add(new FileTsv { { "bandwidth", 2 } });
            _resultSum = _collection.Sum("bandwidth");

            Assert.That(_resultSum, Is.Positive);
            Assert.That(_resultSum, Is.EqualTo(3));
        }
    }
}