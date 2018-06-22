using pluspoint.Database.LinqSQL;
using System.Linq;

namespace pluspoint.Module.DBModule
{
    class APPLI_HISTORY_Module : DBModuleClass
    {
        /// <summary>
        /// LINQ to SQLのテーブルオブジェクト
        /// </summary>
        APPLI_HISTORYDataContext TableList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public APPLI_HISTORY_Module()
        {
            TableList = new APPLI_HISTORYDataContext(base.constr);
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~APPLI_HISTORY_Module()
        {
            TableList.Dispose();
        }

        /// <summary>
        /// 一時的に保存しているサンプル
        /// </summary>
        void Sample()
        {
            try
            {
                var query = from n in TableList.APPLI_HISTORY where n.card_no > 1 select n;

                foreach (var m in query)
                {
                    // MessageBox.Show(m.TestID.ToString() + "：" + m.TestStr);
                }
            }
            catch
            {
                throw;
            }

            return;
        }
    }
}
