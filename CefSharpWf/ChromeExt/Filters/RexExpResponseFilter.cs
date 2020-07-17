using CefSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CefSharpWf.ChromeExt.Filters
{
    public class RexExpResponseFilter : IResponseFilter
    {        
        private List<byte> overflow = new List<byte>();

        bool IResponseFilter.InitFilter()
        {            
            return true;
        }
        private List<KeyValuePair<string, string>> dictionary;

        public RexExpResponseFilter(List<KeyValuePair<string, string>> dictionary)
        {
            this.dictionary = dictionary;
        }

		FilterStatus IResponseFilter.Filter(Stream dataIn, out long dataInRead, Stream dataOut, out long dataOutWritten)
        {            
            if (dataIn == null)
            {
                dataInRead = 0;
                dataOutWritten = 0;

                if(overflow.Count > 0)
                {
                    dataOutWritten = Math.Min(overflow.Count, dataOut.Length);
                    dataOut.Write(overflow.ToArray(), 0, (int)dataOutWritten);

                    if(dataOutWritten < overflow.Count)
                    {
                        overflow.RemoveRange(0, (int)(dataOutWritten - 1));
                        return FilterStatus.NeedMoreData;
                    }
                    else
                    {
                        overflow.Clear();
                        return FilterStatus.Done;
                    }
                }

                return FilterStatus.Done;
                
            }

            dataInRead = dataIn.Length;            

            StreamReader reader = new StreamReader(dataIn, Encoding.UTF8);
            string dataInStr = reader.ReadToEnd();

            Console.WriteLine($"=====================================================================\n" +
                              $"{dataInStr}" +
                              $"=====================================================================\n");

            foreach (var item in dictionary)
            {
                dataInStr = Regex.Replace(dataInStr, item.Key, item.Value, RegexOptions.IgnoreCase);                  
            }

            byte[] messageBytes = Encoding.UTF8.GetBytes(dataInStr);

            dataOutWritten = Math.Min(messageBytes.Length, dataOut.Length);            
            dataOut.Write(messageBytes, 0, (int)dataOutWritten);
           
            if(dataOutWritten < messageBytes.Length)
            {                
                overflow = messageBytes.ToList();
                overflow.RemoveRange(0, (int)(dataOutWritten - 1));

                return FilterStatus.NeedMoreData;
            }
            
            return FilterStatus.Done;
        }

        void IDisposable.Dispose()
        {            
        }
        
    }
}
