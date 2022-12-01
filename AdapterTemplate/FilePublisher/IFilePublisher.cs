using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterTemplate.FilePublisher
{
    interface IFilePublisher
    {
        void Publish(IEnumerable<string> files);
    }
}
