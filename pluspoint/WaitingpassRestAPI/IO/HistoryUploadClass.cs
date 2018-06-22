using Newtonsoft.Json;
using System.Net.Http;

namespace WaitingpassRestAPI.IO
{
    public class HistoryUploadClass : BaseIOClass
    {
        // コンストラクタ
        public HistoryUploadClass(HttpClient client) : base(client)
        {
            URL = Op.WPRestAPI.URL_BaseURL + Op.WPRestAPI.URL_HistoryUpload;
            Req = new HistoryUploadRequest();
            Res = new HistoryUploadResponse();
        }

        // コピーコンストラクタ
        public HistoryUploadClass(HistoryUploadClass source) : base(source) { }

        // JSon変換
        protected override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<HistoryUploadResponse>(json);
        }
    }


    /// <summary>
    /// ポイント同期リクエストデータ
    /// </summary>
    public class HistoryUploadRequest : BaseRequest
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
        /// 売上額
        /// </summary>
        public int sales;
        /// <summary>
        /// 売上ポイント
        /// </summary>
        public int bonus_point;
        /// <summary>
        /// 新規ポイント
        /// </summary>
        public int get_point;
        /// <summary>
        /// 交換ポイント
        /// </summary>
        public int used_point;
        /// <summary>
        /// 累計ポイント
        /// </summary>
        public int card_point;
        /// <summary>
        /// 入金額
        /// </summary>
        public int charge_prepaid;
        /// <summary>
        /// プリカ残高
        /// </summary>
        public int card_prepaid;
        /// <summary>
        /// プリカ処理区分
        /// </summary>
        public string preca_process_type;
    }


    /// <summary>
    /// ポイント同期レスポンスデータ
    /// </summary>
    public class HistoryUploadResponse : BaseResponse { }
}
