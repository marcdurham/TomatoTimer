using System;
using System.Windows.Forms;

namespace TomatoTimer
{
    public partial class TomatoManagerForm : Form
    {
        const int SecondsPerMinute = 60;
        const int Duration = 25 * SecondsPerMinute;
        const int TwentyFive = Duration;
        const int Fifteen = 15 * SecondsPerMinute;
        const int Five = 5 * SecondsPerMinute;
        const int Four = 4 * SecondsPerMinute;
        const int Three = 3 * SecondsPerMinute;
        const int Two = 2 * SecondsPerMinute;
        const int One = 1 * SecondsPerMinute;
        const int Zero = 0;

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
                case TwentyFive:
                    notifyIcon.Icon = Properties.Resources.TwentyFive;
                    break;
                case Fifteen:
                    notifyIcon.Icon = Properties.Resources.Fifteen;
                    break;
                case Five:
                    notifyIcon.Icon = Properties.Resources.Five;
                    break;
                case Four:
                    notifyIcon.Icon = Properties.Resources.Four;
                    break;
                case Three:
                    notifyIcon.Icon = Properties.Resources.Three;
                    break;
                case Two:
                    notifyIcon.Icon = Properties.Resources.Two;
                    break;
                case One:
                    notifyIcon.Icon = Properties.Resources.One;
                    break;
                case Zero:
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
