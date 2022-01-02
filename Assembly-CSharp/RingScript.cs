﻿using System;
using UnityEngine;

// Token: 0x020003D2 RID: 978
public class RingScript : MonoBehaviour
{
	// Token: 0x06001B67 RID: 7015 RVA: 0x00134DC0 File Offset: 0x00132FC0
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (!this.Prompt.Yandere.StudentManager.YandereVisible)
			{
				SchemeGlobals.SetSchemeStage(2, 2);
				this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.Ring = true;
				this.Prompt.Yandere.TheftTimer = 0.1f;
				this.RingEvent.RingStolen = true;
				base.gameObject.SetActive(false);
				return;
			}
			this.Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone is watching!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x04002EE0 RID: 12000
	public RingEventScript RingEvent;

	// Token: 0x04002EE1 RID: 12001
	public PromptScript Prompt;
}