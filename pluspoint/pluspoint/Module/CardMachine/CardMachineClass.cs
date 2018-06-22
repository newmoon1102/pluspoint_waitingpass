using CardMachineCom;
using Logger;
using pluspoint.Base;

namespace pluspoint.Module.CardMachine
{
    public class CardMachineClass : ModuleBaseClass
    {
        //--------------------------------------------------
        // コンストラクタ・デストラクタ
        //--------------------------------------------------
        #region コンストラクタ・デストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CardMachineClass()
        {
            try
            {
                // カード機へ命令を送るイベントの登録
                RelayOrder += base.CardMachineCom.OrderCardMachine;

                // カード機から応答を受け取るイベントの登録
                base.CardMachineCom.ReturnData += OrderCardMachineResponse;
                // カード機から応答がエラーだった場合のイベントの登録
                base.CardMachineCom.ErrorEvent += OrderCardMachineError;

                // カード機から応答を受け取るイベントの登録（カード未挿入からカード処理中）
                base.CardMachineCom.NotInserted_To_Processing += OrderCardMachineResponse_RelayNotInserted_To_Processing;
                // カード機から応答を受け取るイベントの登録（カード処理中からカード抜取り待ち）
                base.CardMachineCom.Processing_To_PullWait += OrderCardMachineResponse_RelayProcessing_To_PullWait;
                // カード機から応答を受け取るイベントの登録（カード抜取り待ちからカード未挿入）
                base.CardMachineCom.PullWait_To_NotInserted += OrderCardMachineResponse_RelayPullWait_To_NotInserted;

                // カード機から応答を受け取るイベントの登録（カード未挿入からカード処理中）
                base.CardMachineCom.Processing_To_NotInserted += OrderCardMachineResponse_RelayProcessing_To_NotInserted;
                // カード機から応答を受け取るイベントの登録（カード処理中からカード抜取り待ち）
                base.CardMachineCom.NotInserted_To_PullWait += OrderCardMachineResponse_RelayNotInserted_To_PullWait;
                // カード機から応答を受け取るイベントの登録（カード抜取り待ちからカード未挿入）
                base.CardMachineCom.PullWait_To_Processing += OrderCardMachineResponse_RelayPullWait_To_Processing;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// デストラクタ
        /// </summary>
        ~CardMachineClass()
        {
            try
            {
                // カード機へ命令を送るイベントの登録
                RelayOrder -= base.CardMachineCom.OrderCardMachine;

                // カード機から応答を受け取るイベントの登録
                base.CardMachineCom.ReturnData -= OrderCardMachineResponse;
                // カード機から応答がエラーだった場合のイベントの登録
                base.CardMachineCom.ErrorEvent -= OrderCardMachineError;

                // カード機から応答を受け取るイベントの登録（カード未挿入からカード処理中）
                base.CardMachineCom.NotInserted_To_Processing -= OrderCardMachineResponse_RelayNotInserted_To_Processing;
                // カード機から応答を受け取るイベントの登録（カード処理中からカード抜取り待ち）
                base.CardMachineCom.Processing_To_PullWait -= OrderCardMachineResponse_RelayProcessing_To_PullWait;
                // カード機から応答を受け取るイベントの登録（カード抜取り待ちからカード未挿入）
                base.CardMachineCom.PullWait_To_NotInserted -= OrderCardMachineResponse_RelayPullWait_To_NotInserted;

                // カード機から応答を受け取るイベントの登録（カード未挿入からカード処理中）
                base.CardMachineCom.Processing_To_NotInserted -= OrderCardMachineResponse_RelayProcessing_To_NotInserted;
                // カード機から応答を受け取るイベントの登録（カード処理中からカード抜取り待ち）
                base.CardMachineCom.NotInserted_To_PullWait -= OrderCardMachineResponse_RelayNotInserted_To_PullWait;
                // カード機から応答を受け取るイベントの登録（カード抜取り待ちからカード未挿入）
                base.CardMachineCom.PullWait_To_Processing -= OrderCardMachineResponse_RelayPullWait_To_Processing;
            }
            catch
            {
                throw;
            }
        }
        #endregion


        //--------------------------------------------------
        // Event定義
        //--------------------------------------------------
        #region カード機通信Event定義
        /// <summary>
        /// カード機への命令イベントのデリゲート
        /// </summary>
        public delegate void OrderCardMachineDelegate(OrderCardMachineState ordername, object param = null);
        /// <summary>
        /// カード機への命令イベント
        /// </summary>
        public OrderCardMachineDelegate RelayOrder;
        #endregion

        #region 自作カード状態認識Event定義
        /// <summary>
        /// カード未挿入からカード処理中に状態遷移した時のデリゲート
        /// </summary>
        public delegate void RelayNotInserted_To_Processing_Delegate(RmGetStatusParamClass resdata);
        /// <summary>
        /// カード処理中からカード抜取り待ちに状態遷移した時のデリゲート
        /// </summary>
        public delegate void RelayProcessing_To_PullWait_Delegate(RmGetStatusParamClass resdata);
        /// <summary>
        /// カード抜取り待ちからカード未挿入に状態遷移した時のデリゲート
        /// </summary>
        public delegate void RelayPullWait_To_NotInserted_Delegate(RmGetStatusParamClass resdata);
        /// <summary>
        /// カード未挿入からカード処理中に状態遷移した時
        /// </summary>
        public RelayNotInserted_To_Processing_Delegate RelayNotInserted_To_Processing;
        /// <summary>
        /// カード処理中からカード抜取り待ちに状態遷移した時
        /// </summary>
        public RelayProcessing_To_PullWait_Delegate RelayProcessing_To_PullWait;
        /// <summary>
        /// カード抜取り待ちからカード未挿入に状態遷移した時
        /// </summary>
        public RelayPullWait_To_NotInserted_Delegate RelayPullWait_To_NotInserted;

        // カード状態遷移の例外パターン対応
        /// <summary>
        /// カード処理中からカード未挿入に状態遷移した時のデリゲート
        /// </summary>
        public delegate void RelayProcessing_To_NotInserted_Delegate(RmGetStatusParamClass resdata);
        /// <summary>
        /// カード処理中からカード未挿入に状態遷移した時
        /// </summary>
        public RelayProcessing_To_NotInserted_Delegate RelayProcessing_To_NotInserted;

        /// <summary>
        /// カード未挿入から抜取り待ちに状態遷移した時のデリゲート
        /// </summary>
        public delegate void RelayNotInserted_To_PullWait_Delegate(RmGetStatusParamClass resdata);
        /// <summary>
        /// カード未挿入から抜取り待ちに状態遷移した時
        /// </summary>
        public RelayNotInserted_To_PullWait_Delegate RelayNotInserted_To_PullWait;

        /// <summary>
        /// カード抜取り待ちからカード処理中に状態遷移した時のデリゲート
        /// </summary>
        public delegate void RelayPullWait_To_Processing_Delegate(RmGetStatusParamClass resdata);
        /// <summary>
        /// カード抜取り待ちからカード処理中に状態遷移した時
        /// </summary>
        public RelayPullWait_To_Processing_Delegate RelayPullWait_To_Processing;
        #endregion

        #region ModuleへのEvent定義
        public delegate void RelayOpenPortDelegate(OpenPortParamClass resdata);
        public delegate void RelayClosePortDelegate();
        public delegate void RelayRmGetStatusDelegate(RmGetStatusParamClass resdata);
        public delegate void RelayRmGetVersionDelegate(RmGetVersionParamClass resdata);
        public delegate void RelayRmSendClockDelegate(RmSendClockParamClass resdata);
        public delegate void RelayRmSendRecCardDelegate(RmSendRecCardParamClass resdata);
        public delegate void RelayRmGetCardDataADelegate(RmGetCardDataAParamClass resdata);
        public delegate void RelayRmSendExchngeDelegate(RmSendExchngeParamClass resdata);
        public delegate void RelayRmSendSellADelegate(RmSendSellAParamClass resdata);
        public delegate void RelayRmGetCalcADelegate(RmGetCalcAParamClass resdata);
        public delegate void RelayRmSendMessageDataDelegate(RmSendMessageDataParamClass resdata);
        public delegate void RelayRmSendNameDelegate(RmSendNameParamClass resdata);
        public delegate void RelayRmGetICMDelegate(RmGetICMParamClass resdata);
        public delegate void RelayRmGetModeDelegate(RmGetModeParamClass resdata);
        public delegate void RelayRmSendProcRunDelegate();
        public delegate void RelayRmSendCancelDelegate();
        public delegate void RelayRmSendCleaningDelegate();
        public delegate void RelayRmSendTestModeDelegate();
        public delegate void RelayRmSendICMClearDelegate();
        public delegate void RelayRmSendModemDelegate();

        public RelayOpenPortDelegate RelayOpenPort;
        public RelayClosePortDelegate RelayClosePort;
        public RelayRmGetStatusDelegate RelayRmGetStatus;
        public RelayRmGetVersionDelegate RelayRmGetVersion;
        public RelayRmSendClockDelegate RelayRmSendClock;
        public RelayRmSendRecCardDelegate RelayRmSendRecCard;
        public RelayRmGetCardDataADelegate RelayRmGetCardDataA;
        public RelayRmSendExchngeDelegate RelayRmSendExchnge;
        public RelayRmSendSellADelegate RelayRmSendSellA;
        public RelayRmGetCalcADelegate RelayRmGetCalcA;
        public RelayRmSendMessageDataDelegate RelayRmSendMessageData;
        public RelayRmSendNameDelegate RelayRmSendName;
        public RelayRmGetICMDelegate RelayRmGetICM;
        public RelayRmGetModeDelegate RelayRmGetMode;
        public RelayRmSendProcRunDelegate RelayRmSendProcRun;
        public RelayRmSendCancelDelegate RelayRmSendCancel;
        public RelayRmSendCleaningDelegate RelayRmSendCleaning;
        public RelayRmSendTestModeDelegate RelayRmSendTestMode;
        public RelayRmSendICMClearDelegate RelayRmSendICMClear;
        public RelayRmSendModemDelegate RelayRmSendModem;

        /// <summary>
        /// カード機エラー応答中継デリゲート
        /// </summary>
        /// <param name="CardMachineError">エラーデータ</param>
        public delegate void RelayOrderCardMachineResponseErrorDelegate(CardMachineErrorClass CardMachineError);
        /// <summary>
        /// カード機エラー応答中継イベント
        /// </summary>
        public RelayOrderCardMachineResponseErrorDelegate RelayOrderCardMachineResponseError;
        #endregion


        //--------------------------------------------------
        // カード機命令リレー
        //--------------------------------------------------
        /// <summary>
        /// カード機へ命令を送る
        /// </summary>
        /// <param name="ordername">命令種別</param>
        /// <param name="param">命令パラメータ</param>
        public void OrderCardMachine(OrderCardMachineState ordername, object param = null)
        {
            try
            {
                RelayOrder?.Invoke(ordername, param);
            }
            catch
            {
                throw;
            }
        }


        //--------------------------------------------------
        // カード機応答受取リレー
        //--------------------------------------------------
        /// <summary>
        /// カード機からの応答を受け取る
        /// </summary>
        /// <param name="ordername">応答種別</param>
        /// <param name="param">応答データ</param>
        public void OrderCardMachineResponse(OrderCardMachineState ordername, object param = null)
        {
            try
            {
                ResponseCardMachineOrder(ordername, param);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カード機からのエラー応答を受け取る
        /// </summary>
        /// <param name="CardMachineError">エラー情報</param>
        public void OrderCardMachineError(CardMachineErrorClass CardMachineError)
        {
            try
            {
                ResponseError(CardMachineError);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カード未挿入からカード処理中
        /// </summary>
        /// <param name="RetData">応答データ</param>
        public void OrderCardMachineResponse_RelayNotInserted_To_Processing(RmGetStatusParamClass RetData)
        {
            try
            {
                RelayNotInserted_To_Processing?.Invoke((RmGetStatusParamClass)RetData);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// カード処理中からカード抜取り待ち
        /// </summary>
        /// <param name="RetData">応答データ</param>
        public void OrderCardMachineResponse_RelayProcessing_To_PullWait(RmGetStatusParamClass RetData)
        {
            try
            {
                RelayProcessing_To_PullWait?.Invoke((RmGetStatusParamClass)RetData);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// カード抜取り待ちからカード未挿入
        /// </summary>
        /// <param name="RetData">応答データ</param>
        public void OrderCardMachineResponse_RelayPullWait_To_NotInserted(RmGetStatusParamClass RetData)
        {
            try
            {
                RelayPullWait_To_NotInserted?.Invoke((RmGetStatusParamClass)RetData);
            }
            catch
            {
                throw;
            }
        }

        // カード状態例外
        /// <summary>
        /// カード処理中からカード未挿入
        /// </summary>
        /// <param name="RetData">応答データ</param>
        public void OrderCardMachineResponse_RelayProcessing_To_NotInserted(RmGetStatusParamClass RetData)
        {
            try
            {
                RelayProcessing_To_NotInserted?.Invoke((RmGetStatusParamClass)RetData);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// カード未挿入からカード抜取り待ち
        /// </summary>
        /// <param name="RetData">応答データ</param>
        public void OrderCardMachineResponse_RelayNotInserted_To_PullWait(RmGetStatusParamClass RetData)
        {
            try
            {
                RelayNotInserted_To_PullWait?.Invoke((RmGetStatusParamClass)RetData);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// カード抜取り待ちからカード処理中
        /// </summary>
        /// <param name="RetData">応答データ</param>
        public void OrderCardMachineResponse_RelayPullWait_To_Processing(RmGetStatusParamClass RetData)
        {
            try
            {
                RelayPullWait_To_Processing?.Invoke((RmGetStatusParamClass)RetData);
            }
            catch
            {
                throw;
            }
        }

        //--------------------------------------------------
        // カード機制御関連
        //--------------------------------------------------
        /// <summary>
        /// カード機命令
        /// </summary>
        /// <param name="ordername">命令種類</param>
        /// <param name="param">命令時のパラメータ</param>
        public void CardMachineOrder(OrderCardMachineState ordername, object param = null)
        {
            try
            {
                RelayOrder(ordername, param);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 応答データ振り分け
        /// </summary>
        /// <param name="ordername">応答種類</param>
        /// <param name="param">応答受取データ</param>
        private void ResponseCardMachineOrder(OrderCardMachineState ordername, object param = null)
        {
            try
            {
                switch (ordername)
                {
                    case OrderCardMachineState.None:
                        break;
                    case OrderCardMachineState.OpenPort:
                        RelayOpenPort?.Invoke((OpenPortParamClass)param);
                        break;
                    case OrderCardMachineState.ClosePort:
                        RelayClosePort?.Invoke();
                        break;
                    case OrderCardMachineState.RmGetStatus:
                        RelayRmGetStatus?.Invoke((RmGetStatusParamClass)param);
                        break;
                    case OrderCardMachineState.RmGetVersion:
                        RelayRmGetVersion?.Invoke((RmGetVersionParamClass)param);
                        break;
                    case OrderCardMachineState.RmSendClock:
                        RelayRmSendClock?.Invoke((RmSendClockParamClass)param);
                        break;
                    case OrderCardMachineState.RmSendRecCard:
                        RelayRmSendRecCard?.Invoke((RmSendRecCardParamClass)param);
                        break;
                    case OrderCardMachineState.RmGetCardDataA:
                        RelayRmGetCardDataA?.Invoke((RmGetCardDataAParamClass)param);
                        break;
                    case OrderCardMachineState.RmSendExchnge:
                        RelayRmSendExchnge?.Invoke((RmSendExchngeParamClass)param);
                        break;
                    case OrderCardMachineState.RmSendSellA:
                        RelayRmSendSellA?.Invoke((RmSendSellAParamClass)param);
                        break;
                    case OrderCardMachineState.RmGetCalcA:
                        RelayRmGetCalcA?.Invoke((RmGetCalcAParamClass)param);
                        break;
                    case OrderCardMachineState.RmSendMessageData:
                        RelayRmSendMessageData?.Invoke((RmSendMessageDataParamClass)param);
                        break;
                    case OrderCardMachineState.RmSendName:
                        RelayRmSendName?.Invoke((RmSendNameParamClass)param);
                        break;
                    case OrderCardMachineState.RmGetICM:
                        RelayRmGetICM?.Invoke((RmGetICMParamClass)param);
                        break;
                    case OrderCardMachineState.RmGetMode:
                        RelayRmGetMode?.Invoke((RmGetModeParamClass)param);
                        break;
                    case OrderCardMachineState.RmSendProcRun:
                        RelayRmSendProcRun?.Invoke();
                        break;
                    case OrderCardMachineState.RmSendCancel:
                        RelayRmSendCancel?.Invoke();
                        break;
                    case OrderCardMachineState.RmSendCleaning:
                        RelayRmSendCleaning?.Invoke();
                        break;
                    case OrderCardMachineState.RmSendTestMode:
                        RelayRmSendTestMode?.Invoke();
                        break;
                    case OrderCardMachineState.RmSendICMClear:
                        RelayRmSendICMClear?.Invoke();
                        break;
                    case OrderCardMachineState.RmSendModem:
                        RelayRmSendModem?.Invoke();
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// カード機エラー応答
        /// </summary>
        /// <param name="CardMachineError">エラー情報</param>
        protected virtual void ResponseError(CardMachineErrorClass CardMachineError)
        {
            try
            {
                // 例外エラーのログ出力
                Log.Error(CardMachineError.ErrorTitle + "：" + CardMachineError.ErrorCode.ToString() + "：" + CardMachineError.ErrorMessage);

                // エラーイベント起動
                RelayOrderCardMachineResponseError?.Invoke(CardMachineError);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 監視開始・停止を送る
        /// </summary>
        public void MonitoringSwitch(bool MonitorFlag)
        {
            try
            {
                base.CardMachineCom.MonitoringMode = MonitorFlag;
            }
            catch
            {
                throw;
            }
        }
    }
}
