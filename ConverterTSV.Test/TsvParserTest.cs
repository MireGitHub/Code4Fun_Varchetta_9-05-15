using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace ConverterTSV.Test
{
    [TestFixture]
    public class TsvParserTest
    {
        private string _folder;

        [SetUp]
        public void Setup()
        {
            _folder = Path.GetFullPath(@"..\..\TestFolder\FilesForTest\");
        }

        [Test]
        public void File_exists_with_values_to_keep()
        {
            throw new System.NotImplementedException();  
        }

        [Test]
        public void File_does_not_exists()
        {
            throw new System.NotImplementedException(); 
        }

        [Test]
        public void File_without_label_to_keep()
        {
            throw new System.NotImplementedException();
        }

        [Test]
        public void File_with_value_not_parsable()
        {
            throw new System.NotImplementedException();
        }
    }
}
