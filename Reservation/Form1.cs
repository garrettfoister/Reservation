using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reservation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            DateTime dArival = DateTime.Parse(txtArrivalDate.Text, new System.Globalization.CultureInfo("en-US"));
            DateTime dDeparture = DateTime.Parse(txtDepartureDate.Text, new System.Globalization.CultureInfo("en-US"));
            TimeSpan timeSpan = dDeparture - dArival;

            int numOfDays = (int)timeSpan.TotalDays;

            txtNights.Text = numOfDays.ToString();

            double totalPrice = 0;



            int txtI = 0;
            int roomRate = 0;

            // Room Price = room rate + $150 Friday or Saturday, room rate + $120 all other days


            if (rdoSingle.Checked)
                roomRate = 15;
            else if (rdoTwin.Checked)
                roomRate = 35;
            else
                roomRate = 90;


            while (txtI < numOfDays)

            {
                DateTime dtTemp = dArival.AddDays(txtI);
                DayOfWeek dowNow = dtTemp.DayOfWeek;
                string strSWeek = dowNow.ToString();

                if (strSWeek.Equals("Friday") || strSWeek.Equals("Saturday"))
                    totalPrice = totalPrice + 150 + roomRate;
                else
                    totalPrice = totalPrice + 120 + roomRate;
                txtI++;

            }



            txtTotalPrice.Text = totalPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            double avgPrice = totalPrice / numOfDays;
            txtAvgPrice.Text = avgPrice.ToString("C2", System.Globalization.CultureInfo.GetCultureInfo("en-US"));

        }



        private void Form1_Load(object sender, EventArgs e)

        {
            DateTime dArival = DateTime.Now.Date;
            DateTime dDeparture = dArival.AddDays(3).Date;
            txtArrivalDate.Text = dArival.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            txtDepartureDate.Text = dDeparture.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblArrival_Click(object sender, EventArgs e)
        {

        }
    }
}

