using Newtonsoft.Json;
using System.Net.Http;

namespace WaitingpassRestAPI.IO
{
    public class HistoryUploadAppliClass : BaseIOClass
    {
        // コンストラクタ
        public HistoryUploadAppliClass(HttpClient client) : base(client)
        {
            URL = Op.WPRestAPI.URL_BaseURL + Op.WPRestAPI.URL_HistoryUploadAppli;
            Req = new HistoryUploadAppliRequest();
            Res = new HistoryUploadAppliResponse();
        }

        // コピーコンストラクタ
        public HistoryUploadAppliClass(HistoryUploadAppliClass source) : base(source) { }

        // JSon変換
        protected override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<HistoryUploadAppliResponse>(json);
        }
    }


    /// <summary>
    /// ポイント同期(アプリ履歴)リクエストデータ
    /// </summary>
    public class HistoryUploadAppliRequest : BaseRequest
    {
        /// <summary>
        /// 店舗認証コード
        /// </summary>
        public string shop_auth_code;
        /// <summary>
        /// ポイントカード番号
        /// </summary>
        public string card_no;
        /// <summary>
        /// 利用日時
        /// </summary>
        public string use_datetime;
        /// <summary>
        /// 利用店舗番号
        /// </summary>
        public string card_shop_no;
        /// <summary>
        /// カード氏名
        /// </summary>
        public string user_name;
        /// <summary>
        /// 操作区分
        /// </summary>
        public int operation_type;
        /// <summary>
        /// 入金額/売上金額
        /// </summary>
        public int total_amount;
        /// <summary>
        /// プリペイド
        /// </summary>
        public int prepaid;
        /// <summary>
        /// ポイント累計
        /// </summary>
        public int point;
        /// <summary>
        /// 金券１
        /// </summary>
        public int other1;
        /// <summary>
        /// 金券２
        /// </summary>
        public int other2;
        /// <summary>
        /// 金券３
        /// </summary>
        public int other3;
        /// <summary>
        /// 金券４（クレジット）
        /// </summary>
        public int other4_credit;
        /// <summary>
        /// 現金
        /// </summary>
        public int cash;
        /// <summary>
        /// 今回ポイント
        /// </summary>
        public int added_point;
        /// <summary>
        /// 累計ポイント
        /// </summary>
        public int card_point;
        /// <summary>
        /// プリカ残高
        /// </summary>
        public int card_prepaid;
        /// <summary>
        /// カード機履歴取得日時
        /// </summary>
        public string pointcard_history_get_datetime;
        /// <summary>
        /// カード機履歴行番号
        /// </summary>
        public int pointcard_history_line_number;
        /// <summary>
        /// 予備
        /// </summary>
        public string reserve;
    }


    /// <summary>
    /// ポイント同期(アプリ履歴)レスポンスデータ
    /// </summary>
    public class HistoryUploadAppliResponse : BaseResponse { }
}
