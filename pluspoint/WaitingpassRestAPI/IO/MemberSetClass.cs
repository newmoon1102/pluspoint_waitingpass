using Newtonsoft.Json;
using System.Net.Http;

namespace WaitingpassRestAPI.IO
{
    public class MemberSetClass : BaseIOClass
    {
        // コンストラクタ
        public MemberSetClass(HttpClient client) : base(client)
        {
            URL = Op.WPRestAPI.URL_BaseURL + Op.WPRestAPI.URL_MemberSet;
            Req = new MemberSetRequest();
            Res = new MemberSetResponse();
        }

        // コピーコンストラクタ
        public MemberSetClass(MemberSetClass source) : base(source) { }

        // JSon変換
        protected override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<MemberSetResponse>(json);
        }
    }


    /// <summary>
    /// 会員情報登録・更新リクエストデータ
    /// </summary>
    public class MemberSetRequest : BaseRequest
    {
        /// <summary>
        /// 店舗認証コード
        /// </summary>
        public string shop_auth_code;
        /// <summary>
        /// 会員ID
        /// </summary>
        public int member_id;
        /// <summary>
        /// ポイントカード番号
        /// </summary>
        public string card_no;
        /// <summary>
        /// QRコード値
        /// </summary>
        public string qr_code;
        /// <summary>
        /// 氏名・姓
        /// </summary>
        public string last_name;
        /// <summary>
        /// 氏名・名
        /// </summary>
        public string first_name;
        /// <summary>
        /// 氏名（ふりがな）姓
        /// </summary>
        public string last_name_y;
        /// <summary>
        /// 氏名（ふりがな）名
        /// </summary>
        public string first_name_y;
        /// <summary>
        /// 郵便番号　上位3桁
        /// </summary>
        public string zip_1;
        /// <summary>
        /// 郵便番号　下位4桁
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
        /// 携帯電話番号　市外局番
        /// </summary>
        public string mobile_number_1;
        /// <summary>
        /// 携帯電話番号　市内局番
        /// </summary>
        public string mobile_number_2;
        /// <summary>
        /// 携帯電話番号　加入者番号
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
        /// 性別
        /// </summary>
        public int sex;
        /// <summary>
        /// 生年月日
        /// </summary>
        public string birth;
        /// <summary>
        /// お呼び出し名
        /// </summary>
        public string call_name;
        /// <summary>
        /// メルマガ未発送チェック
        /// </summary>
        public int mailmaga_disable_flag;
        /// <summary>
        /// DM未発送チェック
        /// </summary>
        public int dm_disable_flag;
    }


    /// <summary>
    /// 会員情報登録・更新レスポンスデータ
    /// </summary>
    public class MemberSetResponse : BaseResponse
    {
        /// <summary>
        /// 会員ID
        /// </summary>
        public int member_id;
        /// <summary>
        /// メールアドレス
        /// </summary>
        public string mail_address;
    }
}
