using System;
using System.Windows.Forms;

namespace TomatoTimer
{
    public partial class TomatoManagerForm : Form
    {
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
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
    }
}
