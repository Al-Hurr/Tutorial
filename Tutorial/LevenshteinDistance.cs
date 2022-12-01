using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial
{
    public class LevenshteinDistance
    {
        public static int GetLevenshteinDistance(string writedStr, string strFromStore)
        {
            if(string.IsNullOrEmpty(writedStr) || string.IsNullOrWhiteSpace(writedStr))
            {
                return -1;
            }
            if(writedStr == strFromStore)
            {
                return 0;
            }

            int l1 = writedStr.Length;
            int l2 = strFromStore.Length;
            int track, t;
            int[,] dist = new int[l2 + 1, l1 + 1];
            for (int i = 0; i <= l1; i++)
            {
                dist[0, i] = i;
            }
            for (int i = 0; i <= l2; i++)
            {
                dist[i, 0] = i;
            }
            for (int j = 1; j <= l1; j++)
            {
                for (int i = 1; i <= l2; i++)
                {
                    if (writedStr[j - 1] == strFromStore[i - 1])
                    {
                        track = 0;
                    }
                    else
                    {
                        track = 1;
                    }
                    t = dist[i - 1, j] + 1 < dist[i, j - 1] + 1 ? dist[i - 1, j] + 1 : dist[i, j - 1] + 1;

                    dist[i, j] = t < dist[i - 1, j - 1] + track ? t : dist[i - 1, j - 1] + track;
                }
            }
            return dist[l2, l1];
        }
    }
}
