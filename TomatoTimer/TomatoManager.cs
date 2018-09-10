using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using FlimFlan.IconEncoder;

namespace TomatoTimer
{
    public partial class TomatoManagerForm : Form
    {
        const int SecondsPerMinute = 60;
        const int Duration = 25 * SecondsPerMinute;

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
            int minutes = ticks / SecondsPerMinute;
            int seconds = ticks % SecondsPerMinute;

            notifyIcon.Text = $"Remaining {minutes}:{seconds}";

            var bmp = new Bitmap(16, 16, PixelFormat.Format24bppRgb);
            var font = new Font(FontFamily.GenericSansSerif, 10.0f);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawString($"{minutes}", font, Brushes.White, 0.0f, 0.0f);
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
