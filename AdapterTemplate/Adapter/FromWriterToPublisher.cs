using AdapterTemplate.FilePublisher;
using AdapterTemplate.FileWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTemplate.Adapter
{
    class FromWriterToPublisher : IFileWriter
    {
        private IFilePublisher _filePublisher;

        public FromWriterToPublisher(IFilePublisher filePublisher)
        {
            this._filePublisher = filePublisher;
        }

        public bool Write(IEnumerable<string> files)
        {
            try
            {
                Console.WriteLine($"Вызов метода {nameof(Write)} класса {nameof(FromWriterToPublisher)}");
                _filePublisher.Publish(files);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
