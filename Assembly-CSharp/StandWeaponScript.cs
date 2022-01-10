﻿using System;
using UnityEngine;

// Token: 0x02000442 RID: 1090
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D00 RID: 7424 RVA: 0x001587EC File Offset: 0x001569EC
	private void Update()
	{
		if (this.Prompt.enabled)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.MoveToStand();
				return;
			}
		}
		else
		{
			base.transform.Rotate(Vector3.forward * (Time.deltaTime * this.RotationSpeed));
			base.transform.Rotate(Vector3.right * (Time.deltaTime * this.RotationSpeed));
			base.transform.Rotate(Vector3.up * (Time.deltaTime * this.RotationSpeed));
		}
	}

	// Token: 0x06001D01 RID: 7425 RVA: 0x0015888C File Offset: 0x00156A8C
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x040034B7 RID: 13495
	public PromptScript Prompt;

	// Token: 0x040034B8 RID: 13496
	public StandScript Stand;

	// Token: 0x040034B9 RID: 13497
	public float RotationSpeed;
}
