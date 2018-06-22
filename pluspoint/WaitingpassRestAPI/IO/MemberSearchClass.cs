using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace WaitingpassRestAPI.IO
{
    public class MemberSearchClass : BaseIOClass
    {
        // コンストラクタ
        public MemberSearchClass(HttpClient client) : base(client)
        {
            URL = Op.WPRestAPI.URL_BaseURL + Op.WPRestAPI.URL_MemberSearch;
            Req = new MemberSearchRequest();
            Res = new MemberSearchResponse();
        }

        // コピーコンストラクタ
        public MemberSearchClass(MemberSearchClass source) : base(source) { }

        // JSon変換
        protected override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<MemberSearchResponse>(json);
        }
    }

    /// <summary>
    /// 会員情報検索リクエストデータ
    /// </summary>
    public class MemberSearchRequest : BaseRequest
    {
        /// <summary>
        /// 店舗認証コード
        /// </summary>
        public string shop_auth_code;
        /// <summary>
        /// メールアドレス
        /// </summary>
        public string mail_address;
        /// <summary>
        /// ポイントカード番号
        /// </summary>
        public string card_no;
        /// <summary>
        /// QRコード値
        /// </summary>
        public string qr_code;
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
        /// 生年月日
        /// </summary>
        public string birth;
        /// <summary>
        /// リミット
        /// </summary>
        public string limit;
        /// <summary>
        /// オフセット
        /// </summary>
        public string offset;
    }
    /// <summary>
    /// 会員情報検索レスポンスデータ
    /// </summary>
    public class MemberSearchResponse : BaseResponse
    {
        /// <summary>
        /// 会員情報リスト
        /// </summary>
        public List<MemberSearchItem> data;
    }
    /// <summary>
    /// 会員情報検索レスポンスデータ・会員情報
    /// </summary>
    public class MemberSearchItem
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
