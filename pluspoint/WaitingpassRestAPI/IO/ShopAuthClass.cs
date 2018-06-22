using Newtonsoft.Json;
using System.Net.Http;

namespace WaitingpassRestAPI.IO
{
    public class ShopAuthClass : BaseIOClass
    {
        // コンストラクタ
        public ShopAuthClass(HttpClient client) : base(client)
        {
            URL = Op.WPRestAPI.URL_BaseURL + Op.WPRestAPI.URL_ShopAuth;
            Req = new ShopAuthRequest();
            Res = new ShopAuthResponse();
        }

        // コピーコンストラクタ
        public ShopAuthClass(ShopAuthClass source) : base(source) { }

        // JSon変換
        protected override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<ShopAuthResponse>(json);
        }
    }


    /// <summary>
    /// 店舗管理認証リクエストデータ
    /// </summary>
    public class ShopAuthRequest : BaseRequest
    {
        /// <summary>
        /// ログインID
        /// </summary>
        public string login_id;
        /// <summary>
        /// パスワード
        /// </summary>
        public string password;
    }
    /// <summary>
    /// 店舗管理認証レスポンスデータ
    /// </summary>
    public class ShopAuthResponse : BaseResponse
    {
        /// <summary>
        /// テナントID
        /// </summary>
        public int tenant_id;
        /// <summary>
        /// 店舗ID
        /// </summary>
        public string shop_id;
        /// <summary>
        /// 店舗認証コード
        /// </summary>
        public string shop_auth_code;
        /// <summary>
        /// 店舗名
        /// </summary>
        public string shop_name;
    }
}
