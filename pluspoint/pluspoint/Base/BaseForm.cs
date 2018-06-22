using Logger;
using pluspoint.Base;
using pluspoint.Module.CardMachine;
using System;
using System.Windows.Forms;

namespace pluspoint
{
    public partial class BaseForm : Form
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        // 画面更新制御Class
        private ScreenTransitionClass ScreenTransition = null;


        // メイン画面オブジェクト
        private BaseView MainView = null;

        // タッチ入力画面オブジェクト
        private TouchForm TouchInputForm = null;

        /// <summary>
        /// フォーム生成時に呼ばれる
        /// </summary>
        public BaseForm()
        {
            // 自動生成コード
            InitializeComponent();

            // 画面遷移制御クラス
            ScreenTransition = new ScreenTransitionClass();

            // 各種イベント設定
            EventRegistration();

            // 最初の画面を表示する
            ScreenTransition.ChangeTopView();

            // タッチ入力画面の生成
            TouchInputForm = new TouchForm(this);
            // タッチ入力画面をBaseFormにオーナー登録
            this.AddOwnedForm(TouchInputForm);

            // タッチイベント設定
            TouchEventRegistration();
        }
        /// <summary>
        /// 各種イベントを設定する
        /// </summary>
        private void EventRegistration()
        {
            // 画面更新時
            ScreenTransition.EventScreenView += this.ScreenViewUpdate;

            // プログラム終了時
            ScreenTransition.EventProgramClose += this.BaseFormClose;

            // タッチ入力画面表示時
            ScreenTransition.EventTouchNumberShow += this.TouchDisplayShow;

            // タッチ入力画面非表示時
            ScreenTransition.EventTouchNumberHide += this.TouchDisplayHide;
        }

        /// <summary>
        /// 各種イベントを設定する
        /// </summary>
        private void TouchEventRegistration()
        {
            TouchInputForm.EventTouchBtAllCancel += ScreenTransition.TouchAllCancel;
            TouchInputForm.EventTouchBtEnter += ScreenTransition.TouchEnter;
            TouchInputForm.EventTouchBtExecution += ScreenTransition.TouchExecution;
        }

        /// <summary>
        /// タッチ入力画面を表示する
        /// </summary>
        private void TouchDisplayShow(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                TouchInputForm.ControlTextBox = tb;

                // タッチパネル表示時の重なりを補正計算
                int tbpos = tb.Parent.Location.Y + tb.Parent.Size.Height;
                int tppos = TouchInputForm.Location.Y;
                int movenum = 0;
                if (tppos < tbpos) movenum = tppos - tbpos;

                // 表示補正を適用
                ScreenTransition.NowView.TouchLocationMove(movenum);
            }

            TouchInputForm.Show();
        }
        /// <summary>
        /// タッチ入力画面を非表示にする
        /// </summary>
        private void TouchDisplayHide(object sender, EventArgs e)
        {
            TouchInputForm.ControlTextBox = null;
            TouchInputForm.Hide();

            // タッチパネルの重なり補正を元に戻す
            ScreenTransition.NowView.TouchLocationReverse();
        }

        /// <summary>
        /// 画面更新時に呼ばれるイベントの実態
        /// </summary>
        private void ScreenViewUpdate(object sender, EventArgs e)
        {
            // タイトルの更新
            this.Text = ScreenTransition.NowView.SetTaskBarTitle();

            // 画面の更新
            MainView = ScreenTransition.NowView;

            // 一旦ユーザーコントローラーをすべて削除
            this.Controls.Clear();

            // ユーザーコントローラーの作成
            this.Controls.Add(MainView);
        }

        /// <summary>
        /// プログラム終了時に呼ばれるイベントの実態
        /// </summary>
        private void BaseFormClose(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
