using CardMachineCom;
using pluspoint.Message;
using pluspoint.Module.CardMachine;
using System.Windows.Forms;
using WaitingpassRestAPI.IO;

namespace pluspoint.View
{
    public partial class NewIssue_Input2View : BaseView
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
        public NewIssue_Input2View()
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
        public override string SetTaskBarTitle() { return ViewNewIssueMessage.ViewTitle_NewIssue_Input2; }


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
        /// 次のページへ
        /// </summary>
        private void BtNextPage_Click(object sender, System.EventArgs e)
        {
            try
            {
                // 画面の入力情報を変数へ設定
                InData.zip_1 = this.TextPostalCode1.Text;       // 郵便番号上位3桁
                InData.zip_2 = this.TextPostalCode2.Text;       // 郵便番号下位4桁
                InData.pref_nmae = this.ComboPrefectures.Text;  // 都道府県名
                InData.area_name = this.TextArea.Text;          // 市区町村名
                InData.city_name = this.TextCity.Text;          // 町域名
                InData.block = this.TextBlock.Text;             // 番地
                InData.building = this.TextBdname.Text;         // 建物～号室

                // 次の画面へ遷移
                this.PageChange("NewIssue_Input3View", new object[] { InData });
            }
            catch
            {
                throw;
            }
        }

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
        /// 新規遷移
        /// </summary>
        public override void CreateView()
        {
            try
            {
                if (this.ScreenData != null)
                {
                    foreach(object data in this.ScreenData)
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

        /// <summary>
        /// 戻る画面から戻ってきた場合
        /// </summary>
        public override void BackView()
        {
            try
            {
                // 変数のデータを画面へ設定
                this.TextPostalCode1.Text = InData.zip_1;       // 郵便番号上位3桁
                this.TextPostalCode2.Text = InData.zip_2;       // 郵便番号下位4桁
                this.ComboPrefectures.Text = InData.pref_nmae;  // 都道府県名
                this.TextArea.Text = InData.area_name;          // 市区町村名
                this.TextCity.Text = InData.city_name;          // 町域名
                this.TextBlock.Text = InData.block;             // 番地
                this.TextBdname.Text = InData.building;         // 建物～号室
            }
            catch
            {
                throw;
            }
        }
    }
}
