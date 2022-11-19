using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using ScottPlot;
using ScottPlot.Plottable;
using Newtonsoft.Json.Linq;

namespace XCI
{
    internal class apiLoadRealTimeData
    {
        public static string[] dats;
        public string typeX;
        public string typeY;
        public string typeZ;
        public int typeT;
        public Newtonsoft.Json.Linq.JObject temp;
        public string[] dts;
        
        public apiLoadRealTimeData(string typeZ)
        {
            temp = dataticc(typeZ);
            dts = pricelst_Dates();
        }
        public Newtonsoft.Json.Linq.JObject dataticc(string symbol)
        {
            string url1 = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=";
            string url2 = "&interval=1min&outputsize=full&apikey=SAK4Q525BO4HUS0Y";
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
        public string[] pricelst_Dates()
        {
            List<string> stx = new List<string>();
            JToken jt = temp["Time Series (1min)"];
            foreach (JProperty j in jt)
            {
                stx.Add(j.Name);

            }
            stx.Reverse();
            dats = stx.ToArray();

            string[] sxx = stx.ToArray();
            return sxx;
        }

        public string[] pricelst_A1(string x1)
        {
            List<string> newda = new List<string>();
            int i = 0;
            DateTime now = DateTime.Now;
            for (i = 1; i < dts.Length; i++)
            {
                try
                {
                    newda.Add(temp["Time Series (1min)"][dts[i]][x1].ToString());
                }
                catch { }
            }
            string[] ars = newda.ToArray();
            return ars;
        }

    }
}
