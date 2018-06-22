using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CardMachineCom
{
    /// <summary>
    /// C++ライブラリをそのままC#で使えるように変換したもの
    /// </summary>
    public class TCSPOS110PWrapperClass
    {
        const string dllName = @"TCSPOS110P.dll";

        /// <summary>通信ポートオープン</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="portno">通信ポート番号</param>
        /// <param name="bps">通信ボーレート</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int OpenPort(ref IntPtr port_hndl, short portno, int bps);

        /// <summary>通信ポートクローズ</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int ClosePort(ref IntPtr port_hndl);

        /// <summary>ステータス要求</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="card">カード受付状態（戻り値）</param>
        /// <param name="rwStatus">カードリ－ダライタ動作状態（戻り値）</param>
        /// <param name="mvmode">動作モード（戻り値）</param>
        /// <param name="icStatus">メモリカード状態（戻り値）</param>
        /// <param name="datanum">取引データ個数（戻り値）</param>
        /// <param name="datamax">格納可能データ個数（戻り値）</param>
        /// <param name="errcode">エラ－コード（戻り値）</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmGetStatus(ref IntPtr port_hndl, ref short card, ref short rwsStatus, ref short mvmode, ref short icStatus, ref int datanum, ref int datamax, ref short errcode);

        /// <summary>バージョンデータ要求</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="tmcode">機種コード（戻り値）</param>
        /// <param name="sfver">端末ソフトバージョン（戻り値）</param>
        /// <param name="mkmode">運用モード（戻り値）</param>
        /// <param name="card">カード媒体（戻り値）</param>
        /// <param name="mcard">メモリカード（戻り値）</param>
        /// <param name="reserve2">予備（戻り値）</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmGetVersion(ref IntPtr port_hndl, ref short tmcode, ref int sfver, ref short mkmode, ref short card, ref int mcard, ref int reserve2);

        /// <summary>時計データ送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="clock">日付・時刻データ</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendClock(ref IntPtr port_hndl, byte[] clock);

        /// <summary>カード受付可能送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="card">カード受付状態</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendRecCard(ref IntPtr port_hndl, short card);

        /// <summary>カードデータＡ要求</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="cardid">会員ｺｰﾄﾞ</param>
        /// <param name="rank">会員ランク</param>
        /// <param name="ownpoint">保有ポイント</param>
        /// <param name="ownbalance">保有金額</param>
        /// <param name="issuedate">入会日</param>
        /// <param name="usecount">利用回数</param>
        /// <param name="usedate">直近利用日</param>
        /// <param name="limit">カード有効期限</param>
        /// <param name="plimit">プリカ有効期限</param>
        /// <param name="expired">期限情報</param>
        /// <param name="ctype">カード種別</param>
        /// <param name="pflag">プリカフラグ</param>
        /// <param name="birthday">誕生日データ</param>
        /// <param name="birthdayplag">誕生日ポイント付加フラグ</param>
        /// <param name="luckplag">ラッキーポイント付加フラグ</param>
        /// <param name="memlist">会員リスト照合</param>
        /// <param name="namedata">名前データ</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmGetCardDataA(ref IntPtr port_hndl, byte[] cardid, ref short rank, ref int ownpoint, ref int ownbalance, byte[] issuedate, ref int usecount, byte[] usedate,
            byte[] limit, byte[] plimit, ref short expired, ref short ctype, ref short pflag, byte[] birthday, ref short birthdayplag, ref short luckplag, ref short memlist, byte[] namedata);

        /// <summary>交換データ送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="chgpoint">交換ポイント</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendExchnge(ref IntPtr port_hndl, int chgpoint);

        /// <summary>売上データＡ送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="sendsaledatainf">売上データ情報</param>
        /// <param name="datacount">データ個数</param>
        /// <param name="services">サービスコード（配列）</param>
        /// <param name="sales">売上金額データ（配列）</param>
        /// <param name="paddflag">ポイント付加フラグ（配列）</param>
        /// <param name="dmflag">DM持参フラグ(配列)</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendSellA(ref IntPtr port_hndl, IntPtr stsendsaledatainf, short datacount, int[] services, int[] sales, short[] paddflag, short[] dmflag);

        /// <summary>演算データＡ要求</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="point">演算ポイントデータ（戻り値）</param>
        /// <param name="chgflag">到達フラグ（戻り値）</param>
        /// <param name="chgpoint">交換設定ポイントデータ（戻り値）</param>
        /// <param name="tmoney">振替金額データ（戻り値）</param>
        /// <param name="tolpoint">累計ポイントデータ（戻り値）</param>
        /// <param name="ownbalance">利用後残高データ（戻り値）</param>
        /// <param name="usecout">通算利用回数（戻り値）</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmGetCalcA(ref IntPtr port_hndl, ref int point, ref short chgflag, ref int chgpoint, ref int tmoney, ref int tolpoint, ref int ownbalance, ref int usecout);

        /// <summary>サービスメッセージ送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="memory">メモリ機能</param>
        /// <param name="block">印字ブロック指定</param>
        /// <param name="msg1">メッセージ１データ</param>
        /// <param name="msg2">メッセージ２データ</param>
        /// <param name="msg3">メッセージ３データ</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendMessageData(ref IntPtr port_hndl, short memory, short block, byte[] msg1, byte[] msg2, byte[] msg3);

        /// <summary>名前データ送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="namedata"></param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendName(ref IntPtr port_hndl, byte[] namedata);

        /// <summary>確定処理コマンド送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendProcRun(ref IntPtr port_hndl);

        /// <summary>取消コード送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendCancel(ref IntPtr port_hndl);

        /// <summary>クリーニングモード送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendCleaning(ref IntPtr port_hndl);

        /// <summary>テストカードモード送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendTestMode(ref IntPtr port_hndl);

        /// <summary>取引データ要求</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="filename">データ出力ファイル名</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmGetICM(ref IntPtr port_hndl, byte[] filename);

        /// <summary>メモリカードクリア</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendICMClear(ref IntPtr port_hndl);

        /// <summary>モデム起動モード送信</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmSendModem(ref IntPtr port_hndl);

        /// <summary>モード要求</summary>
        /// <param name="port_hndl">通信ポート番号</param>
        /// <param name="mrate">倍率（戻り値）</param>
        /// <param name="gpoint">商品ポイント付加設定有無（戻り値）</param>
        /// <param name="special">特別ポイント付加設定有無（戻り値）</param>
        /// <param name="service">印字ブロック１設定内容（戻り値）</param>
        /// <param name="sprint">店名印字有無（戻り値）</param>
        /// <param name="exchange">交換ポイント処理設定（戻り値）</param>
        /// <param name="division">区分料率運用設定（戻り値）</param>
        /// <param name="rank">ランク別設定（戻り値）</param>
        /// <param name="birthday">誕生日ポイント付加設定（戻り値）</param>
        /// <param name="ncard">生カード運用（戻り値）</param>
        /// <param name="tcard">サーマルカード併用設定（戻り値）</param>
        /// <param name="reserve">予備</param>
        /// <returns></returns>
        [DllImport(dllName, CharSet = CharSet.Unicode)]
        public static extern int RmGetMode(ref IntPtr port_hndl, ref short mrate, ref short gpoint, ref short special, ref short service, ref short sprint, ref short exchange, ref short division, ref short rank, ref short birthday, ref short ncard, ref short tcard, ref short reserve);
    }

    /// <summary>通信ポートオープンパラメータ</summary>
    public class OpenPortParamClass
    {
        /// <summary>
        /// 通信ポート番号
        /// </summary>
        public short ComPort;

        /// <summary>
        /// 通信速度レート
        /// </summary>
        public int Baud;
    }

    /// <summary>ステータス要求パラメータ</summary>
    public class RmGetStatusParamClass
    {
        public short card;
        public short rwsStatus;
        public short mvmode;
        public short icStatus;
        public int datanum;
        public int datamax;
        public short errcode;
    }

    /// <summary>バージョンデータ要求パラメータ</summary>
    public class RmGetVersionParamClass
    {
        public short tmcode;
        public int sfver;
        public short mkmode;
        public short card;
        public int mcard;
        public int reserve2;
    }

    /// <summary>時計データ送信パラメータ</summary>
    public class RmSendClockParamClass
    {
        /// <summary>
        /// 時計データ
        /// </summary>
        public byte[] clock;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RmSendClockParamClass()
        {
            try
            {
                clock = new byte[256];
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// デストラクタ
        /// </summary>
        ~RmSendClockParamClass()
        {
            try
            {
                clock = null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// ClockをString型で設定
        /// </summary>
        public string Clock
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(clock); }
            set { clock = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }
    }

    /// <summary>カード受付可能送信パラメータ</summary>
    public class RmSendRecCardParamClass
    {
        public short card;
    }

    /// <summary>カードデータＡ要求パラメータ</summary>
    public class RmGetCardDataAParamClass
    {
        public byte[] cardid;
        public short rank;
        public int ownpoint;
        public int ownbalance;
        public byte[] issuedate;
        public int usecount;
        public byte[] usedate;
        public byte[] limit;
        public byte[] plimit;
        public short expired;
        public short ctype;
        public short pflag;
        public byte[] birthday;
        public short birthdayplag;
        public short luckplag;
        public short memlist;
        public byte[] namedata;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RmGetCardDataAParamClass()
        {
            try
            {
                cardid = new byte[256];
                issuedate = new byte[256];
                usedate = new byte[256];
                limit = new byte[256];
                plimit = new byte[256];
                birthday = new byte[256];
                namedata = new byte[256];
            }
            catch
            {
                throw;
            }
        }
        ~RmGetCardDataAParamClass()
        {
            try
            {
                cardid = null;
                issuedate = null;
                usedate = null;
                limit = null;
                plimit = null;
                birthday = null;
                namedata = null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// CardidをString型で設定
        /// </summary>
        public string Cardid
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(cardid); }
            set { cardid = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }

        /// <summary>
        /// IssuedateをString型で設定
        /// </summary>
        public string Issuedate
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(issuedate); }
            set { issuedate = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }

        /// <summary>
        /// UsedateをString型で設定
        /// </summary>
        public string Usedate
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(usedate); }
            set { usedate = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }

        /// <summary>
        /// UsedateをString型で設定
        /// </summary>
        public string Limit
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(limit); }
            set { limit = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }

        /// <summary>
        /// PlimitをString型で設定
        /// </summary>
        public string Plimit
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(plimit); }
            set { plimit = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }

        /// <summary>
        /// BirthdayをString型で設定
        /// </summary>
        public string Birthday
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(birthday); }
            set { birthday = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }

        /// <summary>
        /// BirthdayをString型で設定
        /// </summary>
        public string Namedata
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(namedata); }
            set { namedata = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }
    }

    /// <summary>交換データ送信パラメータ</summary>
    public class RmSendExchngeParamClass
    {
        public int chgpoint;
    }

    /// <summary>売上データＡ送信パラメータ</summary>
    public class RmSendSellAParamClass
    {
        public StSendSaleDataInf stsendsaledatainf;
        public short datacount;
        public int[] services;
        public int[] sales;
        public short[] paddflag;
        public short[] dmflag;

        public RmSendSellAParamClass()
        {
            try
            {
                stsendsaledatainf = new StSendSaleDataInf
                {
                    cardid = null,
                    rank = 0,
                    birthday = "0000",
                    pchargflag = 0,
                    mreceivedata = 0,
                    preceivedata = 0,
                    pgflag = 0,
                    pgdata = 0,
                    pspflag = 0,
                    pspdata = 0,
                    pfreedata = 0,
                    pretdata = 0,
                    manageflag = 0,
                    expiredflag = 0
                };

                services = new int[30];
                sales = new int[30];
                paddflag = new short[30];
                dmflag = new short[30];

                datacount = 1;

                for (int i = 0; i < datacount; i++)
                {
                    services[i] = 0;
                    sales[i] = 0;
                    paddflag[i] = 0;
                    dmflag[i] = 0;
                }
            }
            catch
            {
                throw;
            }
        }
        ~RmSendSellAParamClass()
        {
            try
            {
                services = null;
                sales = null;
                paddflag = null;
                dmflag = null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// servicesをString型で設定
        /// </summary>
        public void SetServices(params int[] data) { services = data; }

        /// <summary>
        /// salesをString型で設定
        /// </summary>
        public void SetSales(params int[] data) { sales = data; }

        /// <summary>
        /// salesをString型で設定
        /// </summary>
        public void SetPaddflag(params short[] data) { paddflag = data; }

        /// <summary>
        /// salesをString型で設定
        /// </summary>
        public void SetDmflag(params short[] data) { dmflag = data; }
    }

    /// <summary>演算データＡ要求パラメータ</summary>
    public class RmGetCalcAParamClass
    {
        public int point;
        public short chgflag;
        public int chgpoint;
        public int tmoney;
        public int tolpoint;
        public int ownbalance;
        public int usecout;
    }

    /// <summary>サービスメッセージ送信パラメータ</summary>
    public class RmSendMessageDataParamClass
    {
        public short memory;
        public short block;
        public byte[] msg1;
        public byte[] msg2;
        public byte[] msg3;

        public RmSendMessageDataParamClass()
        {
            try
            {
                msg1 = new byte[256];
                msg2 = new byte[256];
                msg3 = new byte[256];
            }
            catch
            {
                throw;
            }
        }
        ~RmSendMessageDataParamClass()
        {
            try
            {
                msg1 = null;
                msg2 = null;
                msg3 = null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// msg1をString型で設定
        /// </summary>
        public string Msg1
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(msg1); }
            set { msg1 = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }

        /// <summary>
        /// msg2をString型で設定
        /// </summary>
        public string Msg2
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(msg2); }
            set { msg2 = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }

        /// <summary>
        /// msg3をString型で設定
        /// </summary>
        public string Msg3
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(msg3); }
            set { msg3 = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }
    }

    /// <summary>名前データ送信パラメータ</summary>
    public class RmSendNameParamClass
    {
        /// <summary>
        /// 名前データ
        /// </summary>
        public byte[] namedata;

        public RmSendNameParamClass()
        {
            try
            {
                namedata = new byte[256];
            }
            catch
            {
                throw;
            }
        }
        ~RmSendNameParamClass()
        {
            try
            {
                namedata = null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 名前データをString型で設定
        /// </summary>
        public string Name
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(namedata); }
            set { namedata = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }
    }

    /// <summary>取引データ要求パラメータ</summary>
    public class RmGetICMParamClass
    {
        /// <summary>
        /// ファイル名
        /// </summary>
        public byte[] filename;

        public RmGetICMParamClass()
        {
            try
            {
                filename = new byte[256];
            }
            catch
            {
                throw;
            }
        }
        ~RmGetICMParamClass()
        {
            try
            {
                filename = null;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 名前データをString型で設定
        /// </summary>
        public string FileName
        {
            get { return Encoding.GetEncoding("shift_jis").GetString(filename); }
            set { filename = Encoding.GetEncoding("shift_jis").GetBytes(value); }
        }
    }

    /// <summary>モード要求パラメータ</summary>
    public class RmGetModeParamClass
    {
        public short mrate;
        public short gpoint;
        public short special;
        public short service;
        public short sprint;
        public short exchange;
        public short division;
        public short rank;
        public short birthday;
        public short ncard;
        public short tcard;
        public short reserve;
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct StSendSaleDataInf
    {
        /// <summary>会員コード</summary>
        [MarshalAs(UnmanagedType.LPStr, SizeConst = 255)]
        public string cardid;
        /// <summary>会員ランク</summary>
        public short rank;
        /// <summary>誕生日データ</summary>
        [MarshalAs(UnmanagedType.LPStr, SizeConst = 255)]
        public string birthday;
        /// <summary>プリカチャージフラグ</summary>
        public short pchargflag;
        /// <summary>プリカ入金額データ</summary>
        public int mreceivedata;
        /// <summary>プリカプレミアム金額データ</summary>
        public int preceivedata;
        /// <summary>商品ポイント付加フラグ</summary>
        public short pgflag;
        /// <summary>商品ポイントデータ</summary>
        public int pgdata;
        /// <summary>特別ポイント付加フラグ</summary>
        public short pspflag;
        /// <summary>特別ポイントデータ</summary>
        public int pspdata;
        /// <summary>任意ポイントデータ</summary>
        public int pfreedata;
        /// <summary>返品ポイントデータ</summary>
        public int pretdata;
        /// <summary>処理フラグ</summary>
        public short manageflag;
        /// <summary>期限更新フラグ</summary>
        public short expiredflag;
    }
}
