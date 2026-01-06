using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountDown
{
    public partial class MainWindow : Form
    {
        private Color transparentColor = Color.Black;
        private bool allowTransparentClick = false;
        private string endTime = "17:30:00";

        public MainWindow()
        {
            InitializeComponent();
            this.Setup();
        }

        public void Setup()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = this.Width;
            int formHeight = this.Height;
            this.Location = new Point(screenWidth - formWidth - 20, screenHeight - formHeight - 20);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            this.BackColor = transparentColor;
            this.TransparencyKey = transparentColor;
            this.TopMost = true;
            this.AllowTransparency = true;
            this.ShowInTaskbar = false;

            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, false);

            this.RegisterTaskWithSideEffect(this.CountDown);
            this.RegisterCountDownEvents();
        }

        public void RegisterCountDownEvents()
        {
            Label countDown = (Label)this.GetControlByName("countDown");
            countDown.EnableDrag();
            countDown.EnableDoubleClickToClose();
            countDown.MouseClick += (sender, e) =>
            {
                if(e.Button == MouseButtons.Right)
                {
                    ColorDialog colorDialog = new ColorDialog();
                    colorDialog.Color = transparentColor;
                    if(colorDialog.ShowDialog() == DialogResult.OK)
                    {
                        if(colorDialog.Color != transparentColor)
                            countDown.ForeColor = colorDialog.Color;
                        else
                        {
                            MessageBox.Show("设置为该颜色将导致文字变为透明，不允许设置为当前颜色");
                        }
                    }
                }
            };
            countDown.MouseClick += (sender, e) =>
            {
                if (e.Button != MouseButtons.Middle) return;
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = transparentColor;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    if (colorDialog.Color != countDown.ForeColor)
                    {
                        transparentColor = colorDialog.Color;
                        this.TransparencyKey = transparentColor;
                        countDown.BackColor = transparentColor;
                        this.BackColor = transparentColor;
                    }
                    else
                    {
                        MessageBox.Show("设置为该颜色将导致文字变为透明，不允许设置为当前颜色");
                    }
                }
            };
        }

        public Task RegisterTaskWithSideEffect(Action action, Action taskEnd=null)
        {
            Task newTask = new Task(action);
            newTask.Start();
            newTask.ContinueWith(t=>taskEnd, TaskScheduler.FromCurrentSynchronizationContext());
            return newTask;
        }

        public void CountDown()
        {
            DateTime now = DateTime.Now;
            DateTime end = DateTime.Parse(now.ToString("yyyy-MM-dd "+this.endTime));
            while (now < end)
            {
                end = DateTime.Parse(now.ToString("yyyy-MM-dd " + this.endTime));
                if (now > end) continue;
                TimeSpan timeSpan = end - now;
                string leftTime = String.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);

                MethodInvoker mi = new MethodInvoker(() =>
                {
                    Label countDown = (Label)this.GetControlByName("countDown");
                    if (countDown == null) return;
                    countDown.Text = leftTime;
                });
                this.BeginInvoke(mi);
                Thread.Sleep(1000);
                now = DateTime.Now;
            }
        }

        private Control GetControlByName(string name)
        {
            Control control = this.Controls.Find(name, true).FirstOrDefault();
            return control;
        }

        private void NotifyMenuItemClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void allowTransparentMenuItem_Click(object sender, EventArgs e)
        {
            this.allowTransparentClick = !this.allowTransparentClick;
            this.allowTransparentMenuItem.Checked = this.allowTransparentClick;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, this.allowTransparentClick);
            if (this.allowTransparentClick)
            {
                this.onClickThrough();
            }
            else
            {
                this.offClickThrough();
            }
        }

        private void setEndTimeMenuItem_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DateTime endTime = DateTime.Parse(now.ToString("yyyy-MM-dd " + this.endTime));
            Form setEndTimeDialog = new Config();
            DateTimePicker endTimePicker = (DateTimePicker)setEndTimeDialog.Controls.Find("endTimePicker", true).FirstOrDefault();
            endTimePicker.Value = endTime;
            Button endTimeConfirm = (Button)setEndTimeDialog.Controls.Find("endTimeConfirm", true).FirstOrDefault();
            endTimeConfirm.MouseClick += (s, _e) => 
            {
                endTime = endTimePicker.Value;
                this.endTime = endTime.ToString("HH:mm:ss");
                setEndTimeDialog.Close();
            };
            Button endTimeCancel = (Button)setEndTimeDialog.Controls.Find("endTimeCancel", true).First();
            endTimeCancel.MouseClick += (s, _e) =>
            {
                setEndTimeDialog.Close();
            };
            setEndTimeDialog.ShowDialog();
        }

        private void onClickThrough()
        {
            const int WS_EX_TRANSPARENT = 0x20;
            const int WS_EX_LAYERED = 0x80000;
            const int GWL_EXSTYLE = -20;

            int style = GetWindowLong(this.Handle, GWL_EXSTYLE);

            style |= WS_EX_TRANSPARENT;

            SetWindowLong(this.Handle, GWL_EXSTYLE, style);
        }

        private void offClickThrough()
        {
            const int WS_EX_TRANSPARENT = 0x20;
            const int WS_EX_LAYERED = 0x80000;
            const int GWL_EXSTYLE = -20;

            int style = GetWindowLong(this.Handle, GWL_EXSTYLE);

            style &= ~WS_EX_TRANSPARENT;

            SetWindowLong(this.Handle, GWL_EXSTYLE, style);
        }

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}
