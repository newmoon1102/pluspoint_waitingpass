﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pluspoint.View
{
    public partial class DailyView : BaseView
    {
        //--------------------------------------------------
        // 初期設定
        //--------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DailyView()
        {
            InitializeComponent();
        }


        //--------------------------------------------------
        // 画面からのイベント処理
        //--------------------------------------------------
        /// <summary>
        /// 前のページ（Top）へ戻る
        /// </summary>
        private void BtBack_Click(object sender, EventArgs e) { this.PageBack(null); }
    }
}
