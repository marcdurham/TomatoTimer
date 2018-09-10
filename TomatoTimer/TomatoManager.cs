using FlimFlan.IconEncoder;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace TomatoTimer
{
    public partial class TomatoManagerForm : Form
    {
        const int SecondsPerMinute = 60;
        const int TwentyFive = 25 * SecondsPerMinute;
        const int Twenty = 20 * SecondsPerMinute;
        const int Fifteen = 15 * SecondsPerMinute;
        const int Ten = 10 * SecondsPerMinute;
        const int Five = 5 * SecondsPerMinute;
        const int Four = 4 * SecondsPerMinute;
        const int Three = 3 * SecondsPerMinute;
        const int Two = 2 * SecondsPerMinute;
        const int One = 1 * SecondsPerMinute;
        const int Zero = 0;
        const int Duration = TwentyFive;

        int ticks = Duration;

        public TomatoManagerForm()
        {
            InitializeComponent();
            StartTomato();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTomato();
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            ShowTomatoManager();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DecrementTimer();
        }

        void ShowTomatoManager()
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = true;
        }

        void DecrementTimer()
        {
            switch (ticks)
            {
                case TwentyFive:
                    notifyIcon.Icon = Properties.Resources.TwentyFive;
                    break;
                case Twenty:
                    notifyIcon.Icon = Properties.Resources.Twenty;
                    break;
                case Fifteen:
                    notifyIcon.Icon = Properties.Resources.Fifteen;
                    break;
                case Ten:
                    notifyIcon.Icon = Properties.Resources.Ten;
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
                    notifyIcon.Icon = Properties.Resources.Tomato;
                    Done();
                    break;
            }

            int minutes = ticks / SecondsPerMinute;
            int seconds = ticks % SecondsPerMinute;

            notifyIcon.Text = $"Remaining {minutes}:{seconds}";

            Bitmap bmp = new Bitmap(16, 16, PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.FillEllipse(Brushes.Red, 0, 0, 16, 16);
                g.FillRectangle(Brushes.White, 4, 6, 8, 4);
            }
            notifyIcon.Icon = Converter.BitmapToIcon(bmp);

            ticks--;
        }

        void Done()
        {
            timer.Stop();
            ShowTomatoManager();
            MessageBox.Show(
                "Tomato Done", 
                "Tomato Timer", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Asterisk);
        }

        void StartTomato()
        {
            Hide();
            notifyIcon.Visible = true;
            ticks = Duration;
            timer.Start();
        }
    }
}
