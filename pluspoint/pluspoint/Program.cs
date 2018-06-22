using CardMachineCom;
using System;
using System.Windows.Forms;
using System.Linq;
using pluspoint.Database.LinqSQL;
using Logger;
using pluspoint.Module.CardMachine;

namespace pluspoint
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LoggerClass Log = LoggerClass.Instance;
            CardMachineComThreadClass CardMachineThread = null;

            try
            {
                //--------------------------------------------------
                // カード機通信スレッド起動
                //--------------------------------------------------
                CardMachineThread = CardMachineComThreadClass.Instance;
                CardMachineThread.OrderThreadStart();

                //--------------------------------------------------
                // メインフォームスレッド起動
                //--------------------------------------------------
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BaseForm());

                //--------------------------------------------------
                // カード機通信スレッド終了
                //--------------------------------------------------
                CardMachineThread.OrderThreadEnd();
            }
            catch(Exception ex)
            {
                // 例外エラーのログ出力
                Log.Error(ex);

                // 処理途中でエラーが起きた場合、スレッドを終了させる。
                if (CardMachineThread != null)
                {
                    CardMachineThread.OrderThreadEnd();
                }
                else
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
        }


        //--------------------------------------------------
        // WaitingpassRestAPIサンプル
        //--------------------------------------------------
        //MemberGetRequest Req = new MemberGetRequest
        //{
        //    shop_auth_code = SARes.shop_auth_code,
        //    member_id = 179
        //};
        //MemberGetResponse test2 = WPRestAPI.PointCard_MemberGet(Req);
        //RestAPIClass WPRestAPI = new RestAPIClass();
        //ShopAuthResponse SARes = WPRestAPI.PointCard_ShopAuth(new ShopAuthRequest { login_id = "0002001", password = "Oa0528965511" });
    }
}
