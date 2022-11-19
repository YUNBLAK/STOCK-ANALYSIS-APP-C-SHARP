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

namespace XCI
{
    internal class timeclass
    {
        public string getDateNow()
        {
            DateTime todayNow = DateTime.Now;
            string temp = todayNow.ToString("yyyy-MM-dd HH: mm: ss");
            return temp;
        }

        public string getUTCdateNow()
        {
            DateTime tutc = DateTime.UtcNow;
            string temp = tutc.ToString("yyyy-MM-dd HH: mm: ss");
            return temp;
        }
    }
}
