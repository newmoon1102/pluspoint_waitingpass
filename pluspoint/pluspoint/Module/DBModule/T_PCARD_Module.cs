using pluspoint.Database.LinqSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluspoint.Module.DBModule
{
    class T_PCARD_Module : DBModuleClass
    {
        /// <summary>
        /// LINQ to SQLのテーブルオブジェクト
        /// </summary>
        T_PCARDDataContext TableList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public T_PCARD_Module()
        {
            TableList = new T_PCARDDataContext(base.constr);
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~T_PCARD_Module()
        {
            TableList.Dispose();
        }
    }
}
