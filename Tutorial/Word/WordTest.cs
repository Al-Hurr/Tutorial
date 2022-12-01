using Aspose.Words;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial.Word
{
    static public class WordTest
    {
        static public void Prepare()
        {
            string _myDir = @"C:\Users\Азат\Desktop\azat\TODO\";
            using (Stream stream = File.OpenRead(_myDir + "teest.docx"))
            {
                Document doc = new Document(stream);
            }
        }
    }
}
