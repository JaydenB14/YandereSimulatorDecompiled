﻿using System;
using UnityEngine;

// Token: 0x0200027E RID: 638
public class DemonSlashScript : MonoBehaviour
{
	// Token: 0x06001379 RID: 4985 RVA: 0x000B34D1 File Offset: 0x000B16D1
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x0600137A RID: 4986 RVA: 0x000B34E0 File Offset: 0x000B16E0
	private void Update()
	{
		if (this.MyCollider.enabled)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.33333334f)
			{
				this.MyCollider.enabled = false;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x0600137B RID: 4987 RVA: 0x000B3530 File Offset: 0x000B1730
	private void OnTriggerEnter(Collider other)
	{
		Transform root = other.gameObject.transform.root;
		StudentScript component = root.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID != 1 && component.Alive)
		{
			component.DeathType = DeathType.EasterEgg;
			if (!component.Male)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.FemaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
			}
			else
			{
				UnityEngine.Object.Instantiate<GameObject>(this.MaleBloodyScream, root.transform.position + Vector3.up, Quaternion.identity);
			}
			component.BecomeRagdoll();
			component.Ragdoll.Dismember();
			this.MyAudio.Play();
		}
	}

	// Token: 0x04001CB9 RID: 7353
	public GameObject FemaleBloodyScream;

	// Token: 0x04001CBA RID: 7354
	public GameObject MaleBloodyScream;

	// Token: 0x04001CBB RID: 7355
	public AudioSource MyAudio;

	// Token: 0x04001CBC RID: 7356
	public Collider MyCollider;

	// Token: 0x04001CBD RID: 7357
	public float Timer;
}
