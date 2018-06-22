using Newtonsoft.Json;
using System.Net.Http;

namespace WaitingpassRestAPI.IO
{
    public class MasterZipClass : BaseIOClass
    {
        // コンストラクタ
        public MasterZipClass(HttpClient client) : base(client)
        {
            URL = Op.WPRestAPI.URL_MasterZip;
            Req = new MasterZipRequest();
            Res = new MasterZipResponse();
        }

        // コピーコンストラクタ
        public MasterZipClass(MasterZipClass source) : base(source) { }

        // JSon変換
        protected override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<MasterZipResponse>(json);
        }
    }


    /// <summary>
    /// 店舗管理認証リクエストデータ
    /// </summary>
    public class MasterZipRequest : BaseRequest
    {
        /// <summary>
        /// テナントID
        /// </summary>
        public string tenant_id;
        /// <summary>
        /// 郵便番号
        /// </summary>
        public string zip_code;
    }
    /// <summary>
    /// 店舗管理認証レスポンスデータ
    /// </summary>
    public class MasterZipResponse : BaseResponse
    {
        /// <summary>
        /// 郵便番号種類
        /// </summary>
        public string type;
        /// <summary>
        /// 都道府県コード
        /// </summary>
        public string pref_code;
        /// <summary>
        /// 県名読み
        /// </summary>
        public string pref_name_y;
        /// <summary>
        /// 市区名読み
        /// </summary>
        public string area_name_y;
        /// <summary>
        /// 町村名読み
        /// </summary>
        public string city_name_y;
        /// <summary>
        /// 町村名読み２
        /// </summary>
        public string city_name2_y;
        /// <summary>
        /// 県名
        /// </summary>
        public string pref_name;
        /// <summary>
        /// 市名
        /// </summary>
        public string area_name;
        /// <summary>
        /// 町村名
        /// </summary>
        public string city_name;
        /// <summary>
        /// 町村名２
        /// </summary>
        public string city_name2;
        /// <summary>
        /// 市区コード
        /// </summary>
        public string area_code;
        /// <summary>
        /// 不明
        /// </summary>
        public string c1;
        /// <summary>
        /// 不明
        /// </summary>
        public string c2;
        /// <summary>
        /// 不明
        /// </summary>
        public string c3;
        /// <summary>
        /// 不明
        /// </summary>
        public string c4;
        /// <summary>
        /// 不明
        /// </summary>
        public string c5;
        /// <summary>
        /// 不明
        /// </summary>
        public string c6;
    }
}
