using Logger;
using Option;
using pluspoint.Base;
using System;
using System.Windows.Forms;

namespace pluspoint
{
    public partial class BaseView : UserControl
    {
        //--------------------------------------------------
        // メンバ変数
        //--------------------------------------------------
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// オプション
        /// </summary>
        protected OptionClass XMLOption = OptionClass.Instance;

        /// <summary>
        /// ログイントークン
        /// </summary>
        public static string LoginToken;

        /// <summary>
        /// 画面の保持しているデータ、戻るにて戻ってきた時に上位画面でデータを受け取りたいときに使用する
        /// </summary>
        public object[] ScreenData = null;

        /// <summary>
        /// タッチパネル呼び時の移動量
        /// </summary>
        private int TouchMoveNum = 0;

        //--------------------------------------------------
        // イベント関連
        //--------------------------------------------------
        #region イベントデリゲート
        /// <summary>
        /// ページ変更イベントのデリゲート
        /// </summary>
        /// <param name="ViewClassName">遷移先Class名</param>
        /// <param name="viewclassdata">コンストラクタ引数</param>
        public delegate void PageChangeEventHandler(string ViewClassName, object[] viewclassdata);
        /// <summary>
        /// ページ戻るイベントのデリゲート
        /// </summary>
        /// <param name="backdata"></param>
        public delegate void PageBackEventHandler(object[] backdata);
        /// <summary>
        /// ページトップイベントのデリゲート
        /// </summary>
        public delegate void PageTopEventHandler();
        /// <summary>
        /// プログラム終了イベントのデリゲート
        /// </summary>
        public delegate void ProgramCloseEventHandler();
        /// <summary>
        /// タッチ入力画面表示イベントのデリゲート
        /// </summary>
        public delegate void TouchDisplayShowEventHandler(TextBox textbox);
        /// <summary>
        /// タッチ入力画面非表示イベントのデリゲート
        /// </summary>
        public delegate void TouchDisplayHideEventHandler();
        #endregion

        #region イベント
        /// <summary>
        /// ページ変更イベント
        /// </summary>
        public event PageChangeEventHandler PageChangeEvent;
        /// <summary>
        /// ページ戻るイベント
        /// </summary>
        public event PageBackEventHandler PageBackEvent;
        /// <summary>
        /// ページトップイベント
        /// </summary>
        public event PageTopEventHandler PageTopEvent;
        /// <summary>
        /// プログラム終了イベント
        /// </summary>
        public event ProgramCloseEventHandler ProgramCloseEvent;
        /// <summary>
        /// タッチ画面表示イベント
        /// </summary>
        public event TouchDisplayShowEventHandler TouchDisplayShowEvent;
        /// <summary>
        /// タッチ画面非表示イベント
        /// </summary>
        public event TouchDisplayHideEventHandler TouchDisplayHideEvent;
        #endregion


        //--------------------------------------------------
        // 基本系
        //--------------------------------------------------
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public BaseView()
        {
            //--------------------------------------------------
            // デフォルトの初期化（自動生成）
            //--------------------------------------------------
            InitializeComponent();

            //--------------------------------------------------
            // 現在日付の取得
            //--------------------------------------------------
            DateTime dtToday = DateTime.Today;

            //--------------------------------------------------
            // ラベルに現在日付を表示
            //--------------------------------------------------
            lb_nowdate.Text = "現在日付 " + dtToday.ToLongDateString();

            //--------------------------------------------------
            // 表示位置調整
            //--------------------------------------------------
            // 現在日付ラベルの横幅取得
            int LabelWidth = lb_nowdate.Size.Width;
            // フォームの横幅取得
            int FormWidth = this.Size.Width;
            // ラベルの座標取得
            var location = lb_nowdate.Location;
            // ラベルの座標をぴったり右上になるように計算
            location.X = (FormWidth - LabelWidth);
            // ラベルの座標を画面に反映
            lb_nowdate.Location = location;
        }


        //--------------------------------------------------
        // ページ設定関連
        //--------------------------------------------------
        /// <summary>
        /// タスクバータイトル変更・画面遷移時自動で呼ばれる
        /// </summary>
        /// <returns>タイトルを変更する</returns>
        public virtual string SetTaskBarTitle()
        {
            return "タイトルが設定されていません";
        }

