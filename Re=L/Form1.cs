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
        // Validate IP
        public static bool CheckIPValid(string strIP)
        {
            IPAddress result = null;
            return
                !String.IsNullOrEmpty(strIP) &&
                IPAddress.TryParse(strIP, out result);
        }

        // IP Lookup
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckIPValid(target_input.Text))
            {
                string api = $"https://ip-geolocation.whoisxmlapi.com/api/v1?apiKey=at_kAFXO0mbYmXrMT7Hr3Hg9zXUjweGB&ipAddress=" + target_input.Text; // Getting API
                var client = new WebClient(); // Creating web client
                var json = client.DownloadString(api);
                dynamic ip = JsonConvert.DeserializeObject(json);

                // Writing results
                Output.Text = "IP: " + ip.ip + Environment.NewLine + "Country: " + ip.location.country + Environment.NewLine + "Region: " + ip.location.region + Environment.NewLine + "City: " + ip.location.city + Environment.NewLine + "Lat: " + ip.location.lat + Environment.NewLine + "Long: " + ip.location.lng + Environment.NewLine + "Postal Code: " + ip.location.postalCode + Environment.NewLine + "Time Zone" + ip.location.timezone + Environment.NewLine + "Geo Name ID: " + ip.location.geonameId + Environment.NewLine + "ISP: " + ip.isp + Environment.NewLine + "Connection Type: " + ip.connectionType + Environment.NewLine + "Domains: " + ip.domains;
            }
            else
            {
                MessageBox.Show("Invalid IP, try again");
            }
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

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
