using Newtonsoft.Json;
using System.Net.Http;

namespace WaitingpassRestAPI.IO
{
    public class MemberAuthClass : BaseIOClass
    {
        // コンストラクタ
        public MemberAuthClass(HttpClient client) : base(client)
        {
            URL = Op.WPRestAPI.URL_BaseURL + Op.WPRestAPI.URL_MemberAuth;
            Req = new MemberAuthRequest();
            Res = new MemberAuthResponse();
        }

        // コピーコンストラクタ
        public MemberAuthClass(MemberAuthClass source) : base(source) { }

        // JSon変換
        protected override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<MemberAuthResponse>(json);
        }
    }


    /// <summary>
    /// ポイントカード認証リクエストデータ
    /// </summary>
    public class MemberAuthRequest : BaseRequest
    {
        /// <summary>
        /// 店舗認証コード
        /// </summary>
        public string shop_auth_code;
        /// <summary>
        /// QRコード値
        /// </summary>
        public string qr_code;
        /// <summary>
        /// ログインID
        /// </summary>
        public string login_id;
        /// <summary>
        /// パスワード
        /// </summary>
        public string password;
        /// <summary>
        /// 会員データ返却フラグ
        /// </summary>
        public int with_data_flag;
    }


    /// <summary>
    /// ポイントカード認証レスポンスデータ
    /// </summary>
    public class MemberAuthResponse : BaseResponse
    {
        /// <summary>
        /// 会員ID
        /// </summary>
        public string member_id;
        /// <summary>
        /// ポイントカード番号
        /// </summary>
        public string card_no;
        /// <summary>
        /// QRコード値
        /// </summary>
        public string card_qr;
        /// <summary>
        /// ポイント累計
        /// </summary>
        public string point;
        /// <summary>
        /// 氏名・姓
        /// </summary>
        public string last_name;
        /// <summary>
        /// 氏名・名
        /// </summary>
        public string first_name;
        /// <summary>
        /// 氏名（ふりがな）・姓
        /// </summary>
        public string last_name_y;
        /// <summary>
        /// 氏名（ふりがな）・名
        /// </summary>
        public string first_name_y;
        /// <summary>
        /// 郵便番号上位3桁
        /// </summary>
        public string zip_1;
        /// <summary>
        /// 郵便番号下位4桁
        /// </summary>
        public string zip_2;
        /// <summary>
        /// 都道府県名
        /// </summary>
        public string pref_nmae;
        /// <summary>
        /// 市区町村名
        /// </summary>
        public string area_name;
        /// <summary>
        /// 町域名
        /// </summary>
        public string city_name;
        /// <summary>
        /// 番地
        /// </summary>
        public string block;
        /// <summary>
        /// 建物～号室
        /// </summary>
        public string building;
        /// <summary>
        /// 自宅電話番号　市外局番
        /// </summary>
        public string tel_number_1;
        /// <summary>
        /// 自宅電話番号　市内局番
        /// </summary>
        public string tel_number_2;
        /// <summary>
        /// 自宅電話番号　加入者番号
        /// </summary>
        public string tel_number_3;
        /// <summary>
        /// 携帯電話　市外局番
        /// </summary>
        public string mobile_number_1;
        /// <summary>
        /// 携帯電話　市内局番
        /// </summary>
        public string mobile_number_2;
        /// <summary>
        /// 携帯電話　加入者番号
        /// </summary>
        public string mobile_number_3;
        /// <summary>
        /// 予備電話番号　市外局番
        /// </summary>
        public string other_tel_number_1;
        /// <summary>
        /// 予備電話番号　市内局番
        /// </summary>
        public string other_tel_number_2;
        /// <summary>
        /// 予備電話番号　加入者番号
        /// </summary>
        public string other_tel_number_3;
        /// <summary>
        /// メールアドレス
        /// </summary>
        public string mail_address;
        /// <summary>
        /// パスワード
        /// </summary>
        public string password;
        /// <summary>
        /// お呼び出し名
        /// </summary>
        public string call_name;
        /// <summary>
        /// メルマガ未発送チェック
        /// </summary>
        public string mailmaga_disable_flag;
        /// <summary>
        /// DM未発送チェック
        /// </summary>
        public string dm_disable_flag;
        /// <summary>
        /// 性別
        /// </summary>
        public string sex;
        /// <summary>
        /// 生年月日
        /// </summary>
        public string birth;
        /// <summary>
        /// 会員種別
        /// </summary>
        public string member_type;
    }
}
