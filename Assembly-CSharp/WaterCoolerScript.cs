﻿using System;
using UnityEngine;

// Token: 0x020004C3 RID: 1219
public class WaterCoolerScript : MonoBehaviour
{
	// Token: 0x06001FE8 RID: 8168 RVA: 0x001C4154 File Offset: 0x001C2354
	private void Start()
	{
		this.Cylinder.localScale = new Vector3(1f, 0f, 1f);
		this.TripwireTrap.SetActive(false);
		this.Prompt.HideButton[1] = true;
		this.OriginalColor[0] = this.Prompt.Label[1].gradientTop;
		this.OriginalColor[1] = this.Prompt.Label[1].gradientBottom;
	}

	// Token: 0x06001FE9 RID: 8169 RVA: 0x001C41D8 File Offset: 0x001C23D8
	private void Update()
	{
		if (this.Empty)
		{
			if (this.Yandere.PickUp != null)
			{
				if ((this.Yandere.PickUp.Bucket != null && this.Yandere.PickUp.Bucket.Full) || this.Yandere.PickUp.BrownPaint || this.Yandere.PickUp.JerryCan)
				{
					this.Prompt.HideButton[0] = false;
					if (this.Prompt.Circle[0].fillAmount == 0f)
					{
						if (this.Yandere.PickUp.Bucket == null)
						{
							this.BrownPaint = this.Yandere.PickUp.BrownPaint;
							this.Gasoline = this.Yandere.PickUp.JerryCan;
							this.UpdateCylinderColor();
						}
						else
						{
							if (this.Yandere.PickUp.Bucket.DyedBrown)
							{
								this.BrownPaint = true;
							}
							else if (this.Yandere.PickUp.Bucket.Bloodiness > 50f)
							{
								this.Blood = true;
							}
							else if (this.Yandere.PickUp.Bucket.Gasoline)
							{
								this.Gasoline = true;
							}
							else
							{
								this.Water = true;
							}
							this.UpdateCylinderColor();
							this.Yandere.PickUp.Bucket.Empty();
						}
						this.Empty = false;
						this.Timer = 1f;
						this.Prompt.HideButton[0] = true;
					}
				}
				else
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
			this.Prompt.HideButton[1] = true;
		}
		else if (!this.TrapSet)
		{
			if (this.Yandere.Inventory.String && this.Yandere.Inventory.MaskingTape && this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].Type == WeaponType.Knife)
			{
				this.Prompt.HideButton[1] = false;
				this.Prompt.Label[1].applyGradient = false;
				this.Prompt.Label[1].color = Color.red;
				if (this.Prompt.Circle[1].fillAmount == 0f)
				{
					this.Prompt.Circle[1].fillAmount = 1f;
					this.Yandere.SuspiciousActionTimer = 1f;
					this.SetTrap();
				}
			}
			else
			{
				this.Prompt.HideButton[1] = true;
				this.Prompt.Label[1].applyGradient = true;
				this.Prompt.Label[1].gradientTop = this.OriginalColor[0];
				this.Prompt.Label[1].gradientBottom = this.OriginalColor[1];
			}
		}
		else if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			this.Prompt.Label[1].text = "     Create Tripwire Trap";
			this.Prompt.Label[1].applyGradient = false;
			this.Prompt.Label[1].color = Color.red;
			this.TripwireTrap.SetActive(false);
			this.TrapSet = false;
			this.Prompt.HideButton[3] = false;
			this.PickUp.enabled = true;
			this.MyRigidbody.isKinematic = false;
		}
		if (this.Timer > 0f)
		{
			this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
			if (this.Empty)
			{
				this.Cylinder.localScale = Vector3.Lerp(this.Cylinder.localScale, new Vector3(1f, 0f, 1f), Time.deltaTime * 10f);
			}
			else
			{
				this.Cylinder.localScale = Vector3.Lerp(this.Cylinder.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
		}
		if ((this.Prompt.enabled && this.Prompt.DistanceSqr < 1f) || (!this.Prompt.enabled && Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f))
		{
			if (this.WaterCoolerChecklist.alpha < 1f)
			{
				this.WaterCoolerChecklist.alpha = Mathf.MoveTowards(this.WaterCoolerChecklist.alpha, 1f, Time.deltaTime * 10f);
			}
			this.WeaponCheckmark.spriteName = ((this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].Type == WeaponType.Knife) ? "Yes" : "No");
			this.TapeCheckmark.spriteName = (this.Yandere.Inventory.MaskingTape ? "Yes" : "No");
			this.ThreadCheckmark.spriteName = (this.Yandere.Inventory.String ? "Yes" : "No");
			this.LiquidCheckmark.spriteName = ((!this.Empty) ? "Yes" : "No");
			return;
		}
		if (this.WaterCoolerChecklist.alpha > 0f)
		{
			this.WaterCoolerChecklist.alpha = Mathf.MoveTowards(this.WaterCoolerChecklist.alpha, 0f, Time.deltaTime * 10f);
		}
	}

