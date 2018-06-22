using Logger;
using Option;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace CardMachineCom
{
    public enum OrderCardMachineState
    {
        None,               // 命令無し（何もしない）
        OpenPort,           // 通信ポートオープン
        RmGetStatus,        // ステータス要求
        RmGetVersion,       // バージョンデータ要求
        RmSendClock,        // 時計データ送信
        RmSendRecCard,      // カード受付可能送信
        RmGetCardDataA,     // カードデータＡ要求
        RmSendExchnge,      // 交換データ送信
        RmSendSellA,        // 売上データＡ送信
        RmGetCalcA,         // 演算データＡ要求
        RmSendMessageData,  // サービスメッセージ送信
        RmSendName,         // 名前データ送信
        RmGetICM,           // 取引データ要求
        RmGetMode,          // モード要求
        ClosePort,          // 通信ポートクローズ
        RmSendProcRun,      // 確定処理コマンド送信
        RmSendCancel,       // 取消コード送信
        RmSendCleaning,     // クリーニングモード送信
        RmSendTestMode,     // テストカードモード送信
        RmSendICMClear,     // メモリカードクリア
        RmSendModem,        // モデム起動モード送信
    }

    class CardMachineComClass
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// カード機通信DLL読込
        /// </summary>
        private TCSPOS110PWrapperClass TCSPOS110P = new TCSPOS110PWrapperClass();

        /// <summary>
        /// オプションデータ読込
        /// </summary>
        private OptionClass OP = OptionClass.Instance;

        /// <summary>
        /// 通信ポートハンドル
        /// </summary>
        private IntPtr port_hndl;
        /// <summary>
        /// 通信ポート系パラメータ
        /// </summary>
        private OpenPortParamClass ComPort = new OpenPortParamClass();


        //--------------------------------------------------
        // コンストラクタ・デストラクタ・初期化系
        //--------------------------------------------------
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CardMachineComClass()
        {
            try
            {
                // コムポートスキャン＆設定
                ComPortScan();

                // カード機のバージョン情報取得
                POSModeCheck();
            }
            catch
            {
                throw;
            }
        }
        public CardMachineComClass(int port, int baud)
        {
            try
            {
                // コムポートとボーレートの設定
                ComPort.ComPort = (short)port;
                ComPort.Baud = baud;

                // コムポートのテスト
                if (!ComPortTest())
                {
                    // コムポートスキャン＆設定
                    ComPortScan();
                }

                // カード機のバージョン情報取得
                POSModeCheck();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// デストラクタ
        /// </summary>
        ~CardMachineComClass()
        {
            try
            {
                CardMachineErrorClass Ret = ClosePort();

                if (Ret.ErrorCode != 0)
                {
                    throw new Exception("COMポートのクローズに失敗しました");
                }
            }
            catch
            {
                throw;
            }
        }


        //--------------------------------------------------
        // エラーコード制御
        //--------------------------------------------------
        /// <summary>
        /// エラーリスト
        /// </summary>
        private Dictionary<int, CardMachineErrorClass> ErrorList = new Dictionary<int, CardMachineErrorClass>()
        {
            { 0, new CardMachineErrorClass(0, "", "") },
            { 1, new CardMachineErrorClass(1, "R/Wセンサー異常 [01]", "カードが挿入された状態で電源が切断された場合はカード除去して電源再投入。") },
            { 2, new CardMachineErrorClass(2,"カード詰り [02]","復旧しない場合は端末故障カード除去して電源再投入") },
            { 3, new CardMachineErrorClass(3,"カード誤挿入 [03]","長さ規格外カードが挿入されたカードは強制排出される") },
            { 4, new CardMachineErrorClass(4,"カード搬送異常 [04]","折れ曲がったカードが挿入されたカードは強制排出される") },
            { 5, new CardMachineErrorClass(5,"カード誤挿入 [05]","カード裏表が逆な場合は正しい方向から挿入") },
            { 6, new CardMachineErrorClass(6,"カードリードエラー [06]","カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 7, new CardMachineErrorClass(7, "カードリードエラー  [07]", "カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 8, new CardMachineErrorClass(8, "カードリードエラー  [08]", "カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 9, new CardMachineErrorClass(9, "カードリードエラー  [09]", "カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 10, new CardMachineErrorClass(10, "カードライトエラー [0A]", "カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 11, new CardMachineErrorClass(11, "カードライトエラー [0B]", "カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 12, new CardMachineErrorClass(12, "カードライトエラー [0C]", "カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 13, new CardMachineErrorClass(13, "カードライトエラー [0D]", "カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 14, new CardMachineErrorClass(14, "カード搬送異常 [0E]", "カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 15, new CardMachineErrorClass(15, "カード搬送異常 [0F]", "カードの磁気不良、カードは回収(頻発の場合は内部清掃)") },
            { 22, new CardMachineErrorClass(22, "R/Wメカユニット開放 [16]", "メカユニットを正しくロックして電源再投入") },
            { 24, new CardMachineErrorClass(24, "サーマルヘッド・サーミスタ異常 [18]", "端末故障") },
            { 25, new CardMachineErrorClass(25, "イレーズバー・サーミスタ異常 [19]", "端末故障") },
            { 32, new CardMachineErrorClass(32, "イレーズバー・温度異常 [20]", "端末故障") },
            { 128, new CardMachineErrorClass(128, "受信データ異常", "カード情報取得では発生の場合は排出後に再取得(再々発生の場合は端末故障)") },
            { 256, new CardMachineErrorClass(256, "カードが違います", "条件違いのカードが挿入された。排出して正しいカードを挿入してください。") },
            { 257, new CardMachineErrorClass(257, "無効カードです", "無効カードが挿入された。排出して正しいカードを挿入してください。") },
            { 258, new CardMachineErrorClass(258, "メモリカード未挿入", "メモリカードがセットされていない。メモリカードをセットして電源再投入してください。") },
            { 261, new CardMachineErrorClass(261, "メモリカードが違います", "メモリカード違い。正しいメモリカードをセットして電源再投入してください。") },
            { 262, new CardMachineErrorClass(262, "メモリカードが違います", "端末コードの異なるメモリカードがセット。正しいメモリカードをセットして電源再投入してください。") },
            { 263, new CardMachineErrorClass(263, "メモリカードのデータが満杯です", "メモリカード格納データ満杯。取引データを取得してください。") },
            { 265, new CardMachineErrorClass(265, "データファイル不正", "メモリカードのファイルデータが不正。すみやかにメモリカードを交換してください。") },
            { 266, new CardMachineErrorClass(266, "メモリカード書き込み不良", "メモリカードの書き込み不良。すみやかにメモリカードを交換してください。") },
            { 267, new CardMachineErrorClass(267, "エラーカードです", "エラー処理されたカードが挿入された。カードを 回収してください。") },
            { 270, new CardMachineErrorClass(270, "有効期限オーバー(カード無効)", "有効期限オーバーカードが挿入された（カード無効処理の条件の場合）") },
            { 274, new CardMachineErrorClass(274, "不正なカードです", "ロック会員登録されたカードが挿入された。カードを 回収してください。") },
            { 277, new CardMachineErrorClass(277, "カードデータが不正です", "カードの磁気情報不正。カードを回収して調査してください。") },
            { 514, new CardMachineErrorClass(514, "バックアップ異常", "システムを再設定してください。") },
            { 515, new CardMachineErrorClass(515, "時計データ異常", "時計データ異常再設定してください。") },
            { 516, new CardMachineErrorClass(516, "バッテリ電圧低下", "バッテリ電圧低下(端末故障)") },
            { 517, new CardMachineErrorClass(517, "時計データ受信待ち", "時計データ再設定してください。") },
            { 4000, new CardMachineErrorClass(4000, "通信ポートエラー", "正しいポート番号をセットしてください。") },
            { 4001, new CardMachineErrorClass(4001, "パラメータが違います", "正しい引数をセットしてください。") },
            { 4002, new CardMachineErrorClass(4002, "通信タイムアウト", "通信設定がHOSTと端末で異なる。端末がローカルモード操作の場合にも発生") },
            { 4003, new CardMachineErrorClass(4003, "ＮＡＫ受信エラー", "不適当な関数コール。端末設定、処理ルーチン調査してください。") },
            { 4004, new CardMachineErrorClass(4004, "ホスト交信不可", "ホスト交信不可です。R/Wの電源、シリアルケーブル確認してください。") },
            { 4005, new CardMachineErrorClass(4005, "ディスクエラー", "ディスクが異常です。取引データ要求関数コール時の媒体へのファイル書き込みエラー") },
            { 4006, new CardMachineErrorClass(4006, "ファイルアクセスエラー", "ファイル名またはパス名が存在しない。") },
            { -1, new CardMachineErrorClass(-1, "異常エラー", "異常エラーが発生しました。") }
        };
        /// <summary>
        /// エラーコードからメッセージ付きのエラーを返す
        /// </summary>
        /// <param name="code">エラーコード</param>
        /// <returns>エラーClassを返す</returns>
        public CardMachineErrorClass ErrorCodeCheck(int code)
        {
            ErrorList.TryGetValue(code, out CardMachineErrorClass ret);
            if (ret == null)
            {
                return ErrorList[-1];
            }
            else
            {
                return ErrorList[code];
            }
        }


        //--------------------------------------------------
        // コムポート設定系
        //--------------------------------------------------
        #region コムポート設定系
        /// <summary>
        /// コムポートをスキャンして自動で設定する
        /// </summary>
        private void ComPortScan()
        {
            try
            {
                // COMポートリストを取得
                string[] ports = SerialPort.GetPortNames();

                // 現在取得したポート数
                int PortsLength = ports.Length;

                if (PortsLength == 0)
                {
                    throw new Exception("COMポートが見つかりません、USBケーブルが繋がっていることを確認してください。");
                }

                // 数字のみ抜き出すための正規表現
                Regex re = new Regex(@"[^0-9]");
                
                // 上記リストから数字のみ抜き出す
                string[] portnolist = new string[PortsLength];
                for (int i = 0; i < PortsLength; i++)
                {
                    // COMポート名からポート番号を抜き出す
                    portnolist[i] = re.Replace(ports[i], "");
                }

                // ボーレート取得（デバイスのデフォルト値）
                SerialPort[] PortNames = new SerialPort[PortsLength];
                int[] baudList = new int[PortsLength];
                for (int i = 0; i < PortsLength; i++)
                {
                    PortNames[i] = new SerialPort(ports[i]);
                    baudList[i] = PortNames[i].BaudRate;
                }

                // ポートオープンに成功したポートを設定保持する
                OpenPortParamClass ScanComPort = new OpenPortParamClass();
                CardMachineErrorClass OpenRet = ErrorCodeCheck(-1);
                for (int i = 0; i < PortsLength; i++)
                {
                    // ポート取得
                    ScanComPort.ComPort = short.Parse(portnolist[i]);
                    ScanComPort.Baud = baudList[i];

                    // 取得ポートをオープンテスト
                    OpenRet = OpenPort(ScanComPort);

                    // 成否判定
                    if (OpenRet.ErrorCode == 0)
                    {
                        ComPort.ComPort = ScanComPort.ComPort;
                        ComPort.Baud = ScanComPort.Baud;
                        break;
                    }
                }

                if(OpenRet.ErrorCode != 0)
                {
                    throw new Exception(OpenRet.ErrorMessage);
                }
            }
            catch
            {
                throw;
            }
        }
        private bool ComPortTest()
        {
            try
            {
                CardMachineErrorClass OpenRet = ErrorCodeCheck(-1);

                // 取得ポートをオープンテスト
                OpenRet = OpenPort(ComPort);

                // 成否判定
                if (OpenRet.ErrorCode != 0)
                {
                    return false;
                }

            }
            catch
            {
                throw;
            }

            return true;
        }
        /// <summary>
        /// コムポートの手動設定
        /// </summary>
        public void SetComPort(short comport) { ComPort.ComPort = comport; }
        public void SetComPort(int comport) { ComPort.ComPort = (short)comport; }
        #endregion


        //--------------------------------------------------
        // POS接続モードチェック
        //--------------------------------------------------
        private void POSModeCheck()
        {
            try
            {
                CardMachineErrorClass Res = null;

                // バージョン情報取得
                RmGetVersionParamClass VersionParam = new RmGetVersionParamClass();
                Res = RmGetVersion(VersionParam);
                if (Res.ErrorCode != 0)
                {
                    throw new Exception(Res.ErrorMessage);
                }

                // ステータス情報取得
                RmGetStatusParamClass StatusParam = new RmGetStatusParamClass();
                Res = RmGetStatus(StatusParam);
                if (Res.ErrorCode != 0)
                {
                    throw new Exception(Res.ErrorMessage);
                }

                // POS接続モードチェック
                if (VersionParam.reserve2 != 2 || StatusParam.mvmode != 0)
                {
                    // POS接続モードではないのでエラー出力
                    throw new Exception("カード機がPOS接続モードではありません。\nカード機本体の設定を確認してください。");
                }
            }
            catch
            {
                throw;
            }
        }


        //--------------------------------------------------
        // カード機制御命令
        //--------------------------------------------------
        #region カード機制御命令
        /// <summary>通信ポートオープン</summary>
        public CardMachineErrorClass OpenPort(OpenPortParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.OpenPort(ref port_hndl, Param.ComPort, Param.Baud);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>ステータス要求</summary>
        public CardMachineErrorClass RmGetStatus(RmGetStatusParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmGetStatus(ref port_hndl,
                    ref Param.card,
                    ref Param.rwsStatus,
                    ref Param.mvmode,
                    ref Param.icStatus,
                    ref Param.datanum,
                    ref Param.datamax,
                    ref Param.errcode
                );
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>バージョンデータ要求</summary>
        public CardMachineErrorClass RmGetVersion(RmGetVersionParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmGetVersion(ref port_hndl,
                ref Param.tmcode,
                ref Param.sfver,
                ref Param.mkmode,
                ref Param.card,
                ref Param.mcard,
                ref Param.reserve2);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>時計データ送信</summary>
        public CardMachineErrorClass RmSendClock(RmSendClockParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendClock(ref port_hndl, Param.clock);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>カード受付可能送信</summary>
        public CardMachineErrorClass RmSendRecCard(RmSendRecCardParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendRecCard(ref port_hndl, Param.card);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>カードデータＡ要求</summary>
        public CardMachineErrorClass RmGetCardDataA(RmGetCardDataAParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmGetCardDataA(ref port_hndl,
                    Param.cardid,
                    ref Param.rank,
                    ref Param.ownpoint,
                    ref Param.ownbalance,
                    Param.issuedate,
                    ref Param.usecount,
                    Param.usedate,
                    Param.limit,
                    Param.plimit,
                    ref Param.expired,
                    ref Param.ctype,
                    ref Param.pflag,
                    Param.birthday,
                    ref Param.birthdayplag,
                    ref Param.luckplag,
                    ref Param.memlist,
                    Param.namedata);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>交換データ送信</summary>
        public CardMachineErrorClass RmSendExchnge(RmSendExchngeParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendExchnge(ref port_hndl, Param.chgpoint);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>売上データＡ送信</summary>
        public CardMachineErrorClass RmSendSellA(RmSendSellAParamClass Param)
        {
            int ret = -1;

            try
            {
                IntPtr ptr = Marshal.AllocCoTaskMem(Marshal.SizeOf(Param.stsendsaledatainf));
                Marshal.StructureToPtr(Param.stsendsaledatainf, ptr, false);

                ret = TCSPOS110PWrapperClass.RmSendSellA(ref port_hndl,
                    ptr,
                    Param.datacount,
                    Param.services,
                    Param.sales,
                    Param.paddflag,
                    Param.dmflag);

                Marshal.DestroyStructure(ptr, typeof(StSendSaleDataInf));
                Marshal.FreeCoTaskMem(ptr);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>演算データＡ要求</summary>
        public CardMachineErrorClass RmGetCalcA(RmGetCalcAParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmGetCalcA(ref port_hndl,
                    ref Param.point,
                    ref Param.chgflag,
                    ref Param.chgpoint,
                    ref Param.tmoney,
                    ref Param.tolpoint,
                    ref Param.ownbalance,
                    ref Param.usecout);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>サービスメッセージ送信</summary>
        public CardMachineErrorClass RmSendMessageData(RmSendMessageDataParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendMessageData(ref port_hndl,
                    Param.memory,
                    Param.block,
                    Param.msg1,
                    Param.msg2,
                    Param.msg3);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>名前データ送信</summary>
        public CardMachineErrorClass RmSendName(RmSendNameParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendName(ref port_hndl, Param.namedata);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>取引データ要求</summary>
        public CardMachineErrorClass RmGetICM(RmGetICMParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmGetICM(ref port_hndl, Param.filename);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>モード要求</summary>
        public CardMachineErrorClass RmGetMode(RmGetModeParamClass Param)
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmGetMode(ref port_hndl,
                    ref Param.mrate,
                    ref Param.gpoint,
                    ref Param.special,
                    ref Param.service,
                    ref Param.sprint,
                    ref Param.exchange,
                    ref Param.division,
                    ref Param.rank,
                    ref Param.birthday,
                    ref Param.ncard,
                    ref Param.tcard,
                    ref Param.reserve
                );
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>通信ポートクローズ</summary>
        public CardMachineErrorClass ClosePort()
        {
            int ret = 0;

            try
            {
                if ((int)port_hndl != -1)
                {
                    ret = TCSPOS110PWrapperClass.ClosePort(ref port_hndl);
                }
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>確定処理コマンド送信</summary>
        public CardMachineErrorClass RmSendProcRun()
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendProcRun(ref port_hndl);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>取消コード送信</summary>
        public CardMachineErrorClass RmSendCancel()
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendCancel(ref port_hndl);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>クリーニングモード送信</summary>
        public CardMachineErrorClass RmSendCleaning()
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendCleaning(ref port_hndl);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>テストカードモード送信</summary>
        public CardMachineErrorClass RmSendTestMode()
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendTestMode(ref port_hndl);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>メモリカードクリア</summary>
        public CardMachineErrorClass RmSendICMClear()
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendICMClear(ref port_hndl);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }

        /// <summary>モデム起動モード送信</summary>
        public CardMachineErrorClass RmSendModem()
        {
            int ret = -1;

            try
            {
                ret = TCSPOS110PWrapperClass.RmSendModem(ref port_hndl);
            }
            catch
            {
                throw;
            }

            return ErrorCodeCheck(ret);
        }
        #endregion
    }
}
