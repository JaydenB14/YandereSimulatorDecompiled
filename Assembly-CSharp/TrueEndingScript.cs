﻿using System;
using UnityEngine;

// Token: 0x02000487 RID: 1159
public class TrueEndingScript : MonoBehaviour
{
	// Token: 0x06001EFE RID: 7934 RVA: 0x001B3EB7 File Offset: 0x001B20B7
	private void Start()
	{
		this.Darkness.alpha = 1f;
		this.Subtitle.text = "";
	}

	// Token: 0x06001EFF RID: 7935 RVA: 0x001B3EDC File Offset: 0x001B20DC
	private void Update()
	{
		this.Timer += Time.deltaTime;
		this.Ambience.volume = Mathf.MoveTowards(this.Ambience.volume, 0.25f, Time.deltaTime * 0.25f);
		if (this.Timer > 1f)
		{
			if (!this.FadeOut)
			{
				this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime);
			}
			else
			{
				this.Logo.alpha = Mathf.MoveTowards(this.Logo.alpha, 0f, Time.deltaTime * 0.33333f);
				if (this.Logo.alpha == 0f)
				{
					this.TrueEndingPanel.SetActive(false);
					this.TimelinePanel.SetActive(true);
					base.enabled = false;
				}
			}
			this.WaitTimer += Time.deltaTime;
			if (this.WaitTimer > 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					this.SpeechTimer = 1f;
					if (this.Phase < 16)
					{
						this.MyAudio.Stop();
					}
				}
				if (!this.MyAudio.isPlaying && this.Darkness.alpha == 0f)
				{
					this.SpeechTimer += Time.deltaTime;
					if (this.SpeechTimer > 0.5f && this.Phase < this.Clip.Length - 1)
					{
						this.Phase++;
						this.Subtitle.text = this.Text[this.Phase];
						this.MyAudio.clip = this.Clip[this.Phase];
						this.MyAudio.Play();
						if (this.Phase == this.Clip.Length - 1)
						{
							this.Logo.mainTexture = this.DarkLogo;
							this.Ambience.Stop();
							this.BuildUp.Stop();
							this.Shake = true;
						}
						else if (this.Phase == this.Clip.Length - 2)
						{
							this.BuildUp.Play();
						}
						this.SpeechTimer = 0f;
					}
				}
			}
		}
		if (this.Shake)
		{
			this.Logo.transform.localPosition = new Vector3(UnityEngine.Random.Range(-1f, 1f) * this.Intensity, UnityEngine.Random.Range(-1f, 1f) * this.Intensity, UnityEngine.Random.Range(-1f, 1f) * this.Intensity);
			this.Intensity = Mathf.MoveTowards(this.Intensity, 0f, Time.deltaTime * 100f);
			if (this.Intensity == 0f)
			{
				this.FadeTimer += Time.deltaTime;
				if (this.FadeTimer > 5f && !this.FadeOut)
				{
					this.Darkness.color = new Color(0f, 0f, 0f, 0f);
					this.FadeOut = true;
				}
			}
		}
	}

	// Token: 0x04004078 RID: 16504
	public GameObject TrueEndingPanel;

	// Token: 0x04004079 RID: 16505
	public GameObject TimelinePanel;

	// Token: 0x0400407A RID: 16506
	public AudioSource Ambience;

	// Token: 0x0400407B RID: 16507
	public AudioSource MyAudio;

	// Token: 0x0400407C RID: 16508
	public AudioSource BuildUp;

	// Token: 0x0400407D RID: 16509
	public UISprite Darkness;

	// Token: 0x0400407E RID: 16510
	public Texture DarkLogo;

	// Token: 0x0400407F RID: 16511
	public AudioClip[] Clip;

	// Token: 0x04004080 RID: 16512
	public UILabel Subtitle;

	// Token: 0x04004081 RID: 16513
	public UITexture Logo;

	// Token: 0x04004082 RID: 16514
	public string[] Text;

	// Token: 0x04004083 RID: 16515
	public float SpeechTimer;

	// Token: 0x04004084 RID: 16516
	public float FadeTimer;

	// Token: 0x04004085 RID: 16517
	public float WaitTimer;

	// Token: 0x04004086 RID: 16518
	public float Timer;

	// Token: 0x04004087 RID: 16519
	public float Intensity;

	// Token: 0x04004088 RID: 16520
	public bool FadeOut;

	// Token: 0x04004089 RID: 16521
	public bool Shake;

	// Token: 0x0400408A RID: 16522
	public int Phase;
}
