using AdapterTemplate.FileWriter;
using System;
using System.Collections.Generic;

namespace AdapterTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            //WarZone.

            Console.ReadLine();
        }
    }

    class SampleClassUsingIFileWriterInterface
    {
        private IFileWriter _fileWriter;

        public SampleClassUsingIFileWriterInterface(IFileWriter fileWriter)
        {
            this._fileWriter = fileWriter;
        }

        public void Run(int iterationCount)
        {
            var data = this.GenerateData(iterationCount);
            var result = this._fileWriter.Write(data);
            Console.WriteLine(result ? "Success" : "Fail");
        }

        private IEnumerable<string> GenerateData(int iterationCount)
        {
            var data = new List<string>();
            for(int i = 0; i < iterationCount; i++)
            {
                data.Add(Guid.NewGuid().ToString());
            }
            return data;
        }
    }
}
