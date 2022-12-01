using System.Collections.Generic;

namespace AdapterTemplate.FileWriter
{
    interface IFileWriter
    {
        bool Write(IEnumerable<string> files);
    }
}
