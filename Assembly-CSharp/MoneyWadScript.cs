﻿using System;
using UnityEngine;

// Token: 0x0200036F RID: 879
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019DD RID: 6621 RVA: 0x0010986C File Offset: 0x00107A6C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Money += 20f;
			this.Prompt.Yandere.Inventory.UpdateMoney();
			if (this.Prompt.Yandere.Inventory.Money > 1000f && !GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("RichGirl", 1);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040029A4 RID: 10660
	public PromptScript Prompt;
}
