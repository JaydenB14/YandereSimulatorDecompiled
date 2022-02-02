﻿using System;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class StopAnimationScript : MonoBehaviour
{
	// Token: 0x06001D10 RID: 7440 RVA: 0x0015B3F3 File Offset: 0x001595F3
	private void Start()
	{
		this.StudentManager = GameObject.Find("StudentManager").GetComponent<StudentManagerScript>();
		this.Anim = base.GetComponent<Animation>();
	}

	// Token: 0x06001D11 RID: 7441 RVA: 0x0015B418 File Offset: 0x00159618
	private void Update()
	{
		if (this.StudentManager.DisableFarAnims)
		{
			if (Vector3.Distance(this.Yandere.position, base.transform.position) > 15f)
			{
				if (this.Anim.enabled)
				{
					this.Anim.enabled = false;
					return;
				}
			}
			else if (!this.Anim.enabled)
			{
				this.Anim.enabled = true;
				return;
			}
		}
		else if (!this.Anim.enabled)
		{
			this.Anim.enabled = true;
		}
	}

	// Token: 0x040034DB RID: 13531
	public StudentManagerScript StudentManager;

	// Token: 0x040034DC RID: 13532
	public Transform Yandere;

	// Token: 0x040034DD RID: 13533
	private Animation Anim;
}
