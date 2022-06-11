using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Curs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.06;
        Random rnd = new Random();

        double euro, dollar;
        int day = 0;


        private void btn_StartStop_Click(object sender, EventArgs e)
        {
            if(!timerDays.Enabled)
            {
                timerDays.Interval = (int)edTimeStep.Value;
                euro = (double)edEuro.Value;
                dollar = (double)edDollar.Value;

                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();

                chart1.Series[0].Points.AddXY(day, euro);
                chart1.Series[1].Points.AddXY(day, dollar);

                btn_StartStop.Text = "Stop";

                timerDays.Start();
            }
            else
            {
                timerDays.Stop();
                btn_StartStop.Text = "Start";
            }
        }

        private void timerDays_Tick(object sender, EventArgs e)
        {
            euro = euro * (1 + k * (rnd.NextDouble() - 0.5));
            dollar = dollar * (1 + k * (rnd.NextDouble() - 0.5));

            chart1.Series[0].Points.AddXY(day, euro);
            chart1.Series[1].Points.AddXY(day, dollar);
        }
    }
}
