﻿using System;
using UnityEngine;

// Token: 0x020003CF RID: 975
public class RaincoatScript : MonoBehaviour
{
	// Token: 0x06001B81 RID: 7041 RVA: 0x00136B20 File Offset: 0x00134D20
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Invisible)
			{
				this.Prompt.Yandere.WearRaincoat();
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04002F3F RID: 12095
	public PromptScript Prompt;
}
