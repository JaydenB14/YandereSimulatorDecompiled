﻿using System;
using UnityEngine;

// Token: 0x020003EB RID: 1003
public class RoseBushScript : MonoBehaviour
{
	// Token: 0x06001BCC RID: 7116 RVA: 0x00144AD8 File Offset: 0x00142CD8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Rose = true;
			base.enabled = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x040030CB RID: 12491
	public PromptScript Prompt;
}
