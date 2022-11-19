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

namespace XCI
{
    public partial class Main : MetroFramework.Forms.MetroForm
    {
        private System.Windows.Forms.Timer t1 = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer temp1 = new System.Windows.Forms.Timer();
        private System.Timers.Timer aTimer;
        private int checktime = 0;
        public static bool onBtn_c1 = true;
        public static bool onBtn_c2 = true;
        public static bool onBtn_c3 = true;
        public static bool onBtn_c4 = true;
        public static double screenX;
        public static string[] arrx1;
        public static string[] arrx2;
        public static string[] arrx3;
        public static string[] arrx4;
        public static string stockName = "IBM";


        public Main()
        {
            InitializeComponent();
            mainFormFadeIn();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initializescreen();
            screenX = this.Width; 
            lablsidebnt01_Click(sender, e);

            aTimer = new System.Timers.Timer(500);
            aTimer.Elapsed += viewrefresh;
            aTimer.Enabled = true;
            Chart2Control(sender, e);
            setUpChart4();
        }
    private void mainFormFadeIn()
        {            
            this.Opacity = 0;      //first the opacity is 0
            t1.Interval = 10;  //we'll increase the opacity every 10ms
            t1.Tick += new EventHandler(fadeIn);  //this calls the function that changes opacity 
            t1.Start();
        }

        private void viewrefresh(Object source, ElapsedEventArgs e)
        {
            checktime++;

            if(this.Width > screenX)
            {
                panel_chart2under.Visible = false;
                panel_chart1under.Visible = false;
                //widepanel.Visible = false;
            }
            else
            {
                panel_chart2under.Visible = true;
                panel_chart1under.Visible = true;
                //widepanel.Visible = true;
            }
            timeclass dstr = new timeclass();
            worldtime.Text = "" + dstr.getUTCdateNow() + " UTC+0";
            regiontime.Text = "" + dstr.getDateNow() + "";
        }

        private void fadeIn(object sender, EventArgs e)
        {
            if (this.Opacity >= 1.0)
            {
                t1.Stop();   //this stops the timer if the form is completely displayed
            }
            else
                this.Opacity += 0.03;
        }

        public Color DefaultBtnColr = Color.FromArgb(17, 17, 17);
        public Color HighlightBtnColr = Color.Teal;

