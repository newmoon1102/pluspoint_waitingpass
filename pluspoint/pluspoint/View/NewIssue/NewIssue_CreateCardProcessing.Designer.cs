namespace pluspoint.View
{
    partial class NewIssue_CreateCardProcessing
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
            this.BtBack = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtBack
            // 
            this.BtBack.BackColor = System.Drawing.Color.White;
            this.BtBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBack.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtBack.Location = new System.Drawing.Point(0, 610);
            this.BtBack.Margin = new System.Windows.Forms.Padding(0);
            this.BtBack.Name = "BtBack";
            this.BtBack.Size = new System.Drawing.Size(80, 30);
            this.BtBack.TabIndex = 33;
            this.BtBack.Text = "戻る";
            this.BtBack.UseVisualStyleBackColor = false;
            this.BtBack.Click += new System.EventHandler(this.BtBack_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(20, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(259, 28);
            this.label6.TabIndex = 35;
            this.label6.Text = "只今カード発行処理中です。";
            // 
            // NewIssue_CreateCardProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtBack);
            this.Name = "NewIssue_CreateCardProcessing";
            this.Controls.SetChildIndex(this.BtBack, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtBack;
        private System.Windows.Forms.Label label6;
    }
}
