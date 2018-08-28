using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rajat.Personal.Demo.DAL
{
    /// <summary>
    /// Singleton Alert: Should not have any class level variable / Property
    /// </summary>
    public sealed class RequestUrl
    {
        private int startIndex = 0;
        private static Lazy<RequestUrl> lazy = new Lazy<RequestUrl>(() => new RequestUrl());
        public static RequestUrl Instance { get { return lazy.Value; } }
        private RequestUrl() { }
        public IEnumerable<HttpRequestMessage> GetMessages(int take)
        {
            var uris = ReadData(100);
            var messages = new List<HttpRequestMessage>();
            foreach (var uri in uris)
            {
                HttpRequestMessage msg = new HttpRequestMessage();
                Uri parsedUri;
                Uri.TryCreate(uri, UriKind.Absolute, out parsedUri);
                msg.RequestUri = parsedUri;
                msg.Method = HttpMethod.Get;
                messages.Add(msg);
            }
            return messages;
        }

        private IEnumerable<string> ReadData(int take)
        {
            List<string> listA = new List<string>();
            int currentLine = 0;
            using (var reader = new StreamReader(@"F:\C2ImportCalEventSample.csv"))
            {
                while (!reader.EndOfStream)
                {
                    if(listA.Count < take)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        if(currentLine > startIndex)
                        {
                            //Add to list
                        }
                    }
                }
            }
            startIndex = startIndex + take + 1;
            return listA;
        }
    }
}
