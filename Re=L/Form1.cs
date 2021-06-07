using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace Re_L
{
    public partial class Window : Form
    { 
        public Window()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        // Principal code
        private void button1_Click(object sender, EventArgs e)
        {
            string api = $"https://extreme-ip-lookup.com/json/" + target_input.Text; // Getting API
            var client = new WebClient(); // Creating web client
            var json = client.DownloadString(api);
            dynamic ip = JsonConvert.DeserializeObject(json);

            // Writing results
            ip_label.Text = "IP: " + ip.query;
            country_label.Text = "Country: " + ip.country;
            city_label.Text = "City: " + ip.city;
            isp_label.Text = "ISP: " + ip.isp;
        }

        // Exit button
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Minimize button
        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Move window
        int m, mx, my;

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(m == 1){
                this.SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }
    }
}
