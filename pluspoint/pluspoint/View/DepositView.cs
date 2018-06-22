using CardMachineCom;
using pluspoint.Module.CardMachine;
using pluspoint.Parts;
using System;
using System.Windows.Forms;

namespace pluspoint.View
{
    public partial class DepositView : BaseView
    {
        CardMachineClass CardMachine = null;

        public DepositView()
        {
            try
            {
                InitializeComponent();

                this.Before_PriNokoNum.Number = 1000;
                this.Before_PointRuiNum.Number = 1200;
                this.ThisTime.Number = 1500;
                this.After_PriNokoNum.Number = 2000;
                this.After_PointRuiNum.Number = 2500;

                // カード機操作Class実体化
                CardMachine = new CardMachineClass();

                // カード機イベント登録
                CardMachineEventRegistration();
            }
            catch
            {
                throw;
            }
        }
        ~DepositView()
        {
            try
            {
                // カード機イベント削除
                CardMachineEventDelete();
                // カード機操作Classの破棄
                CardMachine = null;
            }
            catch
            {
                throw;
            }
        }

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
        public override string SetTaskBarTitle() { return "入金"; }

        /// <summary>
        /// 戻るボタン押下
        /// </summary>
        private void Bt_back_Click(object sender, EventArgs e)
        {
            try
            {
                this.PageTop();

                CardMachineEventDelete();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// タッチパネルの全取消押下
        /// </summary>
        public override void TouchBtAllCancel()
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
        /// タッチパネル表示イベント
        /// </summary>
        private void TouchShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender is NumberInputBoxParts Num)
                {
                    this.TouchDisplayShow(Num.AmountTextBox);
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// タッチパネル非表示イベント
        /// </summary>
        private void TouchHide_Click(object sender, EventArgs e)
        {
            try
            {
                this.TouchDisplayHide();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// フォーカスクリアイベント
        /// </summary>
        private void FocusClear(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カードの排出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BTCardDischarge(object sender, EventArgs e)
        {
            try
            {

            }
            catch
            {
                throw;
            }
        }

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
    }
}
