using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XCI
{
    internal class apiloaddailydataset
    {
        public static string[] dats;
        public string typeX;
        public string typeY;
        public string typeZ;
        public int typeT;
        public apiloaddailydataset(string x1, string x2, string x3, int term){
            typeX = x1;
            typeY = x2;
            typeZ = x3;
            typeT = term;
        }
        public Newtonsoft.Json.Linq.JObject dataticc(string symbol)
        {
            string url1 = "https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=";
            string url2 = "&interval=1min&outputsize=full&apikey=IO3FRU8KYS34PD06";
            string url3 = url1 + symbol + url2;
            var webRequest = System.Net.WebRequest.Create(new Uri(url3));
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json";

            //Get the response 
            System.Net.WebResponse wr = webRequest.GetResponseAsync().Result;
            System.IO.Stream receiveStream = wr.GetResponseStream();
            System.IO.StreamReader reader = new System.IO.StreamReader(receiveStream);

            string resp = reader.ReadToEnd();
            Newtonsoft.Json.Linq.JObject jobj = Newtonsoft.Json.Linq.JObject.Parse(resp);
            return jobj;
        }
        public string[] pricelst()
        {
            Newtonsoft.Json.Linq.JObject temp = dataticc(typeZ);
            List<string> newda = new List<string>();
            List<string> stx = new List<string>();
            int i = 0;
            DateTime now = DateTime.Now;
            for (i =1; i<4000; i++)
            {
                DateTime now1 = now.AddDays((-1)*i);
                string stw = now1.ToString("yyyy-MM-dd");
                try
                {
                    newda.Add(temp[typeX][stw][typeY].ToString());
                    stx.Add(stw.ToString());
                }
                catch{}
            }

            

            stx.Reverse();
            dats = stx.ToArray();
            // newda.Reverse();

            string[] strs = newda.ToArray();

            // MessageBox.Show(strs.Length + "");

            return strs;
        } 
    }
}
