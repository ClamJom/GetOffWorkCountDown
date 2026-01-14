using System.Drawing;
using System.Windows.Forms;

namespace CountDown
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label countDown;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.countDownIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NotifyCloseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.allowTransparentMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setEndTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            countDown = new System.Windows.Forms.Label();
            this.notifyMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // countDown
            // 
            countDown.AutoSize = true;
            countDown.BackColor = System.Drawing.Color.Transparent;
            countDown.Cursor = System.Windows.Forms.Cursors.SizeAll;
            countDown.Dock = System.Windows.Forms.DockStyle.Fill;
            countDown.Font = new System.Drawing.Font("宋体", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            countDown.ForeColor = System.Drawing.Color.White;
            countDown.Location = new System.Drawing.Point(0, 0);
            countDown.Name = "countDown";
            countDown.Size = new System.Drawing.Size(124, 27);
            countDown.TabIndex = 0;
            countDown.Text = "08:00:00";
            // 
            // countDownIcon
            // 
            this.countDownIcon.ContextMenuStrip = this.notifyMenuStrip;
            this.countDownIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("countDownIcon.Icon")));
            this.countDownIcon.Text = "CountDown";
            this.countDownIcon.Visible = true;
            // 
            // notifyMenuStrip
            // 
            this.notifyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotifyCloseMenu,
            this.allowTransparentMenuItem,
            this.setEndTimeMenuItem});
            this.notifyMenuStrip.Name = "notifyMenuStrip";
            this.notifyMenuStrip.ShowCheckMargin = true;
            this.notifyMenuStrip.ShowImageMargin = false;
            this.notifyMenuStrip.Size = new System.Drawing.Size(149, 70);
            // 
            // NotifyCloseMenu
            // 
            this.NotifyCloseMenu.Name = "NotifyCloseMenu";
            this.NotifyCloseMenu.Size = new System.Drawing.Size(148, 22);
            this.NotifyCloseMenu.Text = "关闭";
            this.NotifyCloseMenu.Click += new System.EventHandler(this.NotifyMenuItemClose_Click);
            // 
            // allowTransparentMenuItem
            // 
            this.allowTransparentMenuItem.Name = "allowTransparentMenuItem";
            this.allowTransparentMenuItem.Size = new System.Drawing.Size(148, 22);
            this.allowTransparentMenuItem.Text = "点击穿透";
            this.allowTransparentMenuItem.Click += new System.EventHandler(this.allowTransparentMenuItem_Click);
            // 
            // setEndTimeMenuItem
            // 
            this.setEndTimeMenuItem.Name = "setEndTimeMenuItem";
            this.setEndTimeMenuItem.Size = new System.Drawing.Size(148, 22);
            this.setEndTimeMenuItem.Text = "设置截止时间";
            this.setEndTimeMenuItem.Click += new System.EventHandler(this.setEndTimeMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(120, 34);
            this.Controls.Add(countDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(600, 500);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.notifyMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NotifyIcon countDownIcon;
        private ContextMenuStrip notifyMenuStrip;
        private ToolStripMenuItem NotifyCloseMenu;
        private ToolStripMenuItem allowTransparentMenuItem;
        private ToolStripMenuItem setEndTimeMenuItem;
    }
}

