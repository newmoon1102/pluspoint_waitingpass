using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Option;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace WaitingpassRestAPI.IO
{
    public abstract class BaseIOClass
    {
        /// <summary>
        /// HttpClient保持用
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// リクエスト
        /// </summary>
        public BaseRequest Req = null;

        /// <summary>
        /// レスポンス
        /// </summary>
        public BaseResponse Res = null;

        /// <summary>
        /// 通信用URL
        /// </summary>
        protected string URL;

        /// <summary>
        /// オプション読込
        /// </summary>
        protected OptionClass Op = OptionClass.Instance;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="client">通信用</param>
        protected BaseIOClass(HttpClient client)
        {
            httpClient = client;
        }

        /// <summary>
        /// コピーコンストラクタ
        /// </summary>
        /// <param name="source">コピー元</param>
        protected BaseIOClass(BaseIOClass source)
        {
            this.httpClient = source.httpClient;
            this.Res = source.Res;
            this.URL = source.URL;
        }

        /// <summary>
        /// 通信
        /// </summary>
        /// <param name="Request">送信データ</param>
        public async void Communication()
        {
            try
            {
                // Http通信処理
                var response = httpClient.PostAsync(URL, Req.ToHttpContent()).Result;

                // json文字列取得
                string json = await response.Content.ReadAsStringAsync();

                // JObjectに変換
                var jobj = JObject.Parse(json);

                // 応答コード取得
                int code = int.Parse(jobj.SelectToken("code").ToString());

                // コードによる分岐
                if (code == 200)
                {
                    // 成功時
                    Type t = this.Res.GetType();
                    //Res = JsonConvert.DeserializeObject<BaseResponse>(jobj.ToString());
                    Res = (BaseResponse)Deserialize(jobj.ToString());
                }
                else
                {
                    // 失敗時
                    foreach (var j in jobj)
                    {
                        if (j.Key == "code") Res.code = int.Parse(j.Value.ToString());
                        if (j.Key == "note") Res.note = j.Value.ToString();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        protected abstract object Deserialize(string json);
    }


    /// <summary>
    /// リクエストベースClass
    /// </summary>
    public class BaseRequest
    {
        /// <summary>
        /// JSon形式で送信させるための処理
        /// </summary>
        /// <returns></returns>
        public HttpContent ToHttpContent()
        {
            HttpContent ret = null;

            try
            {
                // 自身のClassタイプを取得
                Type ClassType = this.GetType();

                // Classのメンバ情報を取得
                MemberInfo[] members = ClassType.GetMembers(BindingFlags.Public | BindingFlags.NonPublic |
                    BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);

                // リストの生成
                List<KeyValuePair<string, string>> List = new List<KeyValuePair<string, string>>();

                // ループでメンバのリストを動的に作成する
                foreach (MemberInfo m in members)
                {
                    FieldInfo finfo = ClassType.GetField(m.Name);
                    if (m.MemberType == MemberTypes.Field)
                    {
                        if (finfo.GetValue(this) != null)
                        {
                            List.Add(new KeyValuePair<string, string>(m.Name, finfo.GetValue(this).ToString()));
                        }
                    }
                }

                // 作成したリストを設定
                ret = new FormUrlEncodedContent(List.ToArray());
            }
            catch
            {
                throw;
            }

            return ret;
        }
    }
    /// <summary>
    /// レスポンスベースClass
    /// </summary>
    public class BaseResponse
    {
        /// <summary>
        /// ステータスコード
        /// </summary>
        public int code;
        /// <summary>
        /// 備考
        /// </summary>
        public string note;
    }
}
