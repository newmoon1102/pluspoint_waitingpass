using CardMachineCom;
using pluspoint.Message;
using pluspoint.Module.CardMachine;
using pluspoint.Module.DBModule;
using System.Windows.Forms;
using WaitingpassRestAPI.IO;

namespace pluspoint.View
{
    public partial class NewIssue_CheckView : BaseView
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
        public NewIssue_CheckView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// カード機イベント登録
        /// </summary>
        private void CardMachineEventRegistration()
        {
            try
            {
                CardMachine.RelayOrderCardMachineResponseError += CardMachineErrorRes;
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
                CardMachine.RelayOrderCardMachineResponseError -= CardMachineErrorRes;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// タイトル変更
        /// </summary>
        public override string SetTaskBarTitle() { return ViewNewIssueMessage.ViewTitle_NewIssue_Check; }


        //--------------------------------------------------
        // カード機イベント送受信
        //--------------------------------------------------
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


        //--------------------------------------------------
        // 画面遷移系
        //--------------------------------------------------
        /// <summary>
        /// 前のページへ
        /// </summary>
        private void BtBack_Click(object sender, System.EventArgs e)
        {
            try
            {
                this.PageBack(null);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// QRコードを読み込んで次の画面へ
        /// </summary>
        private void BtCheckOK_Click(object sender, System.EventArgs e)
        {
            try
            {
                // ここまでの入力をDBへ登録する
                var TableData = new NEW_RECEIPT_LIST_Module();
                TableData.Insert(InData);
                TableData = null;

                this.PageChange("NewIssue_CreateCardView", new object[] { InData });

                // QRコードの読取り
                string QRCode = this.QRReaderPopup(QRFormMessage.QR_Title001, QRFormMessage.QR_Message001);

                // 仮、文字列があれば次へ
                if (QRCode != null)
                {
                    this.PageChange("NewIssue_CreateCardView", new object[] { InData });
                }
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
                if (this.ScreenData != null)
                {
                    foreach (object data in this.ScreenData)
                    {
                        if (data.GetType() == typeof(MemberSetRequest))
                        {
                            InData = (MemberSetRequest)data;
                        }
                    }
                }
                else
                {
                    InData = new MemberSetRequest();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
