using System;
using System.Collections.Generic;
using System.IO;

namespace ConverterTSV
{
    public class TsvParser
    {
        public List<string> ValuesToKeep { get; set; }
        private const char Separator = '\t';

        public FileTsv ParseTsvFile(string filePath)
        {
            var file = new FileTsv();

            try
            {
                var reader = new StreamReader(filePath);

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    string[] values = line.Split(Separator);

                    if (values.Length < 2)
                    {
                        throw new FormatException(String.Format("The key '{0}' has no value.", values[0]));
                    }

                    if (ValuesToKeep == null)
                    {
                        file.Add(values[0], values[1]);
                    }
                    else if (ValuesToKeep.Contains(values[0]))
                    {
                        file.Add(values[0], values[1]);
                    }
                }
            }
            catch (IOException e)
            {
                throw new IOException(e.Message);
            }

            return file;
        }
    }
}
