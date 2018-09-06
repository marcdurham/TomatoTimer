using System;
using System.Windows.Forms;

namespace TomatoTimer
{
    public partial class TomatoManagerForm : Form
    {
        const int Duration = 5;

        int ticks = Duration;

        public TomatoManagerForm()
        {
            InitializeComponent();
        }

        private void TomatoManagerForm_Resize(object sender, EventArgs e)
        {
            StartTomato();
        }

        private void StartTomato()
        {
            Hide();
            notifyIcon.Visible = true;
            ticks = Duration;
            timer.Start();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowTomatoManager();
        }

        private void ShowTomatoManager()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            switch (ticks)
            {
                case 25:
                    notifyIcon.Icon = Properties.Resources.TwentyFive;
                    break;
                case 15:
                    notifyIcon.Icon = Properties.Resources.Fifteen;
                    break;
                case 5:
                    notifyIcon.Icon = Properties.Resources.Five;
                    break;
                case 4:
                    notifyIcon.Icon = Properties.Resources.Four;
                    break;
                case 3:
                    notifyIcon.Icon = Properties.Resources.Three;
                    break;
                case 2:
                    notifyIcon.Icon = Properties.Resources.Two;
                    break;
                case 1:
                    notifyIcon.Icon = Properties.Resources.One;
                    break;
                case 0:
                    notifyIcon.Icon = Properties.Resources.Zero;
                    Done();
                    break;
            }
            
            ticks--;
        }

        void Done()
        {
            timer.Stop();
            ShowTomatoManager();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTomato();
        }
    }
}
