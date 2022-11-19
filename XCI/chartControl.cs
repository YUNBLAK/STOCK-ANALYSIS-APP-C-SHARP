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

namespace XCI
{
    internal class chartControl
    {
        public string[] dts;
        public string[] prs; 
        public chartControl(Main main, string stockName)
        {
            apiLoadRealTimeData ttx = new apiLoadRealTimeData(stockName);
            dts = ttx.pricelst_Dates();
            prs = ttx.pricelst_A1("1. open");
            chartOneVoid(main);
        }

        private double findMinPrice(string[] arr, int term)
        {
            double minP = 100000000;
            for (int i = 0; i < term; i++)
            {
                if (arr[i] != null && minP >= Double.Parse(arr[i]))
                {
                    minP = Double.Parse(arr[i]);
                }
            }
            return minP;
        }

        public void chartOneVoid(Main main)
        {
            List<string> lst1 = dts.ToList();
            List<string> lst2 = prs.ToList();


            List<string> lst3 = new List<string>();
            List<string> lst4 = new List<string>();

            
            for(int i=0; i < 100; i++)
            {
                lst3.Add(dts[i]);
                lst4.Add(prs[i]);
            }

            string[] ax1 = lst3.ToArray();
            string[] ax2 = lst4.ToArray();

            main.chart1.Series[0].Color = Color.FromArgb(100, 255, 255, 255);
            main.chart1.ChartAreas[0].BackColor = Color.FromArgb(100, 36, 36, 36);
            for (int i=0; i < 100; i++)
            {
                main.chart1.Series[0].Points.AddXY(i, Double.Parse(ax2[i]));
                //main.chart4.Series[0].Points.AddXY(i, Double.Parse(prs[i]));
            }
            main.chart1.ChartAreas[0].AxisY.Minimum = findMinPrice(ax2, ax2.Length) ;
            main.ch4_ltime.Text = dts[dts.Length - 1] + "";

        }


    }
}
