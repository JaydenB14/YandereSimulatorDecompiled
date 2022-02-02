﻿using System;
using UnityEngine;

// Token: 0x020002ED RID: 749
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001579 RID: 5497 RVA: 0x000D97C4 File Offset: 0x000D79C4
	// (set) Token: 0x0600157A RID: 5498 RVA: 0x000D97F4 File Offset: 0x000D79F4
	public static int Week
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Week", value);
		}
	}

	// Token: 0x17000384 RID: 900
	// (get) Token: 0x0600157B RID: 5499 RVA: 0x000D9824 File Offset: 0x000D7A24
	// (set) Token: 0x0600157C RID: 5500 RVA: 0x000D9854 File Offset: 0x000D7A54
	public static DayOfWeek Weekday
	{
		get
		{
			return GlobalsHelper.GetEnum<DayOfWeek>("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		}
		set
		{
			GlobalsHelper.SetEnum<DayOfWeek>("Profile_" + GameGlobals.Profile.ToString() + "_Weekday", value);
		}
	}

	// Token: 0x17000385 RID: 901
	// (get) Token: 0x0600157D RID: 5501 RVA: 0x000D9884 File Offset: 0x000D7A84
	// (set) Token: 0x0600157E RID: 5502 RVA: 0x000D98B4 File Offset: 0x000D7AB4
	public static int PassDays
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PassDays", value);
		}
	}

	// Token: 0x17000386 RID: 902
	// (get) Token: 0x0600157F RID: 5503 RVA: 0x000D98E4 File Offset: 0x000D7AE4
	// (set) Token: 0x06001580 RID: 5504 RVA: 0x000D9914 File Offset: 0x000D7B14
	public static bool DayPassed
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed", value);
		}
	}

	// Token: 0x17000387 RID: 903
	// (get) Token: 0x06001581 RID: 5505 RVA: 0x000D9944 File Offset: 0x000D7B44
	// (set) Token: 0x06001582 RID: 5506 RVA: 0x000D9974 File Offset: 0x000D7B74
	public static int GameplayDay
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay", value);
		}
	}

	// Token: 0x06001583 RID: 5507 RVA: 0x000D99A4 File Offset: 0x000D7BA4
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
	}

	// Token: 0x040021B1 RID: 8625
	private const string Str_Week = "Week";

	// Token: 0x040021B2 RID: 8626
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021B3 RID: 8627
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021B4 RID: 8628
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021B5 RID: 8629
	private const string Str_GameplayDay = "GameplayDay";
}
