using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rajat.Personal.Demo.DAL
{
    /// <summary>
    /// Singleton Alert: Should not have any class level variable / Property
    /// </summary>
    public class ScrappedData
    {
        private static Lazy<ScrappedData> lazy = new Lazy<ScrappedData>(() => new ScrappedData());
        public static ScrappedData Instance { get { return lazy.Value; } }
        private ScrappedData() { }
        public void SaveToBlob(string data)
        {
            //Add Code to Save to Blob
        }
    }
}
