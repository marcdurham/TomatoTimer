using System;
using System.Windows.Forms;

namespace TomatoTimer
{
    public partial class TomatoManagerForm : Form
    {
        int ticks = 0;

        public TomatoManagerForm()
        {
            InitializeComponent();
        }

        private void TomatoManagerForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
                timer.Start();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ticks++;

            if (ticks % 2 == 0)
            {
                notifyIcon.Icon = Properties.Resources.Tomato5;
            }
            else
            {
                notifyIcon.Icon = Properties.Resources.Tomato10;
            }
        }
    }
}
