using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace pluspoint.Parts
{
    public partial class StringViewBoxParts : UserControl
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public StringViewBoxParts()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 表示する数値
        /// </summary>
        public string TextView
        {
            get
            {
                return this.lb_text.Text;
            }
            set
            {
                // 3桁区切りで表示
                this.lb_text.Text = value;

                // 表示更新
                Invalidate();
            }
        }

        public ContentAlignment TextAlign
        {
            get { return this.lb_text.TextAlign; }
            set
            {
                // 表示
                this.lb_text.TextAlign = value;

                // 表示更新
                Invalidate();
            }
        }

        /// <summary>
        /// 読込時
        /// </summary>
        private void StringViewBoxParts_Load(object sender, EventArgs e)
        {
            // ラベルサイズをベースのサイズに合わせる
            this.lb_text.Size = this.Size;

            // フォントサイズは高さ－上下パディング
            float fontsize = (float)(this.Size.Height * 0.45);
            var font = new Font(this.lb_text.Font.FontFamily, fontsize);
            this.lb_text.Font = font;
        }
    }
}
