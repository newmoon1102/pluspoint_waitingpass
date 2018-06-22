using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace WaitingpassRestAPI.IO
{
    public class MemberMatchingListClass : BaseIOClass
    {
        // コンストラクタ
        public MemberMatchingListClass(HttpClient client) : base(client)
        {
            URL = Op.WPRestAPI.URL_BaseURL + Op.WPRestAPI.URL_MemberMatchingList;
            Req = new MemberMatchingListRequest();
            Res = new MemberMatchingListResponse();
        }

        // コピーコンストラクタ
        public MemberMatchingListClass(MemberMatchingListClass source) : base(source) { }

        // JSon変換
        protected override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<MemberMatchingListResponse>(json);
        }
    }


    /// <summary>
    /// 会員照合リストAPIリクエストデータ
    /// </summary>
    public class MemberMatchingListRequest : BaseRequest
    {
        /// <summary>
        /// 店舗認証コード
        /// </summary>
        public string shop_auth_code;
        /// <summary>
        /// リミット
        /// </summary>
        public int limit;
        /// <summary>
        /// オフセット
        /// </summary>
        public int offset;
        /// <summary>
        /// タイプ
        /// </summary>
        public int type;
    }


    /// <summary>
    /// 会員照合リストAPIレスポンスデータ
    /// </summary>
    public class MemberMatchingListResponse : BaseResponse
    {
        public List<MemberMatchingListResponse_InvalidCard> invalid_card;
        public List<MemberMatchingListResponse_InactiveCard> inactive_card;
        public List<MemberMatchingListResponse_MemberData> member_data;
    }


    /// <summary>
    /// 会員照合リストAPIレスポンスデータ・無効カード番号
    /// </summary>
    public class MemberMatchingListResponse_InvalidCard
    {
        /// <summary>
        /// ポイントカード番号
        /// </summary>
        public string card_no;
    }


    /// <summary>
    /// 会員照合リストAPIレスポンスデータ・非アクティブカード番号
    /// </summary>
    public class MemberMatchingListResponse_InactiveCard
    {
        /// <summary>
        /// ポイントカード番号
        /// </summary>
        public string card_no;
    }


    /// <summary>
    /// 会員照合リストAPIレスポンスデータ・会員情報
    /// </summary>
    public class MemberMatchingListResponse_MemberData
    {
        /// <summary>
        /// ポイントカード番号
        /// </summary>
        public string card_no;
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
        /// 売上
        /// </summary>
        public int sales;
        /// <summary>
        /// 備考１
        /// </summary>
        public string note_1;
        /// <summary>
        /// 備考２
        /// </summary>
        public string note_2;
        /// <summary>
        /// 備考３
        /// </summary>
        public string note_3;
        /// <summary>
        /// 来店回数
        /// </summary>
        public int frequency_of_visits;
    }
}
