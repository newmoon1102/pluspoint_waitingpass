using Logger;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace pluspoint.Parts
{
    public partial class NumberInputBoxParts : UserControl
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        public NumberInputBoxParts()
        {
            // 初期化
            InitializeComponent();

            // 背景色をベースと同じにする
            this.Amount.BackColor = this.BackColor;
        }

        /// <summary>
        /// 3桁区切りフラグ
        /// </summary>
        public bool _DigitSeparator;

        [Description("タイトルラベルに表示する文字")]
        public string TitleText
        {
            get { return this.Title.Text; }
            set
            {
                this.Title.Text = value;
                Invalidate();
            }
        }

        [Description("入力を3桁区切り表示にする")]
        public bool DigitSeparator
        {
            get { return _DigitSeparator; }
            set
            {
                _DigitSeparator = value;
                Invalidate();
            }
        }

        [Description("テキストボックスの背景色")]
        public System.Drawing.Color TextBoxBackColor
        {
            get { return this.Amount.BackColor; }
            set
            {
                this.Amount.BackColor = value;
                Invalidate();
            }
        }

        [Description("読取専用フラグ")]
        public bool ReadOnly
        {
            get { return this.Amount.ReadOnly; }
            set
            {
                this.Amount.ReadOnly = value;
                Invalidate();
            }
        }

        /// <summary>
        /// 金額をint型で保持
        /// </summary>
        public long amountnumber = 0;
        public long AmountNumber
        {
            get { return this.amountnumber; }
            set
            {
                this.amountnumber = value;
                // 表示テキストボックスの更新
                this.Amount.Text = ThreeDigitSeparator(this.amountnumber);
            }
        }

        /// <summary>
        /// テキストボックスへの入力を外部へ公開（タッチパネル用）
        /// </summary>
        public TextBox AmountTextBox
        {
            get { return this.Amount; }
            set { this.Amount = value; }
        }

        /// <summary>
        /// フォーカスされた時、3桁区切りカンマを消す
        /// </summary>
        private void TextBox_FocusIn(object sender, EventArgs e)
        {
            // 読取専用だった場合何もしない
            if (this.Amount.ReadOnly) return;

            // 初期文字カーソルを一番右へ持っていく
            this.Amount.SelectionStart = this.Amount.Text.Length;

            // フォーカスされた時、数値が0の場合、削除
            if (this.Amount.Text == "0") this.Amount.Text = "";

            // 3桁区切りしない場合は処理スキップ
            if (_DigitSeparator)
            {
                try
                {
                    Regex re = new Regex(@"[^0-9]");
                    this.Amount.Text = re.Replace(this.Amount.Text, "");
                }
                catch
                {
                    throw;
                }
            }
        }
        /// <summary>
        /// フォーカスが外れた時、3桁区切り表示
        /// </summary>
        private void TextBox_FocusOut(object sender, EventArgs e)
        {
            try
            {
                // 読取専用だった場合何もしない
                if (this.Amount.ReadOnly) return;

                // フォーカスが外れた時、未入力の場合、0を入れる
                if (this.Amount.Text == "") this.Amount.Text = "0";

                // 金額を数値型で保存＆3桁区切り
                this.AmountNumber = int.Parse(this.Amount.Text);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 入力制限（0～9、Delete、Backspace以外制限）
        /// </summary>
        private void Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 3桁区切り表示文字列に変換（設定を見て３桁表示OFFの場合はそのまま）
        /// </summary>
        /// <param name="num">数値</param>
        /// <returns></returns>
        private String ThreeDigitSeparator(long num)
        {
            string ret;

            try
            {
                if (_DigitSeparator)
                {
                    ret = String.Format("{0:#,0}", num);
                }
                else
                {
                    ret = num.ToString();
                }
            }
            catch
            {
                throw;
            }

            return ret;
        }
    }
}
