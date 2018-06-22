using Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Option
{
    public sealed class OptionClass
    {
        /// <summary>
        /// ログ出力用
        /// </summary>
        LoggerClass Log = LoggerClass.Instance;

        //--------------------------------------------------
        // シングルトン設定
        //--------------------------------------------------
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        private static OptionClass instance = new OptionClass();
        /// <summary>
        /// シングルトンインスタンスを返す
        /// </summary>
        public static OptionClass Instance { get { return instance; } }

        //--------------------------------------------------
        // 各種設定
        //--------------------------------------------------
        public CardMachineControlUserOptionClass PointCardUser = null;
        public CardMachineControlOptionClass PointCard = null;
        public WPRestAPIOptionClass WPRestAPI = null;

        //--------------------------------------------------
        // コンストラクタ・デストラクタ
        //--------------------------------------------------
        private OptionClass()
        {
            try
            {
                //--------------------------------------------------
                // ポイントカード制御アプリユーザー設定
                //--------------------------------------------------
                // XML読込
                PointCardUser = XMLRead<CardMachineControlUserOptionClass>("Option_CardMachineControlUser.xml");
                // 失敗時、デフォ値を読む
                if (PointCardUser == null) PointCardUser = new CardMachineControlUserOptionClass();

                //--------------------------------------------------
                // ポイントカード制御アプリ設定
                //--------------------------------------------------
                // XML読込
                PointCard = XMLRead<CardMachineControlOptionClass>("Option_CardMachineControl.xml");
                // 失敗時、デフォ値を読む
                if (PointCard == null) PointCard = new CardMachineControlOptionClass();
                
                //--------------------------------------------------
                // Waitingpass REST API設定
                //--------------------------------------------------
                // XML読込
                WPRestAPI = XMLRead<WPRestAPIOptionClass>("Option_WPRestAPI.xml");
                // 失敗時、デフォ値を読む
                if (WPRestAPI == null) WPRestAPI = new WPRestAPIOptionClass();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        ~OptionClass()
        {
            try
            {
                // ポイントカード制御アプリユーザー設定
                XMLWrite<CardMachineControlUserOptionClass>("Option_CardMachineControlUser.xml", PointCardUser);
                
                // ポイントカード制御アプリ設定
                XMLWrite<CardMachineControlOptionClass>("Option_CardMachineControl.xml", PointCard);
                
                // Waitingpass REST API設定
                XMLWrite<WPRestAPIOptionClass>("Option_WPRestAPI.xml", WPRestAPI);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //--------------------------------------------------
        // 機能
        //--------------------------------------------------
        private Type XMLRead<Type>(string FilePath)
        {
            Type ret = default(Type);
            FileStream inputStream = null;
            XmlSerializer serializer = null;

            try
            {
                if (File.Exists(FilePath))
                {
                    // ファイルストリーム準備
                    inputStream = new FileStream(FilePath, FileMode.Open);
                    // シリアライザーのインスタンス準備
                    serializer = new XmlSerializer(typeof(Type));
                    // 逆シリアライズしてオブジェクトに格納
                    ret = (Type)serializer.Deserialize(inputStream);
                }

                // ファイルストリームを閉じる
                if (inputStream != null)
                {
                    inputStream.Close();
                    inputStream = null;
                }
            }
            catch
            {
                throw;
            }

            return ret;
        }
        private void XMLWrite<Type>(string FilePath, object data)
        {
            try
            {
                //名前空間出力抑制
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);

                // ファイルストリーム準備
                FileStream outputStream = new FileStream(FilePath, FileMode.Create);
                // 書き込みストリームの作成
                StreamWriter writer = new StreamWriter(outputStream, System.Text.Encoding.UTF8);

                // シリアライザーのインスタンス準備
                XmlSerializer serializer = new XmlSerializer(typeof(Type));
                // シリアライズ
                serializer.Serialize(writer, data, ns);
                
                // ファイル書込
                writer.Flush();
                // ファイルストリームを閉じる
                writer.Close();
            }
            catch
            {
                throw;
            }
        }
    }

    [System.Xml.Serialization.XmlRoot("root")]
    public class CardMachineControlUserOptionClass
    {
        [System.Xml.Serialization.XmlElement("CheckPhoneNumber")]
        public bool CheckPhoneNumber;

        [System.Xml.Serialization.XmlElement("CheckBirthDay")]
        public bool CheckBirthDay;

        [System.Xml.Serialization.XmlElement("CheckAddress")]
        public bool CheckAddress;
    }

    [System.Xml.Serialization.XmlRoot("root")]
    public class CardMachineControlOptionClass
    {
        [System.Xml.Serialization.XmlElement("DB_UserName")]
        public string DB_UserName;

        [System.Xml.Serialization.XmlElement("DB_Password")]
        public string DB_Password;

        [System.Xml.Serialization.XmlElement("DB_Host")]
        public string DB_Host;

        [System.Xml.Serialization.XmlElement("PrinterCorpCode")]
        public string PrinterCorpCode;

        [System.Xml.Serialization.XmlElement("PrinterShopCode")]
        public string PrinterShopCode;

        [System.Xml.Serialization.XmlElement("BackupPath")]
        public string BackupPath;

        [System.Xml.Serialization.XmlElement("BackupFileName")]
        public string BackupFileName;

        [System.Xml.Serialization.XmlElement("QRCodeFixedString")]
        public string QRCodeFixedString;

        [System.Xml.Serialization.XmlElement("MoenyTypeList")]
        public List<CardMachineMoneyType> MoenyTypeList { get; set; }

        [System.Xml.Serialization.XmlElement("MoenyTypeRateList")]
        public List<CardMachinePointRate> MoenyTypeRateList { get; set; }

        [System.Xml.Serialization.XmlElement("DepositBonusList")]
        public List<CardMachineDepositBonus> DepositBonusList { get; set; }
    }

    [System.Xml.Serialization.XmlRoot("root")]
    public class WPRestAPIOptionClass
    {
        [System.Xml.Serialization.XmlElement("URL_BaseURL")]
        public string URL_BaseURL;

        [System.Xml.Serialization.XmlElement("URL_MemberSet")]
        public string URL_MemberSet;

        [System.Xml.Serialization.XmlElement("URL_MemberGet")]
        public string URL_MemberGet;

        [System.Xml.Serialization.XmlElement("URL_MemberSearch")]
        public string URL_MemberSearch;

        [System.Xml.Serialization.XmlElement("URL_MasterZip")]
        public string URL_MasterZip;

        [System.Xml.Serialization.XmlElement("URL_MemberMerge")]
        public string URL_MemberMerge;

        [System.Xml.Serialization.XmlElement("URL_HistoryUpload")]
        public string URL_HistoryUpload;

        [System.Xml.Serialization.XmlElement("URL_ShopAuth")]
        public string URL_ShopAuth;

        [System.Xml.Serialization.XmlElement("URL_MemberAuth")]
        public string URL_MemberAuth;

        [System.Xml.Serialization.XmlElement("URL_HistoryUploadAppli")]
        public string URL_HistoryUploadAppli;

        [System.Xml.Serialization.XmlElement("URL_MemberMatchingList")]
        public string URL_MemberMatchingList;
    }

    public class CardMachineMoneyType
    {
        /// <summary>
        /// 金種名称
        /// </summary>
        [System.Xml.Serialization.XmlElement("MoneyTypeName")]
        public string MoneyTypeName;

        /// <summary>
        /// 金種使用フラグ
        /// </summary>
        [System.Xml.Serialization.XmlElement("MoneyTypeUseFlag")]
        public bool MoneyTypeUseFlag;
    }

    public class CardMachinePointRate
    {
        /// <summary>
        /// 金種名称
        /// </summary>
        [System.Xml.Serialization.XmlElement("MoneyTypeName")]
        public string MoneyTypeName;

        /// <summary>
        /// ポイント加算
        /// </summary>
        [System.Xml.Serialization.XmlElement("Add")]
        public int Add;

        /// <summary>
        /// ポイント換算率
        /// </summary>
        [System.Xml.Serialization.XmlElement("Rate")]
        public float Rate;

        /// <summary>
        /// 以下
        /// </summary>
        [System.Xml.Serialization.XmlElement("Less")]
        public int Less;

        /// <summary>
        /// 以上
        /// </summary>
        [System.Xml.Serialization.XmlElement("More")]
        public int More;
    }

    public class CardMachineDepositBonus
    {
        /// <summary>
        /// ポイント加算
        /// </summary>
        [System.Xml.Serialization.XmlElement("Add")]
        public int Add;

        /// <summary>
        /// ポイント換算率
        /// </summary>
        [System.Xml.Serialization.XmlElement("Rate")]
        public float Rate;

        /// <summary>
        /// 以下
        /// </summary>
        [System.Xml.Serialization.XmlElement("Less")]
        public int Less;

        /// <summary>
        /// 以上
        /// </summary>
        [System.Xml.Serialization.XmlElement("More")]
        public int More;
    }
}
