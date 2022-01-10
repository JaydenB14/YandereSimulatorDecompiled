﻿using System;
using UnityEngine;

// Token: 0x02000311 RID: 785
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x06001844 RID: 6212 RVA: 0x000E9BFC File Offset: 0x000E7DFC
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0 && this.Prompt.Yandere.Pursuer == null)
			{
				if (this.Bench)
				{
					this.Prompt.Yandere.MyController.radius = 0.1f;
				}
				else
				{
					this.Prompt.Yandere.MyController.center = new Vector3(this.Prompt.Yandere.MyController.center.x, 0.3f, this.Prompt.Yandere.MyController.center.z);
					this.Prompt.Yandere.MyController.radius = 0f;
					this.Prompt.Yandere.MyController.height = 0.5f;
				}
				this.Prompt.Yandere.HideAnim = this.AnimName;
				this.Prompt.Yandere.HidingSpot = this.Spot;
				this.Prompt.Yandere.ExitSpot = this.Exit;
				this.Prompt.Yandere.CanMove = false;
				this.Prompt.Yandere.Hiding = true;
				this.Prompt.Yandere.EmptyHands();
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[1].text = "Stop";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
		}
	}

	// Token: 0x040023EB RID: 9195
	public PromptBarScript PromptBar;

	// Token: 0x040023EC RID: 9196
	public PromptScript Prompt;

	// Token: 0x040023ED RID: 9197
	public Transform Exit;

	// Token: 0x040023EE RID: 9198
	public Transform Spot;

	// Token: 0x040023EF RID: 9199
	public string AnimName;

	// Token: 0x040023F0 RID: 9200
	public bool Bench;
}
