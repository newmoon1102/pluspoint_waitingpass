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
	public partial class T_PCARDDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region 拡張メソッドの定義
    partial void OnCreated();
    #endregion
		
		public T_PCARDDataContext() : 
				base(global::pluspoint.Properties.Settings.Default.pluspointDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public T_PCARDDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public T_PCARDDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public T_PCARDDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public T_PCARDDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<T_PCARD> T_PCARD
		{
			get
			{
				return this.GetTable<T_PCARD>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.T_PCARD")]
	public partial class T_PCARD
	{
		
		private string _START_FUGO;
		
		private string _TAMMATSU_CD;
		
		private string _RECORD_SU;
		
		private string _TAMMATSU_VER;
		
		private string _RIYO_DATE;
		
		private string _KAIIN_NO;
		
		private string _SERVICE_CD;
		
		private string _URIAGE_GAKU;
		
		private string _URIAGE_POINT;
		
		private string _BAI_POINT;
		
		private string _KAISU_POINT;
		
		private string _TOKU_POINT;
		
		private string _SHIN_POINT;
		
		private string _RUIK_POINT;
		
		private string _KOKAN_POINT;
		
		private string _RIYO_KAISU;
		
		private string _ZENKAI_RIYO_DATE;
		
		private string _YUKO_KIGEN;
		
		private string _SEKI_URIAGE_GAKU;
		
		private string _UCHIZEI_KBN;
		
		private string _TEISEI_KBN;
		
		private string _TORIHIKI_KBN;
		
		private string _KOSHIN_KBN;
		
		private string _RANK_KBN;
		
		private string _KAIIN_SHOGO_KBN;
		
		private string _NAMAE_SHOGO_KBN;
		
		private string _RECORD_NO;
		
		private string _TANTOSHA_CD;
		
		private string _NYUKIN_GAKU;
		
		private string _FUKA_PRE_GAKU;
		
		private string _ZANGAKU;
		
		private string _PRECA_FLG;
		
		private string _BARCODE_DATA;
		
		private string _HIKITSUGI_DATA;
		
		private string _KESSAI_PRE_GAKU;
		
		private string _YOYAKU_DATE1;
		
		private string _YOYAKU_DATE2;
		
		private string _NAMAE_DATA;
		
		private string _NAMAE_FLG;
		
		private string _NAMAE_KANA_DATA;
		
		private string _PRECA_KIGEN;
		
		private string _YOBI1;
		
		private string _YOBI2;
		
		private System.Nullable<int> _UPLOAD_FLG;
		
		private string _UPLOAD_DATE;
		
		private string _DBS_STATUS;
		
		private string _DBS_CREATE_USER;
		
		private string _DBS_CREATE_DATE;
		
		private string _DBS_UPDATE_USER;
		
		private string _DBS_UPDATE_DATE;
		
		public T_PCARD()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_START_FUGO", DbType="NVarChar(50)")]
		public string START_FUGO
		{
			get
			{
				return this._START_FUGO;
			}
			set
			{
				if ((this._START_FUGO != value))
				{
					this._START_FUGO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TAMMATSU_CD", DbType="NVarChar(50)")]
		public string TAMMATSU_CD
		{
			get
			{
				return this._TAMMATSU_CD;
			}
			set
			{
				if ((this._TAMMATSU_CD != value))
				{
					this._TAMMATSU_CD = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RECORD_SU", DbType="NVarChar(50)")]
		public string RECORD_SU
		{
			get
			{
				return this._RECORD_SU;
			}
			set
			{
				if ((this._RECORD_SU != value))
				{
					this._RECORD_SU = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TAMMATSU_VER", DbType="NVarChar(50)")]
		public string TAMMATSU_VER
		{
			get
			{
				return this._TAMMATSU_VER;
			}
			set
			{
				if ((this._TAMMATSU_VER != value))
				{
					this._TAMMATSU_VER = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RIYO_DATE", DbType="NVarChar(50)")]
		public string RIYO_DATE
		{
			get
			{
				return this._RIYO_DATE;
			}
			set
			{
				if ((this._RIYO_DATE != value))
				{
					this._RIYO_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KAIIN_NO", DbType="NVarChar(50)")]
		public string KAIIN_NO
		{
			get
			{
				return this._KAIIN_NO;
			}
			set
			{
				if ((this._KAIIN_NO != value))
				{
					this._KAIIN_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SERVICE_CD", DbType="NVarChar(50)")]
		public string SERVICE_CD
		{
			get
			{
				return this._SERVICE_CD;
			}
			set
			{
				if ((this._SERVICE_CD != value))
				{
					this._SERVICE_CD = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_URIAGE_GAKU", DbType="NVarChar(50)")]
		public string URIAGE_GAKU
		{
			get
			{
				return this._URIAGE_GAKU;
			}
			set
			{
				if ((this._URIAGE_GAKU != value))
				{
					this._URIAGE_GAKU = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_URIAGE_POINT", DbType="NVarChar(50)")]
		public string URIAGE_POINT
		{
			get
			{
				return this._URIAGE_POINT;
			}
			set
			{
				if ((this._URIAGE_POINT != value))
				{
					this._URIAGE_POINT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BAI_POINT", DbType="NVarChar(50)")]
		public string BAI_POINT
		{
			get
			{
				return this._BAI_POINT;
			}
			set
			{
				if ((this._BAI_POINT != value))
				{
					this._BAI_POINT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KAISU_POINT", DbType="NVarChar(50)")]
		public string KAISU_POINT
		{
			get
			{
				return this._KAISU_POINT;
			}
			set
			{
				if ((this._KAISU_POINT != value))
				{
					this._KAISU_POINT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TOKU_POINT", DbType="NVarChar(50)")]
		public string TOKU_POINT
		{
			get
			{
				return this._TOKU_POINT;
			}
			set
			{
				if ((this._TOKU_POINT != value))
				{
					this._TOKU_POINT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SHIN_POINT", DbType="NVarChar(50)")]
		public string SHIN_POINT
		{
			get
			{
				return this._SHIN_POINT;
			}
			set
			{
				if ((this._SHIN_POINT != value))
				{
					this._SHIN_POINT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RUIK_POINT", DbType="NVarChar(50)")]
		public string RUIK_POINT
		{
			get
			{
				return this._RUIK_POINT;
			}
			set
			{
				if ((this._RUIK_POINT != value))
				{
					this._RUIK_POINT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KOKAN_POINT", DbType="NVarChar(50)")]
		public string KOKAN_POINT
		{
			get
			{
				return this._KOKAN_POINT;
			}
			set
			{
				if ((this._KOKAN_POINT != value))
				{
					this._KOKAN_POINT = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RIYO_KAISU", DbType="NVarChar(50)")]
		public string RIYO_KAISU
		{
			get
			{
				return this._RIYO_KAISU;
			}
			set
			{
				if ((this._RIYO_KAISU != value))
				{
					this._RIYO_KAISU = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZENKAI_RIYO_DATE", DbType="NVarChar(50)")]
		public string ZENKAI_RIYO_DATE
		{
			get
			{
				return this._ZENKAI_RIYO_DATE;
			}
			set
			{
				if ((this._ZENKAI_RIYO_DATE != value))
				{
					this._ZENKAI_RIYO_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YUKO_KIGEN", DbType="NVarChar(50)")]
		public string YUKO_KIGEN
		{
			get
			{
				return this._YUKO_KIGEN;
			}
			set
			{
				if ((this._YUKO_KIGEN != value))
				{
					this._YUKO_KIGEN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SEKI_URIAGE_GAKU", DbType="NVarChar(50)")]
		public string SEKI_URIAGE_GAKU
		{
			get
			{
				return this._SEKI_URIAGE_GAKU;
			}
			set
			{
				if ((this._SEKI_URIAGE_GAKU != value))
				{
					this._SEKI_URIAGE_GAKU = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UCHIZEI_KBN", DbType="NVarChar(50)")]
		public string UCHIZEI_KBN
		{
			get
			{
				return this._UCHIZEI_KBN;
			}
			set
			{
				if ((this._UCHIZEI_KBN != value))
				{
					this._UCHIZEI_KBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEISEI_KBN", DbType="NVarChar(50)")]
		public string TEISEI_KBN
		{
			get
			{
				return this._TEISEI_KBN;
			}
			set
			{
				if ((this._TEISEI_KBN != value))
				{
					this._TEISEI_KBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TORIHIKI_KBN", DbType="NVarChar(50)")]
		public string TORIHIKI_KBN
		{
			get
			{
				return this._TORIHIKI_KBN;
			}
			set
			{
				if ((this._TORIHIKI_KBN != value))
				{
					this._TORIHIKI_KBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KOSHIN_KBN", DbType="NVarChar(50)")]
		public string KOSHIN_KBN
		{
			get
			{
				return this._KOSHIN_KBN;
			}
			set
			{
				if ((this._KOSHIN_KBN != value))
				{
					this._KOSHIN_KBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RANK_KBN", DbType="NVarChar(50)")]
		public string RANK_KBN
		{
			get
			{
				return this._RANK_KBN;
			}
			set
			{
				if ((this._RANK_KBN != value))
				{
					this._RANK_KBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KAIIN_SHOGO_KBN", DbType="NVarChar(50)")]
		public string KAIIN_SHOGO_KBN
		{
			get
			{
				return this._KAIIN_SHOGO_KBN;
			}
			set
			{
				if ((this._KAIIN_SHOGO_KBN != value))
				{
					this._KAIIN_SHOGO_KBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAMAE_SHOGO_KBN", DbType="NVarChar(50)")]
		public string NAMAE_SHOGO_KBN
		{
			get
			{
				return this._NAMAE_SHOGO_KBN;
			}
			set
			{
				if ((this._NAMAE_SHOGO_KBN != value))
				{
					this._NAMAE_SHOGO_KBN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RECORD_NO", DbType="NVarChar(50)")]
		public string RECORD_NO
		{
			get
			{
				return this._RECORD_NO;
			}
			set
			{
				if ((this._RECORD_NO != value))
				{
					this._RECORD_NO = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TANTOSHA_CD", DbType="NVarChar(50)")]
		public string TANTOSHA_CD
		{
			get
			{
				return this._TANTOSHA_CD;
			}
			set
			{
				if ((this._TANTOSHA_CD != value))
				{
					this._TANTOSHA_CD = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NYUKIN_GAKU", DbType="NVarChar(50)")]
		public string NYUKIN_GAKU
		{
			get
			{
				return this._NYUKIN_GAKU;
			}
			set
			{
				if ((this._NYUKIN_GAKU != value))
				{
					this._NYUKIN_GAKU = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FUKA_PRE_GAKU", DbType="NVarChar(50)")]
		public string FUKA_PRE_GAKU
		{
			get
			{
				return this._FUKA_PRE_GAKU;
			}
			set
			{
				if ((this._FUKA_PRE_GAKU != value))
				{
					this._FUKA_PRE_GAKU = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ZANGAKU", DbType="NVarChar(50)")]
		public string ZANGAKU
		{
			get
			{
				return this._ZANGAKU;
			}
			set
			{
				if ((this._ZANGAKU != value))
				{
					this._ZANGAKU = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PRECA_FLG", DbType="NVarChar(50)")]
		public string PRECA_FLG
		{
			get
			{
				return this._PRECA_FLG;
			}
			set
			{
				if ((this._PRECA_FLG != value))
				{
					this._PRECA_FLG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BARCODE_DATA", DbType="NVarChar(50)")]
		public string BARCODE_DATA
		{
			get
			{
				return this._BARCODE_DATA;
			}
			set
			{
				if ((this._BARCODE_DATA != value))
				{
					this._BARCODE_DATA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HIKITSUGI_DATA", DbType="NVarChar(50)")]
		public string HIKITSUGI_DATA
		{
			get
			{
				return this._HIKITSUGI_DATA;
			}
			set
			{
				if ((this._HIKITSUGI_DATA != value))
				{
					this._HIKITSUGI_DATA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_KESSAI_PRE_GAKU", DbType="NVarChar(50)")]
		public string KESSAI_PRE_GAKU
		{
			get
			{
				return this._KESSAI_PRE_GAKU;
			}
			set
			{
				if ((this._KESSAI_PRE_GAKU != value))
				{
					this._KESSAI_PRE_GAKU = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YOYAKU_DATE1", DbType="NVarChar(50)")]
		public string YOYAKU_DATE1
		{
			get
			{
				return this._YOYAKU_DATE1;
			}
			set
			{
				if ((this._YOYAKU_DATE1 != value))
				{
					this._YOYAKU_DATE1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YOYAKU_DATE2", DbType="NVarChar(50)")]
		public string YOYAKU_DATE2
		{
			get
			{
				return this._YOYAKU_DATE2;
			}
			set
			{
				if ((this._YOYAKU_DATE2 != value))
				{
					this._YOYAKU_DATE2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAMAE_DATA", DbType="NVarChar(50)")]
		public string NAMAE_DATA
		{
			get
			{
				return this._NAMAE_DATA;
			}
			set
			{
				if ((this._NAMAE_DATA != value))
				{
					this._NAMAE_DATA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAMAE_FLG", DbType="NVarChar(50)")]
		public string NAMAE_FLG
		{
			get
			{
				return this._NAMAE_FLG;
			}
			set
			{
				if ((this._NAMAE_FLG != value))
				{
					this._NAMAE_FLG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAMAE_KANA_DATA", DbType="NVarChar(50)")]
		public string NAMAE_KANA_DATA
		{
			get
			{
				return this._NAMAE_KANA_DATA;
			}
			set
			{
				if ((this._NAMAE_KANA_DATA != value))
				{
					this._NAMAE_KANA_DATA = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PRECA_KIGEN", DbType="NVarChar(50)")]
		public string PRECA_KIGEN
		{
			get
			{
				return this._PRECA_KIGEN;
			}
			set
			{
				if ((this._PRECA_KIGEN != value))
				{
					this._PRECA_KIGEN = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YOBI1", DbType="NVarChar(50)")]
		public string YOBI1
		{
			get
			{
				return this._YOBI1;
			}
			set
			{
				if ((this._YOBI1 != value))
				{
					this._YOBI1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_YOBI2", DbType="NVarChar(50)")]
		public string YOBI2
		{
			get
			{
				return this._YOBI2;
			}
			set
			{
				if ((this._YOBI2 != value))
				{
					this._YOBI2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPLOAD_FLG", DbType="Int")]
		public System.Nullable<int> UPLOAD_FLG
		{
			get
			{
				return this._UPLOAD_FLG;
			}
			set
			{
				if ((this._UPLOAD_FLG != value))
				{
					this._UPLOAD_FLG = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UPLOAD_DATE", DbType="NVarChar(50)")]
		public string UPLOAD_DATE
		{
			get
			{
				return this._UPLOAD_DATE;
			}
			set
			{
				if ((this._UPLOAD_DATE != value))
				{
					this._UPLOAD_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBS_STATUS", DbType="NVarChar(50)")]
		public string DBS_STATUS
		{
			get
			{
				return this._DBS_STATUS;
			}
			set
			{
				if ((this._DBS_STATUS != value))
				{
					this._DBS_STATUS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBS_CREATE_USER", DbType="NVarChar(50)")]
		public string DBS_CREATE_USER
		{
			get
			{
				return this._DBS_CREATE_USER;
			}
			set
			{
				if ((this._DBS_CREATE_USER != value))
				{
					this._DBS_CREATE_USER = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBS_CREATE_DATE", DbType="NVarChar(50)")]
		public string DBS_CREATE_DATE
		{
			get
			{
				return this._DBS_CREATE_DATE;
			}
			set
			{
				if ((this._DBS_CREATE_DATE != value))
				{
					this._DBS_CREATE_DATE = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBS_UPDATE_USER", DbType="NVarChar(50)")]
		public string DBS_UPDATE_USER
		{
			get
			{
				return this._DBS_UPDATE_USER;
			}
			set
			{
				if ((this._DBS_UPDATE_USER != value))
				{
					this._DBS_UPDATE_USER = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DBS_UPDATE_DATE", DbType="NVarChar(50)")]
		public string DBS_UPDATE_DATE
		{
			get
			{
				return this._DBS_UPDATE_DATE;
			}
			set
			{
				if ((this._DBS_UPDATE_DATE != value))
				{
					this._DBS_UPDATE_DATE = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