        private void initializescreen()
        {
            // lb_stockName.Enabled = false;
            lb_stockName.Text = "-";
            // btn_search.Enabled = false;

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void allbtndefault()
        {
            clablsidebnt01.BackColor = DefaultBtnColr;
            clablsidebnt02.BackColor = DefaultBtnColr;
            clablsidebnt03.BackColor = DefaultBtnColr;
            clablsidebnt04.BackColor = DefaultBtnColr;
            clablsidebnt05.BackColor = DefaultBtnColr;
            clablsidebnt06.BackColor = DefaultBtnColr;
            clablsidebnt07.BackColor = DefaultBtnColr;
            clablsidebnt08.BackColor = DefaultBtnColr;
        }

        private void lablsidebnt01_Click(object sender, EventArgs e)
        {
            widepanel.Visible = false;
            panel_overview.BringToFront();
            allbtndefault();
            clablsidebnt01.BackColor = HighlightBtnColr;
        }

        private void lablsidebnt02_Click(object sender, EventArgs e)
        {
            panel_detailView.BringToFront();
            widepanel.BringToFront();
            widepanel.Visible = true;
            allbtndefault();
            clablsidebnt02.BackColor = HighlightBtnColr;
        }

        private void lablsidebnt03_Click(object sender, EventArgs e)
        {
            widepanel.Visible = false;
            panel_prediction.BringToFront();
            allbtndefault();
            clablsidebnt03.BackColor = HighlightBtnColr;
        }

        private void lablsidebnt04_Click(object sender, EventArgs e)
        {
            widepanel.Visible = false;
            panel_list.BringToFront();
            allbtndefault();
            clablsidebnt04.BackColor = HighlightBtnColr;
        }

        private void lablsidebnt05_Click(object sender, EventArgs e)
        {
            widepanel.Visible = false;
            panel_stock.BringToFront();
            allbtndefault();
            clablsidebnt05.BackColor = HighlightBtnColr;
        }

        private void lablsidebnt06_Click(object sender, EventArgs e)
        {
            widepanel.Visible = false;
            panel_tracking.BringToFront();
            allbtndefault();
            clablsidebnt06.BackColor = HighlightBtnColr;
        }

        private void lablsidebnt07_Click(object sender, EventArgs e)
        {
            widepanel.Visible = false;
            panel_tmp1.BringToFront();
            allbtndefault();
            clablsidebnt07.BackColor = HighlightBtnColr;
        }

        private void lablsidebnt08_Click(object sender, EventArgs e)
        {
            widepanel.Visible = false;
            panel_tmp2.BringToFront();
            allbtndefault();
            clablsidebnt08.BackColor = HighlightBtnColr;
        }

        private void sidebnt01_Click(object sender, EventArgs e)
        {
            lablsidebnt01_Click(sender, e);
        }

        private void sidebnt02_Click(object sender, EventArgs e)
        {
            lablsidebnt02_Click(sender, e);
        }

        private void sidebnt03_Click(object sender, EventArgs e)
        {
            lablsidebnt03_Click(sender, e);
        }

        private void sidebnt04_Click(object sender, EventArgs e)
        {
            lablsidebnt04_Click(sender, e);
        }

        private void sidebnt05_Click(object sender, EventArgs e)
        {
            lablsidebnt05_Click(sender, e);
        }

        private void sidebnt06_Click(object sender, EventArgs e)
        {
            lablsidebnt06_Click(sender, e);
        }

        private void sidebnt07_Click(object sender, EventArgs e)
        {
            lablsidebnt07_Click(sender, e);
        }

        private void sidebnt08_Click(object sender, EventArgs e)
        {
            lablsidebnt08_Click(sender, e);
        }

        private void splitContainer4_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void OnBtn01_Click(object sender, EventArgs e)
        {
            if (!onBtn_c1)
            {
                onBtn_c1 = true;
                OnBtn01.ForeColor = Color.Lime;
                chart2.Series[0].Color = Color.FromArgb(100, 0, 255, 0);
            }
            else
            {
                OnBtn01.ForeColor = Color.Silver;
                onBtn_c1 = false;
                chart2.Series[0].Color = Color.FromArgb(100, 36, 36, 36);
            }
        }

        private void OnBtn02_Click(object sender, EventArgs e)
        {
            if (!onBtn_c2)
            {
                onBtn_c2 = true;
                OnBtn02.ForeColor = Color.Lime;
                chart2.Series[1].Color = Color.RoyalBlue;
            }
            else
            {
                OnBtn02.ForeColor = Color.Silver;
                onBtn_c2 = false;
                chart2.Series[1].Color = Color.FromArgb(100, 36, 36, 36);
            }
        }

        private void OnBtn03_Click(object sender, EventArgs e)
        {
            if (!onBtn_c3)
            {
                onBtn_c3 = true;
                OnBtn03.ForeColor = Color.Lime;
                chart2.Series[2].Color = Color.FromArgb(100, 255, 0, 0);
            }
            else
            {
                OnBtn03.ForeColor = Color.Silver;
                onBtn_c3 = false;
                chart2.Series[2].Color = Color.FromArgb(100, 36, 36, 36);
            }
        }

        private void OnBtn04_Click(object sender, EventArgs e)
        {
            if (!onBtn_c4)
            {
                onBtn_c4 = true;
                OnBtn04.ForeColor = Color.Lime;
                chart2.Series[3].Color = Color.FromArgb(100, 255, 192, 0);
            }
            else
            {
                OnBtn04.ForeColor = Color.Silver;
                onBtn_c4 = false;
                chart2.Series[3].Color = Color.FromArgb(100, 36, 36, 36);
            }
        }

        private void btn_chart2_y01_Click(object sender, EventArgs e)
        {
            OnBtn01_Click(sender, e);
        }

        private void btn_chart2_y02_Click(object sender, EventArgs e)
        {
            OnBtn02_Click(sender, e);
        }

        private void btn_chart2_y03_Click(object sender, EventArgs e)
        {
            OnBtn03_Click(sender, e);
        }

        private void btn_chart2_y04_Click(object sender, EventArgs e)
        {
            OnBtn04_Click(sender, e);
        }

        private void defaultYearBtn()
        {
            OnYearBtn01.ForeColor = Color.Silver;
            OnYearBtn02.ForeColor = Color.Silver;
            OnYearBtn03.ForeColor = Color.Silver;
            OnYearBtn04.ForeColor = Color.Silver;
        }

        private void OnYearBtn01_Click(object sender, EventArgs e)
        {
            defaultBtn(sender, e);
            defaultYearBtn();
            OnYearBtn01.ForeColor = Color.Lime;
            chart1Control chx = new chart1Control(this, arrx1, arrx2, arrx3, arrx4, 180);
        }

        private void OnYearBtn02_Click(object sender, EventArgs e)
        {
            defaultBtn(sender, e);
            defaultYearBtn();
            OnYearBtn02.ForeColor = Color.Lime;
            chart1Control chx = new chart1Control(this, arrx1, arrx2, arrx3, arrx4, 365);
        }

        private void OnYearBtn03_Click(object sender, EventArgs e)
        {
            defaultBtn(sender, e);
            defaultYearBtn();
            OnYearBtn03.ForeColor = Color.Lime;
            chart1Control chx = new chart1Control(this, arrx1, arrx2, arrx3, arrx4, 1000);
        }

        private void OnYearBtn04_Click(object sender, EventArgs e)
        {
            defaultBtn(sender, e);
            defaultYearBtn();
            OnYearBtn04.ForeColor = Color.Lime;
            chart1Control chx = new chart1Control(this, arrx1, arrx2, arrx3, arrx4, 3650);
        }

        private void Chart2Control(object sender, EventArgs e)
        {
            /*
            chart2.Series[0].Color = Color.FromArgb(100, 0, 255, 0);
            chart2.Series[1].Color = Color.FromArgb(100, 255, 0, 0);
            chart2.Series[2].Color = Color.FromArgb(100, 0, 0, 255);
            chart2.Series[3].Color = Color.FromArgb(100, 255, 192, 0);
            */

            chartControl dx = new chartControl(this, "IBM");
            
            apiloaddailydataset arx1 = new apiloaddailydataset("Time Series (Daily)", "1. open", stockName, 4000);
            string[] arr = arx1.pricelst();
            // arr.Reverse();
            arrx1 = arr;

            apiloaddailydataset arx2 = new apiloaddailydataset("Time Series (Daily)", "4. close", stockName, 4000);
            string[] arr2 = arx2.pricelst();
            // arr2.Reverse();
            arrx2 = arr2;

            apiloaddailydataset arx3 = new apiloaddailydataset("Time Series (Daily)", "2. high", stockName, 4000);
            string[] arr3 = arx3.pricelst();
            // arr3.Reverse();
            arrx3 = arr3;

            apiloaddailydataset arx4 = new apiloaddailydataset("Time Series (Daily)", "3. low", stockName, 4000);
            string[] arr4 = arx4.pricelst();
            // arr4.Reverse();
            arrx4 = arr4;

            OnYearBtn01_Click(sender, e);
        }

        private void btn_chart2_y05_Click(object sender, EventArgs e)
        {
            //defaultBtn(sender, e);
            OnYearBtn01_Click(sender, e);
        }

        private void btn_chart2_y06_Click(object sender, EventArgs e)
        {
            //defaultBtn(sender, e);
            OnYearBtn02_Click(sender, e);
        }

        private void btn_chart2_y07_Click(object sender, EventArgs e)
        {
            //defaultBtn(sender, e);
            OnYearBtn03_Click(sender, e);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            //defaultBtn(sender, e);
            OnYearBtn04_Click(sender, e);
        }

        private void defaultBtn(object sender, EventArgs e)
        {
            onBtn_c1 = false;
            onBtn_c2 = false;
            onBtn_c3 = false;
            onBtn_c4 = false;

            OnBtn01.ForeColor = Color.Lime;
            OnBtn02.ForeColor = Color.Lime;
            OnBtn03.ForeColor = Color.Lime;
            OnBtn04.ForeColor = Color.Lime;

            OnBtn01_Click(sender, e);
            OnBtn02_Click(sender, e);
            OnBtn03_Click(sender, e);
            OnBtn04_Click(sender, e);
        }

        private void btn_chart2_Click(object sender, EventArgs e)
        {
            List<Double> lst = new List<Double>();
            List<Double> lst2 = new List<Double>();
            List<Double> lst3 = new List<Double>();
            List<Double> lst4 = new List<Double>();

            for (int i = 0; i< arrx1.Length; i++)
            {
                if (arrx1[i] != null)
                {
                    lst.Add(Double.Parse(arrx1[i]));
                    lst2.Add(Double.Parse(arrx2[i]));
                    lst3.Add(Double.Parse(arrx3[i]));
                    lst4.Add(Double.Parse(arrx4[i]));
                }
            }

            lst.Reverse();
            lst2.Reverse();
            lst3.Reverse();
            lst4.Reverse();

            Double[] a1 = lst.ToArray();
            Double[] a2 = lst2.ToArray();
            Double[] a3 = lst3.ToArray();
            Double[] a4 = lst4.ToArray();

            GraphExForm FRM = new GraphExForm(a1, a2, a3, a4, arrx1);
            FRM.Show();
        }

        private void chrt1md1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void chrt1md2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }

        private void chrt1md3_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
        }

        private void chrt1md4_Click(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Stock;
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

        private void setUpChart4()
        {
            chart4.ChartAreas[0].BackColor = Color.FromArgb(100, 36, 36, 36);
            chart4.ChartAreas[0].AxisY.Minimum = findMinPrice(arrx3, arrx3.Length);
            chart4.Series[1].Color = Color.FromArgb(100, 46, 46, 46);
            int ix = 0;

            //MessageBox.Show(arrx3.Length + "");
            for (int i = 0; i < arrx3.Length; i++)
            {
                if (arrx3[i] != null)
                {
                    try
                    {
                        double rndInt = Double.Parse(arrx3[i]);
                        chart4.Series[0].Points.AddXY(ix, rndInt);
                        chart4.Series[1].Points.AddXY(ix, rndInt);
                        //main.chart4.Series[0].Points.AddXY(i1, rndInt);
                        ix++;
                    }
                    catch
                    {

                    }

                }
            }

        }

        
    }
}
