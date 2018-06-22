using pluspoint.Database.LinqSQL;
using System.Linq;
using WaitingpassRestAPI.IO;

namespace pluspoint.Module.DBModule
{
    class NEW_RECEIPT_LIST_Module : DBModuleClass
    {
        /// <summary>
        /// LINQ to SQLのテーブルオブジェクト
        /// </summary>
        NEW_RECEIPT_LISTDataContext DB;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public NEW_RECEIPT_LIST_Module()
        {
            DB = new NEW_RECEIPT_LISTDataContext(base.constr);
        }

        /// <summary>
        /// デストラクタ
        /// </summary>
        ~NEW_RECEIPT_LIST_Module()
        {
            DB.Dispose();
        }

        /// <summary>
        /// 指定受付番号のレコードを削除する
        /// </summary>
        /// <param name="RECEIPTID">受付番号</param>
        public void Delete(int RECEIPTID)
        {
            try
            {
                // 削除レコード抽出
                var query = from n in DB.NEW_RECEIPT_LIST
                            where n.RECEIPT_ID == RECEIPTID
                            select n;

                // 削除処理（削除保留状態）
                foreach(var q in query)
                {
                    DB.NEW_RECEIPT_LIST.DeleteOnSubmit(q);
                }

                // データベースへ変更内容を送信
                DB.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 申込データの入力
        /// </summary>
        /// <param name="InData">登録データ</param>
        public void Insert(MemberSetRequest InData)
        {
            try
            {
                // Insertオーダーの作成
                NEW_RECEIPT_LIST ord = new NEW_RECEIPT_LIST
                {
                    LAST_NAME = InData.last_name,
                    FIRT_NAME = InData.first_name,
                    LAST_NAME_Y = InData.last_name_y,
                    FIRT_NAME_Y = InData.first_name_y,
                    ZIP_1 = InData.zip_1,
                    ZIP_2 = InData.zip_2,
                    PREF_NAME = InData.pref_nmae,
                    AREA_NAME = InData.area_name,
                    CITY_NAME = InData.city_name,
                    BLOCK = InData.block,
                    BUILDING = InData.building,
                    TEL_NUMBER_1 = InData.tel_number_1,
                    TEL_NUMBER_2 = InData.tel_number_2,
                    TEL_NUMBER_3 = InData.tel_number_3,
                    MOBILE_NUMBER_1 = InData.mobile_number_1,
                    MOBILE_NUMBER_2 = InData.mobile_number_2,
                    MOBILE_NUMBER_3 = InData.mobile_number_3,
                    OTHER_NUMBER_1 = InData.other_tel_number_1,
                    OTHER_NUMBER_2 = InData.other_tel_number_2,
                    OTHER_NUMBER_3 = InData.other_tel_number_3,
                    MAIL_ADDRESS = InData.mail_address,
                    PASSWORD = InData.password,
                    CALL_NAME = InData.call_name,
                    MAILMAGA_DISABLE_FLG = InData.mailmaga_disable_flag,
                    DM_DISABLE_FLG = InData.dm_disable_flag,
                    SEX = (InData.sex == 2 ? "女" : "男"),
                    BIRTH = InData.birth
                };

                // Insert要求
                DB.NEW_RECEIPT_LIST.InsertOnSubmit(ord);

                // コミット
                DB.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}