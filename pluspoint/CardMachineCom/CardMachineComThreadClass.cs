using Logger;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace CardMachineCom
{
    public class OrderCardMachineClass
    {
        /// <summary>
        /// カード機への命令
        /// </summary>
        public OrderCardMachineState OrderName;
        /// <summary>
        /// 命令時に送るパラメータ
        /// </summary>
        public object Param;
    }

    public sealed class CardMachineComThreadClass
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// カード状態監視モード
        /// </summary>
        public bool MonitoringMode = false;

        /// <summary>
        /// カード状態前回
        /// </summary>
        private short OldRWStatus = 0;

        //--------------------------------------------------
        // シングルトン設定
        //--------------------------------------------------
        #region シングルトン
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static readonly CardMachineComThreadClass instance = new CardMachineComThreadClass();
        /// <summary>
        /// シングルトンインスタンスを返す
        /// </summary>
        public static CardMachineComThreadClass Instance { get { return instance; } }
        #endregion


        //--------------------------------------------------
        // Event定義
        //--------------------------------------------------
        #region Event定義
        /// <summary>
        /// エラーイベントのデリゲート
        /// </summary>
        public delegate void ErrorMessageDelegate(CardMachineErrorClass Error);
        /// <summary>
        /// エラーイベント
        /// </summary>
        public ErrorMessageDelegate ErrorEvent;

        /// <summary>
        /// 応答データイベントのデリゲート
        /// </summary>
        public delegate void ReturnDataDelegate(OrderCardMachineState ordername, object param = null);
        /// <summary>
        /// 応答データイベント
        /// </summary>
        public ReturnDataDelegate ReturnData;

        //------------------------------
        // 状態監視イベント
        //------------------------------
        /// <summary>
        /// カード未挿入からカード処理中に状態遷移した時のデリゲート
        /// </summary>
        public delegate void NotInserted_To_Processing_Delegate(RmGetStatusParamClass ResStatus);
        /// <summary>
        /// カード未挿入からカード処理中に状態遷移した時
        /// </summary>
        public NotInserted_To_Processing_Delegate NotInserted_To_Processing;

        /// <summary>
        /// カード処理中からカード抜取り待ちに状態遷移した時のデリゲート
        /// </summary>
        public delegate void Processing_To_PullWait_Delegate(RmGetStatusParamClass ResStatus);
        /// <summary>
        /// カード処理中からカード抜取り待ちに状態遷移した時
        /// </summary>
        public Processing_To_PullWait_Delegate Processing_To_PullWait;

        /// <summary>
        /// カード抜取り待ちからカード未挿入に状態遷移した時のデリゲート
        /// </summary>
        public delegate void PullWait_To_NotInserted_Delegate(RmGetStatusParamClass ResStatus);
        /// <summary>
        /// カード抜取り待ちからカード未挿入に状態遷移した時
        /// </summary>
        public PullWait_To_NotInserted_Delegate PullWait_To_NotInserted;

        //----------
        // 例外対応
        // 例外だが起きる可能性が高い（カード処理後側抜き取ると処理中から未挿入に遷移する）
        //----------
        // 処理中から未挿入に遷移
        /// <summary>
        /// カード未挿入からカード抜取り待ちに状態遷移した時のデリゲート
        /// </summary>
        public delegate void Processing_To_NotInserted_Delegate(RmGetStatusParamClass ResStatus);
        /// <summary>
        /// カード未挿入からカード抜取り待ちに状態遷移した時
        /// </summary>
        public Processing_To_NotInserted_Delegate Processing_To_NotInserted;

        // 未挿入から抜き取り待ち
        /// <summary>
        /// カード未挿入からカード抜取り待ちに状態遷移した時のデリゲート
        /// </summary>
        public delegate void NotInserted_To_PullWait_Delegate(RmGetStatusParamClass ResStatus);
        /// <summary>
        /// カード未挿入からカード抜取り待ちに状態遷移した時
        /// </summary>
        public NotInserted_To_PullWait_Delegate NotInserted_To_PullWait;

        // 抜取り待ちから処理中
        /// <summary>
        /// カード処理中からカード抜取り待ちに状態遷移した時のデリゲート
        /// </summary>
        public delegate void PullWait_To_Processing_Delegate(RmGetStatusParamClass ResStatus);
        /// <summary>
        /// カード処理中からカード抜取り待ちに状態遷移した時
        /// </summary>
        public PullWait_To_Processing_Delegate PullWait_To_Processing;

        #endregion


        //--------------------------------------------------
        // メンバ変数
        //--------------------------------------------------
        #region メンバ変数
        /// <summary>
        /// スレッド
        /// </summary>
        private Thread thread = null;
        /// <summary>
        /// スレッド終了命令フラグ
        /// </summary>
        private bool ThreadEndFlag = false;
        /// <summary>
        /// スレッド中断命令フラグ
        /// </summary>
        private bool ThreadWaitFlag = false;

        /// <summary>
        /// エラー情報
        /// 最後に出たエラーの情報を記録
        /// </summary>
        private CardMachineErrorClass Error = new CardMachineErrorClass();

        /// <summary>
        /// カード機通信制御
        /// </summary>
        private CardMachineComClass CardMachineCom = new CardMachineComClass();

        /// <summary>
        /// 命令をキューにて貯め込む
        /// </summary>
        private Queue<OrderCardMachineClass> OrderQue = new Queue<OrderCardMachineClass>();
        #endregion


        //--------------------------------------------------
        // コンストラクタ・デストラクタ
        //--------------------------------------------------
        #region コンストラクタ・デストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CardMachineComThreadClass()
        {
            try
            {
                thread = new Thread(new ThreadStart(MainProcess));
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// デストラクタ
        /// </summary>
        ~CardMachineComThreadClass()
        {
            try
            {

            }
            catch
            {
                throw;
            }
        }
        #endregion


        //--------------------------------------------------
        // スレッド制御関連
        //--------------------------------------------------
        #region スレッド制御関連
        /// <summary>
        /// スレッド開始
        /// </summary>
        public void OrderThreadStart()
        {
            try
            {
                thread.Start();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// スレッド中断
        /// </summary>
        public void OrderThreadWait()
        {
            try
            {
                ThreadWaitFlag = true;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// スレッド再開
        /// </summary>
        public void OrderThreadResume()
        {
            try
            {
                ThreadWaitFlag = false;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// スレッド終了
        /// </summary>
        public void OrderThreadEnd()
        {
            try
            {
                ThreadEndFlag = true;
            }
            catch
            {
                throw;
            }
        }
        #endregion


        //--------------------------------------------------
        // カード機通信
        //--------------------------------------------------
        /// <summary>
        /// 命令を受け取る
        /// </summary>
        /// <param name="ordername">命令名</param>
        /// <param name="param">命令時のパラメータ</param>
        public void OrderCardMachine(OrderCardMachineState ordername, object param = null)
        {
            try
            {
                OrderQue.Enqueue(new OrderCardMachineClass()
                {
                    OrderName = ordername,
                    Param = param
                });
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 受け取った命令を実行する
        /// </summary>
        /// <param name="OrderName"></param>
        /// <param name="Param"></param>
        private void ExecutionCardMachine()
        {
            try
            {
                // 戻り値格納用
                CardMachineErrorClass ret = null;

                // 命令格納用
                OrderCardMachineClass Order = null;

                // 監視命令のステータスかどうか
                bool MonitoringFlag = false;

                // 命令が無ければ監視モード
                if (OrderQue.Count != 0)
                {
                    // 命令取得
                    Order = OrderQue.Dequeue();

                    // 監視命令OFF
                    MonitoringFlag = false;
                }
                else
                {
                    // 監視モードじゃなければ終了
                    if (!MonitoringMode) return;

                    // ステータス監視
                    Order = new OrderCardMachineClass
                    {
                        OrderName = OrderCardMachineState.RmGetStatus,
                        Param = new RmGetStatusParamClass()
                    };

                    // 監視命令ON
                    MonitoringFlag = true;
                }
                

                // 各種処理分岐
                switch (Order.OrderName)
                {
                    case OrderCardMachineState.None:
                        break;
                    case OrderCardMachineState.OpenPort:
                        ret = CardMachineCom.OpenPort((OpenPortParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.ClosePort:
                        ret = CardMachineCom.ClosePort();
                        break;
                    case OrderCardMachineState.RmGetStatus:
                        ret = CardMachineCom.RmGetStatus((RmGetStatusParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmGetVersion:
                        ret = CardMachineCom.RmGetVersion((RmGetVersionParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmSendClock:
                        ret = CardMachineCom.RmSendClock((RmSendClockParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmSendRecCard:
                        ret = CardMachineCom.RmSendRecCard((RmSendRecCardParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmGetCardDataA:
                        ret = CardMachineCom.RmGetCardDataA((RmGetCardDataAParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmSendExchnge:
                        ret = CardMachineCom.RmSendExchnge((RmSendExchngeParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmSendSellA:
                        ret = CardMachineCom.RmSendSellA((RmSendSellAParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmGetCalcA:
                        ret = CardMachineCom.RmGetCalcA((RmGetCalcAParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmSendMessageData:
                        ret = CardMachineCom.RmSendMessageData((RmSendMessageDataParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmSendName:
                        ret = CardMachineCom.RmSendName((RmSendNameParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmGetICM:
                        ret = CardMachineCom.RmGetICM((RmGetICMParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmGetMode:
                        ret = CardMachineCom.RmGetMode((RmGetModeParamClass)Order.Param);
                        break;
                    case OrderCardMachineState.RmSendProcRun:
                        ret = CardMachineCom.RmSendProcRun();
                        break;
                    case OrderCardMachineState.RmSendCancel:
                        ret = CardMachineCom.RmSendCancel();
                        break;
                    case OrderCardMachineState.RmSendCleaning:
                        ret = CardMachineCom.RmSendCleaning();
                        break;
                    case OrderCardMachineState.RmSendTestMode:
                        ret = CardMachineCom.RmSendTestMode();
                        break;
                    case OrderCardMachineState.RmSendICMClear:
                        ret = CardMachineCom.RmSendICMClear();
                        break;
                    case OrderCardMachineState.RmSendModem:
                        ret = CardMachineCom.RmSendModem();
                        break;
                    default:
                        break;
                }

                // 命令完了処理
                if (ret != null)
                {
                    // 応答処理
                    if (ret.ErrorCode == 0)
                    {
                        if(!MonitoringFlag) ReturnData?.Invoke(Order.OrderName, Order.Param);
                        else
                        {
                            // 監視モード時の特殊応答
                            MonitoringEventReturn(Order, ret);
                        }
                    }
                    else
                    {
                        Error = ret;
                        ErrorEvent?.Invoke(Error);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 監視モード時の応答割り振り
        /// </summary>
        /// <param name="order">OrderCardMachineClass</param>
        /// <param name="ret">CardMachineErrorClass</param>
        private void MonitoringEventReturn(OrderCardMachineClass order, CardMachineErrorClass ret)
        {
            try
            {
                RmGetStatusParamClass Data = (RmGetStatusParamClass)order.Param;

                // 監視している場合は特殊応答
                if (OldRWStatus == 0 && Data.rwsStatus == 1)
                {
                    // 未挿入から処理中
                    NotInserted_To_Processing?.Invoke(Data);
                }
                else if (OldRWStatus == 1 && Data.rwsStatus == 2)
                {
                    // 処理中から抜き取り待ち
                    Processing_To_PullWait?.Invoke(Data);
                }
                else if (OldRWStatus == 2 && Data.rwsStatus == 0)
                {
                    // 抜取り待ちから未挿入
                    PullWait_To_NotInserted?.Invoke(Data);
                }
                else if (OldRWStatus == 1 && Data.rwsStatus == 0)
                {
                    // 処理中から未挿入
                    Processing_To_NotInserted?.Invoke(Data);
                }
                else if (OldRWStatus == 0 && Data.rwsStatus == 2)
                {
                    // 未挿入から抜き取り待ち
                    NotInserted_To_PullWait?.Invoke(Data);
                }

                // 最新ステータスを保持
                OldRWStatus = Data.rwsStatus;
            }
            catch
            {
                throw;
            }
        }

        //--------------------------------------------------
        // メイン処理
        //--------------------------------------------------
        private void MainProcess()
        {
            try
            {
                while (true)
                {
                    //------------------------------
                    // スレッド終了命令があれば抜ける
                    //------------------------------
                    if (ThreadEndFlag) break;

                    //------------------------------
                    // スレッド待機命令があれば処理せずにループ先頭へ
                    //------------------------------
                    if (ThreadWaitFlag)
                    {
                        Thread.Sleep(1000);
                        continue;
                    }

                    //------------------------------
                    // メイン処理
                    //------------------------------
                    // カード機との通信処理関連
                    ExecutionCardMachine();

                    // スレッド処理の譲渡（実行可能な他のスレッドへ処理を渡す）
                    Thread.Sleep(0);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
