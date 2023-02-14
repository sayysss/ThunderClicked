using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thunder_Clicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey); // Keys enumeration

        private void siticoneControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void siticoneControlBox3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCMI8lOj32t-a9QUCAD77eBw");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void trackbar_Scroll(object sender, ScrollEventArgs e)
        {
            CpsCount.Text = $"{trackbar.Value} CPS";
        }

        private void LeftClicker_Tick(object sender, EventArgs e)
        {
            LeftClicker.Interval = 1000 / jittercps;
            Process[] processes = Process.GetProcessesByName("javaw");
            foreach (Process process in processes)
                if (GetForegroundWindow() == FindWindow(null, process.MainWindowTitle))
                {       
                        if (checkBox1.Checked)
                        if (MouseButtons == MouseButtons.Left)
                    {
                        SendMessage(GetForegroundWindow(), 0x202, 0, 0);
                        Task.Delay(20).Wait();
                        SendMessage(GetForegroundWindow(), 0x201, 0, 0);
                    }
                }
        }

        int jittercps;
        private void timer1_Tick(object sender, EventArgs e)
        {
            jittercps = new Random().Next(trackbar.Value - 4, trackbar.Value * 2 - 5);
        }

        private void btnBind_KeyUp(object sender, KeyEventArgs e)
        {
            if (btnBind.Text == ".....")
            {
                if (GetAsyncKeyState(Keys.Escape) < 0)
                {
                    btnBind.Text = "Bind";
                }
                else
                {
                    btnBind.Text = e.KeyCode.ToString();
                }
            }
        }

        private void btnBind_Click(object sender, EventArgs e)
        {
            btnBind.Text = ".....";
        }
        public static KeysConverter Key = new KeyConverter();
        private void Bind_Tick(object sender, EventArgs e)
        {
            if (btnBind.Text != "Bind")
            {
                if (btnBind.Text != ".....")
                {
                    Keys key = (Keys)Key.ConvertFromString(btnBind.Text);
                    if (GetAsyncKeyState(key) < 0)
                    {
                        checkBox1.Checked = !checkBox1.Checked;
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