	// Token: 0x06001FEA RID: 8170 RVA: 0x001C47D8 File Offset: 0x001C29D8
	public void UpdateCylinderColor()
	{
		if (this.BrownPaint)
		{
			this.CylinderRenderer.material.color = new Color(0.5f, 0.25f, 0f, 1f);
			return;
		}
		if (this.Blood)
		{
			this.CylinderRenderer.material.color = new Color(1f, 0f, 0f, 1f);
			return;
		}
		if (this.Gasoline)
		{
			this.CylinderRenderer.material.color = new Color(1f, 1f, 0f, 1f);
			return;
		}
		this.CylinderRenderer.material.color = new Color(0f, 1f, 1f, 1f);
	}

	// Token: 0x06001FEB RID: 8171 RVA: 0x001C48A4 File Offset: 0x001C2AA4
	public void SetTrap()
	{
		this.Prompt.Label[1].text = "     Remove Trap";
		this.Prompt.Label[1].applyGradient = true;
		this.Prompt.Label[1].gradientTop = this.OriginalColor[0];
		this.Prompt.Label[1].gradientBottom = this.OriginalColor[1];
		this.Prompt.Label[1].color = Color.white;
		this.TripwireTrap.SetActive(true);
		this.TrapSet = true;
		this.Prompt.HideButton[1] = false;
		this.Prompt.HideButton[3] = true;
		this.PickUp.enabled = false;
		this.MyRigidbody.isKinematic = true;
	}

	// Token: 0x040042EC RID: 17132
	public StringTrapScript Tripwire;

	// Token: 0x040042ED RID: 17133
	public YandereScript Yandere;

	// Token: 0x040042EE RID: 17134
	public PickUpScript PickUp;

	// Token: 0x040042EF RID: 17135
	public PromptScript Prompt;

	// Token: 0x040042F0 RID: 17136
	public UIPanel WaterCoolerChecklist;

	// Token: 0x040042F1 RID: 17137
	public UISprite LiquidCheckmark;

	// Token: 0x040042F2 RID: 17138
	public UISprite WeaponCheckmark;

	// Token: 0x040042F3 RID: 17139
	public UISprite ThreadCheckmark;

	// Token: 0x040042F4 RID: 17140
	public UISprite TapeCheckmark;

	// Token: 0x040042F5 RID: 17141
	public Renderer CylinderRenderer;

	// Token: 0x040042F6 RID: 17142
	public GameObject TripwireTrap;

	// Token: 0x040042F7 RID: 17143
	public Rigidbody MyRigidbody;

	// Token: 0x040042F8 RID: 17144
	public Transform Cylinder;

	// Token: 0x040042F9 RID: 17145
	public bool BrownPaint;

	// Token: 0x040042FA RID: 17146
	public bool Gasoline;

	// Token: 0x040042FB RID: 17147
	public bool Water;

	// Token: 0x040042FC RID: 17148
	public bool Blood;

	// Token: 0x040042FD RID: 17149
	public bool TrapSet;

	// Token: 0x040042FE RID: 17150
	public bool Empty;

	// Token: 0x040042FF RID: 17151
	public float Timer;

	// Token: 0x04004300 RID: 17152
	public Color[] OriginalColor;
}
