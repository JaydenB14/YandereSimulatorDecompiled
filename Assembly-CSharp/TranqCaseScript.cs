﻿using System;
using UnityEngine;

// Token: 0x0200048B RID: 1163
public class TranqCaseScript : MonoBehaviour
{
	// Token: 0x06001F31 RID: 7985 RVA: 0x001B9E47 File Offset: 0x001B8047
	private void Start()
	{
		this.Prompt.enabled = false;
	}

	// Token: 0x06001F32 RID: 7986 RVA: 0x001B9E58 File Offset: 0x001B8058
	private void Update()
	{
		if (this.Yandere.transform.position.x > base.transform.position.x && Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f)
		{
			if (this.Yandere.Dragging)
			{
				if (this.Ragdoll == null)
				{
					this.Ragdoll = this.Yandere.Ragdoll.GetComponent<RagdollScript>();
				}
				if (this.Ragdoll.Tranquil)
				{
					if (!this.Prompt.enabled)
					{
						this.Prompt.enabled = true;
					}
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.enabled && this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.Yandere.TranquilHiding = true;
				this.Yandere.CanMove = false;
				this.Prompt.enabled = false;
				this.Prompt.Hide();
				this.Ragdoll.TranqCase = this;
				this.VictimClubType = this.Ragdoll.Student.Club;
				this.VictimID = this.Ragdoll.StudentID;
				this.Door.Prompt.enabled = true;
				this.Door.enabled = true;
				this.Occupied = true;
				this.Animate = true;
				this.Open = true;
			}
		}
		if (this.Animate)
		{
			if (this.Open)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 105f, Time.deltaTime * 10f);
			}
			else
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
				this.Ragdoll.Student.OsanaHairL.transform.localScale = Vector3.MoveTowards(this.Ragdoll.Student.OsanaHairL.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
				this.Ragdoll.Student.OsanaHairR.transform.localScale = Vector3.MoveTowards(this.Ragdoll.Student.OsanaHairR.transform.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
				if (this.Rotation < 1f)
				{
					this.Animate = false;
					this.Rotation = 0f;
				}
			}
			this.Hinge.localEulerAngles = new Vector3(0f, 0f, this.Rotation);
		}
	}

	// Token: 0x04004122 RID: 16674
	public YandereScript Yandere;

	// Token: 0x04004123 RID: 16675
	public RagdollScript Ragdoll;

	// Token: 0x04004124 RID: 16676
	public PromptScript Prompt;

	// Token: 0x04004125 RID: 16677
	public DoorScript Door;

	// Token: 0x04004126 RID: 16678
	public Transform Hinge;

	// Token: 0x04004127 RID: 16679
	public bool Occupied;

	// Token: 0x04004128 RID: 16680
	public bool Open;

	// Token: 0x04004129 RID: 16681
	public int VictimID;

	// Token: 0x0400412A RID: 16682
	public ClubType VictimClubType;

	// Token: 0x0400412B RID: 16683
	public float Rotation;

	// Token: 0x0400412C RID: 16684
	public bool Animate;
}
