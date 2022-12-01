using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTemplate.FileWriter
{
    public class TextFileWriter : IFileWriter
    {
        public string Path { get; init; }

        public TextFileWriter(string path)
        {
            this.Path = path;
        }

        public bool Write(IEnumerable<string> files)
        {
            try
            {
                Console.WriteLine($"Вызов метода {nameof(Write)} класса {nameof(TextFileWriter)}");
                File.WriteAllLines(this.Path, files);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine( ex.Message);
                return false;
            }
        }
    }
}
