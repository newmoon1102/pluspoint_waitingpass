using CardMachineCom;
using Logger;
using pluspoint.Module.CardMachine;

namespace pluspoint.Base
{
    public class ModuleBaseClass
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        protected LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// カード機通信スレッド
        /// </summary>
        protected CardMachineComThreadClass CardMachineCom = CardMachineComThreadClass.Instance;


        //--------------------------------------------------
        // コンストラクタ・デストラクタ
        //--------------------------------------------------
        public ModuleBaseClass() { }
        ~ModuleBaseClass() { }
    }
}
