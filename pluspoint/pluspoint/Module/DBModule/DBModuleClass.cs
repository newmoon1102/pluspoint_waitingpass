using Logger;
using pluspoint.Database.LinqSQL;
using System.Linq;

namespace pluspoint.Module.DBModule
{
    class DBModuleClass
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// DB接続文字列
        /// </summary>
        protected string constr;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DBModuleClass()
        {
            // 接続文字列の作成
            constr = Properties.Settings.Default.pluspointDBConnectionString;
        }
    }
}
