using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTemplate.FilePublisher
{
    public class DefaultPublisher : IFilePublisher
    {
        public void Publish(IEnumerable<string> files)
        {
            Console.WriteLine($"Вывод элементов коллекции {nameof(files)}");

            foreach (var item in files)
            {
                Console.WriteLine(item);
            }
        }
    }
}
