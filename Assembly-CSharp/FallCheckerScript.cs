﻿using System;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class FallCheckerScript : MonoBehaviour
{
	// Token: 0x06001484 RID: 5252 RVA: 0x000C84E0 File Offset: 0x000C66E0
	private void OnTriggerEnter(Collider other)
	{
		if (this.Ragdoll == null && other.gameObject.layer == 11)
		{
			this.Ragdoll = other.transform.root.gameObject.GetComponent<RagdollScript>();
			this.Ragdoll.Prompt.Hide();
			this.Ragdoll.Prompt.enabled = false;
			this.Ragdoll.Prompt.MyCollider.enabled = false;
			this.Ragdoll.BloodPoolSpawner.enabled = false;
			this.Ragdoll.HideCollider = this.MyCollider;
			if (!this.Ragdoll.Concealed)
			{
				this.Ragdoll.Police.HiddenCorpses++;
			}
			this.Ragdoll.Hidden = true;
			this.Dumpster.Corpse = this.Ragdoll.gameObject;
			this.Dumpster.Victim = this.Ragdoll.Student;
		}
	}

	// Token: 0x06001485 RID: 5253 RVA: 0x000C85E4 File Offset: 0x000C67E4
	private void Update()
	{
		if (this.Ragdoll != null)
		{
			if (this.Ragdoll.Prompt.transform.localPosition.y > -10.5f)
			{
				this.Ragdoll.Prompt.transform.localEulerAngles = new Vector3(-90f, 90f, 0f);
				this.Ragdoll.AllColliders[2].transform.localEulerAngles = Vector3.zero;
				this.Ragdoll.AllColliders[7].transform.localEulerAngles = new Vector3(0f, 0f, -80f);
				this.Ragdoll.Prompt.transform.position = new Vector3(this.Dumpster.transform.position.x, this.Ragdoll.Prompt.transform.position.y, this.Dumpster.transform.position.z);
				return;
			}
			base.GetComponent<AudioSource>().Play();
			this.Dumpster.Slide = true;
			this.Ragdoll = null;
		}
	}

	// Token: 0x04001FD1 RID: 8145
	public DumpsterLidScript Dumpster;

	// Token: 0x04001FD2 RID: 8146
	public RagdollScript Ragdoll;

	// Token: 0x04001FD3 RID: 8147
	public Collider MyCollider;
}
