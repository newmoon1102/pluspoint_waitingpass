using Logger;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Option;
using System.Net;
using System.Net.Http;
using WaitingpassRestAPI.IO;

namespace WaitingpassRestAPI
{
    public class RestAPIClass
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        /// <summary>
        /// オプション用
        /// </summary>
        OptionClass Op = OptionClass.Instance;

        /// <summary>
        /// Httpクライアント
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public RestAPIClass()
        {
            // Httpクライアントハンドル
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseCookies = false
            };
            // 自己証明書を使用しているサーバにHttpClientで接続する場合に必要な設定
            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
            {
                return true;
            };
            //Httpクライアント生成
            httpClient = new HttpClient(handler);
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~RestAPIClass()
        {
            httpClient.Dispose();
            httpClient = null;
        }

        //--------------------------------------------------
        // 通信用
        //--------------------------------------------------
        public ShopAuthResponse PointCard_ShopAuth(ShopAuthRequest req)
        {
            ShopAuthResponse ret = null;

            try
            {
                ShopAuthClass item = new ShopAuthClass(httpClient) { Req = req };
                item.Communication();
                ret = (ShopAuthResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }
        
        public MemberAuthResponse PointCard_MemberAuth(MemberAuthRequest req)
        {
            MemberAuthResponse ret = null;

            try
            {
                MemberAuthClass item = new MemberAuthClass(httpClient) { Req = req };
                item.Communication();
                ret = (MemberAuthResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }
        
        public MemberGetResponse PointCard_MemberGet(MemberGetRequest req)
        {
            MemberGetResponse ret = null;

            try
            {
                MemberGetClass item = new MemberGetClass(httpClient) { Req = req };
                item.Communication();
                ret = (MemberGetResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }
        
        public MemberSetResponse PointCard_MemberSet(MemberSetRequest req)
        {
            MemberSetResponse ret = null;

            try
            {
                MemberSetClass item = new MemberSetClass(httpClient) { Req = req };
                item.Communication();
                ret = (MemberSetResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }

        public MemberSearchResponse PointCard_MemberSearch(MemberSearchRequest req)
        {
            MemberSearchResponse ret = null;

            try
            {
                MemberSearchClass item = new MemberSearchClass(httpClient) { Req = req };
                item.Communication();
                ret = (MemberSearchResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }

        public MemberMergeResponse PointCard_MemberMerge(MemberMergeRequest req)
        {
            MemberMergeResponse ret = null;

            try
            {
                MemberMergeClass item = new MemberMergeClass(httpClient) { Req = req };
                item.Communication();
                ret = (MemberMergeResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }
        
        public HistoryUploadResponse PointCard_HistoryUpload(HistoryUploadRequest req)
        {
            HistoryUploadResponse ret = null;

            try
            {
                HistoryUploadClass item = new HistoryUploadClass(httpClient) { Req = req };
                item.Communication();
                ret = (HistoryUploadResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }

        public MasterZipResponse PointCard_MasterZip(MasterZipRequest req)
        {
            MasterZipResponse ret = null;

            try
            {
                MasterZipClass item = new MasterZipClass(httpClient) { Req = req };
                item.Communication();
                ret = (MasterZipResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }

        // 追加依頼分
        //public MemberAuthResponseClass PointCard_MemberAuth(MemberAuthRequestClass req) { }
        //public MemberGetResponseClass PointCard_MemberGet(MemberGetRequestClass req) { }
        //public MemberSetResponseClass PointCard_MemberSet(MemberSetRequestClass req) { }
        //public HistoryUploadResponseClass PointCard_HistoryUpload(HistoryUploadRequestClass req) { }
        public HistoryUploadAppliResponse PointCard_HistoryUploadAppli(HistoryUploadAppliRequest req)
        {
            HistoryUploadAppliResponse ret = null;

            try
            {
                HistoryUploadAppliClass item = new HistoryUploadAppliClass(httpClient) { Req = req };
                item.Communication();
                ret = (HistoryUploadAppliResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }

        public MemberMatchingListResponse PointCard_MemberMatchingList(MemberMatchingListRequest req)
        {
            MemberMatchingListResponse ret = null;

            try
            {
                MemberMatchingListClass item = new MemberMatchingListClass(httpClient) { Req = req };
                item.Communication();
                ret = (MemberMatchingListResponse)item.Res;
            }
            catch
            {
                throw;
            }

            return ret;
        }
    }
}
