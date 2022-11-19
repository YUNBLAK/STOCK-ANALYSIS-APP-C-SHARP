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
    internal class chart1Control
    {
        
        public chart1Control(Main main, string[] arr1, string[] arr2, string[] arr3, string[] arr4, int term)
        {
            // main.btn_chart2_y01.BackColor = Color.FromArgb(100, 255, 255, 255);
            chart2PriceDataInit(main);
            chart1DataInput(main, arr1, arr2, arr3, arr4, term);
        }
        
        public void chart2PriceDataInit(Main main)
        {
            main.lbmax_op.Text = "-";
            main.lbmax_cp.Text = "-";
            main.lbmax_lp.Text = "-";
            main.lbmax_hp.Text = "-";
            main.lbmin_op.Text = "-";
            main.lbmin_cp.Text = "-";
            main.lbmin_lp.Text = "-";
            main.lbmin_hp.Text = "-";
        }
        private double findMaxPrice(string[] arr, int term)
        {
            double maxP = 0;
            for(int i=0; i < term; i++)
            {
                if(arr[i]!=null && maxP <= Double.Parse(arr[i]))
                {
                    maxP = Double.Parse(arr[i]);
                }
            }
            return maxP;
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

        private void putMaxMinDataToPanel(Main main, string[] arr1, string[] arr2, string[] arr3, string[] arr4, int term)
        {
            main.lbmax_op.Text = findMaxPrice(arr1, term) + "";
            main.lbmax_cp.Text = findMaxPrice(arr4, term) + "";
            main.lbmax_lp.Text = findMaxPrice(arr3, term) + "";
            main.lbmax_hp.Text = findMaxPrice(arr2, term) + "";
            main.lbmin_op.Text = findMinPrice(arr1, term) + "";
            main.lbmin_cp.Text = findMinPrice(arr4, term) + "";
            main.lbmin_lp.Text = findMinPrice(arr3, term) + "";
            main.lbmin_hp.Text = findMinPrice(arr2, term) + "";
            main.chart2.ChartAreas[0].AxisY.Minimum = findMinPrice(arr3, term);
           
        }

        private void chart1DataInput(Main main, string[] arrx1, string[] arrx2, string[] arrx3, string[] arrx4, int term)
        {
            main.chart2.Series[0].Points.Clear();
            main.chart2.Series[1].Points.Clear();
            main.chart2.Series[2].Points.Clear();
            main.chart2.Series[3].Points.Clear();

            string[] arr = arrx1;
            string[] arr2 = arrx2;
            string[] arr3 = arrx3;
            string[] arr4 = arrx4;

            main.chart2.ChartAreas[0].BackColor = Color.FromArgb(100, 36, 36, 36);
            main.panel_chart2under.BackColor = Color.FromArgb(100, 36, 36, 36);
            
            main.chart2.Series[0].Color = Color.FromArgb(100, 0, 255, 0);
            main.chart2.Series[1].Color = Color.RoyalBlue;
            main.chart2.Series[2].Color = Color.FromArgb(100, 255, 0, 0);
            main.chart2.Series[3].Color = Color.FromArgb(100, 255, 192, 0);

            int i1 = 0;
            int i2 = 0;

            int i3 = 0;
            int i4 = 0;

            if (term > arr.Length)
            {
                term = arr.Length;
            }

            List<string> at1 = new List<string>();
            List<string> at2 = new List<string>();
            List<string> at3 = new List<string>();
            List<string> at4 = new List<string>();

            for(int i = 0; i < term; i++)
            {
                if (arr[i] != null)
                {
                    try
                    {
                        at1.Add(arr[i]);
                        at2.Add(arr2[i]);
                        at3.Add(arr3[i]);
                        at4.Add(arr4[i]);
                    }
                    catch
                    {

                    }
                }
            }
            at1.Reverse();
            at2.Reverse();
            at3.Reverse();
            at4.Reverse();

            for (int i = 0; i < term; i++)
            {
                if (at1[i] != null)
                {
                    try { 
                        double rndInt = Double.Parse(at1[i]);
                        main.chart2.Series[0].Points.AddXY(i1, rndInt);
                        //main.chart4.Series[0].Points.AddXY(i1, rndInt);
                        i1++;
                    }
                    catch
                    {
                    }

                }
            }

            for (int i = 0; i < term; i++)
            {
                if (at2[i] != null)
                {
                    try
                    {
                        double rndInt = Double.Parse(at2[i]);
                        main.chart2.Series[1].Points.AddXY(i2, rndInt);
                        i2++;
                    }
                    catch
                    {
                    }
                }
            }

            for (int i = 0; i < term; i++)
            {
                if (at3[i] != null)
                {
                    try {
                        double rndInt = Double.Parse(at3[i]);
                        main.chart2.Series[2].Points.AddXY(i3, rndInt);
                        i3++;
                    }
                    catch
                    {
                    }
                }
            }

            for (int i = 0; i < term; i++)
            {
                if (at4[i] != null)
                {
                    try
                    {
                        double rndInt = Double.Parse(at4[i]);
                        main.chart2.Series[3].Points.AddXY(i4, rndInt);
                        i4++;
                    }
                    catch
                    {
                    }
                }
            }

            putMaxMinDataToPanel(main, arr, arr2, arr3, arr4, term);
        }
    }
}
