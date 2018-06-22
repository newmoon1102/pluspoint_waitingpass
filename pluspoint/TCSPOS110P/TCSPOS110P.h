/******************************************************************************/
/***																		***/
/***		File Name	:	TCSPOS110P.h									***/
/***		Usage		:	Function about R/W Card terminal communication	***/
/***		Creator		:	M.Sakano										***/
/***		Date		:	August 04										***/
/***																		***/
/***		Modified	:													***/
/***																		***/
/******************************************************************************/

#ifndef		_TCSPOS110P_FUNC_H
#define		_TCSPOS110P_FUNC_H

#pragma once

#include <windows.h>

/******************************************************************************/
/***	Struct																***/
/******************************************************************************/
// Send Sale Data A
typedef struct {
	char*	cardid;									/*** 会員ｺｰﾄﾞ ***/
	short	rank;									/*** 会員ﾗﾝｸ  ***/
	char*	birthday;							/*** 誕生日ﾃﾞｰﾀ   ***/
	short	pchargflag;						/*** ﾌﾟﾘｶﾁｬｰｼﾞﾌﾗｸﾞ    ***/
	long	mreceivedata;					/*** ﾌﾟﾘｶ入金額ﾃﾞｰﾀ   ***/
	long	preceivedata;				/*** ﾌﾟﾘｶﾌﾟﾚﾐｱﾑ金額ﾃﾞｰﾀ   ***/
	short	pgflag;						/*** 商品ﾎﾟｲﾝﾄ付加ﾌﾗｸﾞ    ***/
	long	pgdata;							/*** 商品ﾎﾟｲﾝﾄﾃﾞｰﾀ    ***/
	short	pspflag;					/*** 特別ﾎﾟｲﾝﾄ付加ﾌﾗｸﾞ    ***/
	long	pspdata;						/*** 特別ﾎﾟｲﾝﾄﾃﾞｰﾀ    ***/
	long	pfreedata;						/*** 任意ﾎﾟｲﾝﾄﾃﾞｰﾀ    ***/
	long	pretdata;						/*** 返品ﾎﾟｲﾝﾄﾃﾞｰﾀ    ***/
	short	manageflag;								/*** 処理ﾌﾗｸﾞ ***/
	short	expired;							/*** 期限更新ﾌﾗｸﾞ ***/
} StSendSaleDataAInf;


#if !defined(TCSPOS110PDLL_EXPORT)
#define TCSPOS110PDLL_API __declspec(dllimport)
#else
#define TCSPOS110PDLL_API __declspec(dllexport)
#endif  // !defined(TCSPOS110PDLL_EXPORT)

#if defined(__cplusplus)
extern "C" {
#endif

TCSPOS110PDLL_API
short	WINAPI	OpenPort( HANDLE*, short, long );

TCSPOS110PDLL_API
short	WINAPI	ClosePort( HANDLE* );

TCSPOS110PDLL_API
short	WINAPI	RmGetStatus( HANDLE*, short*, short*, short*, short*, long*, long*, short* );

TCSPOS110PDLL_API
short	WINAPI	RmGetMode( HANDLE*, short*, short*, short*, short*, short*, short*, short*, short*, short*, short*, short*, short* );

TCSPOS110PDLL_API
short	WINAPI	RmSendRecCard( HANDLE*, short );

TCSPOS110PDLL_API
short	WINAPI	RmGetCardDataA( HANDLE*, char*, short*, long*, long*, char*, long*, char*, char*, char*, short*, short*, short*, char*, short*, short*, char*, char* );

TCSPOS110PDLL_API
short	WINAPI	RmSendCancel( HANDLE* );

TCSPOS110PDLL_API
short	WINAPI	RmSendSellA( HANDLE*, StSendSaleDataAInf*, short, long*, long*, short*, short* );

TCSPOS110PDLL_API
short	WINAPI	RmSendExchnge( HANDLE*, long );

TCSPOS110PDLL_API
short	WINAPI	RmSendProcRun( HANDLE* );

TCSPOS110PDLL_API
short	WINAPI	RmGetCalcA(	HANDLE*, long*, short*,	long*, long*, long*, long*, long* );

TCSPOS110PDLL_API
short	WINAPI	RmSendTestMode( HANDLE* );

TCSPOS110PDLL_API
short	WINAPI	RmSendCleaning( HANDLE* );

TCSPOS110PDLL_API
short	WINAPI	RmSendName( HANDLE*, char* );

TCSPOS110PDLL_API
short	WINAPI	RmGetICM( HANDLE*, char* );

TCSPOS110PDLL_API
short	WINAPI	RmSendICMClear( HANDLE* );

TCSPOS110PDLL_API
short	WINAPI	RmSendModem( HANDLE* );

TCSPOS110PDLL_API
short	WINAPI	RmGetVersion( HANDLE*, short*, long*, short*, short*, long*, long* );

TCSPOS110PDLL_API
short	WINAPI	RmSendMessageData( HANDLE*, short, short, char*, char*, char* );

TCSPOS110PDLL_API
short	WINAPI	RmSendClock( HANDLE*, char* );

#if defined(__cplusplus)
}
#endif

#endif
