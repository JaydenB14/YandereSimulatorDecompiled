﻿using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MatchmakingResultsWindowScript : MonoBehaviour
{
	// Token: 0x06001986 RID: 6534 RVA: 0x001041FC File Offset: 0x001023FC
	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			this.AdviceWindow.HUDElement[1].SetActive(true);
			this.AdviceWindow.HUDElement[2].SetActive(true);
			this.AdviceWindow.HUDElement[3].SetActive(true);
			base.gameObject.SetActive(false);
			Time.timeScale = 1f;
		}
	}

	// Token: 0x040028CE RID: 10446
	public AdviceWindowScript AdviceWindow;
}
