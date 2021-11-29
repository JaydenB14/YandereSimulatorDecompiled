﻿using System;
using UnityEngine;

// Token: 0x0200027C RID: 636
public class DemonScript : MonoBehaviour
{
	// Token: 0x0600136F RID: 4975 RVA: 0x000B24F4 File Offset: 0x000B06F4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			this.Communing = true;
		}
		if (this.DemonID == 1)
		{
			if ((double)Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 2.5)
			{
				if (!this.Open)
				{
					AudioSource.PlayClipAtPoint(this.MouthOpen, base.transform.position);
				}
				this.Open = true;
			}
			else
			{
				if (this.Open)
				{
					AudioSource.PlayClipAtPoint(this.MouthClose, base.transform.position);
				}
				this.Open = false;
			}
			if (this.Open)
			{
				this.Value = Mathf.Lerp(this.Value, 100f, Time.deltaTime * 10f);
			}
			else
			{
				this.Value = Mathf.Lerp(this.Value, 0f, Time.deltaTime * 10f);
			}
			this.Face.SetBlendShapeWeight(0, this.Value);
		}
		if (this.Communing)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.Phase == 1)
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
				if (this.Darkness.color.a == 1f)
				{
					this.DemonSubtitle.transform.localPosition = Vector3.zero;
					this.DemonSubtitle.text = this.Lines[this.ID];
					this.DemonSubtitle.color = this.MyColor;
					this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, 0f);
					this.Phase++;
					if (this.Clips[this.ID] != null)
					{
						component.clip = this.Clips[this.ID];
						component.Play();
						return;
					}
				}
			}
			else if (this.Phase == 2)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 1f, Time.deltaTime));
				this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 1f, Time.deltaTime));
				if (this.DemonSubtitle.color.a > 0.9f && Input.GetButtonDown("A"))
				{
					this.Phase++;
					return;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity), UnityEngine.Random.Range(-this.Intensity, this.Intensity));
				this.DemonSubtitle.color = new Color(this.DemonSubtitle.color.r, this.DemonSubtitle.color.g, this.DemonSubtitle.color.b, Mathf.MoveTowards(this.DemonSubtitle.color.a, 0f, Time.deltaTime));
				if (this.DemonSubtitle.color.a == 0f)
				{
					this.ID++;
					if (this.ID >= this.Lines.Length)
					{
						this.Phase++;
						return;
					}
					this.Phase--;
					this.DemonSubtitle.text = this.Lines[this.ID];
					if (this.Clips[this.ID] != null)
					{
						component.clip = this.Clips[this.ID];
						component.Play();
						return;
					}
				}
			}
			else
			{
				this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
				this.Button.color = new Color(this.Button.color.r, this.Button.color.g, this.Button.color.b, Mathf.MoveTowards(this.Button.color.a, 0f, Time.deltaTime));
				if (this.Darkness.color.a == 0f)
				{
					this.Yandere.CanMove = true;
					this.Communing = false;
					this.Phase = 1;
					this.ID = 0;
					SchoolGlobals.SetDemonActive(this.DemonID, true);
					StudentGlobals.FemaleUniform = 1;
					StudentGlobals.MaleUniform = 1;
					GameGlobals.Paranormal = true;
				}
			}
		}
	}

	// Token: 0x04001C7F RID: 7295
	public SkinnedMeshRenderer Face;

	// Token: 0x04001C80 RID: 7296
	public YandereScript Yandere;

	// Token: 0x04001C81 RID: 7297
	public PromptScript Prompt;

	// Token: 0x04001C82 RID: 7298
	public UILabel DemonSubtitle;

	// Token: 0x04001C83 RID: 7299
	public UISprite Darkness;

	// Token: 0x04001C84 RID: 7300
	public UISprite Button;

	// Token: 0x04001C85 RID: 7301
	public AudioClip MouthOpen;

	// Token: 0x04001C86 RID: 7302
	public AudioClip MouthClose;

	// Token: 0x04001C87 RID: 7303
	public AudioClip[] Clips;

	// Token: 0x04001C88 RID: 7304
	public string[] Lines;

	// Token: 0x04001C89 RID: 7305
	public bool Communing;

	// Token: 0x04001C8A RID: 7306
	public bool Open;

	// Token: 0x04001C8B RID: 7307
	public float Intensity = 1f;

	// Token: 0x04001C8C RID: 7308
	public float Value;

	// Token: 0x04001C8D RID: 7309
	public Color MyColor;

	// Token: 0x04001C8E RID: 7310
	public int DemonID;

	// Token: 0x04001C8F RID: 7311
	public int Phase = 1;

	// Token: 0x04001C90 RID: 7312
	public int ID;
}