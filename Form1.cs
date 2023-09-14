using System.Diagnostics;
using System.Management;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace dns_changer
{
    public partial class Form1 : Form
    {
        bool isconnect = false;
        public Form1()
        {
            InitializeComponent();
        }

        public static NetworkInterface GetActiveEthernetOrWifiNetworkInterface()
        {
            var Nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
                a => a.OperationalStatus == OperationalStatus.Up &&
                (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

            return Nic;
        }

        public static void SetDNS(string DnsString1, string DnsString2)
        {
            string[] Dns = { DnsString1, DnsString2 };
            var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
            if (CurrentInterface == null) return;

            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();
            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    if (objMO["Caption"].ToString().Contains(CurrentInterface.Description))
                    {
                        ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        if (objdns != null)
                        {
                            objdns["DNSServerSearchOrder"] = Dns;
                            objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                    }
                }
            }
        }

        public static void UnsetDNS()
        {
            var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
            if (CurrentInterface == null) return;

            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();
            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    if (objMO["Caption"].ToString().Contains(CurrentInterface.Description))
                    {
                        ManagementBaseObject objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        if (objdns != null)
                        {
                            objdns["DNSServerSearchOrder"] = null;
                            objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                    }
                }
            }
        }

        private void btn_shecan_Click(object sender, EventArgs e)
        {
            if (!isconnect)
            {
                SetDNS("178.22.122.100", "185.51.200.2");
                status_label.Text = "Connected";
                status_label.ForeColor = System.Drawing.Color.Green;
                btn_shecan.Text = "Disconnect";
                p_add_dns_label_1.ForeColor = System.Drawing.Color.Green;
                s_add_dns_label_1.ForeColor = System.Drawing.Color.Green;
                tabPage2.Enabled = false;
                tabPage3.Enabled = false;
                tabPage4.Enabled = false;
                tabPage5.Enabled = false;
                tabPage6.Enabled = false;
                isconnect = true;
            }
            else
            {
                UnsetDNS();
                status_label.Text = "Disonnected";
                status_label.ForeColor = System.Drawing.Color.Red;
                btn_shecan.Text = "Connect";
                p_add_dns_label_1.ForeColor = System.Drawing.Color.Black;
                s_add_dns_label_1.ForeColor = System.Drawing.Color.Black;
                tabPage2.Enabled = true;
                tabPage3.Enabled = true;
                tabPage4.Enabled = true;
                tabPage5.Enabled = true;
                tabPage6.Enabled = true;
                isconnect = false;
            }
        }

        private void btn_electro_Click(object sender, EventArgs e)
        {
            if (!isconnect)
            {
                SetDNS("78.157.42.101", "78.157.42.101");
                status_label.Text = "Connected";
                status_label.ForeColor = System.Drawing.Color.Green;
                btn_electro.Text = "Disconnect";
                p_add_dns_label_2.ForeColor = System.Drawing.Color.Green;
                s_add_dns_label_2.ForeColor = System.Drawing.Color.Green;
                tabPage1.Enabled = false;
                tabPage3.Enabled = false;
                tabPage4.Enabled = false;
                tabPage5.Enabled = false;
                tabPage6.Enabled = false;
                isconnect = true;
            }
            else
            {
                UnsetDNS();
                status_label.Text = "Disonnected";
                status_label.ForeColor = System.Drawing.Color.Red;
                btn_electro.Text = "Connect";
                p_add_dns_label_2.ForeColor = System.Drawing.Color.Black;
                s_add_dns_label_2.ForeColor = System.Drawing.Color.Black;
                tabPage1.Enabled = true;
                tabPage3.Enabled = true;
                tabPage4.Enabled = true;
                tabPage5.Enabled = true;
                tabPage6.Enabled = true;
                isconnect = false;
            }
        }

        private void btn_begzar_Click(object sender, EventArgs e)
        {
            if (!isconnect)
            {
                SetDNS("185.55.225.25", "185.55.226.26");
                status_label.Text = "Connected";
                status_label.ForeColor = System.Drawing.Color.Green;
                btn_begzar.Text = "Disconnect";
                p_add_dns_label_3.ForeColor = System.Drawing.Color.Green;
                s_add_dns_label_3.ForeColor = System.Drawing.Color.Green;
                tabPage1.Enabled = false;
                tabPage2.Enabled = false;
                tabPage4.Enabled = false;
                tabPage5.Enabled = false;
                tabPage6.Enabled = false;
                isconnect = true;
            }
            else
            {
                UnsetDNS();
                status_label.Text = "Disonnected";
                status_label.ForeColor = System.Drawing.Color.Red;
                btn_begzar.Text = "Connect";
                p_add_dns_label_3.ForeColor = System.Drawing.Color.Black;
                s_add_dns_label_3.ForeColor = System.Drawing.Color.Black;
                tabPage1.Enabled = true;
                tabPage2.Enabled = true;
                tabPage4.Enabled = true;
                tabPage5.Enabled = true;
                tabPage6.Enabled = true;
                isconnect = false;
            }
        }

        private void btn_403_Click(object sender, EventArgs e)
        {
            if (!isconnect)
            {
                SetDNS("10.202.10.202", "10.202.10.102");
                status_label.Text = "Connected";
                status_label.ForeColor = System.Drawing.Color.Green;
                btn_403.Text = "Disconnect";
                p_add_dns_label_4.ForeColor = System.Drawing.Color.Green;
                s_add_dns_label_4.ForeColor = System.Drawing.Color.Green;
                tabPage1.Enabled = false;
                tabPage2.Enabled = false;
                tabPage3.Enabled = false;
                tabPage5.Enabled = false;
                tabPage6.Enabled = false;
                isconnect = true;
            }
            else
            {
                UnsetDNS();
                status_label.Text = "Disonnected";
                status_label.ForeColor = System.Drawing.Color.Red;
                btn_403.Text = "Connect";
                p_add_dns_label_4.ForeColor = System.Drawing.Color.Black;
                s_add_dns_label_4.ForeColor = System.Drawing.Color.Black;
                tabPage1.Enabled = true;
                tabPage2.Enabled = true;
                tabPage3.Enabled = true;
                tabPage5.Enabled = true;
                tabPage6.Enabled = true;
                isconnect = false;
            }
        }

        private void btn_radar_Click(object sender, EventArgs e)
        {
            if (!isconnect)
            {
                SetDNS("10.202.10.10", "10.202.10.11");
                status_label.Text = "Connected";
                status_label.ForeColor = System.Drawing.Color.Green;
                btn_radar.Text = "Disconnect";
                p_add_dns_label_5.ForeColor = System.Drawing.Color.Green;
                s_add_dns_label_5.ForeColor = System.Drawing.Color.Green;
                tabPage1.Enabled = false;
                tabPage2.Enabled = false;
                tabPage3.Enabled = false;
                tabPage4.Enabled = false;
                tabPage6.Enabled = false;
                isconnect = true;
            }
            else
            {
                UnsetDNS();
                status_label.Text = "Disonnected";
                status_label.ForeColor = System.Drawing.Color.Red;
                btn_radar.Text = "Connect";
                p_add_dns_label_5.ForeColor = System.Drawing.Color.Black;
                s_add_dns_label_5.ForeColor = System.Drawing.Color.Black;
                tabPage1.Enabled = true;
                tabPage2.Enabled = true;
                tabPage3.Enabled = true;
                tabPage4.Enabled = true;
                tabPage6.Enabled = true;
                isconnect = false;
            }
        }

        private void btn_custom_Click(object sender, EventArgs e)
        {
            if (!isconnect)
            {
                string primary_add = textBox_primary.Text;
                string secondary_add = textBox_secondary.Text;
                if (primary_add != "" && secondary_add != "")
                {
                    string pattern = @"^\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b$";
                    if (!Regex.IsMatch(textBox_primary.Text, pattern) || !Regex.IsMatch(textBox_secondary.Text, pattern))
                    {
                        MessageBox.Show("IP Address must be in the format '255.255.255.255'!");
                    }
                    else
                    {
                        SetDNS(primary_add, secondary_add);
                        status_label.Text = "Connected";
                        status_label.ForeColor = System.Drawing.Color.Green;
                        btn_custom.Text = "Disconnect";
                        //p_add_dns_label_5.ForeColor = System.Drawing.Color.Green;
                        //s_add_dns_label_5.ForeColor = System.Drawing.Color.Green;
                        tabPage1.Enabled = false;
                        tabPage2.Enabled = false;
                        tabPage3.Enabled = false;
                        tabPage4.Enabled = false;
                        tabPage5.Enabled = false;
                        isconnect = true;
                    }
                }
                else if(textBox_primary.Text == "")
                {
                    MessageBox.Show("No primary address entered!");
                }
                else if (textBox_secondary.Text == "")
                {
                    MessageBox.Show("No secondary address entered!");
                }
            }
            else
            {
                UnsetDNS();
                status_label.Text = "Disonnected";
                status_label.ForeColor = System.Drawing.Color.Red;
                btn_custom.Text = "Connect";
                //p_add_dns_label_5.ForeColor = System.Drawing.Color.Black;
                //s_add_dns_label_5.ForeColor = System.Drawing.Color.Black;
                tabPage1.Enabled = true;
                tabPage2.Enabled = true;
                tabPage3.Enabled = true;
                tabPage4.Enabled = true;
                tabPage5.Enabled = true;
                isconnect = false;
            }
        }

        private void toolStripDropDownButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void contactOnTelegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Process.Start(new ProcessStartInfo("https://t.me/shadmehr_g") { UseShellExecute = true });
        }

        private void sourceCodeOnGithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Process.Start(new ProcessStartInfo("https://github.com/shadmehr-gh/dns-changer") { UseShellExecute = true });
        }

        private void textBox_primary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            /*
            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            */
        }

        private void textBox_secondary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            /*
            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            */
        }

        private void shadmehrgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://t.me/shadmehr_g") { UseShellExecute = true });
        }

        private void githubcomshadmehrghdnschangerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/shadmehr-gh/dns-changer") { UseShellExecute = true });
        }
    }
}