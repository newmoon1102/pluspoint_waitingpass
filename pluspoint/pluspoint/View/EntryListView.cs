using pluspoint.Database.LinqSQL;
using pluspoint.Message;
using pluspoint.Module.DBModule;
using System;
using System.Windows.Forms;

namespace pluspoint.View
{
    public partial class EntryListView : BaseView
    {


        //--------------------------------------------------
        // 初期設定
        //--------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EntryListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// タイトル設定
        /// </summary>
        public override string SetTaskBarTitle() { return ViewMainMessage.ViewTitle_EntryList; }


        //--------------------------------------------------
        // イベント系
        //--------------------------------------------------
        /// <summary>
        /// 画面ロード時
        /// </summary>
        private void EntryListView_Load(object sender, EventArgs e)
        {
            try
            {
                // DataGridViewにDBの中身を表示する
                this.nEW_RECEIPT_LISTTableAdapter.Fill(this.pluspointDBDataSet.NEW_RECEIPT_LIST);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// セルの中身がクリックされた時（削除ボタン押された時）
        /// </summary>
        private void EntryDataList_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                // データグリッドビュー本体取得
                DataGridView dgv = (DataGridView)sender;

                // クリックしたセル取得
                DataGridViewCell cell = dgv.CurrentCell;

                // 削除ボタンが押された
                if (cell.OwningColumn.Name == "DELETE")
                {
                    // 受付番号の列位置取得
                    int ColIndex = dgv.Columns["rECEIPTIDDataGridViewTextBoxColumn"].Index;
                    // 受付番号取得
                    int ReceiptID = (int)dgv.Rows[cell.RowIndex].Cells[ColIndex].Value;

                    // 受付番号をDB操作モジュールへ渡し削除を行う
                    var TableData = new NEW_RECEIPT_LIST_Module();
                    TableData.Delete(ReceiptID);
                    TableData = null;

                    // データグリッドビューの表示を更新
                    this.nEW_RECEIPT_LISTTableAdapter.Fill(this.pluspointDBDataSet.NEW_RECEIPT_LIST);
                }
            }
            catch
            {
                throw;
            }

            return;
        }


        //--------------------------------------------------
        // 画面遷移系
        //--------------------------------------------------
        /// <summary>
        /// 前のページ（Top）へ戻る
        /// </summary>
        private void BtBack_Click(object sender, EventArgs e) { this.PageBack(null); }
    }
}
