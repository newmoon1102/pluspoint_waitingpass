using log4net;
using log4net.Config;
using System;

namespace Logger
{
    public class LoggerClass
    {
        //--------------------------------------------------
        // シングルトン設定
        //--------------------------------------------------
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static readonly LoggerClass instance = new LoggerClass();
        /// <summary>
        /// シングルトンインスタンスを返す
        /// </summary>
        public static LoggerClass Instance { get { return instance; } }


        //--------------------------------------------------
        // メンバ変数
        //--------------------------------------------------
        // 共通で使用するログ
        public ILog Logger = null;


        //--------------------------------------------------
        // コンストラクタ・デストラクタ
        //--------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        private LoggerClass()
        {
            //--------------------------------------------------
            // ログ出力設定
            //--------------------------------------------------
            Environment.SetEnvironmentVariable("AppNameFolder", "pluspoint");
            // 以下二つは上記「SetEnvironmentVariable」の後に呼ばないとダメ。
            XmlConfigurator.Configure();
            Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }
        /// <summary>
        /// デストラクタ
        /// </summary>
        ~LoggerClass() { }


        //--------------------------------------------------
        // ログ出力
        //--------------------------------------------------
        /// <summary>
        /// Debug Level
        /// </summary>
        public void Debug(object message) { Logger.Debug(message); }
        /// <summary>
        /// Debug Level
        /// </summary>
        public void Debug(object message, Exception e) { Logger.Debug(message, e); }
        /// <summary>
        /// Error Level
        /// </summary>
        public void Error(object message) { Logger.Error(message); }
        /// <summary>
        /// Error Level
        /// </summary>
        public void Error(object message, Exception e) { Logger.Error(message, e); }
        /// <summary>
        /// Fatal Level
        /// </summary>
        public void Fatal(object message) { Logger.Fatal(message); }
        /// <summary>
        /// Fatal Level
        /// </summary>
        public void Fatal(object message, Exception e) { Logger.Fatal(message, e); }
        /// <summary>
        /// Info Level
        /// </summary>
        public void Info(object message) { Logger.Info(message); }
        /// <summary>
        /// Info Level
        /// </summary>
        public void Info(object message, Exception e) { Logger.Info(message, e); }
        /// <summary>
        /// Warn Level
        /// </summary>
        public void Warn(object message) { Logger.Warn(message); }
        /// <summary>
        /// Warn Level
        /// </summary>
        public void Warn(object message, Exception e) { Logger.Warn(message, e); }
    }
}
