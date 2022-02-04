﻿using System;
using UnityEngine;

// Token: 0x020004B8 RID: 1208
public class WeaponMenuScript : MonoBehaviour
{
	// Token: 0x06001FA4 RID: 8100 RVA: 0x001BCED0 File Offset: 0x001BB0D0
	private void Start()
	{
		this.KeyboardMenu.localScale = Vector3.zero;
		base.transform.localScale = Vector3.zero;
		this.OriginalColor = this.BG[1].color;
		this.UpdateSprites();
	}

	// Token: 0x06001FA5 RID: 8101 RVA: 0x001BCF0C File Offset: 0x001BB10C
	private void Update()
	{
		if (!this.PauseScreen.Show && !this.Yandere.DebugMenu.activeInHierarchy)
		{
			if ((this.Yandere.CanMove && !this.Yandere.Aiming) || (this.Yandere.Chased && !this.Yandere.Struggling && !this.Yandere.Sprayed && !this.Yandere.DelinquentFighting))
			{
				if ((this.IM.DPadUp && this.IM.TappedUp) || (this.IM.DPadDown && this.IM.TappedDown) || (this.IM.DPadLeft && this.IM.TappedLeft) || (this.IM.DPadRight && this.IM.TappedRight))
				{
					this.Yandere.EmptyHands();
					if (this.IM.DPadLeft)
					{
						this.Button.localPosition = new Vector3(-320f, 0f, 0f);
						this.Selected = 1;
					}
					else if (this.IM.DPadRight)
					{
						this.Button.localPosition = new Vector3(320f, 0f, 0f);
						this.Selected = 2;
					}
					else if (this.IM.DPadUp)
					{
						if (!this.Show)
						{
							this.Selected = 6;
						}
						if (this.Selected == 6)
						{
							this.Button.localPosition = new Vector3(64f, 190f, 0f);
							this.Selected = 3;
						}
						else
						{
							this.Button.localPosition = new Vector3(64f, 380f, 0f);
							this.Selected = 6;
						}
					}
					else if (this.IM.DPadDown)
					{
						if (this.Selected == 4)
						{
							this.Button.localPosition = new Vector3(64f, -250f, 0f);
							this.Selected = 5;
						}
						else
						{
							this.Button.localPosition = new Vector3(64f, -125f, 0f);
							this.Selected = 4;
						}
					}
					if (this.IM.DPadLeft || this.IM.DPadRight || this.IM.DPadUp || this.Yandere.Mask != null)
					{
						this.KeyboardShow = false;
						this.Panel.enabled = true;
						this.Show = true;
					}
					this.UpdateSprites();
				}
				if (!this.Yandere.EasterEggMenu.activeInHierarchy && (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Alpha6)))
				{
					this.Yandere.EmptyHands();
					this.KeyboardPanel.enabled = true;
					this.KeyboardShow = true;
					this.Show = false;
					this.Timer = 0f;
					if (Input.GetKeyDown(KeyCode.Alpha1))
					{
						this.Selected = 4;
						if (this.Yandere.Equipped > 0)
						{
							this.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0f;
							this.Yandere.ReachWeight = 1f;
							this.Yandere.Unequip();
						}
						if (this.Yandere.PickUp != null)
						{
							this.Yandere.PickUp.Drop();
						}
						this.Yandere.Mopping = false;
					}
					else if (Input.GetKeyDown(KeyCode.Alpha2))
					{
						this.Selected = 1;
						this.Equip();
					}
					else if (Input.GetKeyDown(KeyCode.Alpha3))
					{
						this.Selected = 2;
						this.Equip();
					}
					else if (Input.GetKeyDown(KeyCode.Alpha4))
					{
						this.Selected = 3;
						if (this.Yandere.Container != null)
						{
							this.Yandere.ObstacleDetector.gameObject.SetActive(true);
						}
					}
					else if (Input.GetKeyDown(KeyCode.Alpha5))
					{
						this.Selected = 5;
						this.DropMask();
					}
					else if (Input.GetKeyDown(KeyCode.Alpha6))
					{
						this.Selected = 6;
						this.DropBookbag();
					}
					this.UpdateSprites();
				}
			}
			if (this.Yandere.CanMove || (this.Yandere.Chased && !this.Yandere.Sprayed && !this.StudentManager.PinningDown))
			{
				if (!this.Show)
				{
					if (Input.GetAxis("DpadY") < -0.5f)
					{
						if (this.Yandere.Equipped > 0)
						{
							if (this.Yandere.EquippedWeapon.Concealable)
							{
								this.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0f;
								this.Yandere.ReachWeight = 1f;
							}
							this.Yandere.Unequip();
						}
						if (this.Yandere.PickUp != null)
						{
							this.Yandere.PickUp.Drop();
						}
						this.Yandere.Mopping = false;
					}
				}
				else
				{
					if (Input.GetButtonDown("A"))
					{
						if (this.Selected < 3)
						{
							if (this.Yandere.Weapon[this.Selected] != null)
							{
								this.Equip();
							}
						}
						else if (this.Selected == 3)
						{
							if (this.Yandere.Container != null)
							{
								this.Yandere.ObstacleDetector.gameObject.SetActive(true);
							}
						}
						else if (this.Selected == 5)
						{
							this.DropMask();
						}
						else if (this.Selected == 6)
						{
							this.DropBookbag();
						}
						else
						{
							if (this.Yandere.Equipped > 0)
							{
								this.Yandere.Unequip();
							}
							if (this.Yandere.PickUp != null)
							{
								this.Yandere.PickUp.Drop();
							}
							this.Yandere.Mopping = false;
						}
					}
					if (this.EquipCaseWeaponButton.enabled && Input.GetButtonDown("Y"))
					{
						if (this.Yandere.Container.TrashCan.ConcealedWeapon != null)
						{
							WeaponScript concealedWeapon = this.Yandere.Container.TrashCan.ConcealedWeapon;
						}
						this.Yandere.Container.TrashCan.RemoveContents();
						this.UpdateSprites();
						this.Show = false;
					}
					if (Input.GetButtonDown("B"))
					{
						this.Show = false;
					}
				}
			}
		}
		if (!this.Show)
		{
			if (base.transform.localScale.x > 0.1f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else if (this.Panel.enabled)
			{
				base.transform.localScale = Vector3.zero;
				this.Panel.enabled = false;
			}
		}
		else
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if ((!this.Yandere.CanMove || this.Yandere.Aiming || this.PauseScreen.Show || this.InputDevice.Type == InputDeviceType.MouseAndKeyboard) && (!this.Yandere.Chased || this.Yandere.Sprayed))
			{
				this.Show = false;
			}
		}
		if (!this.KeyboardShow)
		{
			if (this.KeyboardMenu.localScale.x > 0.1f)
			{
				this.KeyboardMenu.localScale = Vector3.Lerp(this.KeyboardMenu.localScale, Vector3.zero, Time.deltaTime * 10f);
				return;
			}
			if (this.KeyboardPanel.enabled)
			{
				this.KeyboardMenu.localScale = Vector3.zero;
				this.KeyboardPanel.enabled = false;
				return;
			}
		}
		else
		{
			this.KeyboardMenu.localScale = Vector3.Lerp(this.KeyboardMenu.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				this.KeyboardShow = false;
			}
			if (this.EquipCaseWeaponKey.enabled && Input.GetButtonDown("Y"))
			{
				if (this.Yandere.Container.TrashCan.ConcealedWeapon != null)
				{
					WeaponScript concealedWeapon2 = this.Yandere.Container.TrashCan.ConcealedWeapon;
				}
				this.Yandere.Container.TrashCan.RemoveContents();
				this.UpdateSprites();
			}
			if (!this.Yandere.CanMove || this.Yandere.Aiming || this.PauseScreen.Show || this.InputDevice.Type == InputDeviceType.Gamepad || Input.GetButton("Y"))
			{
				this.KeyboardShow = false;
			}
		}
	}

	// Token: 0x06001FA6 RID: 8102 RVA: 0x001BD84C File Offset: 0x001BBA4C
	public void Equip()
	{
		if (this.Yandere.Weapon[this.Selected] != null)
		{
			this.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0f;
			this.Yandere.ReachWeight = 1f;
			if (this.Yandere.PickUp != null)
			{
				this.Yandere.PickUp.Drop();
			}
			if (this.Yandere.Equipped == 3)
			{
				this.Yandere.Weapon[3].Drop();
			}
			if (this.Yandere.Weapon[1] != null)
			{
				this.Yandere.Weapon[1].gameObject.SetActive(false);
			}
			if (this.Yandere.Weapon[2] != null)
			{
				this.Yandere.Weapon[2].gameObject.SetActive(false);
			}
			this.Yandere.Equipped = this.Selected;
			this.Yandere.EquippedWeapon.gameObject.SetActive(true);
			if (this.Yandere.EquippedWeapon.Flaming)
			{
				this.Yandere.EquippedWeapon.FireEffect.Play();
			}
			if (!this.Yandere.Gloved)
			{
				this.Yandere.EquippedWeapon.FingerprintID = 100;
			}
			this.Yandere.StudentManager.UpdateStudents(0);
			this.Yandere.WeaponManager.UpdateLabels();
			if (this.Yandere.EquippedWeapon.Suspicious)
			{
				if (!this.Yandere.WeaponWarning)
				{
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Armed);
					this.Yandere.WeaponWarning = true;
				}
			}
			else
			{
				this.Yandere.WeaponWarning = false;
			}
			AudioSource.PlayClipAtPoint(this.Yandere.EquippedWeapon.EquipClip, Camera.main.transform.position);
			this.Show = false;
		}
	}

	// Token: 0x06001FA7 RID: 8103 RVA: 0x001BDA48 File Offset: 0x001BBC48
	public void UpdateSprites()
	{
		this.EquipCaseWeaponButton.enabled = false;
		this.EquipCaseWeaponKey.enabled = false;
		for (int i = 1; i < 3; i++)
		{
			UISprite uisprite = this.KeyboardBG[i];
			UISprite uisprite2 = this.BG[i];
			if (this.Selected == i)
			{
				uisprite.color = new Color(1f, 1f, 1f, 1f);
				uisprite2.color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				uisprite.color = this.OriginalColor;
				uisprite2.color = this.OriginalColor;
			}
			UISprite uisprite3 = this.Item[i];
			UISprite uisprite4 = this.Outline[i];
			UISprite uisprite5 = this.KeyboardItem[i];
			UISprite uisprite6 = this.KeyboardOutline[i];
			if (this.Yandere.Weapon[i] == null)
			{
				uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 0f);
				uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
				uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 0.5f);
				uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 0f);
				uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
				uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 0.5f);
			}
			else
			{
				uisprite3.spriteName = this.Yandere.Weapon[i].SpriteName;
				uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 1f);
				uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 1f);
				uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 1f);
				uisprite5.spriteName = this.Yandere.Weapon[i].SpriteName;
				uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 1f);
				uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 1f);
				uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 1f);
			}
		}
		UISprite uisprite7 = this.KeyboardItem[3];
		UISprite uisprite8 = this.Item[3];
		UISprite uisprite9 = this.KeyboardBG[3];
		UISprite uisprite10 = this.BG[3];
		UISprite uisprite11 = this.Outline[3];
		UISprite uisprite12 = this.KeyboardOutline[3];
		if (this.Yandere.Container == null)
		{
			uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 0f);
			uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 0f);
			if (this.Selected == 3)
			{
				uisprite9.color = new Color(1f, 1f, 1f, 1f);
				uisprite10.color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				uisprite9.color = this.OriginalColor;
				uisprite10.color = this.OriginalColor;
			}
			uisprite10.color = new Color(uisprite10.color.r, uisprite10.color.g, uisprite10.color.b, 0.5f);
			uisprite11.color = new Color(uisprite11.color.r, uisprite11.color.g, uisprite11.color.b, 0.5f);
			uisprite9.color = new Color(uisprite9.color.r, uisprite9.color.g, uisprite9.color.b, 0.5f);
			uisprite12.color = new Color(uisprite12.color.r, uisprite12.color.g, uisprite12.color.b, 0.5f);
		}
		else
		{
			uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 1f);
			uisprite10.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
			uisprite11.color = new Color(uisprite11.color.r, uisprite11.color.g, uisprite11.color.b, 1f);
			uisprite7.spriteName = this.Yandere.Container.SpriteName;
			uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 1f);
			uisprite9.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
			uisprite12.color = new Color(uisprite12.color.r, uisprite12.color.g, uisprite12.color.b, 1f);
		}
		UISprite uisprite13 = this.KeyboardItem[5];
		UISprite uisprite14 = this.Item[5];
		UISprite uisprite15 = this.KeyboardBG[5];
		UISprite uisprite16 = this.BG[5];
		UISprite uisprite17 = this.Outline[5];
		UISprite uisprite18 = this.KeyboardOutline[5];
		if (this.Yandere.Mask == null)
		{
			uisprite13.color = new Color(uisprite13.color.r, uisprite13.color.g, uisprite13.color.b, 0f);
			uisprite14.color = new Color(uisprite14.color.r, uisprite14.color.g, uisprite14.color.b, 0f);
			if (this.Selected == 5)
			{
				uisprite15.color = new Color(1f, 1f, 1f, 1f);
				uisprite16.color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				uisprite15.color = this.OriginalColor;
				uisprite16.color = this.OriginalColor;
			}
			uisprite16.color = new Color(uisprite16.color.r, uisprite16.color.g, uisprite16.color.b, 0.5f);
			uisprite17.color = new Color(uisprite17.color.r, uisprite17.color.g, uisprite17.color.b, 0.5f);
			uisprite15.color = new Color(uisprite15.color.r, uisprite15.color.g, uisprite15.color.b, 0.5f);
			uisprite18.color = new Color(uisprite18.color.r, uisprite18.color.g, uisprite18.color.b, 0.5f);
		}
		else
		{
			uisprite13.color = new Color(uisprite13.color.r, uisprite13.color.g, uisprite13.color.b, 1f);
			uisprite14.color = new Color(uisprite14.color.r, uisprite14.color.g, uisprite14.color.b, 1f);
			uisprite16.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
			uisprite17.color = new Color(uisprite17.color.r, uisprite17.color.g, uisprite17.color.b, 1f);
			uisprite13.color = new Color(uisprite13.color.r, uisprite13.color.g, uisprite13.color.b, 1f);
			uisprite15.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
			uisprite18.color = new Color(uisprite18.color.r, uisprite18.color.g, uisprite18.color.b, 1f);
		}
		UISprite uisprite19 = this.KeyboardItem[6];
		UISprite uisprite20 = this.Item[6];
		UISprite uisprite21 = this.KeyboardBG[6];
		UISprite uisprite22 = this.BG[6];
		UISprite uisprite23 = this.Outline[6];
		UISprite uisprite24 = this.KeyboardOutline[6];
		if (this.Yandere.Bookbag == null)
		{
			uisprite19.color = new Color(uisprite19.color.r, uisprite19.color.g, uisprite19.color.b, 0f);
			uisprite20.color = new Color(uisprite20.color.r, uisprite20.color.g, uisprite20.color.b, 0f);
			if (this.Selected == 6)
			{
				uisprite21.color = new Color(1f, 1f, 1f, 1f);
				uisprite22.color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				uisprite21.color = this.OriginalColor;
				uisprite22.color = this.OriginalColor;
			}
			uisprite22.color = new Color(uisprite22.color.r, uisprite22.color.g, uisprite22.color.b, 0.5f);
			uisprite23.color = new Color(uisprite23.color.r, uisprite23.color.g, uisprite23.color.b, 0.5f);
			uisprite21.color = new Color(uisprite21.color.r, uisprite21.color.g, uisprite21.color.b, 0.5f);
			uisprite24.color = new Color(uisprite24.color.r, uisprite24.color.g, uisprite24.color.b, 0.5f);
		}
		else
		{
			uisprite19.color = new Color(uisprite19.color.r, uisprite19.color.g, uisprite19.color.b, 1f);
			uisprite20.color = new Color(uisprite20.color.r, uisprite20.color.g, uisprite20.color.b, 1f);
			uisprite22.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
			uisprite23.color = new Color(uisprite23.color.r, uisprite23.color.g, uisprite23.color.b, 1f);
			uisprite19.color = new Color(uisprite19.color.r, uisprite19.color.g, uisprite19.color.b, 1f);
			uisprite21.color = new Color(this.OriginalColor.r, this.OriginalColor.g, this.OriginalColor.b, 1f);
			uisprite24.color = new Color(uisprite24.color.r, uisprite24.color.g, uisprite24.color.b, 1f);
		}
		if (this.Selected == 4)
		{
			this.KeyboardBG[4].color = new Color(1f, 1f, 1f, 1f);
			this.BG[4].color = new Color(1f, 1f, 1f, 1f);
		}
		else
		{
			this.KeyboardBG[4].color = this.OriginalColor;
			this.BG[4].color = this.OriginalColor;
		}
		this.Yandere.UpdateConcealedWeaponStatus();
	}

	// Token: 0x06001FA8 RID: 8104 RVA: 0x001BE878 File Offset: 0x001BCA78
	private void DropMask()
	{
		if (this.Yandere.Mask != null)
		{
			this.StudentManager.CanAnyoneSeeYandere();
			if (!this.StudentManager.YandereVisible && !this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.Yandere.Mask.Drop();
				this.UpdateSprites();
				this.StudentManager.UpdateStudents(0);
				return;
			}
			this.Yandere.NotificationManager.CustomText = "Not now. Too suspicious.";
			this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x06001FA9 RID: 8105 RVA: 0x001BE914 File Offset: 0x001BCB14
	private void DropBookbag()
	{
		if (this.Yandere.Bookbag != null)
		{
			this.Yandere.Bookbag.Drop();
			this.Yandere.UpdateConcealedWeaponStatus();
		}
		this.UpdateSprites();
	}

	// Token: 0x06001FAA RID: 8106 RVA: 0x001BE94A File Offset: 0x001BCB4A
	public void InstantHide()
	{
		this.KeyboardMenu.localScale = Vector3.zero;
		base.transform.localScale = Vector3.zero;
	}

	// Token: 0x0400420E RID: 16910
	public StudentManagerScript StudentManager;

	// Token: 0x0400420F RID: 16911
	public InputDeviceScript InputDevice;

	// Token: 0x04004210 RID: 16912
	public PauseScreenScript PauseScreen;

	// Token: 0x04004211 RID: 16913
	public YandereScript Yandere;

	// Token: 0x04004212 RID: 16914
	public InputManagerScript IM;

	// Token: 0x04004213 RID: 16915
	public UIPanel KeyboardPanel;

	// Token: 0x04004214 RID: 16916
	public UIPanel Panel;

	// Token: 0x04004215 RID: 16917
	public Transform KeyboardMenu;

	// Token: 0x04004216 RID: 16918
	public bool KeyboardShow;

	// Token: 0x04004217 RID: 16919
	public bool Released = true;

	// Token: 0x04004218 RID: 16920
	public bool Show;

	// Token: 0x04004219 RID: 16921
	public UISprite[] BG;

	// Token: 0x0400421A RID: 16922
	public UISprite[] Outline;

	// Token: 0x0400421B RID: 16923
	public UISprite[] Item;

	// Token: 0x0400421C RID: 16924
	public UISprite[] KeyboardBG;

	// Token: 0x0400421D RID: 16925
	public UISprite[] KeyboardOutline;

	// Token: 0x0400421E RID: 16926
	public UISprite[] KeyboardItem;

	// Token: 0x0400421F RID: 16927
	public UISprite EquipCaseWeaponButton;

	// Token: 0x04004220 RID: 16928
	public UILabel EquipCaseWeaponKey;

	// Token: 0x04004221 RID: 16929
	public int Selected = 1;

	// Token: 0x04004222 RID: 16930
	public Color OriginalColor;

	// Token: 0x04004223 RID: 16931
	public Transform Button;

	// Token: 0x04004224 RID: 16932
	public float Timer;
}
