using Newtonsoft.Json;
using System.Net.Http;

namespace WaitingpassRestAPI.IO
{
    public class MemberMergeClass : BaseIOClass
    {
        // コンストラクタ
        public MemberMergeClass(HttpClient client) : base(client)
        {
            URL = Op.WPRestAPI.URL_BaseURL + Op.WPRestAPI.URL_MemberMerge;
            Req = new MemberMergeRequest();
            Res = new MemberMergeResponse();
        }

        // コピーコンストラクタ
        public MemberMergeClass(MemberMergeClass source) : base(source) { }

        // JSon変換
        protected override object Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<MemberMergeResponse>(json);
        }
    }

    /// <summary>
    /// 会員紐付け・ポイント履歴更新リクエストデータ
    /// </summary>
    public class MemberMergeRequest : BaseRequest
    {
        /// <summary>
        /// 店舗認証コード
        /// </summary>
        public string shop_auth_code;
        /// <summary>
        /// 紐付け元会員ID
        /// </summary>
        public int old_member_id;
        /// <summary>
        /// 紐付け先会員ID
        /// </summary>
        public int new_member_id;
        /// <summary>
        /// 強制実行フラグ
        /// </summary>
        public int force_flag;
        /// <summary>
        /// 紐付け元会員削除フラグ
        /// </summary>
        public int om_delete_flag;
    }

    /// <summary>
    /// 会員紐付け・ポイント履歴更新レスポンスデータ
    /// </summary>
    public class MemberMergeResponse : BaseResponse { }

}
