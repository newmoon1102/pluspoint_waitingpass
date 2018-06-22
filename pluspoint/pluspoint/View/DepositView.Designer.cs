namespace pluspoint.View
{
    partial class DepositView
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
            this.bt_back = new System.Windows.Forms.Button();
            this.numberInputBoxParts7 = new pluspoint.Parts.NumberInputBoxParts();
            this.numberInputBoxParts6 = new pluspoint.Parts.NumberInputBoxParts();
            this.numberInputBoxParts5 = new pluspoint.Parts.NumberInputBoxParts();
            this.numberInputBoxParts4 = new pluspoint.Parts.NumberInputBoxParts();
            this.numberInputBoxParts2 = new pluspoint.Parts.NumberInputBoxParts();
            this.numberInputBoxParts3 = new pluspoint.Parts.NumberInputBoxParts();
            this.numberInputBoxParts1 = new pluspoint.Parts.NumberInputBoxParts();
            this.lb_title = new System.Windows.Forms.Label();
            this.Before_PriNokoNum = new pluspoint.Parts.NumberViewBoxParts();
            this.Before_PointRuiNum = new pluspoint.Parts.NumberViewBoxParts();
            this.After_PriNokoNum = new pluspoint.Parts.NumberViewBoxParts();
            this.After_PointRuiNum = new pluspoint.Parts.NumberViewBoxParts();
            this.ThisTime = new pluspoint.Parts.NumberViewBoxParts();
            this.button1 = new System.Windows.Forms.Button();
            this.stringViewBoxParts2 = new pluspoint.Parts.StringViewBoxParts();
            this.stringViewBoxParts1 = new pluspoint.Parts.StringViewBoxParts();
            this.stringViewBoxParts4 = new pluspoint.Parts.StringViewBoxParts();
            this.stringViewBoxParts3 = new pluspoint.Parts.StringViewBoxParts();
            this.stringViewBoxParts5 = new pluspoint.Parts.StringViewBoxParts();
            this.stringViewBoxParts6 = new pluspoint.Parts.StringViewBoxParts();
            this.stringViewBoxParts7 = new pluspoint.Parts.StringViewBoxParts();
            this.stringViewBoxParts8 = new pluspoint.Parts.StringViewBoxParts();
            this.stringViewBoxParts9 = new pluspoint.Parts.StringViewBoxParts();
            this.SuspendLayout();
            // 
            // bt_back
            // 
            this.bt_back.BackColor = System.Drawing.Color.White;
            this.bt_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_back.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bt_back.Location = new System.Drawing.Point(0, 610);
            this.bt_back.Margin = new System.Windows.Forms.Padding(0);
            this.bt_back.Name = "bt_back";
            this.bt_back.Size = new System.Drawing.Size(80, 30);
            this.bt_back.TabIndex = 11;
            this.bt_back.Text = "戻る";
            this.bt_back.UseVisualStyleBackColor = false;
            this.bt_back.Click += new System.EventHandler(this.Bt_back_Click);
            // 
            // numberInputBoxParts7
            // 
            this.numberInputBoxParts7.BackColor = System.Drawing.SystemColors.Control;
            this.numberInputBoxParts7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberInputBoxParts7.CausesValidation = false;
            this.numberInputBoxParts7.DigitSeparator = true;
            this.numberInputBoxParts7.Location = new System.Drawing.Point(0, 423);
            this.numberInputBoxParts7.Margin = new System.Windows.Forms.Padding(0);
            this.numberInputBoxParts7.Name = "numberInputBoxParts7";
            this.numberInputBoxParts7.ReadOnly = true;
            this.numberInputBoxParts7.Size = new System.Drawing.Size(206, 59);
            this.numberInputBoxParts7.TabIndex = 19;
            this.numberInputBoxParts7.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.numberInputBoxParts7.TitleText = "ポイント";
            // 
            // numberInputBoxParts6
            // 
            this.numberInputBoxParts6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberInputBoxParts6.DigitSeparator = true;
            this.numberInputBoxParts6.Location = new System.Drawing.Point(0, 365);
            this.numberInputBoxParts6.Margin = new System.Windows.Forms.Padding(0);
            this.numberInputBoxParts6.Name = "numberInputBoxParts6";
            this.numberInputBoxParts6.ReadOnly = false;
            this.numberInputBoxParts6.Size = new System.Drawing.Size(206, 59);
            this.numberInputBoxParts6.TabIndex = 18;
            this.numberInputBoxParts6.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts6.TitleText = "クレジット（金券４）";
            this.numberInputBoxParts6.Enter += new System.EventHandler(this.TouchShow_Click);
            this.numberInputBoxParts6.Leave += new System.EventHandler(this.TouchHide_Click);
            // 
            // numberInputBoxParts5
            // 
            this.numberInputBoxParts5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberInputBoxParts5.DigitSeparator = true;
            this.numberInputBoxParts5.Location = new System.Drawing.Point(0, 307);
            this.numberInputBoxParts5.Margin = new System.Windows.Forms.Padding(0);
            this.numberInputBoxParts5.Name = "numberInputBoxParts5";
            this.numberInputBoxParts5.ReadOnly = false;
            this.numberInputBoxParts5.Size = new System.Drawing.Size(206, 59);
            this.numberInputBoxParts5.TabIndex = 17;
            this.numberInputBoxParts5.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts5.TitleText = "金券３";
            this.numberInputBoxParts5.Enter += new System.EventHandler(this.TouchShow_Click);
            this.numberInputBoxParts5.Leave += new System.EventHandler(this.TouchHide_Click);
            // 
            // numberInputBoxParts4
            // 
            this.numberInputBoxParts4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberInputBoxParts4.DigitSeparator = true;
            this.numberInputBoxParts4.Location = new System.Drawing.Point(0, 249);
            this.numberInputBoxParts4.Margin = new System.Windows.Forms.Padding(0);
            this.numberInputBoxParts4.Name = "numberInputBoxParts4";
            this.numberInputBoxParts4.ReadOnly = false;
            this.numberInputBoxParts4.Size = new System.Drawing.Size(206, 59);
            this.numberInputBoxParts4.TabIndex = 16;
            this.numberInputBoxParts4.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts4.TitleText = "金券２";
            this.numberInputBoxParts4.Enter += new System.EventHandler(this.TouchShow_Click);
            this.numberInputBoxParts4.Leave += new System.EventHandler(this.TouchHide_Click);
            // 
            // numberInputBoxParts2
            // 
            this.numberInputBoxParts2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberInputBoxParts2.DigitSeparator = true;
            this.numberInputBoxParts2.Location = new System.Drawing.Point(0, 191);
            this.numberInputBoxParts2.Margin = new System.Windows.Forms.Padding(0);
            this.numberInputBoxParts2.Name = "numberInputBoxParts2";
            this.numberInputBoxParts2.ReadOnly = false;
            this.numberInputBoxParts2.Size = new System.Drawing.Size(206, 59);
            this.numberInputBoxParts2.TabIndex = 15;
            this.numberInputBoxParts2.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts2.TitleText = "金券１";
            this.numberInputBoxParts2.Enter += new System.EventHandler(this.TouchShow_Click);
            this.numberInputBoxParts2.Leave += new System.EventHandler(this.TouchHide_Click);
            // 
            // numberInputBoxParts3
            // 
            this.numberInputBoxParts3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberInputBoxParts3.DigitSeparator = true;
            this.numberInputBoxParts3.Location = new System.Drawing.Point(0, 133);
            this.numberInputBoxParts3.Margin = new System.Windows.Forms.Padding(0);
            this.numberInputBoxParts3.Name = "numberInputBoxParts3";
            this.numberInputBoxParts3.ReadOnly = false;
            this.numberInputBoxParts3.Size = new System.Drawing.Size(206, 59);
            this.numberInputBoxParts3.TabIndex = 14;
            this.numberInputBoxParts3.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numberInputBoxParts3.TitleText = "ポイント";
            this.numberInputBoxParts3.Enter += new System.EventHandler(this.TouchShow_Click);
            this.numberInputBoxParts3.Leave += new System.EventHandler(this.TouchHide_Click);
            // 
            // numberInputBoxParts1
            // 
            this.numberInputBoxParts1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numberInputBoxParts1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberInputBoxParts1.DigitSeparator = true;
            this.numberInputBoxParts1.Location = new System.Drawing.Point(0, 14);
            this.numberInputBoxParts1.Margin = new System.Windows.Forms.Padding(0);
            this.numberInputBoxParts1.Name = "numberInputBoxParts1";
            this.numberInputBoxParts1.ReadOnly = false;
            this.numberInputBoxParts1.Size = new System.Drawing.Size(206, 59);
            this.numberInputBoxParts1.TabIndex = 12;
            this.numberInputBoxParts1.TextBoxBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.numberInputBoxParts1.TitleText = "入金金額";
            this.numberInputBoxParts1.Enter += new System.EventHandler(this.TouchShow_Click);
            this.numberInputBoxParts1.Leave += new System.EventHandler(this.TouchHide_Click);
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("MS UI Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lb_title.Location = new System.Drawing.Point(215, 23);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(56, 22);
            this.lb_title.TabIndex = 20;
            this.lb_title.Text = "入金";
            // 
            // Before_PriNokoNum
            // 
            this.Before_PriNokoNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Before_PriNokoNum.Location = new System.Drawing.Point(308, 191);
            this.Before_PriNokoNum.Name = "Before_PriNokoNum";
            this.Before_PriNokoNum.Number = 0;
            this.Before_PriNokoNum.Size = new System.Drawing.Size(89, 30);
            this.Before_PriNokoNum.TabIndex = 21;
            // 
            // Before_PointRuiNum
            // 
            this.Before_PointRuiNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Before_PointRuiNum.Location = new System.Drawing.Point(308, 220);
            this.Before_PointRuiNum.Name = "Before_PointRuiNum";
            this.Before_PointRuiNum.Number = 0;
            this.Before_PointRuiNum.Size = new System.Drawing.Size(89, 30);
            this.Before_PointRuiNum.TabIndex = 22;
            // 
            // After_PriNokoNum
            // 
            this.After_PriNokoNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.After_PriNokoNum.Location = new System.Drawing.Point(308, 307);
            this.After_PriNokoNum.Name = "After_PriNokoNum";
            this.After_PriNokoNum.Number = 0;
            this.After_PriNokoNum.Size = new System.Drawing.Size(89, 30);
            this.After_PriNokoNum.TabIndex = 23;
            // 
            // After_PointRuiNum
            // 
            this.After_PointRuiNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.After_PointRuiNum.Location = new System.Drawing.Point(308, 336);
            this.After_PointRuiNum.Margin = new System.Windows.Forms.Padding(0);
            this.After_PointRuiNum.Name = "After_PointRuiNum";
            this.After_PointRuiNum.Number = 0;
            this.After_PointRuiNum.Size = new System.Drawing.Size(89, 30);
            this.After_PointRuiNum.TabIndex = 24;
            // 
            // ThisTime
            // 
            this.ThisTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ThisTime.Location = new System.Drawing.Point(343, 266);
            this.ThisTime.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ThisTime.Name = "ThisTime";
            this.ThisTime.Number = 0;
            this.ThisTime.Size = new System.Drawing.Size(54, 25);
            this.ThisTime.TabIndex = 25;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.button1.FlatAppearance.BorderColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(343, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 62);
            this.button1.TabIndex = 26;
            this.button1.Text = "取出";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.BTCardDischarge);
            // 
            // stringViewBoxParts2
            // 
            this.stringViewBoxParts2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stringViewBoxParts2.Location = new System.Drawing.Point(219, 72);
            this.stringViewBoxParts2.Margin = new System.Windows.Forms.Padding(0);
            this.stringViewBoxParts2.Name = "stringViewBoxParts2";
            this.stringViewBoxParts2.Size = new System.Drawing.Size(125, 32);
            this.stringViewBoxParts2.TabIndex = 28;
            this.stringViewBoxParts2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stringViewBoxParts2.TextView = "0000-00000";
            // 
            // stringViewBoxParts1
            // 
            this.stringViewBoxParts1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stringViewBoxParts1.Location = new System.Drawing.Point(219, 103);
            this.stringViewBoxParts1.Margin = new System.Windows.Forms.Padding(0);
            this.stringViewBoxParts1.Name = "stringViewBoxParts1";
            this.stringViewBoxParts1.Size = new System.Drawing.Size(125, 31);
            this.stringViewBoxParts1.TabIndex = 29;
            this.stringViewBoxParts1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.stringViewBoxParts1.TextView = "Name";
            // 
            // stringViewBoxParts4
            // 
            this.stringViewBoxParts4.BackColor = System.Drawing.SystemColors.Control;
            this.stringViewBoxParts4.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stringViewBoxParts4.Location = new System.Drawing.Point(236, 196);
            this.stringViewBoxParts4.Margin = new System.Windows.Forms.Padding(0);
            this.stringViewBoxParts4.Name = "stringViewBoxParts4";
            this.stringViewBoxParts4.Size = new System.Drawing.Size(69, 20);
            this.stringViewBoxParts4.TabIndex = 31;
            this.stringViewBoxParts4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stringViewBoxParts4.TextView = "プリペイド残";
            // 
            // stringViewBoxParts3
            // 
            this.stringViewBoxParts3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stringViewBoxParts3.Location = new System.Drawing.Point(236, 225);
            this.stringViewBoxParts3.Margin = new System.Windows.Forms.Padding(0);
            this.stringViewBoxParts3.Name = "stringViewBoxParts3";
            this.stringViewBoxParts3.Size = new System.Drawing.Size(69, 20);
            this.stringViewBoxParts3.TabIndex = 32;
            this.stringViewBoxParts3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stringViewBoxParts3.TextView = "ポイント累計";
            // 
            // stringViewBoxParts5
            // 
            this.stringViewBoxParts5.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stringViewBoxParts5.Location = new System.Drawing.Point(272, 269);
            this.stringViewBoxParts5.Margin = new System.Windows.Forms.Padding(0);
            this.stringViewBoxParts5.Name = "stringViewBoxParts5";
            this.stringViewBoxParts5.Size = new System.Drawing.Size(69, 20);
            this.stringViewBoxParts5.TabIndex = 33;
            this.stringViewBoxParts5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stringViewBoxParts5.TextView = "今回ポイント";
            // 
            // stringViewBoxParts6
            // 
            this.stringViewBoxParts6.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stringViewBoxParts6.Location = new System.Drawing.Point(236, 312);
            this.stringViewBoxParts6.Margin = new System.Windows.Forms.Padding(0);
            this.stringViewBoxParts6.Name = "stringViewBoxParts6";
            this.stringViewBoxParts6.Size = new System.Drawing.Size(69, 20);
            this.stringViewBoxParts6.TabIndex = 34;
            this.stringViewBoxParts6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stringViewBoxParts6.TextView = "プリペイド残";
            // 
            // stringViewBoxParts7
            // 
            this.stringViewBoxParts7.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stringViewBoxParts7.Location = new System.Drawing.Point(236, 341);
            this.stringViewBoxParts7.Margin = new System.Windows.Forms.Padding(0);
            this.stringViewBoxParts7.Name = "stringViewBoxParts7";
            this.stringViewBoxParts7.Size = new System.Drawing.Size(69, 20);
            this.stringViewBoxParts7.TabIndex = 35;
            this.stringViewBoxParts7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stringViewBoxParts7.TextView = "ポイント累計";
            // 
            // stringViewBoxParts8
            // 
            this.stringViewBoxParts8.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stringViewBoxParts8.Location = new System.Drawing.Point(209, 196);
            this.stringViewBoxParts8.Margin = new System.Windows.Forms.Padding(0);
            this.stringViewBoxParts8.Name = "stringViewBoxParts8";
            this.stringViewBoxParts8.Size = new System.Drawing.Size(21, 20);
            this.stringViewBoxParts8.TabIndex = 36;
            this.stringViewBoxParts8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stringViewBoxParts8.TextView = "前";
            // 
            // stringViewBoxParts9
            // 
            this.stringViewBoxParts9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.stringViewBoxParts9.Location = new System.Drawing.Point(209, 312);
            this.stringViewBoxParts9.Margin = new System.Windows.Forms.Padding(0);
            this.stringViewBoxParts9.Name = "stringViewBoxParts9";
            this.stringViewBoxParts9.Size = new System.Drawing.Size(21, 20);
            this.stringViewBoxParts9.TabIndex = 37;
            this.stringViewBoxParts9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stringViewBoxParts9.TextView = "後";
            // 
            // DepositView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numberInputBoxParts7);
            this.Controls.Add(this.numberInputBoxParts6);
            this.Controls.Add(this.numberInputBoxParts5);
            this.Controls.Add(this.stringViewBoxParts9);
            this.Controls.Add(this.numberInputBoxParts4);
            this.Controls.Add(this.stringViewBoxParts8);
            this.Controls.Add(this.numberInputBoxParts2);
            this.Controls.Add(this.stringViewBoxParts7);
            this.Controls.Add(this.numberInputBoxParts3);
            this.Controls.Add(this.stringViewBoxParts6);
            this.Controls.Add(this.numberInputBoxParts1);
            this.Controls.Add(this.stringViewBoxParts5);
            this.Controls.Add(this.stringViewBoxParts3);
            this.Controls.Add(this.stringViewBoxParts4);
            this.Controls.Add(this.stringViewBoxParts1);
            this.Controls.Add(this.stringViewBoxParts2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ThisTime);
            this.Controls.Add(this.After_PointRuiNum);
            this.Controls.Add(this.After_PriNokoNum);
            this.Controls.Add(this.Before_PointRuiNum);
            this.Controls.Add(this.Before_PriNokoNum);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.bt_back);
            this.Name = "DepositView";
            this.Click += new System.EventHandler(this.FocusClear);
            this.Controls.SetChildIndex(this.bt_back, 0);
            this.Controls.SetChildIndex(this.lb_title, 0);
            this.Controls.SetChildIndex(this.Before_PriNokoNum, 0);
            this.Controls.SetChildIndex(this.Before_PointRuiNum, 0);
            this.Controls.SetChildIndex(this.After_PriNokoNum, 0);
            this.Controls.SetChildIndex(this.After_PointRuiNum, 0);
            this.Controls.SetChildIndex(this.ThisTime, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.stringViewBoxParts2, 0);
            this.Controls.SetChildIndex(this.stringViewBoxParts1, 0);
            this.Controls.SetChildIndex(this.stringViewBoxParts4, 0);
            this.Controls.SetChildIndex(this.stringViewBoxParts3, 0);
            this.Controls.SetChildIndex(this.stringViewBoxParts5, 0);
            this.Controls.SetChildIndex(this.numberInputBoxParts1, 0);
            this.Controls.SetChildIndex(this.stringViewBoxParts6, 0);
            this.Controls.SetChildIndex(this.numberInputBoxParts3, 0);
            this.Controls.SetChildIndex(this.stringViewBoxParts7, 0);
            this.Controls.SetChildIndex(this.numberInputBoxParts2, 0);
            this.Controls.SetChildIndex(this.stringViewBoxParts8, 0);
            this.Controls.SetChildIndex(this.numberInputBoxParts4, 0);
            this.Controls.SetChildIndex(this.stringViewBoxParts9, 0);
            this.Controls.SetChildIndex(this.numberInputBoxParts5, 0);
            this.Controls.SetChildIndex(this.numberInputBoxParts6, 0);
            this.Controls.SetChildIndex(this.numberInputBoxParts7, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_back;
        private Parts.NumberInputBoxParts numberInputBoxParts1;
        private Parts.NumberInputBoxParts numberInputBoxParts3;
        private Parts.NumberInputBoxParts numberInputBoxParts2;
        private Parts.NumberInputBoxParts numberInputBoxParts4;
        private Parts.NumberInputBoxParts numberInputBoxParts5;
        private Parts.NumberInputBoxParts numberInputBoxParts6;
        private Parts.NumberInputBoxParts numberInputBoxParts7;
        private System.Windows.Forms.Label lb_title;
        private Parts.NumberViewBoxParts Before_PriNokoNum;
        private Parts.NumberViewBoxParts Before_PointRuiNum;
        private Parts.NumberViewBoxParts After_PriNokoNum;
        private Parts.NumberViewBoxParts After_PointRuiNum;
        private Parts.NumberViewBoxParts ThisTime;
        private System.Windows.Forms.Button button1;
        private Parts.StringViewBoxParts stringViewBoxParts2;
        private Parts.StringViewBoxParts stringViewBoxParts1;
        private Parts.StringViewBoxParts stringViewBoxParts4;
        private Parts.StringViewBoxParts stringViewBoxParts3;
        private Parts.StringViewBoxParts stringViewBoxParts5;
        private Parts.StringViewBoxParts stringViewBoxParts6;
        private Parts.StringViewBoxParts stringViewBoxParts7;
        private Parts.StringViewBoxParts stringViewBoxParts8;
        private Parts.StringViewBoxParts stringViewBoxParts9;
    }
}
