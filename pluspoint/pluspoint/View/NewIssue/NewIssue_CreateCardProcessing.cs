using CardMachineCom;
using pluspoint.Message;
using pluspoint.Module.CardMachine;
using System.Windows.Forms;
using WaitingpassRestAPI.IO;

namespace pluspoint.View
{
    public partial class NewIssue_CreateCardProcessing : BaseView
    {
        /// <summary>
        /// カード機操作モジュール
        /// </summary>
        CardMachineClass CardMachine = null;

        /// <summary>
        /// 入力データ格納用（WPRestAPIのRequestデータ）
        /// </summary>
        MemberSetRequest InData = null;

        /// <summary>
        /// カード機をリセットするフラグ
        /// </summary>
        private bool ResetCardMachineFlag = false;

        /// <summary>
        /// カードIDを保持
        /// </summary>
        public string CardID;


        //--------------------------------------------------
        // コンストラクタ・デストラクタ・初期化系
        //--------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewIssue_CreateCardProcessing()
        {
            InitializeComponent();

            CardMachine = new CardMachineClass();
        }

        /// <summary>
        /// カード機イベント登録
        /// </summary>
        private void CardMachineEventRegistration()
        {
            try
            {
                // カード機のエラー応答イベントへ登録
                CardMachine.RelayOrderCardMachineResponseError += CardMachineErrorRes;

                // カード機のカードデータA要求イベント登録
                CardMachine.RelayRmGetCardDataA += RmGetCardDataARes;

                // カード機の名前情報送信イベント登録
                CardMachine.RelayRmSendName += RmSendNameRes;

                // カード機へ売上データ送信イベント登録
                CardMachine.RelayRmSendSellA += RmSendSellARes;

                // カード機の情報確定送信イベント登録
                CardMachine.RelayRmSendProcRun += RmSendProcRunRes;

                // カード状態（未挿入から処理中）監視応答イベント登録
                CardMachine.RelayNotInserted_To_Processing += CardStatus_NotInserted_To_Processing_Res;
                // カード状態（処理中から抜取り待ち）監視応答イベント登録
                CardMachine.RelayProcessing_To_PullWait += CardStatus_Processing_To_PullWait_Res;
                // カード状態（抜取り待ちから未挿入）監視応答イベント登録
                CardMachine.RelayPullWait_To_NotInserted += CardStatus_PullWait_To_NotInserted_Res;

                // カード状態例外（処理中から未挿入）監視応答イベント登録
                CardMachine.RelayProcessing_To_NotInserted += CardStatus_Processing_To_NotInserted_Res;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// カード機イベント削除
        /// </summary>
        private void CardMachineEventDelete()
        {
            try
            {
                // カード機のエラー応答イベント登録解除
                CardMachine.RelayOrderCardMachineResponseError -= CardMachineErrorRes;

                // カード機のカードデータA要求イベント登録解除
                CardMachine.RelayRmGetCardDataA -= RmGetCardDataARes;

                // カード機の名前情報送信イベント登録解除
                CardMachine.RelayRmSendName -= RmSendNameRes;

                // カード機へ売上データ送信イベント登録解除
                CardMachine.RelayRmSendSellA += RmSendSellARes;

                // カード機の情報確定送信イベント登録解除
                CardMachine.RelayRmSendProcRun -= RmSendProcRunRes;

                // カード状態監視（未挿入から処理中）応答イベント登録解除
                CardMachine.RelayNotInserted_To_Processing -= CardStatus_NotInserted_To_Processing_Res;
                // カード状態（処理中から抜取り待ち）監視応答イベント登録解除
                CardMachine.RelayProcessing_To_PullWait -= CardStatus_Processing_To_PullWait_Res;
                // カード状態（抜取り待ちから未挿入）監視応答イベント登録解除
                CardMachine.RelayPullWait_To_NotInserted -= CardStatus_PullWait_To_NotInserted_Res;

                // カード状態例外（処理中から未挿入）監視応答イベント登録
                CardMachine.RelayProcessing_To_NotInserted -= CardStatus_Processing_To_NotInserted_Res;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// タイトル変更
        /// </summary>
        public override string SetTaskBarTitle() { return ViewNewIssueMessage.ViewTitle_NewIssue_CreateCard; }


        //--------------------------------------------------
        // カード機イベント送受信
        //--------------------------------------------------
        #region カード機イベント
        /// <summary>
        /// カード機のエラーを受信
        /// </summary>
        /// <param name="CardMachineError">エラー情報</param>
        private void CardMachineErrorRes(CardMachineErrorClass CardMachineError)
        {
            try
            {
                // メッセージ表示
                MessageBox.Show(CardMachineError.ErrorMessage, CardMachineError.ErrorTitle);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カード状態（未挿入から処理中）へ遷移した時に呼ばれる
        /// </summary>
        /// <param name="ResData"></param>
        private void CardStatus_NotInserted_To_Processing_Res(RmGetStatusParamClass ResData)
        {
            try
            {
                // ここへ入ることは基本的にはありえない
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カード状態（処理中から抜取り待ち）へ遷移した時に呼ばれる
        /// </summary>
        /// <param name="ResData"></param>
        private void CardStatus_Processing_To_PullWait_Res(RmGetStatusParamClass ResData)
        {
            try
            {
                if (ResetCardMachineFlag)
                {
                    //------------------------------
                    // エラー時の排出の場合
                    //------------------------------
                }
                else
                {
                    //------------------------------
                    // エラー排出ではない場合
                    //------------------------------
                    // 表示メッセージの変更
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.label6.Text = ViewNewIssueMessage.NewIssue_ErrorMessage003;
                    });
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カード状態（抜取り待ちから未挿入）へ遷移した時に呼ばれる
        /// </summary>
        /// <param name="ResData"></param>
        private void CardStatus_PullWait_To_NotInserted_Res(RmGetStatusParamClass ResData)
        {
            try
            {
                // カード状態監視の停止
                CardMachine.MonitoringSwitch(false);

                // 画面遷移前にイベントリセット
                CardMachineEventDelete();

                // カード排出判定
                if (ResetCardMachineFlag)
                {
                    //------------------------------
                    // エラー時の排出の場合
                    //------------------------------
                    // 異常につきカード機停止後、確認画面へ遷移
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.PageChange("NewIssue_CheckView", new object[] { InData });
                    });
                }
                else
                {
                    //------------------------------
                    // エラーではない排出の場合
                    //------------------------------
                    // 完了、トップ画面へ遷移
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.PageTop();
                    });
                }
            }
            catch
            {
                throw;
            }
        }

        // カード状態やや例外パターン
        /// <summary>
        /// カード状態（処理中から未挿入）へ遷移した時に呼ばれる
        /// </summary>
        /// <param name="ResData"></param>
        private void CardStatus_Processing_To_NotInserted_Res(RmGetStatusParamClass ResData)
        {
            try
            {
                // カード状態監視の停止
                CardMachine.MonitoringSwitch(false);

                // 画面遷移前にイベントリセット
                CardMachineEventDelete();

                // カード排出判定
                if (ResetCardMachineFlag)
                {
                    //------------------------------
                    // エラー時の排出の場合
                    //------------------------------
                    // 異常につきカード機停止後、確認画面へ遷移
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.PageChange("NewIssue_CheckView", new object[] { InData });
                    });
                }
                else
                {
                    //------------------------------
                    // エラーではない排出の場合
                    //------------------------------
                    // 完了、トップ画面へ遷移
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.PageTop();
                    });
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カードデータA要求応答受信
        /// </summary>
        /// <param name="ResData"></param>
        private void RmGetCardDataARes(RmGetCardDataAParamClass ResData)
        {
            try
            {
                // 新規カードチェック
                if(ResData.usecount != 0)
                {
                    //------------------------------
                    // 新規カードじゃない場合
                    //------------------------------
                    // カード排出フラグ
                    ResetCardMachineFlag = true;

                    // カード処理のキャンセル
                    CardMachine.CardMachineOrder(OrderCardMachineState.RmSendCancel);
                    CardMachine.CardMachineOrder(OrderCardMachineState.RmSendCancel);

                    // 表示メッセージの変更
                    Invoke((MethodInvoker)delegate ()
                    {
                        this.label6.Text = ViewNewIssueMessage.NewIssue_ErrorMessage001;
                    });
                }
                else
                {
                    //------------------------------
                    // 新規カードの場合
                    //------------------------------
                    CardID = ResData.Cardid;

                    // 名前データ送信
                    CreateCard_Step02();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 名前データ送信成功
        /// </summary>
        /// <param name="ResData"></param>
        private void RmSendNameRes(RmSendNameParamClass ResData)
        {
            try
            {
                // 売上データを送信（新規作成の売上無しでも送らないとエラーになる）
                CreateCard_Step03();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 売上データ送信成功
        /// </summary>
        /// <param name="ResData"></param>
        private void RmSendSellARes(RmSendSellAParamClass ResData)
        {
            try
            {
                // 送ったデータで確定、カードを作成する
                CreateCard_Step04();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 完了処理成功
        /// </summary>
        private void RmSendProcRunRes()
        {
            try
            {
                // 表示メッセージの変更
                Invoke((MethodInvoker)delegate ()
                {
                    this.label6.Text = ViewNewIssueMessage.NewIssue_ErrorMessage002;
                });
            }
            catch
            {
                throw;
            }
        }
        #endregion


        //--------------------------------------------------
        // 画面遷移系
        //--------------------------------------------------
        #region 画面遷移系
        /// <summary>
        /// 前のページへ
        /// </summary>
        private void BtBack_Click(object sender, System.EventArgs e)
        {
            try
            {
                // カード機イベント登録解除
                CardMachineEventDelete();

                // カード処理のキャンセル
                CardMachine.CardMachineOrder(OrderCardMachineState.RmSendCancel);
                CardMachine.CardMachineOrder(OrderCardMachineState.RmSendCancel);

                // 前画面へ戻る
                // カード抜取り待ちから未挿入になる状態イベント受取で前の画面に戻す
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 次ページから戻るボタンで戻ってきた場合
        /// </summary>
        public override void BackView()
        {
            try
            {
                // この画面へ戻ってくることが合ってはならないが
                // バグやエラーで戻って来る処理が記述された場合
                // 確認画面へ戻す
                Invoke((MethodInvoker)delegate ()
                {
                    this.PageChange("NewIssue_CheckView", new object[] { InData });
                });
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 新規遷移
        /// </summary>
        public override void CreateView()
        {
            try
            {
                //--------------------------------------------------
                // 前画面からデータ受取
                //--------------------------------------------------
                // 新規カード作成のため、カード情報を受け取って居ない場合、この画面へ来てはいけない
                if (this.ScreenData == null) this.PageTop();

                // 前画面からデータの受取（新規入力のユーザーデータ）
                foreach (object data in this.ScreenData)
                {
                    if (data.GetType() == typeof(MemberSetRequest))
                    {
                        InData = (MemberSetRequest)data;
                    }
                }

                //--------------------------------------------------
                // カード機設定
                //--------------------------------------------------
                // カード機のイベント登録
                CardMachineEventRegistration();

                // カード状態監視の開始
                CardMachine.MonitoringSwitch(true);

                //--------------------------------------------------
                // カード発行処理開始
                //--------------------------------------------------
                CreateCard_Step01();
            }
            catch
            {
                throw;
            }
        }
        #endregion


        //--------------------------------------------------
        // 機能系
        //--------------------------------------------------
        /// <summary>
        /// カードデータを送信する
        /// </summary>
        private void CreateCard_Step01()
        {
            try
            {
                RmGetCardDataAParamClass Param = new RmGetCardDataAParamClass();

                CardMachine.CardMachineOrder(OrderCardMachineState.RmGetCardDataA, Param);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カード機へ名前を送信する
        /// </summary>
        private void CreateCard_Step02()
        {
            try
            {
                RmSendNameParamClass Param = new RmSendNameParamClass
                {
                    Name = InData.last_name + "　" + InData.first_name
                };

                CardMachine.CardMachineOrder(OrderCardMachineState.RmSendName, Param);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 売上データ送信
        /// </summary>
        private void CreateCard_Step03()
        {
            try
            {
                RmSendSellAParamClass Param = new RmSendSellAParamClass();

                Param.stsendsaledatainf.cardid = CardID;

                CardMachine.CardMachineOrder(OrderCardMachineState.RmSendSellA, Param);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カード機へ送った情報で確定する
        /// </summary>
        private void CreateCard_Step04()
        {
            try
            {
                CardMachine.CardMachineOrder(OrderCardMachineState.RmSendProcRun);
            }
            catch
            {
                throw;
            }
        }
    }
}
