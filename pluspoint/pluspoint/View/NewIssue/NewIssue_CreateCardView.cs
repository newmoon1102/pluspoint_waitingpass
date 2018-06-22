using CardMachineCom;
using pluspoint.Message;
using pluspoint.Module.CardMachine;
using System.Windows.Forms;
using WaitingpassRestAPI.IO;

namespace pluspoint.View
{
    public partial class NewIssue_CreateCardView : BaseView
    {
        /// <summary>
        /// カード機操作モジュール
        /// </summary>
        CardMachineClass CardMachine = null;

        /// <summary>
        /// 入力データ格納用（WPRestAPIのRequestデータ）
        /// </summary>
        MemberSetRequest InData = null;


        //--------------------------------------------------
        // コンストラクタ・デストラクタ・初期化系
        //--------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NewIssue_CreateCardView()
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

                // カード状態（未挿入から処理中）監視応答イベント登録
                CardMachine.RelayNotInserted_To_Processing += CardStatus_NotInserted_To_Processing_Res;
                // カード状態（処理中から抜取り待ち）監視応答イベント登録
                CardMachine.RelayProcessing_To_PullWait += CardStatus_Processing_To_PullWait_Res;
                // カード状態（抜取り待ちから未挿入）監視応答イベント登録
                CardMachine.RelayPullWait_To_NotInserted += CardStatus_PullWait_To_NotInserted_Res;
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

                // カード状態監視（未挿入から処理中）応答イベント登録解除
                CardMachine.RelayNotInserted_To_Processing -= CardStatus_NotInserted_To_Processing_Res;
                // カード状態（処理中から抜取り待ち）監視応答イベント登録解除
                CardMachine.RelayProcessing_To_PullWait -= CardStatus_Processing_To_PullWait_Res;
                // カード状態（抜取り待ちから未挿入）監視応答イベント登録解除
                CardMachine.RelayPullWait_To_NotInserted -= CardStatus_PullWait_To_NotInserted_Res;
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
                // カード状態監視の停止
                CardMachine.MonitoringSwitch(false);

                // カード未挿入からカード処理中へ遷移した場合処理中画面へ遷移
                // 遷移前にイベントの停止
                CardMachineEventDelete();

                // 処理中画面へ遷移
                Invoke((MethodInvoker)delegate ()
                {
                    this.PageChange("NewIssue_CreateCardProcessing", new object[] { InData });
                });
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
                // カード状態監視の停止
                CardMachine.MonitoringSwitch(false);

                // 異常につきカード機停止後、確認画面へ遷移
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

                // 異常につきカード機停止後、確認画面へ遷移
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
                // カード状態監視の停止
                CardMachine.MonitoringSwitch(false);

                // カード機イベント登録解除
                CardMachineEventDelete();

                // 前画面へ戻る
                this.PageBack(null);
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
                // この画面の１個前へ戻す

                // 前画面へ戻る
                this.PageBack(null);
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
                // カード機モードチェンジ
                //--------------------------------------------------
                // カード機へ新規カード挿入モードにする
                RmSendRecCardParamClass RecCardParam = new RmSendRecCardParamClass { card = 2 };
                CardMachine.CardMachineOrder(OrderCardMachineState.RmSendRecCard, RecCardParam);
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