        /// <summary>
        /// QR読取りフォームの表示
        /// </summary>
        /// <returns>成功時：QRコードの文字列　失敗時：空白</returns>
        protected string QRReaderPopup()
        {
            string ret;

            try
            {
                // QR読取りPOPUP起動
                QRReadForm QRPop = new QRReadForm
                {
                    // メインフォームがQRフォームを所有する
                    Owner = this.ParentForm
                };

                // ダイアログ表示
                QRPop.ShowDialog(this);

                // QRの戻り値取得
                ret = QRPop.ReturnValue;

                // QR読取りフォームの開放
                QRPop.Dispose();
            }
            catch
            {
                throw;
            }

            return ret;
        }
        protected string QRReaderPopup(string Title, string Message)
        {
            string ret;

            try
            {
                // QR読取りPOPUP起動
                QRReadForm QRPop = new QRReadForm(Title, Message)
                {
                    // メインフォームがQRフォームを所有する
                    Owner = this.ParentForm
                };

                // ダイアログ表示
                QRPop.ShowDialog(this);

                // QRの戻り値取得
                ret = QRPop.ReturnValue;

                // QR読取りフォームの開放
                QRPop.Dispose();
            }
            catch
            {
                throw;
            }

            return ret;
        }

        //--------------------------------------------------
        // ページ遷移関連
        //--------------------------------------------------
        #region ページ遷移
        /// <summary>
        /// ページ遷移
        /// </summary>
        /// <param name="ViewClassName"></param>
        /// <param name="viewclassdata"></param>
        protected void PageChange(string ViewClassName, object[] viewclassdata)
        {
            // ページ遷移イベントを起こす
            PageChangeEvent(ViewClassName, viewclassdata);
        }
        /// <summary>
        /// ページ戻る
        /// </summary>
        /// <param name="backdata"></param>
        protected void PageBack(object[] backdata)
        {
            // ページ戻る遷移イベントを起こす
            PageBackEvent(backdata);
        }
        /// <summary>
        /// ページトップ
        /// </summary>
        protected void PageTop()
        {
            // ページトップ遷移イベントを起こす
            PageTopEvent();
        }

        /// <summary>
        /// 初めて画面に遷移した時に呼ばれる
        /// </summary>
        public virtual void CreateView() { }

        /// <summary>
        /// 戻るボタンにて戻ってきた時に呼ばれる
        /// </summary>
        public virtual void BackView() { }
        #endregion


        //--------------------------------------------------
        // タッチ入力制御制御関連
        //--------------------------------------------------
        #region タッチ入力制御
        /// <summary>
        /// タッチ入力画面を表示したい時に呼ばれる
        /// </summary>
        public void TouchDisplayShow(TextBox textbox)
        {
            TouchDisplayShowEvent(textbox);
        }
        /// <summary>
        /// タッチ入力画面を非表示にしたい時に呼ばれる
        /// </summary>
        public void TouchDisplayHide()
        {
            TouchDisplayHideEvent();
        }
        /// <summary>
        /// タッチ表示時にBaseFormから呼ばれる
        /// </summary>
        /// <param name="MoveNum"></param>
        public void TouchLocationMove(int MoveNum)
        {
            TouchMoveNum = MoveNum;
            var TmpLocation = this.Location;
            TmpLocation.Y += TouchMoveNum;
            this.Location = TmpLocation;
        }
        /// <summary>
        /// タッチ非表示時にBaseFormから呼ばれる
        /// </summary>
        public void TouchLocationReverse()
        {
            var TmpLocation = this.Location;
            TmpLocation.Y -= TouchMoveNum;
            this.Location = TmpLocation;
        }

        /// <summary>
        /// プログラム終了時に呼ばれる
        /// </summary>
        public void ProgramClose()
        {
            // プログラム終了イベントを起こす
            ProgramCloseEvent();
        }

        // タッチ入力画面からのイベントを受け取る。
        public virtual void TouchBtAllCancel() { }
        public virtual void TouchBtEnterl() { }
        public virtual void TouchBtExecution() { }
        public void EventCatchTouchBtAllCancel(object sender, EventArgs e) { TouchBtAllCancel(); }
        public void EventCatchTouchBtEnter(object sender, EventArgs e) { TouchBtEnterl(); }
        public void EventCatchTouchBtExecution(object sender, EventArgs e) { TouchBtExecution(); }
        #endregion


        //--------------------------------------------------
        // 機能
        //--------------------------------------------------
    }
}
