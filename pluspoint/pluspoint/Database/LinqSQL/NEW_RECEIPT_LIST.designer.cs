﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace pluspoint.Database.LinqSQL
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="pluspointDB")]
	public partial class NEW_RECEIPT_LISTDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 拡張メソッドの定義
    partial void OnCreated();
    partial void InsertNEW_RECEIPT_LIST(NEW_RECEIPT_LIST instance);
    partial void UpdateNEW_RECEIPT_LIST(NEW_RECEIPT_LIST instance);
    partial void DeleteNEW_RECEIPT_LIST(NEW_RECEIPT_LIST instance);
    #endregion
		
		public NEW_RECEIPT_LISTDataContext() : 
				base(global::pluspoint.Properties.Settings.Default.pluspointDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public NEW_RECEIPT_LISTDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NEW_RECEIPT_LISTDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NEW_RECEIPT_LISTDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public NEW_RECEIPT_LISTDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<NEW_RECEIPT_LIST> NEW_RECEIPT_LIST
		{
			get
			{
				return this.GetTable<NEW_RECEIPT_LIST>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.NEW_RECEIPT_LIST")]
	public partial class NEW_RECEIPT_LIST : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _RECEIPT_ID;
		
		private string _MEMBER_ID;
		
		private System.Nullable<System.DateTime> _RECEIPT_DATE;
		
		private string _CARD_NO;
		
		private string _QR_CODE;
		
		private string _CARD_POINT;
		
		private string _LAST_NAME;
		
		private string _FIRT_NAME;
		
		private string _LAST_NAME_Y;
		
		private string _FIRT_NAME_Y;
		
		private string _ZIP_1;
		
		private string _ZIP_2;
		
		private string _PREF_NAME;
		
		private string _AREA_NAME;
		
		private string _CITY_NAME;
		
		private string _BLOCK;
		
		private string _BUILDING;
		
		private string _TEL_NUMBER_1;
		
		private string _TEL_NUMBER_2;
		
		private string _TEL_NUMBER_3;
		
		private string _MOBILE_NUMBER_1;
		
		private string _MOBILE_NUMBER_2;
		
		private string _MOBILE_NUMBER_3;
		
		private string _OTHER_NUMBER_1;
		
		private string _OTHER_NUMBER_2;
		
		private string _OTHER_NUMBER_3;
		
		private string _MAIL_ADDRESS;
		
		private string _PASSWORD;
		
		private string _CALL_NAME;
		
		private System.Nullable<int> _MAILMAGA_DISABLE_FLG;
		
		private System.Nullable<int> _DM_DISABLE_FLG;
		
		private string _SEX;
		
		private string _BIRTH;
		
		private string _MEMBER_TYPE;
		
		private string _CARD_ISSUE_DATE;
		
		private string _CARD_FLG;
		
    #region 拡張メソッドの定義
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnRECEIPT_IDChanging(int value);
    partial void OnRECEIPT_IDChanged();
    partial void OnMEMBER_IDChanging(string value);
    partial void OnMEMBER_IDChanged();
    partial void OnRECEIPT_DATEChanging(System.Nullable<System.DateTime> value);
    partial void OnRECEIPT_DATEChanged();
    partial void OnCARD_NOChanging(string value);
    partial void OnCARD_NOChanged();
    partial void OnQR_CODEChanging(string value);
    partial void OnQR_CODEChanged();
    partial void OnCARD_POINTChanging(string value);
    partial void OnCARD_POINTChanged();
    partial void OnLAST_NAMEChanging(string value);
    partial void OnLAST_NAMEChanged();
    partial void OnFIRT_NAMEChanging(string value);
    partial void OnFIRT_NAMEChanged();
    partial void OnLAST_NAME_YChanging(string value);
    partial void OnLAST_NAME_YChanged();
    partial void OnFIRT_NAME_YChanging(string value);
    partial void OnFIRT_NAME_YChanged();
    partial void OnZIP_1Changing(string value);
    partial void OnZIP_1Changed();
    partial void OnZIP_2Changing(string value);
    partial void OnZIP_2Changed();
    partial void OnPREF_NAMEChanging(string value);
    partial void OnPREF_NAMEChanged();
    partial void OnAREA_NAMEChanging(string value);
    partial void OnAREA_NAMEChanged();
    partial void OnCITY_NAMEChanging(string value);
    partial void OnCITY_NAMEChanged();
    partial void OnBLOCKChanging(string value);
    partial void OnBLOCKChanged();
    partial void OnBUILDINGChanging(string value);
    partial void OnBUILDINGChanged();
    partial void OnTEL_NUMBER_1Changing(string value);
    partial void OnTEL_NUMBER_1Changed();
    partial void OnTEL_NUMBER_2Changing(string value);
    partial void OnTEL_NUMBER_2Changed();
    partial void OnTEL_NUMBER_3Changing(string value);
    partial void OnTEL_NUMBER_3Changed();
    partial void OnMOBILE_NUMBER_1Changing(string value);
    partial void OnMOBILE_NUMBER_1Changed();
    partial void OnMOBILE_NUMBER_2Changing(string value);
    partial void OnMOBILE_NUMBER_2Changed();
    partial void OnMOBILE_NUMBER_3Changing(string value);
    partial void OnMOBILE_NUMBER_3Changed();
    partial void OnOTHER_NUMBER_1Changing(string value);
    partial void OnOTHER_NUMBER_1Changed();
    partial void OnOTHER_NUMBER_2Changing(string value);
    partial void OnOTHER_NUMBER_2Changed();
    partial void OnOTHER_NUMBER_3Changing(string value);
    partial void OnOTHER_NUMBER_3Changed();
    partial void OnMAIL_ADDRESSChanging(string value);
    partial void OnMAIL_ADDRESSChanged();
    partial void OnPASSWORDChanging(string value);
    partial void OnPASSWORDChanged();
    partial void OnCALL_NAMEChanging(string value);
    partial void OnCALL_NAMEChanged();
    partial void OnMAILMAGA_DISABLE_FLGChanging(System.Nullable<int> value);
    partial void OnMAILMAGA_DISABLE_FLGChanged();
    partial void OnDM_DISABLE_FLGChanging(System.Nullable<int> value);
    partial void OnDM_DISABLE_FLGChanged();
    partial void OnSEXChanging(string value);
    partial void OnSEXChanged();
    partial void OnBIRTHChanging(string value);
    partial void OnBIRTHChanged();
    partial void OnMEMBER_TYPEChanging(string value);
    partial void OnMEMBER_TYPEChanged();
    partial void OnCARD_ISSUE_DATEChanging(string value);
    partial void OnCARD_ISSUE_DATEChanged();
    partial void OnCARD_FLGChanging(string value);
    partial void OnCARD_FLGChanged();
    #endregion
		
		public NEW_RECEIPT_LIST()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RECEIPT_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int RECEIPT_ID
		{
			get
			{
				return this._RECEIPT_ID;
			}
			set
			{
				if ((this._RECEIPT_ID != value))
				{
					this.OnRECEIPT_IDChanging(value);
					this.SendPropertyChanging();
					this._RECEIPT_ID = value;
					this.SendPropertyChanged("RECEIPT_ID");
					this.OnRECEIPT_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MEMBER_ID", DbType="NVarChar(50)")]
		public string MEMBER_ID
		{
			get
			{
				return this._MEMBER_ID;
			}
			set
			{
				if ((this._MEMBER_ID != value))
				{
					this.OnMEMBER_IDChanging(value);
					this.SendPropertyChanging();
					this._MEMBER_ID = value;
					this.SendPropertyChanged("MEMBER_ID");
					this.OnMEMBER_IDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RECEIPT_DATE", DbType="DateTime2")]
		public System.Nullable<System.DateTime> RECEIPT_DATE
		{
			get
			{
				return this._RECEIPT_DATE;
			}
			set
			{
				if ((this._RECEIPT_DATE != value))
				{
					this.OnRECEIPT_DATEChanging(value);
					this.SendPropertyChanging();
					this._RECEIPT_DATE = value;
					this.SendPropertyChanged("RECEIPT_DATE");
					this.OnRECEIPT_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CARD_NO", DbType="NVarChar(50)")]
		public string CARD_NO
		{
			get
			{
				return this._CARD_NO;
			}
			set
			{
				if ((this._CARD_NO != value))
				{
					this.OnCARD_NOChanging(value);
					this.SendPropertyChanging();
					this._CARD_NO = value;
					this.SendPropertyChanged("CARD_NO");
					this.OnCARD_NOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QR_CODE", DbType="NVarChar(50)")]
		public string QR_CODE
		{
			get
			{
				return this._QR_CODE;
			}
			set
			{
				if ((this._QR_CODE != value))
				{
					this.OnQR_CODEChanging(value);
					this.SendPropertyChanging();
					this._QR_CODE = value;
					this.SendPropertyChanged("QR_CODE");
					this.OnQR_CODEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CARD_POINT", DbType="NVarChar(50)")]
		public string CARD_POINT
		{
			get
			{
				return this._CARD_POINT;
			}
			set
			{
				if ((this._CARD_POINT != value))
				{
					this.OnCARD_POINTChanging(value);
					this.SendPropertyChanging();
					this._CARD_POINT = value;
					this.SendPropertyChanged("CARD_POINT");
					this.OnCARD_POINTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LAST_NAME", DbType="NVarChar(50)")]
		public string LAST_NAME
		{
			get
			{
				return this._LAST_NAME;
			}
			set
			{
				if ((this._LAST_NAME != value))
				{
					this.OnLAST_NAMEChanging(value);
					this.SendPropertyChanging();
					this._LAST_NAME = value;
					this.SendPropertyChanged("LAST_NAME");
					this.OnLAST_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FIRT_NAME", DbType="NVarChar(50)")]
		public string FIRT_NAME
		{
			get
			{
				return this._FIRT_NAME;
			}
			set
			{
				if ((this._FIRT_NAME != value))
				{
					this.OnFIRT_NAMEChanging(value);
					this.SendPropertyChanging();
					this._FIRT_NAME = value;
					this.SendPropertyChanged("FIRT_NAME");
					this.OnFIRT_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LAST_NAME_Y", DbType="NVarChar(50)")]
		public string LAST_NAME_Y
		{
			get
			{
				return this._LAST_NAME_Y;
			}
			set
			{
				if ((this._LAST_NAME_Y != value))
				{
					this.OnLAST_NAME_YChanging(value);
					this.SendPropertyChanging();
					this._LAST_NAME_Y = value;
					this.SendPropertyChanged("LAST_NAME_Y");
					this.OnLAST_NAME_YChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FIRT_NAME_Y", DbType="NVarChar(50)")]
		public string FIRT_NAME_Y
		{
			get
			{
				return this._FIRT_NAME_Y;
			}
			set
			{
				if ((this._FIRT_NAME_Y != value))
				{
					this.OnFIRT_NAME_YChanging(value);
					this.SendPropertyChanging();
					this._FIRT_NAME_Y = value;
					this.SendPropertyChanged("FIRT_NAME_Y");
					this.OnFIRT_NAME_YChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZIP_1", DbType="NVarChar(3)")]
		public string ZIP_1
		{
			get
			{
				return this._ZIP_1;
			}
			set
			{
				if ((this._ZIP_1 != value))
				{
					this.OnZIP_1Changing(value);
					this.SendPropertyChanging();
					this._ZIP_1 = value;
					this.SendPropertyChanged("ZIP_1");
					this.OnZIP_1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZIP_2", DbType="NVarChar(4)")]
		public string ZIP_2
		{
			get
			{
				return this._ZIP_2;
			}
			set
			{
				if ((this._ZIP_2 != value))
				{
					this.OnZIP_2Changing(value);
					this.SendPropertyChanging();
					this._ZIP_2 = value;
					this.SendPropertyChanged("ZIP_2");
					this.OnZIP_2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PREF_NAME", DbType="NVarChar(50)")]
		public string PREF_NAME
		{
			get
			{
				return this._PREF_NAME;
			}
			set
			{
				if ((this._PREF_NAME != value))
				{
					this.OnPREF_NAMEChanging(value);
					this.SendPropertyChanging();
					this._PREF_NAME = value;
					this.SendPropertyChanged("PREF_NAME");
					this.OnPREF_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AREA_NAME", DbType="NVarChar(100)")]
		public string AREA_NAME
		{
			get
			{
				return this._AREA_NAME;
			}
			set
			{
				if ((this._AREA_NAME != value))
				{
					this.OnAREA_NAMEChanging(value);
					this.SendPropertyChanging();
					this._AREA_NAME = value;
					this.SendPropertyChanged("AREA_NAME");
					this.OnAREA_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CITY_NAME", DbType="NVarChar(100)")]
		public string CITY_NAME
		{
			get
			{
				return this._CITY_NAME;
			}
			set
			{
				if ((this._CITY_NAME != value))
				{
					this.OnCITY_NAMEChanging(value);
					this.SendPropertyChanging();
					this._CITY_NAME = value;
					this.SendPropertyChanged("CITY_NAME");
					this.OnCITY_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BLOCK", DbType="NVarChar(100)")]
		public string BLOCK
		{
			get
			{
				return this._BLOCK;
			}
			set
			{
				if ((this._BLOCK != value))
				{
					this.OnBLOCKChanging(value);
					this.SendPropertyChanging();
					this._BLOCK = value;
					this.SendPropertyChanged("BLOCK");
					this.OnBLOCKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BUILDING", DbType="NVarChar(100)")]
		public string BUILDING
		{
			get
			{
				return this._BUILDING;
			}
			set
			{
				if ((this._BUILDING != value))
				{
					this.OnBUILDINGChanging(value);
					this.SendPropertyChanging();
					this._BUILDING = value;
					this.SendPropertyChanged("BUILDING");
					this.OnBUILDINGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEL_NUMBER_1", DbType="NVarChar(5)")]
		public string TEL_NUMBER_1
		{
			get
			{
				return this._TEL_NUMBER_1;
			}
			set
			{
				if ((this._TEL_NUMBER_1 != value))
				{
					this.OnTEL_NUMBER_1Changing(value);
					this.SendPropertyChanging();
					this._TEL_NUMBER_1 = value;
					this.SendPropertyChanged("TEL_NUMBER_1");
					this.OnTEL_NUMBER_1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEL_NUMBER_2", DbType="NVarChar(5)")]
		public string TEL_NUMBER_2
		{
			get
			{
				return this._TEL_NUMBER_2;
			}
			set
			{
				if ((this._TEL_NUMBER_2 != value))
				{
					this.OnTEL_NUMBER_2Changing(value);
					this.SendPropertyChanging();
					this._TEL_NUMBER_2 = value;
					this.SendPropertyChanged("TEL_NUMBER_2");
					this.OnTEL_NUMBER_2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEL_NUMBER_3", DbType="NVarChar(5)")]
		public string TEL_NUMBER_3
		{
			get
			{
				return this._TEL_NUMBER_3;
			}
			set
			{
				if ((this._TEL_NUMBER_3 != value))
				{
					this.OnTEL_NUMBER_3Changing(value);
					this.SendPropertyChanging();
					this._TEL_NUMBER_3 = value;
					this.SendPropertyChanged("TEL_NUMBER_3");
					this.OnTEL_NUMBER_3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MOBILE_NUMBER_1", DbType="NVarChar(5)")]
		public string MOBILE_NUMBER_1
		{
			get
			{
				return this._MOBILE_NUMBER_1;
			}
			set
			{
				if ((this._MOBILE_NUMBER_1 != value))
				{
					this.OnMOBILE_NUMBER_1Changing(value);
					this.SendPropertyChanging();
					this._MOBILE_NUMBER_1 = value;
					this.SendPropertyChanged("MOBILE_NUMBER_1");
					this.OnMOBILE_NUMBER_1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MOBILE_NUMBER_2", DbType="NVarChar(5)")]
		public string MOBILE_NUMBER_2
		{
			get
			{
				return this._MOBILE_NUMBER_2;
			}
			set
			{
				if ((this._MOBILE_NUMBER_2 != value))
				{
					this.OnMOBILE_NUMBER_2Changing(value);
					this.SendPropertyChanging();
					this._MOBILE_NUMBER_2 = value;
					this.SendPropertyChanged("MOBILE_NUMBER_2");
					this.OnMOBILE_NUMBER_2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MOBILE_NUMBER_3", DbType="NVarChar(5)")]
		public string MOBILE_NUMBER_3
		{
			get
			{
				return this._MOBILE_NUMBER_3;
			}
			set
			{
				if ((this._MOBILE_NUMBER_3 != value))
				{
					this.OnMOBILE_NUMBER_3Changing(value);
					this.SendPropertyChanging();
					this._MOBILE_NUMBER_3 = value;
					this.SendPropertyChanged("MOBILE_NUMBER_3");
					this.OnMOBILE_NUMBER_3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OTHER_NUMBER_1", DbType="NVarChar(5)")]
		public string OTHER_NUMBER_1
		{
			get
			{
				return this._OTHER_NUMBER_1;
			}
			set
			{
				if ((this._OTHER_NUMBER_1 != value))
				{
					this.OnOTHER_NUMBER_1Changing(value);
					this.SendPropertyChanging();
					this._OTHER_NUMBER_1 = value;
					this.SendPropertyChanged("OTHER_NUMBER_1");
					this.OnOTHER_NUMBER_1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OTHER_NUMBER_2", DbType="NVarChar(5)")]
		public string OTHER_NUMBER_2
		{
			get
			{
				return this._OTHER_NUMBER_2;
			}
			set
			{
				if ((this._OTHER_NUMBER_2 != value))
				{
					this.OnOTHER_NUMBER_2Changing(value);
					this.SendPropertyChanging();
					this._OTHER_NUMBER_2 = value;
					this.SendPropertyChanged("OTHER_NUMBER_2");
					this.OnOTHER_NUMBER_2Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OTHER_NUMBER_3", DbType="NVarChar(5)")]
		public string OTHER_NUMBER_3
		{
			get
			{
				return this._OTHER_NUMBER_3;
			}
			set
			{
				if ((this._OTHER_NUMBER_3 != value))
				{
					this.OnOTHER_NUMBER_3Changing(value);
					this.SendPropertyChanging();
					this._OTHER_NUMBER_3 = value;
					this.SendPropertyChanged("OTHER_NUMBER_3");
					this.OnOTHER_NUMBER_3Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAIL_ADDRESS", DbType="NVarChar(256)")]
		public string MAIL_ADDRESS
		{
			get
			{
				return this._MAIL_ADDRESS;
			}
			set
			{
				if ((this._MAIL_ADDRESS != value))
				{
					this.OnMAIL_ADDRESSChanging(value);
					this.SendPropertyChanging();
					this._MAIL_ADDRESS = value;
					this.SendPropertyChanged("MAIL_ADDRESS");
					this.OnMAIL_ADDRESSChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSWORD", DbType="NVarChar(20)")]
		public string PASSWORD
		{
			get
			{
				return this._PASSWORD;
			}
			set
			{
				if ((this._PASSWORD != value))
				{
					this.OnPASSWORDChanging(value);
					this.SendPropertyChanging();
					this._PASSWORD = value;
					this.SendPropertyChanged("PASSWORD");
					this.OnPASSWORDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CALL_NAME", DbType="NVarChar(20)")]
		public string CALL_NAME
		{
			get
			{
				return this._CALL_NAME;
			}
			set
			{
				if ((this._CALL_NAME != value))
				{
					this.OnCALL_NAMEChanging(value);
					this.SendPropertyChanging();
					this._CALL_NAME = value;
					this.SendPropertyChanged("CALL_NAME");
					this.OnCALL_NAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MAILMAGA_DISABLE_FLG", DbType="Int")]
		public System.Nullable<int> MAILMAGA_DISABLE_FLG
		{
			get
			{
				return this._MAILMAGA_DISABLE_FLG;
			}
			set
			{
				if ((this._MAILMAGA_DISABLE_FLG != value))
				{
					this.OnMAILMAGA_DISABLE_FLGChanging(value);
					this.SendPropertyChanging();
					this._MAILMAGA_DISABLE_FLG = value;
					this.SendPropertyChanged("MAILMAGA_DISABLE_FLG");
					this.OnMAILMAGA_DISABLE_FLGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DM_DISABLE_FLG", DbType="Int")]
		public System.Nullable<int> DM_DISABLE_FLG
		{
			get
			{
				return this._DM_DISABLE_FLG;
			}
			set
			{
				if ((this._DM_DISABLE_FLG != value))
				{
					this.OnDM_DISABLE_FLGChanging(value);
					this.SendPropertyChanging();
					this._DM_DISABLE_FLG = value;
					this.SendPropertyChanged("DM_DISABLE_FLG");
					this.OnDM_DISABLE_FLGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SEX", DbType="NVarChar(10)")]
		public string SEX
		{
			get
			{
				return this._SEX;
			}
			set
			{
				if ((this._SEX != value))
				{
					this.OnSEXChanging(value);
					this.SendPropertyChanging();
					this._SEX = value;
					this.SendPropertyChanged("SEX");
					this.OnSEXChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BIRTH", DbType="NVarChar(20)")]
		public string BIRTH
		{
			get
			{
				return this._BIRTH;
			}
			set
			{
				if ((this._BIRTH != value))
				{
					this.OnBIRTHChanging(value);
					this.SendPropertyChanging();
					this._BIRTH = value;
					this.SendPropertyChanged("BIRTH");
					this.OnBIRTHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MEMBER_TYPE", DbType="NVarChar(10)")]
		public string MEMBER_TYPE
		{
			get
			{
				return this._MEMBER_TYPE;
			}
			set
			{
				if ((this._MEMBER_TYPE != value))
				{
					this.OnMEMBER_TYPEChanging(value);
					this.SendPropertyChanging();
					this._MEMBER_TYPE = value;
					this.SendPropertyChanged("MEMBER_TYPE");
					this.OnMEMBER_TYPEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CARD_ISSUE_DATE", DbType="NVarChar(50)")]
		public string CARD_ISSUE_DATE
		{
			get
			{
				return this._CARD_ISSUE_DATE;
			}
			set
			{
				if ((this._CARD_ISSUE_DATE != value))
				{
					this.OnCARD_ISSUE_DATEChanging(value);
					this.SendPropertyChanging();
					this._CARD_ISSUE_DATE = value;
					this.SendPropertyChanged("CARD_ISSUE_DATE");
					this.OnCARD_ISSUE_DATEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CARD_FLG", DbType="NVarChar(10)")]
		public string CARD_FLG
		{
			get
			{
				return this._CARD_FLG;
			}
			set
			{
				if ((this._CARD_FLG != value))
				{
					this.OnCARD_FLGChanging(value);
					this.SendPropertyChanging();
					this._CARD_FLG = value;
					this.SendPropertyChanged("CARD_FLG");
					this.OnCARD_FLGChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
