﻿using System;
using UnityEngine;

// Token: 0x02000278 RID: 632
public class DelinquentManagerScript : MonoBehaviour
{
	// Token: 0x06001365 RID: 4965 RVA: 0x000B1197 File Offset: 0x000AF397
	private void Start()
	{
		this.Delinquents.SetActive(false);
		this.TimerMax = 15f;
		this.Timer = 15f;
		this.Phase++;
	}

	// Token: 0x06001366 RID: 4966 RVA: 0x000B11CC File Offset: 0x000AF3CC
	private void Update()
	{
		this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0f, Time.deltaTime);
		if (this.Attacker != null && !this.Attacker.Attacking && this.Attacker.ExpressedSurprise && this.Attacker.Run && !this.Aggro)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			component.clip = this.Attacker.AggroClips[UnityEngine.Random.Range(0, this.Attacker.AggroClips.Length)];
			component.Play();
			this.Aggro = true;
		}
		if (this.Panel.activeInHierarchy && this.Clock.HourTime > this.NextTime[this.Phase])
		{
			if (this.Phase == 3 && this.Clock.HourTime > 7.25f)
			{
				this.TimerMax = 75f;
				this.Timer = 75f;
				this.Phase++;
			}
			else if (this.Phase == 5 && this.Clock.HourTime > 8.5f)
			{
				this.TimerMax = 285f;
				this.Timer = 285f;
				this.Phase++;
			}
			else if (this.Phase == 7 && this.Clock.HourTime > 13.25f)
			{
				this.TimerMax = 15f;
				this.Timer = 15f;
				this.Phase++;
			}
			else if (this.Phase == 9 && this.Clock.HourTime > 13.5f)
			{
				this.TimerMax = 135f;
				this.Timer = 135f;
				this.Phase++;
			}
			if (this.Attacker == null)
			{
				this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / 60f);
			}
			this.Circle.fillAmount = 1f - this.Timer / this.TimerMax;
			if (this.Timer <= 0f)
			{
				this.Delinquents.SetActive(!this.Delinquents.activeInHierarchy);
				if (this.Phase < 8)
				{
					this.Phase++;
					return;
				}
				this.Delinquents.SetActive(false);
				this.Panel.SetActive(false);
			}
		}
	}

	// Token: 0x06001367 RID: 4967 RVA: 0x000B1444 File Offset: 0x000AF644
	public void CheckTime()
	{
		if (this.Clock.HourTime < 13f)
		{
			this.Delinquents.SetActive(false);
			this.TimerMax = 15f;
			this.Timer = 15f;
			this.Phase = 6;
			return;
		}
		if (this.Clock.HourTime < 15.5f)
		{
			this.Delinquents.SetActive(false);
			this.TimerMax = 15f;
			this.Timer = 15f;
			this.Phase = 8;
		}
	}

	// Token: 0x06001368 RID: 4968 RVA: 0x000B14C8 File Offset: 0x000AF6C8
	public void EasterEgg()
	{
		this.RapBeat.SetActive(true);
		this.Mirror.Limit++;
	}

	// Token: 0x04001C42 RID: 7234
	public GameObject Delinquents;

	// Token: 0x04001C43 RID: 7235
	public GameObject RapBeat;

	// Token: 0x04001C44 RID: 7236
	public GameObject Panel;

	// Token: 0x04001C45 RID: 7237
	public float[] NextTime;

	// Token: 0x04001C46 RID: 7238
	public DelinquentScript Attacker;

	// Token: 0x04001C47 RID: 7239
	public MirrorScript Mirror;

	// Token: 0x04001C48 RID: 7240
	public UILabel TimeLabel;

	// Token: 0x04001C49 RID: 7241
	public ClockScript Clock;

	// Token: 0x04001C4A RID: 7242
	public UISprite Circle;

	// Token: 0x04001C4B RID: 7243
	public float SpeechTimer;

	// Token: 0x04001C4C RID: 7244
	public float TimerMax;

	// Token: 0x04001C4D RID: 7245
	public float Timer;

	// Token: 0x04001C4E RID: 7246
	public bool Aggro;

	// Token: 0x04001C4F RID: 7247
	public int Phase = 1;
}
