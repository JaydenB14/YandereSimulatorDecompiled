﻿using System;
using UnityEngine;

// Token: 0x020003CD RID: 973
public class ReputationScript : MonoBehaviour
{
	// Token: 0x06001B4E RID: 6990 RVA: 0x00132BB7 File Offset: 0x00130DB7
	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			this.MissionMode = true;
		}
		if (GameGlobals.Eighties)
		{
			this.BecomeEighties();
		}
		this.Reputation = PlayerGlobals.Reputation;
		this.RepUpdateLabel.enabled = true;
	}

	// Token: 0x06001B4F RID: 6991 RVA: 0x00132BEC File Offset: 0x00130DEC
	private void Update()
	{
		switch (this.Phase)
		{
		case 1:
			if (this.Clock.PresentTime / 60f > 8.5f)
			{
				this.Phase++;
			}
			break;
		case 2:
			if (this.Clock.PresentTime / 60f > 13.5f)
			{
				this.Phase++;
			}
			break;
		case 3:
			if (this.Clock.PresentTime / 60f > 18f)
			{
				this.RepUpdateLabel.text = "REP WILL UPDATE AFTER SCHOOL";
				this.Phase++;
			}
			break;
		}
		if (this.CheckedRep < this.Phase && !this.StudentManager.Yandere.Struggling && !this.StudentManager.Yandere.DelinquentFighting && !this.StudentManager.Yandere.Pickpocketing && !this.StudentManager.Yandere.Noticed && !this.ArmDetector.SummonDemon)
		{
			this.UpdateRep();
			if (this.Reputation <= -100f)
			{
				this.Portal.EndDay();
			}
		}
		if (!this.MissionMode)
		{
			if (this.LerpTimer < 1f)
			{
				this.CurrentRepMarker.localPosition = new Vector3(Mathf.Lerp(this.CurrentRepMarker.localPosition.x, -830f + this.Reputation * 1.5f, Time.deltaTime * 10f), this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
				this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
				this.LerpTimer += Time.deltaTime;
			}
			if (this.PendingRep != this.PreviousRep)
			{
				this.PreviousRep = this.PendingRep;
				this.LerpTimer = 0f;
				if (this.PendingRep > 0f)
				{
					this.PendingRepLabel.text = "+" + this.PendingRep.ToString("F1");
					this.RepUpdateLabel.enabled = true;
				}
				else if (this.PendingRep < 0f)
				{
					this.StudentManager.TutorialWindow.ShowRepMessage = true;
					this.PendingRepLabel.text = this.PendingRep.ToString("F1");
					this.RepUpdateLabel.enabled = true;
				}
				else
				{
					this.RepUpdateLabel.enabled = false;
					this.PendingRepLabel.text = string.Empty;
				}
			}
		}
		else
		{
			this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, -980f + this.PendingRep * -3f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
			if (this.PendingRep < 0f)
			{
				this.PendingRepLabel.text = (-this.PendingRep).ToString("F1");
			}
			else
			{
				this.PendingRepLabel.text = string.Empty;
			}
		}
		if (this.CurrentRepMarker.localPosition.x < -980f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-980f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x < -980f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-980f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		if (this.CurrentRepMarker.localPosition.x > -680f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-680f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x > -680f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-680f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
	}

	// Token: 0x06001B50 RID: 6992 RVA: 0x001330C8 File Offset: 0x001312C8
	public void UpdateRep()
	{
		this.Reputation += this.PendingRep;
		this.PendingRep = 0f;
		this.CheckedRep++;
		if (this.StudentManager.Yandere.Club == ClubType.Delinquent)
		{
			if (this.Reputation > -33.33333f)
			{
				this.Reputation = -33.33333f;
			}
		}
		else if (this.Reputation > 100f)
		{
			this.Reputation = 100f;
		}
		this.StudentManager.WipePendingRep();
	}

	// Token: 0x06001B51 RID: 6993 RVA: 0x00133152 File Offset: 0x00131352
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
		this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
		this.StudentManager.EightiesifyLabel(this.RepLabel);
	}

	// Token: 0x04002EA2 RID: 11938
	public StudentManagerScript StudentManager;

	// Token: 0x04002EA3 RID: 11939
	public ArmDetectorScript ArmDetector;

	// Token: 0x04002EA4 RID: 11940
	public PortalScript Portal;

	// Token: 0x04002EA5 RID: 11941
	public Transform CurrentRepMarker;

	// Token: 0x04002EA6 RID: 11942
	public Transform PendingRepMarker;

	// Token: 0x04002EA7 RID: 11943
	public UILabel PendingRepLabel;

	// Token: 0x04002EA8 RID: 11944
	public UILabel RepUpdateLabel;

	// Token: 0x04002EA9 RID: 11945
	public UILabel RepLabel;

	// Token: 0x04002EAA RID: 11946
	public ClockScript Clock;

	// Token: 0x04002EAB RID: 11947
	public float Reputation;

	// Token: 0x04002EAC RID: 11948
	public float LerpTimer;

	// Token: 0x04002EAD RID: 11949
	public float PreviousRep;

	// Token: 0x04002EAE RID: 11950
	public float PendingRep;

	// Token: 0x04002EAF RID: 11951
	public int CheckedRep = 1;

	// Token: 0x04002EB0 RID: 11952
	public int Phase;

	// Token: 0x04002EB1 RID: 11953
	public bool MissionMode;
}