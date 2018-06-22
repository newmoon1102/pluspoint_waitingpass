namespace pluspoint.Parts
{
    partial class StringViewBoxParts
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
            this.lb_text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_text
            // 
            this.lb_text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_text.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_text.Location = new System.Drawing.Point(0, 0);
            this.lb_text.Margin = new System.Windows.Forms.Padding(0);
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(150, 30);
            this.lb_text.TabIndex = 1;
            this.lb_text.Text = "Text";
            this.lb_text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StringViewBoxParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_text);
            this.Name = "StringViewBoxParts";
            this.Size = new System.Drawing.Size(150, 30);
            this.Load += new System.EventHandler(this.StringViewBoxParts_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lb_text;
    }
}
