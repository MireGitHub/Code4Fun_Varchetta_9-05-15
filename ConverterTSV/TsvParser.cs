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
            string[] values = new string[] { };

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

                    values = line.Split(Separator);

                    if (ValuesToKeep == null)
                    {
                        file.Add(values[0], int.Parse(values[1]));
                    }
                    else if (ValuesToKeep.Contains(values[0]))
                    {
                        file.Add(values[0], int.Parse(values[1]));
                    }
                }
            }
            catch (IOException e)
            {
                throw new IOException(e.Message);
            }
            catch (FormatException e)
            {
                throw new FormatException(String.Format("Cannot parse value '{0}' for label '{1}'", values[1], values[0]));
            }

            return file;
        }
    }
}
