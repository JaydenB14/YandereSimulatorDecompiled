﻿using System;
using UnityEngine;

// Token: 0x020002E5 RID: 741
public static class GlobalsHelper
{
	// Token: 0x060014F7 RID: 5367 RVA: 0x000D75E5 File Offset: 0x000D57E5
	public static bool GetBool(string key)
	{
		return PlayerPrefs.GetInt(key) == 1;
	}

	// Token: 0x060014F8 RID: 5368 RVA: 0x000D75F0 File Offset: 0x000D57F0
	public static void SetBool(string key, bool value)
	{
		PlayerPrefs.SetInt(key, value ? 1 : 0);
	}

	// Token: 0x060014F9 RID: 5369 RVA: 0x000D75FF File Offset: 0x000D57FF
	public static T GetEnum<T>(string key) where T : struct, IConvertible
	{
		return (T)((object)PlayerPrefs.GetInt(key));
	}

	// Token: 0x060014FA RID: 5370 RVA: 0x000D7611 File Offset: 0x000D5811
	public static void SetEnum<T>(string key, T value) where T : struct, IConvertible
	{
		PlayerPrefs.SetInt(key, (int)((object)value));
	}

	// Token: 0x060014FB RID: 5371 RVA: 0x000D7624 File Offset: 0x000D5824
	public static Vector2 GetVector2(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_X");
		float float2 = PlayerPrefs.GetFloat(key + "_Y");
		return new Vector2(@float, float2);
	}

	// Token: 0x060014FC RID: 5372 RVA: 0x000D7658 File Offset: 0x000D5858
	public static void SetVector2(string key, Vector2 value)
	{
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
	}

	// Token: 0x060014FD RID: 5373 RVA: 0x000D7686 File Offset: 0x000D5886
	public static void DeleteVector2(string key)
	{
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
	}

	// Token: 0x060014FE RID: 5374 RVA: 0x000D76A8 File Offset: 0x000D58A8
	public static void DeleteVector2Collection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			GlobalsHelper.DeleteVector2(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x060014FF RID: 5375 RVA: 0x000D76E4 File Offset: 0x000D58E4
	public static Vector3 GetVector3(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_X");
		float float2 = PlayerPrefs.GetFloat(key + "_Y");
		float float3 = PlayerPrefs.GetFloat(key + "_Z");
		return new Vector3(@float, float2, float3);
	}

	// Token: 0x06001500 RID: 5376 RVA: 0x000D772C File Offset: 0x000D592C
	public static void SetVector3(string key, Vector3 value)
	{
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
		PlayerPrefs.SetFloat(key + "_Z", value.z);
	}

	// Token: 0x06001501 RID: 5377 RVA: 0x000D777B File Offset: 0x000D597B
	public static void DeleteVector3(string key)
	{
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
		Globals.Delete(key + "_Z");
	}

	// Token: 0x06001502 RID: 5378 RVA: 0x000D77B0 File Offset: 0x000D59B0
	public static void DeleteVector3Collection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			GlobalsHelper.DeleteVector3(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}

	// Token: 0x06001503 RID: 5379 RVA: 0x000D77EC File Offset: 0x000D59EC
	public static Vector4 GetVector4(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_W");
		float float2 = PlayerPrefs.GetFloat(key + "_X");
		float float3 = PlayerPrefs.GetFloat(key + "_Y");
		float float4 = PlayerPrefs.GetFloat(key + "_Z");
		return new Vector4(@float, float2, float3, float4);
	}

	// Token: 0x06001504 RID: 5380 RVA: 0x000D7844 File Offset: 0x000D5A44
	public static void SetVector4(string key, Vector4 value)
	{
		PlayerPrefs.SetFloat(key + "_W", value.w);
		PlayerPrefs.SetFloat(key + "_X", value.x);
		PlayerPrefs.SetFloat(key + "_Y", value.y);
		PlayerPrefs.SetFloat(key + "_Z", value.z);
	}

	// Token: 0x06001505 RID: 5381 RVA: 0x000D78AC File Offset: 0x000D5AAC
	public static void DeleteVector4(string key)
	{
		Globals.Delete(key + "_W");
		Globals.Delete(key + "_X");
		Globals.Delete(key + "_Y");
		Globals.Delete(key + "_Z");
	}

	// Token: 0x06001506 RID: 5382 RVA: 0x000D78FC File Offset: 0x000D5AFC
	public static Color GetColor(string key)
	{
		float @float = PlayerPrefs.GetFloat(key + "_R");
		float float2 = PlayerPrefs.GetFloat(key + "_G");
		float float3 = PlayerPrefs.GetFloat(key + "_B");
		float float4 = PlayerPrefs.GetFloat(key + "_A");
		return new Color(@float, float2, float3, float4);
	}

	// Token: 0x06001507 RID: 5383 RVA: 0x000D7954 File Offset: 0x000D5B54
	public static void SetColor(string key, Color value)
	{
		PlayerPrefs.SetFloat(key + "_R", value.r);
		PlayerPrefs.SetFloat(key + "_G", value.g);
		PlayerPrefs.SetFloat(key + "_B", value.b);
		PlayerPrefs.SetFloat(key + "_A", value.a);
	}

	// Token: 0x06001508 RID: 5384 RVA: 0x000D79BC File Offset: 0x000D5BBC
	public static void DeleteColor(string key)
	{
		Globals.Delete(key + "_R");
		Globals.Delete(key + "_G");
		Globals.Delete(key + "_B");
		Globals.Delete(key + "_A");
	}

	// Token: 0x06001509 RID: 5385 RVA: 0x000D7A0C File Offset: 0x000D5C0C
	public static void DeleteColorCollection(string key, int[] usedKeys)
	{
		foreach (int num in usedKeys)
		{
			GlobalsHelper.DeleteColor(key + num.ToString());
		}
		KeysHelper.Delete(key);
	}
}
