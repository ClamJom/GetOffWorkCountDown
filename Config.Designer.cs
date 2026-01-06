namespace CountDown
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimeConfirm = new System.Windows.Forms.Button();
            this.endTimeCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "截止时间";
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "HH:mm:ss";
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(98, 19);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.ShowUpDown = true;
            this.endTimePicker.Size = new System.Drawing.Size(99, 21);
            this.endTimePicker.TabIndex = 1;
            // 
            // endTimeConfirm
            // 
            this.endTimeConfirm.Location = new System.Drawing.Point(17, 61);
            this.endTimeConfirm.Name = "endTimeConfirm";
            this.endTimeConfirm.Size = new System.Drawing.Size(75, 23);
            this.endTimeConfirm.TabIndex = 2;
            this.endTimeConfirm.Text = "确定";
            this.endTimeConfirm.UseVisualStyleBackColor = true;
            // 
            // endTimeCancel
            // 
            this.endTimeCancel.Location = new System.Drawing.Point(139, 61);
            this.endTimeCancel.Name = "endTimeCancel";
            this.endTimeCancel.Size = new System.Drawing.Size(75, 23);
            this.endTimeCancel.TabIndex = 3;
            this.endTimeCancel.Text = "取消";
            this.endTimeCancel.UseVisualStyleBackColor = true;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 96);
            this.Controls.Add(this.endTimeCancel);
            this.Controls.Add(this.endTimeConfirm);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.label1);
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Button endTimeConfirm;
        private System.Windows.Forms.Button endTimeCancel;
    }
}