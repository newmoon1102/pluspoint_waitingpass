using pluspoint.Database;
using pluspoint.Database.pluspointDBDataSetTableAdapters;

namespace pluspoint.View
{
    partial class EntryListView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtBack = new System.Windows.Forms.Button();
            this.EntryDataList = new System.Windows.Forms.DataGridView();
            this.nEWRECEIPTLISTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pluspointDBDataSet = new pluspoint.Database.pluspointDBDataSet();
            this.nEW_RECEIPT_LISTTableAdapter = new pluspoint.Database.pluspointDBDataSetTableAdapters.NEW_RECEIPT_LISTTableAdapter();
            this.rECEIPTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lASTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fIRTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lASTNAMEYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fIRTNAMEYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DELETE = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.EntryDataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEWRECEIPTLISTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pluspointDBDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // BtBack
            // 
            this.BtBack.BackColor = System.Drawing.Color.White;
            this.BtBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtBack.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtBack.Location = new System.Drawing.Point(0, 610);
            this.BtBack.Margin = new System.Windows.Forms.Padding(0);
            this.BtBack.Name = "BtBack";
            this.BtBack.Size = new System.Drawing.Size(80, 30);
            this.BtBack.TabIndex = 2;
            this.BtBack.Text = "戻る";
            this.BtBack.UseVisualStyleBackColor = false;
            this.BtBack.Click += new System.EventHandler(this.BtBack_Click);
            // 
            // EntryDataList
            // 
            this.EntryDataList.AllowUserToAddRows = false;
            this.EntryDataList.AllowUserToDeleteRows = false;
            this.EntryDataList.AutoGenerateColumns = false;
            this.EntryDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EntryDataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rECEIPTIDDataGridViewTextBoxColumn,
            this.lASTNAMEDataGridViewTextBoxColumn,
            this.fIRTNAMEDataGridViewTextBoxColumn,
            this.lASTNAMEYDataGridViewTextBoxColumn,
            this.fIRTNAMEYDataGridViewTextBoxColumn,
            this.DELETE});
            this.EntryDataList.DataSource = this.nEWRECEIPTLISTBindingSource;
            this.EntryDataList.Location = new System.Drawing.Point(3, 17);
            this.EntryDataList.Name = "EntryDataList";
            this.EntryDataList.ReadOnly = true;
            this.EntryDataList.RowHeadersWidth = 4;
            this.EntryDataList.RowTemplate.Height = 21;
            this.EntryDataList.Size = new System.Drawing.Size(394, 590);
            this.EntryDataList.TabIndex = 7;
            this.EntryDataList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EntryDataList_CellContentClick);
            // 
            // nEWRECEIPTLISTBindingSource
            // 
            this.nEWRECEIPTLISTBindingSource.DataMember = "NEW_RECEIPT_LIST";
            this.nEWRECEIPTLISTBindingSource.DataSource = this.pluspointDBDataSet;
            // 
            // pluspointDBDataSet
            // 
            this.pluspointDBDataSet.DataSetName = "pluspointDBDataSet";
            this.pluspointDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nEW_RECEIPT_LISTTableAdapter
            // 
            this.nEW_RECEIPT_LISTTableAdapter.ClearBeforeFill = true;
            // 
            // rECEIPTIDDataGridViewTextBoxColumn
            // 
            this.rECEIPTIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rECEIPTIDDataGridViewTextBoxColumn.DataPropertyName = "RECEIPT_ID";
            this.rECEIPTIDDataGridViewTextBoxColumn.HeaderText = "受付番号";
            this.rECEIPTIDDataGridViewTextBoxColumn.Name = "rECEIPTIDDataGridViewTextBoxColumn";
            this.rECEIPTIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.rECEIPTIDDataGridViewTextBoxColumn.Width = 78;
            // 
            // lASTNAMEDataGridViewTextBoxColumn
            // 
            this.lASTNAMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lASTNAMEDataGridViewTextBoxColumn.DataPropertyName = "LAST_NAME";
            this.lASTNAMEDataGridViewTextBoxColumn.HeaderText = "姓";
            this.lASTNAMEDataGridViewTextBoxColumn.Name = "lASTNAMEDataGridViewTextBoxColumn";
            this.lASTNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.lASTNAMEDataGridViewTextBoxColumn.Width = 42;
            // 
            // fIRTNAMEDataGridViewTextBoxColumn
            // 
            this.fIRTNAMEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fIRTNAMEDataGridViewTextBoxColumn.DataPropertyName = "FIRT_NAME";
            this.fIRTNAMEDataGridViewTextBoxColumn.HeaderText = "名";
            this.fIRTNAMEDataGridViewTextBoxColumn.Name = "fIRTNAMEDataGridViewTextBoxColumn";
            this.fIRTNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            this.fIRTNAMEDataGridViewTextBoxColumn.Width = 42;
            // 
            // lASTNAMEYDataGridViewTextBoxColumn
            // 
            this.lASTNAMEYDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lASTNAMEYDataGridViewTextBoxColumn.DataPropertyName = "LAST_NAME_Y";
            this.lASTNAMEYDataGridViewTextBoxColumn.HeaderText = "せい";
            this.lASTNAMEYDataGridViewTextBoxColumn.Name = "lASTNAMEYDataGridViewTextBoxColumn";
            this.lASTNAMEYDataGridViewTextBoxColumn.ReadOnly = true;
            this.lASTNAMEYDataGridViewTextBoxColumn.Width = 50;
            // 
            // fIRTNAMEYDataGridViewTextBoxColumn
            // 
            this.fIRTNAMEYDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fIRTNAMEYDataGridViewTextBoxColumn.DataPropertyName = "FIRT_NAME_Y";
            this.fIRTNAMEYDataGridViewTextBoxColumn.HeaderText = "めい";
            this.fIRTNAMEYDataGridViewTextBoxColumn.Name = "fIRTNAMEYDataGridViewTextBoxColumn";
            this.fIRTNAMEYDataGridViewTextBoxColumn.ReadOnly = true;
            this.fIRTNAMEYDataGridViewTextBoxColumn.Width = 50;
            // 
            // DELETE
            // 
            this.DELETE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DELETE.HeaderText = "削除";
            this.DELETE.Name = "DELETE";
            this.DELETE.ReadOnly = true;
            this.DELETE.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DELETE.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DELETE.Text = "削除";
            this.DELETE.UseColumnTextForButtonValue = true;
            this.DELETE.Width = 54;
            // 
            // EntryListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.EntryDataList);
            this.Controls.Add(this.BtBack);
            this.Name = "EntryListView";
            this.Load += new System.EventHandler(this.EntryListView_Load);
            this.Controls.SetChildIndex(this.BtBack, 0);
            this.Controls.SetChildIndex(this.EntryDataList, 0);
            ((System.ComponentModel.ISupportInitialize)(this.EntryDataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nEWRECEIPTLISTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pluspointDBDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtBack;
        private System.Windows.Forms.DataGridView EntryDataList;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEMBERIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rECEIPTDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDNODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qRCODEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDPOINTDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zIP1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zIP2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pREFNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aREANAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cITYNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bLOCKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bUILDINGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tELNUMBER1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tELNUMBER2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tELNUMBER3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOBILENUMBER1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOBILENUMBER2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mOBILENUMBER3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oTHERNUMBER1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oTHERNUMBER2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn oTHERNUMBER3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAILADDRESSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pASSWORDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cALLNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mAILMAGADISABLEFLGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dMDISABLEFLGDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sEXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bIRTHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mEMBERTYPEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDISSUEDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cARDFLGDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource nEWRECEIPTLISTBindingSource;
        private pluspointDBDataSet pluspointDBDataSet;
        private NEW_RECEIPT_LISTTableAdapter nEW_RECEIPT_LISTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rECEIPTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lASTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIRTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lASTNAMEYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fIRTNAMEYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn DELETE;
    }
}
