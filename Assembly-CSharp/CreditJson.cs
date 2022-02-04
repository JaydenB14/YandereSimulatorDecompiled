﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000343 RID: 835
[Serializable]
public class CreditJson : JsonData
{
	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x0600191D RID: 6429 RVA: 0x000FB1E0 File Offset: 0x000F93E0
	public static string FilePath
	{
		get
		{
			return Path.Combine(JsonData.FolderPath, "Credits.json");
		}
	}

	// Token: 0x0600191E RID: 6430 RVA: 0x000FB1F4 File Offset: 0x000F93F4
	public static CreditJson[] LoadFromJson(string path)
	{
		List<CreditJson> list = new List<CreditJson>();
		foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path))
		{
			list.Add(new CreditJson
			{
				name = TFUtils.LoadString(dictionary, "Name"),
				size = TFUtils.LoadInt(dictionary, "Size")
			});
		}
		return list.ToArray();
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x0600191F RID: 6431 RVA: 0x000FB259 File Offset: 0x000F9459
	public string Name
	{
		get
		{
			return this.name;
		}
	}

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x06001920 RID: 6432 RVA: 0x000FB261 File Offset: 0x000F9461
	public int Size
	{
		get
		{
			return this.size;
		}
	}

	// Token: 0x04002744 RID: 10052
	[SerializeField]
	private string name;

	// Token: 0x04002745 RID: 10053
	[SerializeField]
	private int size;
}
