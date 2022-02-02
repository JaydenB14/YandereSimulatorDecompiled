﻿using System;
using UnityEngine;

// Token: 0x020004BE RID: 1214
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06001FC4 RID: 8132 RVA: 0x001C14DF File Offset: 0x001BF6DF
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06001FC5 RID: 8133 RVA: 0x001C1514 File Offset: 0x001BF714
	private void Update()
	{
		if (this.Show)
		{
			this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.25f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.44444445f, Time.deltaTime * 10f));
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, base.transform.localPosition.z + Time.deltaTime * 0.09f);
			this.WitnessTimer += Time.deltaTime;
			if (this.WitnessTimer > 5f)
			{
				this.WitnessTimer = 0f;
				this.Show = false;
			}
			if (this.Yandere.Struggling)
			{
				this.WitnessTimer = 0f;
				this.Show = false;
				return;
			}
		}
		else
		{
			this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0f, Time.deltaTime * 10f));
			if (this.MyCamera.enabled && this.MyCamera.rect.width < 0.1f)
			{
				this.MyCamera.enabled = false;
				base.transform.parent = null;
			}
		}
	}

	// Token: 0x040042A4 RID: 17060
	public YandereScript Yandere;

	// Token: 0x040042A5 RID: 17061
	public Transform WitnessPOV;

	// Token: 0x040042A6 RID: 17062
	public float WitnessTimer;

	// Token: 0x040042A7 RID: 17063
	public Camera MyCamera;

	// Token: 0x040042A8 RID: 17064
	public bool Show;
}
