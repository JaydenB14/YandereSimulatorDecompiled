﻿using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class StudentGlobals
{
	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x06001720 RID: 5920 RVA: 0x000DF554 File Offset: 0x000DD754
	// (set) Token: 0x06001721 RID: 5921 RVA: 0x000DF584 File Offset: 0x000DD784
	public static bool CustomSuitor
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor", value);
		}
	}

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x06001722 RID: 5922 RVA: 0x000DF5B4 File Offset: 0x000DD7B4
	// (set) Token: 0x06001723 RID: 5923 RVA: 0x000DF5E4 File Offset: 0x000DD7E4
	public static int CustomSuitorAccessory
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory", value);
		}
	}

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x06001724 RID: 5924 RVA: 0x000DF614 File Offset: 0x000DD814
	// (set) Token: 0x06001725 RID: 5925 RVA: 0x000DF644 File Offset: 0x000DD844
	public static bool CustomSuitorBlonde
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde", value);
		}
	}

	// Token: 0x17000430 RID: 1072
	// (get) Token: 0x06001726 RID: 5926 RVA: 0x000DF674 File Offset: 0x000DD874
	// (set) Token: 0x06001727 RID: 5927 RVA: 0x000DF6A4 File Offset: 0x000DD8A4
	public static bool CustomSuitorBlack
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack", value);
		}
	}

	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x06001728 RID: 5928 RVA: 0x000DF6D4 File Offset: 0x000DD8D4
	// (set) Token: 0x06001729 RID: 5929 RVA: 0x000DF704 File Offset: 0x000DD904
	public static int CustomSuitorEyewear
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear", value);
		}
	}

	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x0600172A RID: 5930 RVA: 0x000DF734 File Offset: 0x000DD934
	// (set) Token: 0x0600172B RID: 5931 RVA: 0x000DF764 File Offset: 0x000DD964
	public static int CustomSuitorHair
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair", value);
		}
	}

	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x0600172C RID: 5932 RVA: 0x000DF794 File Offset: 0x000DD994
	// (set) Token: 0x0600172D RID: 5933 RVA: 0x000DF7C4 File Offset: 0x000DD9C4
	public static int CustomSuitorJewelry
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry", value);
		}
	}

	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x0600172E RID: 5934 RVA: 0x000DF7F4 File Offset: 0x000DD9F4
	// (set) Token: 0x0600172F RID: 5935 RVA: 0x000DF824 File Offset: 0x000DDA24
	public static bool CustomSuitorTan
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan", value);
		}
	}

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000DF854 File Offset: 0x000DDA54
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000DF884 File Offset: 0x000DDA84
	public static int ExpelProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress", value);
		}
	}

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000DF8B4 File Offset: 0x000DDAB4
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000DF8E4 File Offset: 0x000DDAE4
	public static int FemaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform", value);
		}
	}

	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000DF914 File Offset: 0x000DDB14
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000DF944 File Offset: 0x000DDB44
	public static int MaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform", value);
		}
	}

	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x06001736 RID: 5942 RVA: 0x000DF974 File Offset: 0x000DDB74
	// (set) Token: 0x06001737 RID: 5943 RVA: 0x000DF9A4 File Offset: 0x000DDBA4
	public static int MemorialStudents
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents", value);
		}
	}

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x06001738 RID: 5944 RVA: 0x000DF9D4 File Offset: 0x000DDBD4
	// (set) Token: 0x06001739 RID: 5945 RVA: 0x000DFA04 File Offset: 0x000DDC04
	public static int MemorialStudent1
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1", value);
		}
	}

	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x0600173A RID: 5946 RVA: 0x000DFA34 File Offset: 0x000DDC34
	// (set) Token: 0x0600173B RID: 5947 RVA: 0x000DFA64 File Offset: 0x000DDC64
	public static int MemorialStudent2
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2", value);
		}
	}

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x0600173C RID: 5948 RVA: 0x000DFA94 File Offset: 0x000DDC94
	// (set) Token: 0x0600173D RID: 5949 RVA: 0x000DFAC4 File Offset: 0x000DDCC4
	public static int MemorialStudent3
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3", value);
		}
	}

	// Token: 0x1700043C RID: 1084
	// (get) Token: 0x0600173E RID: 5950 RVA: 0x000DFAF4 File Offset: 0x000DDCF4
	// (set) Token: 0x0600173F RID: 5951 RVA: 0x000DFB24 File Offset: 0x000DDD24
	public static int MemorialStudent4
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4", value);
		}
	}

	// Token: 0x1700043D RID: 1085
	// (get) Token: 0x06001740 RID: 5952 RVA: 0x000DFB54 File Offset: 0x000DDD54
	// (set) Token: 0x06001741 RID: 5953 RVA: 0x000DFB84 File Offset: 0x000DDD84
	public static int MemorialStudent5
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5", value);
		}
	}

	// Token: 0x1700043E RID: 1086
	// (get) Token: 0x06001742 RID: 5954 RVA: 0x000DFBB4 File Offset: 0x000DDDB4
	// (set) Token: 0x06001743 RID: 5955 RVA: 0x000DFBE4 File Offset: 0x000DDDE4
	public static int MemorialStudent6
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6", value);
		}
	}

	// Token: 0x1700043F RID: 1087
	// (get) Token: 0x06001744 RID: 5956 RVA: 0x000DFC14 File Offset: 0x000DDE14
	// (set) Token: 0x06001745 RID: 5957 RVA: 0x000DFC44 File Offset: 0x000DDE44
	public static int MemorialStudent7
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7", value);
		}
	}

	// Token: 0x17000440 RID: 1088
	// (get) Token: 0x06001746 RID: 5958 RVA: 0x000DFC74 File Offset: 0x000DDE74
	// (set) Token: 0x06001747 RID: 5959 RVA: 0x000DFCA4 File Offset: 0x000DDEA4
	public static int MemorialStudent8
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8", value);
		}
	}

	// Token: 0x17000441 RID: 1089
	// (get) Token: 0x06001748 RID: 5960 RVA: 0x000DFCD4 File Offset: 0x000DDED4
	// (set) Token: 0x06001749 RID: 5961 RVA: 0x000DFD04 File Offset: 0x000DDF04
	public static int MemorialStudent9
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9", value);
		}
	}

	// Token: 0x0600174A RID: 5962 RVA: 0x000DFD34 File Offset: 0x000DDF34
	public static string GetStudentAccessory(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + studentID.ToString());
	}

	// Token: 0x0600174B RID: 5963 RVA: 0x000DFD6C File Offset: 0x000DDF6C
	public static void SetStudentAccessory(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + text, value);
	}

	// Token: 0x0600174C RID: 5964 RVA: 0x000DFDC8 File Offset: 0x000DDFC8
	public static int[] KeysOfStudentAccessory()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_");
	}

	// Token: 0x0600174D RID: 5965 RVA: 0x000DFDF8 File Offset: 0x000DDFF8
	public static bool GetStudentArrested(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + studentID.ToString());
	}

	// Token: 0x0600174E RID: 5966 RVA: 0x000DFE30 File Offset: 0x000DE030
	public static void SetStudentArrested(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + text, value);
	}

	// Token: 0x0600174F RID: 5967 RVA: 0x000DFE8C File Offset: 0x000DE08C
	public static int[] KeysOfStudentArrested()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_");
	}

	// Token: 0x06001750 RID: 5968 RVA: 0x000DFEBC File Offset: 0x000DE0BC
	public static bool GetStudentBroken(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + studentID.ToString());
	}

	// Token: 0x06001751 RID: 5969 RVA: 0x000DFEF4 File Offset: 0x000DE0F4
	public static void SetStudentBroken(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + text, value);
	}

	// Token: 0x06001752 RID: 5970 RVA: 0x000DFF50 File Offset: 0x000DE150
	public static int[] KeysOfStudentBroken()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_");
	}

	// Token: 0x06001753 RID: 5971 RVA: 0x000DFF80 File Offset: 0x000DE180
	public static float GetStudentBustSize(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + studentID.ToString());
	}

	// Token: 0x06001754 RID: 5972 RVA: 0x000DFFB8 File Offset: 0x000DE1B8
	public static void SetStudentBustSize(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + text, value);
	}

	// Token: 0x06001755 RID: 5973 RVA: 0x000E0014 File Offset: 0x000DE214
	public static int[] KeysOfStudentBustSize()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_");
	}

	// Token: 0x06001756 RID: 5974 RVA: 0x000E0044 File Offset: 0x000DE244
	public static Color GetStudentColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + studentID.ToString());
	}

	// Token: 0x06001757 RID: 5975 RVA: 0x000E007C File Offset: 0x000DE27C
	public static void SetStudentColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + text, value);
	}

	// Token: 0x06001758 RID: 5976 RVA: 0x000E00D8 File Offset: 0x000DE2D8
	public static int[] KeysOfStudentColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_");
	}

	// Token: 0x06001759 RID: 5977 RVA: 0x000E0108 File Offset: 0x000DE308
	public static bool GetStudentDead(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + studentID.ToString());
	}

	// Token: 0x0600175A RID: 5978 RVA: 0x000E0140 File Offset: 0x000DE340
	public static void SetStudentDead(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + text, value);
	}

	// Token: 0x0600175B RID: 5979 RVA: 0x000E019C File Offset: 0x000DE39C
	public static int[] KeysOfStudentDead()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_");
	}

	// Token: 0x0600175C RID: 5980 RVA: 0x000E01CC File Offset: 0x000DE3CC
	public static bool GetStudentDying(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + studentID.ToString());
	}

	// Token: 0x0600175D RID: 5981 RVA: 0x000E0204 File Offset: 0x000DE404
	public static void SetStudentDying(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + text, value);
	}

	// Token: 0x0600175E RID: 5982 RVA: 0x000E0260 File Offset: 0x000DE460
	public static int[] KeysOfStudentDying()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_");
	}

	// Token: 0x0600175F RID: 5983 RVA: 0x000E0290 File Offset: 0x000DE490
	public static bool GetStudentExpelled(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + studentID.ToString());
	}

	// Token: 0x06001760 RID: 5984 RVA: 0x000E02C8 File Offset: 0x000DE4C8
	public static void SetStudentExpelled(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + text, value);
	}

	// Token: 0x06001761 RID: 5985 RVA: 0x000E0324 File Offset: 0x000DE524
	public static int[] KeysOfStudentExpelled()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_");
	}

	// Token: 0x06001762 RID: 5986 RVA: 0x000E0354 File Offset: 0x000DE554
	public static bool GetStudentExposed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + studentID.ToString());
	}

	// Token: 0x06001763 RID: 5987 RVA: 0x000E038C File Offset: 0x000DE58C
	public static void SetStudentExposed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + text, value);
	}

	// Token: 0x06001764 RID: 5988 RVA: 0x000E03E8 File Offset: 0x000DE5E8
	public static int[] KeysOfStudentExposed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_");
	}

	// Token: 0x06001765 RID: 5989 RVA: 0x000E0418 File Offset: 0x000DE618
	public static Color GetStudentEyeColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + studentID.ToString());
	}

	// Token: 0x06001766 RID: 5990 RVA: 0x000E0450 File Offset: 0x000DE650
	public static void SetStudentEyeColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + text, value);
	}

	// Token: 0x06001767 RID: 5991 RVA: 0x000E04AC File Offset: 0x000DE6AC
	public static int[] KeysOfStudentEyeColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_");
	}

	// Token: 0x06001768 RID: 5992 RVA: 0x000E04DC File Offset: 0x000DE6DC
	public static bool GetStudentGrudge(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + studentID.ToString());
	}

	// Token: 0x06001769 RID: 5993 RVA: 0x000E0514 File Offset: 0x000DE714
	public static void SetStudentGrudge(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + text, value);
	}

	// Token: 0x0600176A RID: 5994 RVA: 0x000E0570 File Offset: 0x000DE770
	public static int[] KeysOfStudentGrudge()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_");
	}

	// Token: 0x0600176B RID: 5995 RVA: 0x000E05A0 File Offset: 0x000DE7A0
	public static string GetStudentHairstyle(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + studentID.ToString());
	}

	// Token: 0x0600176C RID: 5996 RVA: 0x000E05D8 File Offset: 0x000DE7D8
	public static void SetStudentHairstyle(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + text, value);
	}

	// Token: 0x0600176D RID: 5997 RVA: 0x000E0634 File Offset: 0x000DE834
	public static int[] KeysOfStudentHairstyle()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_");
	}

	// Token: 0x0600176E RID: 5998 RVA: 0x000E0664 File Offset: 0x000DE864
	public static bool GetStudentKidnapped(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + studentID.ToString());
	}

	// Token: 0x0600176F RID: 5999 RVA: 0x000E069C File Offset: 0x000DE89C
	public static void SetStudentKidnapped(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + text, value);
	}

	// Token: 0x06001770 RID: 6000 RVA: 0x000E06F8 File Offset: 0x000DE8F8
	public static int[] KeysOfStudentKidnapped()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_");
	}

	// Token: 0x06001771 RID: 6001 RVA: 0x000E0728 File Offset: 0x000DE928
	public static bool GetStudentMissing(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + studentID.ToString());
	}

	// Token: 0x06001772 RID: 6002 RVA: 0x000E0760 File Offset: 0x000DE960
	public static void SetStudentMissing(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + text, value);
	}

	// Token: 0x06001773 RID: 6003 RVA: 0x000E07BC File Offset: 0x000DE9BC
	public static int[] KeysOfStudentMissing()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_");
	}

	// Token: 0x06001774 RID: 6004 RVA: 0x000E07EC File Offset: 0x000DE9EC
	public static string GetStudentName(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + studentID.ToString());
	}

	// Token: 0x06001775 RID: 6005 RVA: 0x000E0824 File Offset: 0x000DEA24
	public static void SetStudentName(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + text, value);
	}

	// Token: 0x06001776 RID: 6006 RVA: 0x000E0880 File Offset: 0x000DEA80
	public static int[] KeysOfStudentName()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_");
	}

	// Token: 0x06001777 RID: 6007 RVA: 0x000E08B0 File Offset: 0x000DEAB0
	public static bool GetStudentPhotographed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + studentID.ToString());
	}

	// Token: 0x06001778 RID: 6008 RVA: 0x000E08E8 File Offset: 0x000DEAE8
	public static void SetStudentPhotographed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + text, value);
	}

	// Token: 0x06001779 RID: 6009 RVA: 0x000E0944 File Offset: 0x000DEB44
	public static int[] KeysOfStudentPhotographed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_");
	}

	// Token: 0x0600177A RID: 6010 RVA: 0x000E0974 File Offset: 0x000DEB74
	public static bool GetStudentPhoneStolen(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + studentID.ToString());
	}

	// Token: 0x0600177B RID: 6011 RVA: 0x000E09AC File Offset: 0x000DEBAC
	public static void SetStudentPhoneStolen(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + text, value);
	}

	// Token: 0x0600177C RID: 6012 RVA: 0x000E0A08 File Offset: 0x000DEC08
	public static int[] KeysOfStudentPhoneStolen()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_");
	}

	// Token: 0x0600177D RID: 6013 RVA: 0x000E0A38 File Offset: 0x000DEC38
	public static bool GetStudentReplaced(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + studentID.ToString());
	}

	// Token: 0x0600177E RID: 6014 RVA: 0x000E0A70 File Offset: 0x000DEC70
	public static void SetStudentReplaced(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + text, value);
	}

	// Token: 0x0600177F RID: 6015 RVA: 0x000E0ACC File Offset: 0x000DECCC
	public static int[] KeysOfStudentReplaced()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_");
	}

	// Token: 0x06001780 RID: 6016 RVA: 0x000E0AFC File Offset: 0x000DECFC
	public static int GetStudentReputation(int studentID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + studentID.ToString());
	}

	// Token: 0x06001781 RID: 6017 RVA: 0x000E0B34 File Offset: 0x000DED34
	public static void SetStudentReputation(int studentID, int value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + text, value);
	}

	// Token: 0x06001782 RID: 6018 RVA: 0x000E0B90 File Offset: 0x000DED90
	public static int[] KeysOfStudentReputation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_");
	}

	// Token: 0x06001783 RID: 6019 RVA: 0x000E0BC0 File Offset: 0x000DEDC0
	public static float GetStudentSanity(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + studentID.ToString());
	}

	// Token: 0x06001784 RID: 6020 RVA: 0x000E0BF8 File Offset: 0x000DEDF8
	public static void SetStudentSanity(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + text, value);
	}

	// Token: 0x06001785 RID: 6021 RVA: 0x000E0C54 File Offset: 0x000DEE54
	public static int[] KeysOfStudentSanity()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_");
	}

	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x06001786 RID: 6022 RVA: 0x000E0C84 File Offset: 0x000DEE84
	// (set) Token: 0x06001787 RID: 6023 RVA: 0x000E0CB4 File Offset: 0x000DEEB4
	public static int StudentSlave
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave", value);
		}
	}

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x06001788 RID: 6024 RVA: 0x000E0CE4 File Offset: 0x000DEEE4
	// (set) Token: 0x06001789 RID: 6025 RVA: 0x000E0D14 File Offset: 0x000DEF14
	public static int FragileSlave
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave", value);
		}
	}

	// Token: 0x17000444 RID: 1092
	// (get) Token: 0x0600178A RID: 6026 RVA: 0x000E0D44 File Offset: 0x000DEF44
	// (set) Token: 0x0600178B RID: 6027 RVA: 0x000E0D74 File Offset: 0x000DEF74
	public static int FragileTarget
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget", value);
		}
	}

	// Token: 0x0600178C RID: 6028 RVA: 0x000E0DA4 File Offset: 0x000DEFA4
	public static Vector3 GetReputationTriangle(int studentID)
	{
		return GlobalsHelper.GetVector3(string.Concat(new string[]
		{
			"Profile_",
			GameGlobals.Profile.ToString(),
			"_Student_",
			studentID.ToString(),
			"_ReputatonTriangle"
		}));
	}

	// Token: 0x0600178D RID: 6029 RVA: 0x000E0DF4 File Offset: 0x000DEFF4
	public static void SetReputationTriangle(int studentID, Vector3 triangle)
	{
		GlobalsHelper.SetVector3(string.Concat(new string[]
		{
			"Profile_",
			GameGlobals.Profile.ToString(),
			"_Student_",
			studentID.ToString(),
			"_ReputatonTriangle"
		}), triangle);
	}

	// Token: 0x0600178E RID: 6030 RVA: 0x000E0E44 File Offset: 0x000DF044
	public static bool GetStudentRansomed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + studentID.ToString());
	}

	// Token: 0x0600178F RID: 6031 RVA: 0x000E0E7C File Offset: 0x000DF07C
	public static void SetStudentRansomed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + text, value);
	}

	// Token: 0x06001790 RID: 6032 RVA: 0x000E0ED8 File Offset: 0x000DF0D8
	public static int[] KeysOfStudentRansomed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_");
	}

	// Token: 0x06001791 RID: 6033 RVA: 0x000E0F08 File Offset: 0x000DF108
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", StudentGlobals.KeysOfStudentAccessory());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", StudentGlobals.KeysOfStudentArrested());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", StudentGlobals.KeysOfStudentBroken());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", StudentGlobals.KeysOfStudentBustSize());
		GlobalsHelper.DeleteColorCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", StudentGlobals.KeysOfStudentColor());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", StudentGlobals.KeysOfStudentDead());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", StudentGlobals.KeysOfStudentDying());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", StudentGlobals.KeysOfStudentExpelled());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", StudentGlobals.KeysOfStudentExposed());
		GlobalsHelper.DeleteColorCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", StudentGlobals.KeysOfStudentEyeColor());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", StudentGlobals.KeysOfStudentGrudge());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", StudentGlobals.KeysOfStudentHairstyle());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", StudentGlobals.KeysOfStudentKidnapped());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", StudentGlobals.KeysOfStudentMissing());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", StudentGlobals.KeysOfStudentName());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", StudentGlobals.KeysOfStudentPhotographed());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", StudentGlobals.KeysOfStudentPhoneStolen());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", StudentGlobals.KeysOfStudentReplaced());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", StudentGlobals.KeysOfStudentReputation());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", StudentGlobals.KeysOfStudentSanity());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", StudentGlobals.KeysOfStudentRansomed());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9");
	}

	// Token: 0x04002268 RID: 8808
	private const string Str_CustomSuitor = "CustomSuitor";

	// Token: 0x04002269 RID: 8809
	private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";

	// Token: 0x0400226A RID: 8810
	private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";

	// Token: 0x0400226B RID: 8811
	private const string Str_CustomSuitorBlack = "CustomSuitorBlack";

	// Token: 0x0400226C RID: 8812
	private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";

	// Token: 0x0400226D RID: 8813
	private const string Str_CustomSuitorHair = "CustomSuitorHair";

	// Token: 0x0400226E RID: 8814
	private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";

	// Token: 0x0400226F RID: 8815
	private const string Str_CustomSuitorTan = "CustomSuitorTan";

	// Token: 0x04002270 RID: 8816
	private const string Str_ExpelProgress = "ExpelProgress";

	// Token: 0x04002271 RID: 8817
	private const string Str_FemaleUniform = "FemaleUniform";

	// Token: 0x04002272 RID: 8818
	private const string Str_MaleUniform = "MaleUniform";

	// Token: 0x04002273 RID: 8819
	private const string Str_StudentAccessory = "StudentAccessory_";

	// Token: 0x04002274 RID: 8820
	private const string Str_StudentArrested = "StudentArrested_";

	// Token: 0x04002275 RID: 8821
	private const string Str_StudentBroken = "StudentBroken_";

	// Token: 0x04002276 RID: 8822
	private const string Str_StudentBustSize = "StudentBustSize_";

	// Token: 0x04002277 RID: 8823
	private const string Str_StudentColor = "StudentColor_";

	// Token: 0x04002278 RID: 8824
	private const string Str_StudentDead = "StudentDead_";

	// Token: 0x04002279 RID: 8825
	private const string Str_StudentDying = "StudentDying_";

	// Token: 0x0400227A RID: 8826
	private const string Str_StudentExpelled = "StudentExpelled_";

	// Token: 0x0400227B RID: 8827
	private const string Str_StudentExposed = "StudentExposed_";

	// Token: 0x0400227C RID: 8828
	private const string Str_StudentEyeColor = "StudentEyeColor_";

	// Token: 0x0400227D RID: 8829
	private const string Str_StudentGrudge = "StudentGrudge_";

	// Token: 0x0400227E RID: 8830
	private const string Str_StudentHairstyle = "StudentHairstyle_";

	// Token: 0x0400227F RID: 8831
	private const string Str_StudentKidnapped = "StudentKidnapped_";

	// Token: 0x04002280 RID: 8832
	private const string Str_StudentMissing = "StudentMissing_";

	// Token: 0x04002281 RID: 8833
	private const string Str_StudentName = "StudentName_";

	// Token: 0x04002282 RID: 8834
	private const string Str_StudentPhotographed = "StudentPhotographed_";

	// Token: 0x04002283 RID: 8835
	private const string Str_StudentPhoneStolen = "StudentPhoneStolen_";

	// Token: 0x04002284 RID: 8836
	private const string Str_StudentReplaced = "StudentReplaced_";

	// Token: 0x04002285 RID: 8837
	private const string Str_StudentReputation = "StudentReputation_";

	// Token: 0x04002286 RID: 8838
	private const string Str_StudentSanity = "StudentSanity_";

	// Token: 0x04002287 RID: 8839
	private const string Str_StudentSlave = "StudentSlave";

	// Token: 0x04002288 RID: 8840
	private const string Str_FragileSlave = "FragileSlave";

	// Token: 0x04002289 RID: 8841
	private const string Str_FragileTarget = "FragileTarget";

	// Token: 0x0400228A RID: 8842
	private const string Str_ReputationTriangle = "ReputatonTriangle";

	// Token: 0x0400228B RID: 8843
	private const string Str_StudentRansomed = "StudentRansomed_";

	// Token: 0x0400228C RID: 8844
	private const string Str_MemorialStudents = "MemorialStudents";

	// Token: 0x0400228D RID: 8845
	private const string Str_MemorialStudent1 = "MemorialStudent1";

	// Token: 0x0400228E RID: 8846
	private const string Str_MemorialStudent2 = "MemorialStudent2";

	// Token: 0x0400228F RID: 8847
	private const string Str_MemorialStudent3 = "MemorialStudent3";

	// Token: 0x04002290 RID: 8848
	private const string Str_MemorialStudent4 = "MemorialStudent4";

	// Token: 0x04002291 RID: 8849
	private const string Str_MemorialStudent5 = "MemorialStudent5";

	// Token: 0x04002292 RID: 8850
	private const string Str_MemorialStudent6 = "MemorialStudent6";

	// Token: 0x04002293 RID: 8851
	private const string Str_MemorialStudent7 = "MemorialStudent7";

	// Token: 0x04002294 RID: 8852
	private const string Str_MemorialStudent8 = "MemorialStudent8";

	// Token: 0x04002295 RID: 8853
	private const string Str_MemorialStudent9 = "MemorialStudent9";
}
