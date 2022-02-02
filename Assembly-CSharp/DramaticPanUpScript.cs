﻿using System;
using UnityEngine;

// Token: 0x0200028D RID: 653
public class DramaticPanUpScript : MonoBehaviour
{
	// Token: 0x060013B0 RID: 5040 RVA: 0x000BA48C File Offset: 0x000B868C
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Pan = true;
		}
		if (this.Pan)
		{
			this.Power += Time.deltaTime * 0.5f;
			this.Height = Mathf.Lerp(this.Height, 1.4f, this.Power * Time.deltaTime);
			base.transform.localPosition = new Vector3(0f, this.Height, 1f);
		}
	}

	// Token: 0x04001D40 RID: 7488
	public bool Pan;

	// Token: 0x04001D41 RID: 7489
	public float Height;

	// Token: 0x04001D42 RID: 7490
	public float Power;
}
