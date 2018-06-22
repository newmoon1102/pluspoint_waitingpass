using CardMachineCom;
using pluspoint.Message;
using pluspoint.Module.CardMachine;
using System;
using System.Globalization;
using System.Windows.Forms;
using WaitingpassRestAPI.IO;

namespace pluspoint.View
{
    public partial class NewIssue_Input3View : BaseView
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
        public NewIssue_Input3View()
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
        public override string SetTaskBarTitle() { return ViewNewIssueMessage.ViewTitle_NewIssue_Input3; }


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
                //--------------------------------------------------
                // 画面の入力情報を変数へ設定
                //--------------------------------------------------
                // 性別
                if (this.RadioButtonMale.Checked && !this.RadioButtonMale2.Checked) InData.sex = 1;
                if (!this.RadioButtonMale.Checked && this.RadioButtonMale2.Checked) InData.sex = 2;
                // 誕生日
                if (this.ComboBoxbirth_y.Text != "----" && this.ComboBoxbirth_m.Text != "--" && this.ComboBoxbirth_d.Text != "--")
                {
                    InData.birth = this.ComboBoxbirth_y.Text + "/" + this.ComboBoxbirth_m.Text + "/" + this.ComboBoxbirth_d.Text;
                }
                // メアド
                InData.mail_address = this.TextEmail.Text;
                // メールマガジン
                InData.mailmaga_disable_flag = this.CheckBoxMagazin.Checked ? 2 : 1;
                // ダイレクトメール
                InData.dm_disable_flag = this.CheckBoxDM.Checked ? 2 : 1;

                //--------------------------------------------------
                // 次の画面へ遷移
                //--------------------------------------------------
                this.PageChange("NewIssue_CheckView", new object[] { InData });
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 前のページへ
        /// </summary>
        private void BtBack_Click(object sender, System.EventArgs e) { this.PageBack(null); }

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

        /// <summary>
        /// 戻る画面から戻ってきた場合
        /// </summary>
        public override void BackView()
        {
            try
            {
                //--------------------------------------------------
                // 画面の入力情報を変数へ設定
                //--------------------------------------------------
                // 性別
                if(InData.sex == 2) this.RadioButtonMale2.Checked = true;
                else this.RadioButtonMale.Checked = true;
                // 誕生日
                if(InData.birth != null)
                {
                    this.ComboBoxbirth_y.Text = DateTime.Parse(InData.birth, new CultureInfo("ja-JP")).Year.ToString();
                    this.ComboBoxbirth_m.Text = DateTime.Parse(InData.birth, new CultureInfo("ja-JP")).Month.ToString().PadLeft(2, '0');
                    this.ComboBoxbirth_d.Text = DateTime.Parse(InData.birth, new CultureInfo("ja-JP")).Day.ToString().PadLeft(2, '0');
                }
                // メアド
                this.TextEmail.Text = InData.mail_address;
                // メールマガジン
                this.CheckBoxMagazin.Checked = (InData.mailmaga_disable_flag == 2 ? true : false);
                // ダイレクトメール
                this.CheckBoxDM.Checked = (InData.dm_disable_flag == 2 ? true : false);
            }
            catch
            {
                throw;
            }
        }


        //--------------------------------------------------
        // フォームイベント系
        //--------------------------------------------------
        // 画面ロード後、初期化
        private void NewIssue_Input3View_Load(object sender, System.EventArgs e)
        {
            try
            {
                ComboBoxbirth_y.Items.Add("----");
                int year = DateTime.Now.Year;
                for (int i = year; i >= year - 150; i--)
                {
                    ComboBoxbirth_y.Items.Add(i);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
