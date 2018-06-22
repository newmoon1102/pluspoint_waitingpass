using Logger;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace pluspoint.Base
{

    public partial class TouchForm : Form
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// タッチボタンイベント：全取消
        /// </summary>
        public EventHandler EventTouchBtAllCancel;
        /// <summary>
        /// タッチボタンイベント：Enter
        /// </summary>
        public EventHandler EventTouchBtEnter;
        /// <summary>
        /// タッチボタンイベント：実行
        /// </summary>
        public EventHandler EventTouchBtExecution;

        public TextBox ControlTextBox;

        public TouchForm(BaseForm baseform)
        {
            // 自動生成、フォーム初期化
            InitializeComponent();

            // ベースフォームの情報から位置・サイズを計算設定
            LocationAndSizeCalculation(baseform.Location, baseform.Size);
        }

        public void ViewSetting(TouchFormViewSettingClass Setting)
        {

            if (Setting.BtNumber)
            {
                this.Num1.Show();
                this.Num2.Show();
                this.Num3.Show();
                this.Num4.Show();
                this.Num5.Show();
                this.Num6.Show();
                this.Num7.Show();
                this.Num8.Show();
                this.Num9.Show();
                this.Num0.Show();
                this.Num00.Show();
                this.NumMillion.Show();
            }
            else
            {
                this.Num1.Hide();
                this.Num2.Hide();
                this.Num3.Hide();
                this.Num4.Hide();
                this.Num5.Hide();
                this.Num6.Hide();
                this.Num7.Hide();
                this.Num8.Hide();
                this.Num9.Hide();
                this.Num0.Hide();
                this.Num00.Hide();
                this.NumMillion.Hide();
            }

            if (Setting.BtClear) this.BtClear.Show();
            else this.BtClear.Hide();

            if (Setting.BtAllClear) this.BtAllClear.Show();
            else this.BtAllClear.Hide();

            if (Setting.BtEnter) this.BtEnter.Show();
            else this.BtEnter.Hide();

            if (Setting.BtExecution) this.BtExecution.Show();
            else this.BtExecution.Hide();
        }

        private void LocationAndSizeCalculation(Point BasePos, Size BaseSize)
        {
            // タッチパネルの幅
            Size MySize = new Size();
            // タッチパネルの位置
            Point MyLocation = new Point();

            //--------------------------------------------------
            // 縦置きか横置きか計算（幅を確定、高さを仮設定）
            //--------------------------------------------------
            if (BaseSize.Width > BaseSize.Height)
            {
                // 横置き（イレギュラーだが表示が崩れるのは良くないので入れる）
                MySize.Width = BaseSize.Height;
                MySize.Height = BaseSize.Height;    // 仮設定
            }
            else
            {
                // 縦置き（カード機アプリは横置きが基本）
                MySize.Width = BaseSize.Width;
                MySize.Height = BaseSize.Width;     // 仮設定
            }

            //--------------------------------------------------
            // 各種パーツサイズを計算
            //--------------------------------------------------
            Size BtNum = new Size();    // 数字系のボタンサイズ
            Size BtHalf = new Size();   // クリアと全消しのボタンサイズ
            Size BtFull = new Size();   // Enterと実行のボタンサイズ

            // 数字系ボタンのサイズ作成
            BtNum.Width = (MySize.Width / 2) / 3;   // 横幅の半分を3等分したサイズ
            BtNum.Height = BtNum.Width;             // 正方形なので横幅が決まれば縦幅も確定

            // HalfとFullボタンの横幅設定
            BtFull.Width = (MySize.Width - (BtNum.Width * 3));  // 横幅の半分をフルボタンへ
            BtHalf.Width = (BtFull.Width / 2);  // フルボタンの半分をハーフボタンへ

            // HalfとFullボタンの縦幅設定
            BtFull.Height = (BtNum.Height * 4) / 3; // 数字系ボタン４つを足して3分の１にしたサイズを割り振る
            BtHalf.Height = BtFull.Height;          // FullもHalfも縦幅は同じ

            //--------------------------------------------------
            // 各種パーツ位置を算出
            //--------------------------------------------------
            Point Num1 = new Point();
            Point Num2 = new Point();
            Point Num3 = new Point();
            Point Num4 = new Point();
            Point Num5 = new Point();
            Point Num6 = new Point();
            Point Num7 = new Point();
            Point Num8 = new Point();
            Point Num9 = new Point();
            Point Num0 = new Point();
            Point Num00 = new Point();
            Point NumMillion = new Point();
            Point BtClear = new Point();
            Point BtAllClear = new Point();
            Point BtEnter = new Point();
            Point BtExecution = new Point();

            // 数字系パーツの位置を算出
            // 7  8  9
            // 4  5  6
            // 1  2  3
            // 0  00 万
            // Y設定
            Num7.Y = Num8.Y = Num9.Y = 0;
            Num4.Y = Num5.Y = Num6.Y = (BtNum.Height);
            Num1.Y = Num2.Y = Num3.Y = (BtNum.Height * 2);
            Num0.Y = Num00.Y = NumMillion.Y = (BtNum.Height * 3);
            // X設定
            Num7.X = Num4.X = Num1.X = Num0.X = 0;
            Num8.X = Num5.X = Num2.X = Num00.X = (BtNum.Width);
            Num9.X = Num6.X = Num3.X = NumMillion.X = (BtNum.Width * 2);

            // ハーフ、フルのボタン位置設定
            // Clear  AllClear
            // Enter
            // Execution
            // Y設定
            BtClear.Y = BtAllClear.Y = 0;
            BtEnter.Y = (BtHalf.Height);
            BtExecution.Y = (BtHalf.Height + BtFull.Height);
            // X設定
            BtClear.X = BtEnter.X = BtExecution.X = (BtNum.Width * 3);
            BtAllClear.X = (BtClear.X + BtHalf.Width);

            // ボタンの位置を確定
            this.Num1.Location = Num1;
            this.Num2.Location = Num2;
            this.Num3.Location = Num3;
            this.Num4.Location = Num4;
            this.Num5.Location = Num5;
            this.Num6.Location = Num6;
            this.Num7.Location = Num7;
            this.Num8.Location = Num8;
            this.Num9.Location = Num9;
            this.Num0.Location = Num0;
            this.Num00.Location = Num00;
            this.NumMillion.Location = NumMillion;
            this.BtClear.Location = BtClear;
            this.BtAllClear.Location = BtAllClear;
            this.BtEnter.Location = BtEnter;
            this.BtExecution.Location = BtExecution;

            // ボタンのサイズを確定
            this.Num1.Size = BtNum;
            this.Num2.Size = BtNum;
            this.Num3.Size = BtNum;
            this.Num4.Size = BtNum;
            this.Num5.Size = BtNum;
            this.Num6.Size = BtNum;
            this.Num7.Size = BtNum;
            this.Num8.Size = BtNum;
            this.Num9.Size = BtNum;
            this.Num0.Size = BtNum;
            this.Num00.Size = BtNum;
            this.NumMillion.Size = BtNum;
            this.BtClear.Size = BtHalf;
            this.BtAllClear.Size = BtHalf;
            this.BtEnter.Size = BtFull;
            this.BtExecution.Size = BtFull;

            // タッチの縦幅を設定
            MySize.Height = BtNum.Height * 4;

            // タッチの位置を設定
            MyLocation.X = 0;
            MyLocation.Y = (BaseSize.Height - MySize.Height);

            // タッチの幅を確定
            this.Size = MySize;

            // タッチパネルの位置を確定
            this.Location = MyLocation;
        }

        /// <summary>
        /// クリア、全取消のボタンを押した時
        /// </summary>
        private void ColorChangeClear_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Label btn)
            {
                btn.BackColor = Color.FromArgb(255, 240, 240, 240);
            }
        }
        /// <summary>
        /// クリア、全取消のボタンを離した時
        /// </summary>
        private void ColorChangeClear_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Label btn)
            {
                btn.BackColor = Color.FromArgb(255, 224, 224, 224);
            }
        }

        /// <summary>
        /// タッチのEnterボタンを押した時
        /// </summary>
        private void ColorChangeEnter_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Label btn)
            {
                btn.BackColor = Color.FromArgb(255, 255, 220, 50);
            }
        }
        /// <summary>
        /// タッチのEnterボタンを離した時
        /// </summary>
        private void ColorChangeEnter_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Label btn)
            {
                btn.BackColor = Color.FromArgb(255, 255, 203, 26);
            }
        }

        /// <summary>
        /// 実行ボタンを押した時
        /// </summary>
        private void ColorChangeExecution_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Label btn)
            {
                btn.BackColor = Color.FromArgb(255, 255, 100, 100);
            }
        }
        /// <summary>
        /// 実行ボタンを離した時
        /// </summary>
        private void ColorChangeExecution_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Label btn)
            {
                btn.BackColor = Color.FromArgb(255, 255, 0, 0);
            }
        }

        /// <summary>
        /// 数字ボタンを押した時
        /// </summary>
        private void ColorChangeNum_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Label btn)
            {
                btn.BackColor = Color.FromArgb(255, 200, 200, 255);
            }
        }
        /// <summary>
        /// 数字ボタンを離した時
        /// </summary>
        private void ColorChangeNum_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is Label btn)
            {
                btn.BackColor = Color.FromArgb(255, 0, 120, 215);
            }
        }
        
        private void Text_MouseClick(object sender, EventArgs e)
        {
            if (sender is Label btn)
            {
                ControlTextBox.SelectionStart = ControlTextBox.TextLength;
                
                string str = btn.Text;
                if(int.TryParse(str, out int retnum))
                {
                    if ((ControlTextBox.TextLength + 1) <= ControlTextBox.MaxLength)
                    {
                        ControlTextBox.SelectedText = btn.Text;
                    }
                }
                else
                {
                    if (str == "万")
                    {
                        if ((ControlTextBox.TextLength + 4) <= ControlTextBox.MaxLength)
                        {
                            ControlTextBox.SelectedText = "0000";
                        }
                    }
                    if (str == "クリア") { ControlTextBox.Text = ""; }
                    if (str == "全取消") { EventTouchBtAllCancel(this, EventArgs.Empty); }
                    if (str == "Enter") { EventTouchBtEnter(this, EventArgs.Empty); }
                    if (str == "実行") { EventTouchBtExecution(this, EventArgs.Empty); }

                }
            }
            
        }
    }
}
