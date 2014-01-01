namespace StreamingDemo.Client
{
    partial class Form1
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
            this.btnPlay = new System.Windows.Forms.Button();
            this.lblMiddle = new System.Windows.Forms.Label();
            this.lblBytes = new System.Windows.Forms.Label();
            this.lblMilliseconds = new System.Windows.Forms.Label();
            this.lblRight = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(12, 12);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 0;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlayClick);
            // 
            // lblMiddle
            // 
            this.lblMiddle.AutoSize = true;
            this.lblMiddle.Location = new System.Drawing.Point(208, 17);
            this.lblMiddle.Name = "lblMiddle";
            this.lblMiddle.Size = new System.Drawing.Size(88, 13);
            this.lblMiddle.TabIndex = 1;
            this.lblMiddle.Text = "bytes returned in ";
            // 
            // lblBytes
            // 
            this.lblBytes.AutoSize = true;
            this.lblBytes.Location = new System.Drawing.Point(114, 17);
            this.lblBytes.Name = "lblBytes";
            this.lblBytes.Size = new System.Drawing.Size(0, 13);
            this.lblBytes.TabIndex = 2;
            // 
            // lblMilliseconds
            // 
            this.lblMilliseconds.AutoSize = true;
            this.lblMilliseconds.Location = new System.Drawing.Point(303, 17);
            this.lblMilliseconds.Name = "lblMilliseconds";
            this.lblMilliseconds.Size = new System.Drawing.Size(73, 13);
            this.lblMilliseconds.TabIndex = 3;
            this.lblMilliseconds.Text = "33333333333";
            // 
            // lblRight
            // 
            this.lblRight.AutoSize = true;
            this.lblRight.Location = new System.Drawing.Point(396, 17);
            this.lblRight.Name = "lblRight";
            this.lblRight.Size = new System.Drawing.Size(63, 13);
            this.lblRight.TabIndex = 4;
            this.lblRight.Text = "milliseconds";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 163);
            this.Controls.Add(this.lblRight);
            this.Controls.Add(this.lblMilliseconds);
            this.Controls.Add(this.lblBytes);
            this.Controls.Add(this.lblMiddle);
            this.Controls.Add(this.btnPlay);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Label lblMiddle;
        private System.Windows.Forms.Label lblBytes;
        private System.Windows.Forms.Label lblMilliseconds;
        private System.Windows.Forms.Label lblRight;
    }
}

