namespace pluspoint.Base
{
    partial class QRReadForm
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
            this.components = new System.ComponentModel.Container();
            this.LbTitle = new System.Windows.Forms.Label();
            this.LbMessage = new System.Windows.Forms.Label();
            this.BtClose = new System.Windows.Forms.Button();
            this.VideoImageView = new System.Windows.Forms.PictureBox();
            this.TimerWait = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.VideoImageView)).BeginInit();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("メイリオ", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbTitle.Location = new System.Drawing.Point(12, 2);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(134, 28);
            this.LbTitle.TabIndex = 0;
            this.LbTitle.Text = "QRコード読取";
            // 
            // LbMessage
            // 
            this.LbMessage.AutoSize = true;
            this.LbMessage.Font = new System.Drawing.Font("メイリオ", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LbMessage.Location = new System.Drawing.Point(12, 412);
            this.LbMessage.Name = "LbMessage";
            this.LbMessage.Size = new System.Drawing.Size(80, 21);
            this.LbMessage.TabIndex = 2;
            this.LbMessage.Text = "メッセージ";
            // 
            // BtClose
            // 
            this.BtClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtClose.Location = new System.Drawing.Point(368, 0);
            this.BtClose.Margin = new System.Windows.Forms.Padding(0);
            this.BtClose.Name = "BtClose";
            this.BtClose.Size = new System.Drawing.Size(32, 30);
            this.BtClose.TabIndex = 5;
            this.BtClose.Text = "X";
            this.BtClose.UseVisualStyleBackColor = true;
            this.BtClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // VideoImageView
            // 
            this.VideoImageView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.VideoImageView.BackColor = System.Drawing.SystemColors.ControlDark;
            this.VideoImageView.Location = new System.Drawing.Point(12, 33);
            this.VideoImageView.Name = "VideoImageView";
            this.VideoImageView.Size = new System.Drawing.Size(376, 376);
            this.VideoImageView.TabIndex = 6;
            this.VideoImageView.TabStop = false;
            // 
            // TimerWait
            // 
            this.TimerWait.Tick += new System.EventHandler(this.TimerWait_Tick);
            // 
            // QRReadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(400, 640);
            this.Controls.Add(this.VideoImageView);
            this.Controls.Add(this.BtClose);
            this.Controls.Add(this.LbMessage);
            this.Controls.Add(this.LbTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QRReadForm";
            this.Text = "QRReadForm";
            this.Load += new System.EventHandler(this.QRReadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoImageView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Label LbMessage;
        private System.Windows.Forms.Button BtClose;
        private System.Windows.Forms.PictureBox VideoImageView;
        private System.Windows.Forms.Timer TimerWait;
    }
}