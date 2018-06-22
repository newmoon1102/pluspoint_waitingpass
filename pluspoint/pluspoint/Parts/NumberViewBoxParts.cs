using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace pluspoint.Parts
{
    public partial class NumberViewBoxParts : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NumberViewBoxParts()
        {
            InitializeComponent();

            // 初期値は0
            this.lb_number.Text = "0";
        }

        /// <summary>
        /// 表示する数値
        /// </summary>
        public int Number
        {
            get
            {
                Regex re = new Regex(@"[^0-9]");
                return int.Parse(re.Replace(this.lb_number.Text, ""));
            }
            set
            {
                // 3桁区切りで表示
                this.lb_number.Text = String.Format("{0:#,0}", value);

                // 表示更新
                Invalidate();
            }
        }

        /// <summary>
        /// 読込時
        /// </summary>
        private void NumberViewBoxParts_Load(object sender, EventArgs e)
        {
            // ラベルサイズをベースのサイズに合わせる
            this.lb_number.Size = this.Size;

            // フォントサイズは高さ－上下パディング
            float fontsize = (float)(this.Size.Height * 0.45);
            var font = new Font(this.lb_number.Font.FontFamily, fontsize);
            this.lb_number.Font = font;
        }
    }
}
