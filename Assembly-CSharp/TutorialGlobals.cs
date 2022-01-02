﻿using System;

// Token: 0x020002FD RID: 765
public static class TutorialGlobals
{
	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x060017A8 RID: 6056 RVA: 0x000E1B0C File Offset: 0x000DFD0C
	// (set) Token: 0x060017A9 RID: 6057 RVA: 0x000E1B3C File Offset: 0x000DFD3C
	public static bool IgnoreClothing
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClothing");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClothing", value);
		}
	}

	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x060017AA RID: 6058 RVA: 0x000E1B6C File Offset: 0x000DFD6C
	// (set) Token: 0x060017AB RID: 6059 RVA: 0x000E1B9C File Offset: 0x000DFD9C
	public static bool IgnoreCouncil
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreCouncil");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreCouncil", value);
		}
	}

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017AC RID: 6060 RVA: 0x000E1BCC File Offset: 0x000DFDCC
	// (set) Token: 0x060017AD RID: 6061 RVA: 0x000E1BFC File Offset: 0x000DFDFC
	public static bool IgnoreTeacher
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreTeacher");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreTeacher", value);
		}
	}

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017AE RID: 6062 RVA: 0x000E1C2C File Offset: 0x000DFE2C
	// (set) Token: 0x060017AF RID: 6063 RVA: 0x000E1C5C File Offset: 0x000DFE5C
	public static bool IgnoreLocker
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreLocker");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreLocker", value);
		}
	}

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x060017B0 RID: 6064 RVA: 0x000E1C8C File Offset: 0x000DFE8C
	// (set) Token: 0x060017B1 RID: 6065 RVA: 0x000E1CBC File Offset: 0x000DFEBC
	public static bool IgnorePolice
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePolice");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePolice", value);
		}
	}

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x060017B2 RID: 6066 RVA: 0x000E1CEC File Offset: 0x000DFEEC
	// (set) Token: 0x060017B3 RID: 6067 RVA: 0x000E1D1C File Offset: 0x000DFF1C
	public static bool IgnoreSanity
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSanity");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSanity", value);
		}
	}

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x060017B4 RID: 6068 RVA: 0x000E1D4C File Offset: 0x000DFF4C
	// (set) Token: 0x060017B5 RID: 6069 RVA: 0x000E1D7C File Offset: 0x000DFF7C
	public static bool IgnoreSenpai
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSenpai");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSenpai", value);
		}
	}

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x060017B6 RID: 6070 RVA: 0x000E1DAC File Offset: 0x000DFFAC
	// (set) Token: 0x060017B7 RID: 6071 RVA: 0x000E1DDC File Offset: 0x000DFFDC
	public static bool IgnoreVision
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreVision");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreVision", value);
		}
	}

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x060017B8 RID: 6072 RVA: 0x000E1E0C File Offset: 0x000E000C
	// (set) Token: 0x060017B9 RID: 6073 RVA: 0x000E1E3C File Offset: 0x000E003C
	public static bool IgnoreWeapon
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreWeapon");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreWeapon", value);
		}
	}

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x060017BA RID: 6074 RVA: 0x000E1E6C File Offset: 0x000E006C
	// (set) Token: 0x060017BB RID: 6075 RVA: 0x000E1E9C File Offset: 0x000E009C
	public static bool IgnoreBlood
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreBlood");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreBlood", value);
		}
	}

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x060017BC RID: 6076 RVA: 0x000E1ECC File Offset: 0x000E00CC
	// (set) Token: 0x060017BD RID: 6077 RVA: 0x000E1EFC File Offset: 0x000E00FC
	public static bool IgnoreClass
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass", value);
		}
	}

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x060017BE RID: 6078 RVA: 0x000E1F2C File Offset: 0x000E012C
	// (set) Token: 0x060017BF RID: 6079 RVA: 0x000E1F5C File Offset: 0x000E015C
	public static bool IgnoreMoney
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreMoney");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreMoney", value);
		}
	}

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x060017C0 RID: 6080 RVA: 0x000E1F8C File Offset: 0x000E018C
	// (set) Token: 0x060017C1 RID: 6081 RVA: 0x000E1FBC File Offset: 0x000E01BC
	public static bool IgnorePhoto
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePhoto");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePhoto", value);
		}
	}

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x060017C2 RID: 6082 RVA: 0x000E1FEC File Offset: 0x000E01EC
	// (set) Token: 0x060017C3 RID: 6083 RVA: 0x000E201C File Offset: 0x000E021C
	public static bool IgnoreClub
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClub");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClub", value);
		}
	}

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x060017C4 RID: 6084 RVA: 0x000E204C File Offset: 0x000E024C
	// (set) Token: 0x060017C5 RID: 6085 RVA: 0x000E207C File Offset: 0x000E027C
	public static bool IgnoreInfo
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreInfo");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreInfo", value);
		}
	}

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x060017C6 RID: 6086 RVA: 0x000E20AC File Offset: 0x000E02AC
	// (set) Token: 0x060017C7 RID: 6087 RVA: 0x000E20DC File Offset: 0x000E02DC
	public static bool IgnorePool
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePool");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePool", value);
		}
	}

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060017C8 RID: 6088 RVA: 0x000E210C File Offset: 0x000E030C
	// (set) Token: 0x060017C9 RID: 6089 RVA: 0x000E213C File Offset: 0x000E033C
	public static bool IgnoreRep
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass", value);
		}
	}

	// Token: 0x060017CA RID: 6090 RVA: 0x000E216C File Offset: 0x000E036C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClothing");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreCouncil");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreTeacher");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreLocker");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePolice");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSanity");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSenpai");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreVision");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreWeapon");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreBlood");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreMoney");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePhoto");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClub");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreInfo");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
	}

	// Token: 0x0400229D RID: 8861
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x0400229E RID: 8862
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x0400229F RID: 8863
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x040022A0 RID: 8864
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x040022A1 RID: 8865
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x040022A2 RID: 8866
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x040022A3 RID: 8867
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x040022A4 RID: 8868
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x040022A5 RID: 8869
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x040022A6 RID: 8870
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x040022A7 RID: 8871
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x040022A8 RID: 8872
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x040022A9 RID: 8873
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x040022AA RID: 8874
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x040022AB RID: 8875
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x040022AC RID: 8876
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x040022AD RID: 8877
	private const string Str_IgnoreRep = "IgnoreClass";
}