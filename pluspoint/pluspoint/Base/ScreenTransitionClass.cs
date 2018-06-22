using Logger;
using System;
using System.Collections;
using System.Windows.Forms;

namespace pluspoint.Base
{
    class ScreenTransitionClass
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// 現在表示中のユーザーコントロール
        /// </summary>
        public BaseView NowView = null;

        /// <summary>
        /// 画面表示イベント
        /// </summary>
        public EventHandler EventScreenView;

        /// <summary>
        /// プログラム終了イベント
        /// </summary>
        public EventHandler EventProgramClose;

        /// <summary>
        /// タッチ入力画面表示イベント
        /// </summary>
        public EventHandler EventTouchNumberShow;
        /// <summary>
        /// タッチ入力画面非表示イベント
        /// </summary>
        public EventHandler EventTouchNumberHide;

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

        /// <summary>
        /// 画面スタック
        /// </summary>
        private Stack ViewStack = null;

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ScreenTransitionClass()
        {
            // 初期化
            NowView = null;
            ViewStack = new Stack();
        }

        /// <summary>
        /// ユーザーコントロールへイベントで動かすメンバメソッドを登録する
        /// </summary>
        private void EventRegistration()
        {
            // 新しい画面からトップへ遷移イベントを受け取るための設定
            NowView.PageTopEvent += this.ChangeTopView;

            // 新しい画面からページ遷移イベントを受け取るための設定
            NowView.PageChangeEvent += this.ChangeScreenView;

            // 新しい画面からページ戻るイベントを受け取るための設定
            NowView.PageBackEvent += this.BackView;

            // 新しい画面からプログラム終了イベントを受け取るための設定
            NowView.ProgramCloseEvent += this.ProgramClose;

            // 新しい画面からタッチ画面表示イベントを受け取るための設定
            NowView.TouchDisplayShowEvent += this.TouchNumberShow;

            // 新しい画面からタッチ画面非表示イベントを受け取るための設定
            NowView.TouchDisplayHideEvent += this.TouchNumberHide;


            // タッチ画面で全取消ボタンが押された場合、新しい画面で呼び出されるメソッドを設定
            this.EventTouchBtAllCancel = NowView.EventCatchTouchBtAllCancel;
            // タッチ画面でEnterボタンが押された場合、新しい画面で呼び出されるメソッドを設定
            this.EventTouchBtEnter = NowView.EventCatchTouchBtEnter;
            // タッチ画面で実行ボタンが押された場合、新しい画面で呼び出されるメソッドを設定
            this.EventTouchBtExecution = NowView.EventCatchTouchBtExecution;
        }

        /// <summary>
        /// 画面遷移時に呼ばれる
        /// </summary>
        public void ChangeScreenView(string ViewClassName, object[] data)
        {
            try
            {
                if (ViewClassName == "TopView")
                {
                    this.ChangeTopView();
                }
                else
                {
                    // 今表示している画面を戻る用にスタック
                    if (NowView != null) ViewStack.Push(NowView);

                    // 新しい画面を取得
                    NowView = (BaseView)Type.GetType("pluspoint.View." + ViewClassName).InvokeMember(null, System.Reflection.BindingFlags.CreateInstance, null, null, null);

                    // 前の画面から受け取ったデータを次の画面へ設定
                    if(data != null) NowView.ScreenData = data;

                    // 新しい画面から各種イベントを受け取るための設定
                    EventRegistration();

                    // 新規の画面なのでCreateViewを呼ぶ
                    NowView.CreateView();

                    // 新しい画面に遷移
                    EventScreenView(this, EventArgs.Empty);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// １つ前の画面へ戻る
        /// </summary>
        public void BackView(object[] data)
        {
            if (ViewStack.Count != 0)
            {
                // １つ前の画面を抜き出す
                NowView = (BaseView)ViewStack.Pop();

                // 今現在のデータを１つ前の画面に戻す場合
                if (data != null) NowView.ScreenData = data;

                // 別画面から戻ったのでBackViewを呼ぶ
                NowView.BackView();

                // 現在の画面を１つ前の画面に書き換える
                EventScreenView(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Top画面へ遷移
        /// </summary>
        public void ChangeTopView()
        {
            // 現在画面の終了
            if (NowView != null)
            {
                NowView.Dispose();
                NowView = null;
            }

            // 画面表示をTOPに変更
            NowView = new TopView();

            // イベントを設定
            EventRegistration();

            // 新規の画面なのでCreateViewを呼ぶ
            NowView.CreateView();

            // TOP画面へ更新
            EventScreenView(this, EventArgs.Empty);

            // スタッククリア（各画面開放）
            ViewStack.Clear();
        }

        /// <summary>
        /// プログラムを終了する
        /// </summary>
        public void ProgramClose()
        {
            EventProgramClose(this, EventArgs.Empty);
        }

        /// <summary>
        /// タッチ入力画面を表示する
        /// </summary>
        public void TouchNumberShow(TextBox textbox)
        {
            EventTouchNumberShow(textbox, EventArgs.Empty);
        }
        /// <summary>
        /// タッチ入力画面を非表示にする
        /// </summary>
        public void TouchNumberHide()
        {
            EventTouchNumberHide(this, EventArgs.Empty);
        }
        
        public void TouchAllCancel(object sender, EventArgs e) { EventTouchBtAllCancel(sender, e); }
        public void TouchEnter(object sender, EventArgs e) { EventTouchBtEnter(sender, e); }
        public void TouchExecution(object sender, EventArgs e) { EventTouchBtExecution(sender, e); }
    }
}
