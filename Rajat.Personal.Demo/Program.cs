using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Rajat.Personal.Demo.DAL;

namespace Rajat.Personal.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            var messages = RequestUrl.Instance.GetMessages(100);
            foreach (var msg in messages)
            {
                using (msg)
                {
                    var result = client.SendAsync(msg).Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var data = result.Content.ReadAsStringAsync().Result;
                        ScrappedData.Instance.SaveToBlob(data);
                    }
                }
            }
        }
    }
}
