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
    public partial class GraphExForm : MetroFramework.Forms.MetroForm
    {
        public static int indx1;
        public static int indx2;
        public static int indx3;
        public static int indx4;
        public static int indx5;
        public static double[] a1;
        public static double[] a2;
        public static double[] a3;
        public static double[] a4;
        public static string[] dat;


        public GraphExForm(double[] arr1 = null, double[] arr2 = null, double[] arr3 = null, double[] arr4 = null, string[] dt = null)
        {
            InitializeComponent();
            label6.Text = "GRAPH - " + Main.stockName;
            a1 = arr1;
            a2 = arr2;
            a3 = arr3;
            a4 = arr4;
            dat = apiloaddailydataset.dats;
            Crosshair cross = formsPlot1.Plot.AddCrosshair(25, .5);
            formsPlot1.Render();
            formsPlot1.MouseMove += formsPlot1_MouseMove;
            CrosshairsByPlot.Add(formsPlot1, cross);
        }
        private readonly Dictionary<FormsPlot, Crosshair> CrosshairsByPlot = new Dictionary<FormsPlot, Crosshair>();
        private void GraphExForm_Load(object sender, EventArgs e)
        {
            var plt = new ScottPlot.Plot(1900, 1200);
            formsPlot1.Plot.Frameless();
            double[] values = DataGen.Consecutive(a1.Length);
            plt.Frameless();
            plt.AddSignal(a1, sampleRate: 100_000, Color.FromArgb(100, 255, 0, 0));
            plt.AddSignal(a2, sampleRate: 100_000, Color.RoyalBlue);
            plt.AddSignal(a3, sampleRate: 100_000, Color.Lime);
            plt.AddSignal(a4, sampleRate: 100_000, Color.FromArgb(100, 255, 100, 0));
            plt.Style(ScottPlot.Style.Gray2);
            plt.Style(figureBackground: Color.FromArgb(100, 17, 17, 17));
            //plt.XAxis.Layout(padding: 5);
            plt.YAxis.Ticks(false);
            formsPlot1.Reset(plt);
            //plt.YAxis.Ticks(false);
            

        }

        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            FormsPlot formsPlot = (FormsPlot)sender;
            Crosshair crosshair = CrosshairsByPlot[formsPlot];
            (double x, double y) = formsPlot.GetMouseCoordinates();
            // panel1.Location = new Point((int)(x), (int)(y));
            crosshair.X = x;
            crosshair.Y = y;
            if(e.Location.X < 10 || e.Location.Y < 10)
            {
                panel1.Visible = false;
            }
            else
            {
                panel1.Visible = true;
            }
            
          
            if(x * 100000 < 0 || x * 100000 > a1.Length)
            {
                
            }
            else
            {
                label1.Text = "$ " + a1[(int)(x * 100000)] + "";
                label2.Text = "$ " + a2[(int)(x * 100000)] + "";
                label3.Text = "$ " + a3[(int)(x * 100000)] + "";
                label4.Text = "$ " + a4[(int)(x * 100000)] + "";
                label5.Text = dat[(int)(x * 100000)];
            }
            
            if(e.Location.X > this.Width / 2)
            {
                panel1.Location = new Point(e.Location.X - 170, e.Location.Y + 20);
            }
            else
            {
                panel1.Location = new Point(e.Location.X + 20, e.Location.Y + 20);
            }

            formsPlot.Render();
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            var plt = new ScottPlot.Plot(600, 400);
            OHLC[] prices = DataGen.RandomStockPrices(null, 60);
            MessageBox.Show(prices[0].ToString());
            
        }

        private void btn_rf_Click(object sender, EventArgs e)
        {
            var plt = new ScottPlot.Plot(1900, 1200);
            formsPlot1.Plot.Frameless();
            double[] values = DataGen.Consecutive(a1.Length);
            plt.Frameless();
            plt.AddSignal(a1, sampleRate: 100_000, Color.FromArgb(100, 255, 0, 0));
            plt.AddSignal(a2, sampleRate: 100_000, Color.RoyalBlue);
            plt.AddSignal(a3, sampleRate: 100_000, Color.Lime);
            plt.AddSignal(a4, sampleRate: 100_000, Color.FromArgb(100, 255, 100, 0));
            plt.Style(ScottPlot.Style.Gray2);
            plt.Style(figureBackground: Color.FromArgb(100, 17, 17, 17));
            //plt.XAxis.Layout(padding: 5);
            plt.YAxis.Ticks(false);
            formsPlot1.Reset(plt);
        }
        private static bool modew = false;
        private void label9_Click(object sender, EventArgs e)
        {
            if (!modew)
            {
                label9.Text = "DARK MODE";
                modew = true;
                formsPlot1.Plot.Style(ScottPlot.Style.Light1);
                //this.Theme = MetroFramework.MetroThemeStyle.Light;
            }
            else
            {
                label9.Text = "WHITE MODE";
                modew = false;
                formsPlot1.Plot.Style(ScottPlot.Style.Gray2);
                //this.Theme = MetroFramework.MetroThemeStyle.Dark;
            }
        }
    }
}
