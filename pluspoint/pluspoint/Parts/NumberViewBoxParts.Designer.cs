namespace pluspoint.Parts
{
    partial class NumberViewBoxParts
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
            this.lb_number = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_number
            // 
            this.lb_number.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_number.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_number.Location = new System.Drawing.Point(0, 0);
            this.lb_number.Margin = new System.Windows.Forms.Padding(0);
            this.lb_number.Name = "lb_number";
            this.lb_number.Size = new System.Drawing.Size(150, 30);
            this.lb_number.TabIndex = 1;
            this.lb_number.Text = "0";
            this.lb_number.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumberViewBoxParts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_number);
            this.Name = "NumberViewBoxParts";
            this.Size = new System.Drawing.Size(150, 30);
            this.Load += new System.EventHandler(this.NumberViewBoxParts_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lb_number;
    }
}
