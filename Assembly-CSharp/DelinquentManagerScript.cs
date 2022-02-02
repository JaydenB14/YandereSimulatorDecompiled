﻿using System;
using UnityEngine;

// Token: 0x02000277 RID: 631
public class DelinquentManagerScript : MonoBehaviour
{
	// Token: 0x06001361 RID: 4961 RVA: 0x000B119F File Offset: 0x000AF39F
	private void Start()
	{
		this.Delinquents.SetActive(false);
		this.TimerMax = 15f;
		this.Timer = 15f;
		this.Phase++;
	}

	// Token: 0x06001362 RID: 4962 RVA: 0x000B11D4 File Offset: 0x000AF3D4
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

	// Token: 0x06001363 RID: 4963 RVA: 0x000B144C File Offset: 0x000AF64C
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

	// Token: 0x06001364 RID: 4964 RVA: 0x000B14D0 File Offset: 0x000AF6D0
	public void EasterEgg()
	{
		this.RapBeat.SetActive(true);
		this.Mirror.Limit++;
	}

	// Token: 0x04001C3C RID: 7228
	public GameObject Delinquents;

	// Token: 0x04001C3D RID: 7229
	public GameObject RapBeat;

	// Token: 0x04001C3E RID: 7230
	public GameObject Panel;

	// Token: 0x04001C3F RID: 7231
	public float[] NextTime;

	// Token: 0x04001C40 RID: 7232
	public DelinquentScript Attacker;

	// Token: 0x04001C41 RID: 7233
	public MirrorScript Mirror;

	// Token: 0x04001C42 RID: 7234
	public UILabel TimeLabel;

	// Token: 0x04001C43 RID: 7235
	public ClockScript Clock;

	// Token: 0x04001C44 RID: 7236
	public UISprite Circle;

	// Token: 0x04001C45 RID: 7237
	public float SpeechTimer;

	// Token: 0x04001C46 RID: 7238
	public float TimerMax;

	// Token: 0x04001C47 RID: 7239
	public float Timer;

	// Token: 0x04001C48 RID: 7240
	public bool Aggro;

	// Token: 0x04001C49 RID: 7241
	public int Phase = 1;
}
