﻿using System;
using UnityEngine;

// Token: 0x0200046F RID: 1135
public class TapePlayerScript : MonoBehaviour
{
	// Token: 0x06001ECA RID: 7882 RVA: 0x001B3B00 File Offset: 0x001B1D00
	private void Start()
	{
		this.Tape.SetActive(false);
	}

	// Token: 0x06001ECB RID: 7883 RVA: 0x001B3B10 File Offset: 0x001B1D10
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.HeartCamera.enabled = false;
			this.Yandere.RPGCamera.enabled = false;
			this.TapePlayerMenu.TimeBar.gameObject.SetActive(true);
			this.TapePlayerMenu.List.gameObject.SetActive(true);
			this.TapePlayerCamera.enabled = true;
			this.TapePlayerMenu.UpdateLabels();
			this.TapePlayerMenu.Show = true;
			this.NoteWindow.SetActive(false);
			this.Yandere.CanMove = false;
			this.Yandere.HUD.alpha = 0f;
			Time.timeScale = 0.0001f;
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[1].text = "EXIT";
			this.PromptBar.Label[4].text = "CHOOSE";
			this.PromptBar.Label[5].text = "CATEGORY";
			this.TapePlayerMenu.CheckSelection();
			this.PromptBar.Show = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Spin)
		{
			Transform transform = this.Rolls[0];
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + 0.016666668f * (360f * this.SpinSpeed), transform.localEulerAngles.z);
			Transform transform2 = this.Rolls[1];
			transform2.localEulerAngles = new Vector3(transform2.localEulerAngles.x, transform2.localEulerAngles.y + 0.016666668f * (360f * this.SpinSpeed), transform2.localEulerAngles.z);
		}
		if (this.FastForward)
		{
			this.FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.FFButton.localEulerAngles.x, 6.25f, 1.6666666f), this.FFButton.localEulerAngles.y, this.FFButton.localEulerAngles.z);
			this.SpinSpeed = 2f;
		}
		else
		{
			this.FFButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.FFButton.localEulerAngles.x, 0f, 1.6666666f), this.FFButton.localEulerAngles.y, this.FFButton.localEulerAngles.z);
			this.SpinSpeed = 1f;
		}
		if (this.Rewind)
		{
			this.RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.RWButton.localEulerAngles.x, 6.25f, 1.6666666f), this.RWButton.localEulerAngles.y, this.RWButton.localEulerAngles.z);
			this.SpinSpeed = -2f;
			return;
		}
		this.RWButton.localEulerAngles = new Vector3(Mathf.MoveTowards(this.RWButton.localEulerAngles.x, 0f, 1.6666666f), this.RWButton.localEulerAngles.y, this.RWButton.localEulerAngles.z);
	}

	// Token: 0x04003FD1 RID: 16337
	public TapePlayerMenuScript TapePlayerMenu;

	// Token: 0x04003FD2 RID: 16338
	public PromptBarScript PromptBar;

	// Token: 0x04003FD3 RID: 16339
	public YandereScript Yandere;

	// Token: 0x04003FD4 RID: 16340
	public PromptScript Prompt;

	// Token: 0x04003FD5 RID: 16341
	public Transform RWButton;

	// Token: 0x04003FD6 RID: 16342
	public Transform FFButton;

	// Token: 0x04003FD7 RID: 16343
	public Camera TapePlayerCamera;

	// Token: 0x04003FD8 RID: 16344
	public Transform[] Rolls;

	// Token: 0x04003FD9 RID: 16345
	public GameObject NoteWindow;

	// Token: 0x04003FDA RID: 16346
	public GameObject Tape;

	// Token: 0x04003FDB RID: 16347
	public bool FastForward;

	// Token: 0x04003FDC RID: 16348
	public bool Rewind;

	// Token: 0x04003FDD RID: 16349
	public bool Spin;

	// Token: 0x04003FDE RID: 16350
	public float SpinSpeed;
}
