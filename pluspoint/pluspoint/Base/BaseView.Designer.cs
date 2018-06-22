namespace pluspoint
{
    partial class BaseView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_nowdate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_nowdate
            // 
            this.lb_nowdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_nowdate.AutoSize = true;
            this.lb_nowdate.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_nowdate.Location = new System.Drawing.Point(285, 3);
            this.lb_nowdate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lb_nowdate.Name = "lb_nowdate";
            this.lb_nowdate.Size = new System.Drawing.Size(112, 11);
            this.lb_nowdate.TabIndex = 6;
            this.lb_nowdate.Text = "現在日時 2018/02/17";
            this.lb_nowdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lb_nowdate);
            this.Name = "BaseView";
            this.Size = new System.Drawing.Size(400, 640);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_nowdate;
    }
}
