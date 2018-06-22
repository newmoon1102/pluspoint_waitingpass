using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logger;

namespace pluspoint.Parts
{
    public partial class NumberTouchPanel : UserControl
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        public NumberTouchPanel()
        {
            InitializeComponent();
        }
    }
}
