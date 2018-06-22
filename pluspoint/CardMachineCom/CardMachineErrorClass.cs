using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardMachineCom
{
    public class CardMachineErrorClass
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// エラーコード
        /// </summary>
        public int ErrorCode;
        /// <summary>
        /// エラータイトル
        /// </summary>
        public string ErrorTitle;
        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string ErrorMessage;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CardMachineErrorClass()
        {
            ErrorCode = 0;
            ErrorMessage = "";
        }
        public CardMachineErrorClass(int code, string Title, string Message)
        {
            ErrorCode = code;
            ErrorTitle = Title;
            ErrorMessage = Message;
        }
        ~CardMachineErrorClass() { }
    }
}
