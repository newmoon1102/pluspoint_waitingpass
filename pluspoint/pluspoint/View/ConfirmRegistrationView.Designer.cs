namespace pluspoint.View
{
    partial class ConfirmRegistrationView
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
            this.label1 = new System.Windows.Forms.Label();
            this.BtBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(89, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "登録確認の画面予定";
            // 
            // BtBack
            // 
            this.BtBack.BackColor = System.Drawing.Color.White;
            this.BtBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBack.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtBack.Location = new System.Drawing.Point(0, 610);
            this.BtBack.Margin = new System.Windows.Forms.Padding(0);
            this.BtBack.Name = "BtBack";
            this.BtBack.Size = new System.Drawing.Size(80, 30);
            this.BtBack.TabIndex = 9;
            this.BtBack.Text = "戻る";
            this.BtBack.UseVisualStyleBackColor = false;
            this.BtBack.Click += new System.EventHandler(this.BtBack_Click);
            // 
            // ConfirmRegistrationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtBack);
            this.Controls.Add(this.label1);
            this.Name = "ConfirmRegistrationView";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.BtBack, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtBack;
    }
}
