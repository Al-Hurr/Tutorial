using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    public class Model
    {
        public int Id { get; set; }
        public int MessageCount { get; set; }
        public bool ReceivedNotification { get; set; }

        public Tuple<List<string>, List<Model>> SendMessage(List<Model> students)
        {
            List<string> response = new List<string>();
            int messageCount = 0;
            foreach (var st in students)
            {
                if (this.Id == st.Id || st.ReceivedNotification)
                    continue;

                if (messageCount == MessageCount)
                    break;
                
                response.Add($"{this.Id} - {st.Id}");
                st.ReceivedNotification = true;
                messageCount++;
            }
            return new Tuple<List<string>, List<Model>>(response, students);
        }
    }
}
