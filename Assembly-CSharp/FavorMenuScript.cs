﻿using System;
using UnityEngine;

// Token: 0x020002C8 RID: 712
public class FavorMenuScript : MonoBehaviour
{
	// Token: 0x06001494 RID: 5268 RVA: 0x000CA19C File Offset: 0x000C839C
	private void Update()
	{
		if (!this.BountyMenu.activeInHierarchy)
		{
			if (this.InputManager.TappedRight)
			{
				this.ID++;
				this.UpdateHighlight();
			}
			else if (this.InputManager.TappedLeft)
			{
				this.ID--;
				this.UpdateHighlight();
			}
			if (!this.TutorialWindow.Hide && !this.TutorialWindow.Show)
			{
				if (Input.GetButtonDown("A"))
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Accept";
					this.PromptBar.Label[1].text = "Exit";
					this.PromptBar.Label[4].text = "Choose";
					this.PromptBar.UpdateButtons();
					if (this.ID == 1)
					{
						this.SchemesMenu.UpdatePantyCount();
						this.SchemesMenu.UpdateSchemeList();
						this.SchemesMenu.UpdateSchemeInfo();
						this.SchemesMenu.gameObject.SetActive(true);
						base.gameObject.SetActive(false);
						return;
					}
					if (this.ID == 2)
					{
						this.ServicesMenu.UpdatePantyCount();
						this.ServicesMenu.UpdateList();
						this.ServicesMenu.UpdateDesc();
						this.ServicesMenu.gameObject.SetActive(true);
						base.gameObject.SetActive(false);
						return;
					}
					if (this.ID == 3)
					{
						this.DropsMenu.UpdatePantyCount();
						this.DropsMenu.UpdateList();
						this.DropsMenu.UpdateDesc();
						this.DropsMenu.gameObject.SetActive(true);
						base.gameObject.SetActive(false);
						return;
					}
					if (this.ID == 4)
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[1].text = "Back";
						this.PromptBar.UpdateButtons();
						this.Panel.SetActive(false);
						this.BountyMenu.SetActive(true);
						return;
					}
				}
				else
				{
					if (Input.GetButtonDown("X"))
					{
						this.TutorialWindow.TitleLabel.text = "Info Points";
						this.TutorialWindow.TutorialLabel.text = this.TutorialWindow.PointsString;
						this.TutorialWindow.TutorialLabel.text = this.TutorialWindow.TutorialLabel.text.Replace('@', '\n');
						this.TutorialWindow.TutorialImage.mainTexture = this.TutorialWindow.InfoTexture;
						this.TutorialWindow.ForcingTutorial = true;
						this.TutorialWindow.enabled = true;
						this.TutorialWindow.SummonWindow();
						return;
					}
					if (Input.GetButtonDown("B"))
					{
						this.PromptBar.ClearButtons();
						this.PromptBar.Label[0].text = "Accept";
						this.PromptBar.Label[1].text = "Exit";
						this.PromptBar.Label[4].text = "Choose";
						this.PromptBar.UpdateButtons();
						this.PauseScreen.MainMenu.SetActive(true);
						this.PauseScreen.Sideways = false;
						this.PauseScreen.PressedB = true;
						base.gameObject.SetActive(false);
						return;
					}
				}
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.Panel.SetActive(true);
			this.BountyMenu.SetActive(false);
		}
	}

	// Token: 0x06001495 RID: 5269 RVA: 0x000CA578 File Offset: 0x000C8778
	private void UpdateHighlight()
	{
		if (this.ID > 4)
		{
			this.ID = 1;
		}
		else if (this.ID < 1)
		{
			this.ID = 4;
		}
		this.Highlight.transform.localPosition = new Vector3(-500f + 200f * (float)this.ID, this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z);
	}

	// Token: 0x0400201E RID: 8222
	public TutorialWindowScript TutorialWindow;

	// Token: 0x0400201F RID: 8223
	public InputManagerScript InputManager;

	// Token: 0x04002020 RID: 8224
	public PauseScreenScript PauseScreen;

	// Token: 0x04002021 RID: 8225
	public ServicesScript ServicesMenu;

	// Token: 0x04002022 RID: 8226
	public SchemesScript SchemesMenu;

	// Token: 0x04002023 RID: 8227
	public DropsScript DropsMenu;

	// Token: 0x04002024 RID: 8228
	public PromptBarScript PromptBar;

	// Token: 0x04002025 RID: 8229
	public GameObject BountyMenu;

	// Token: 0x04002026 RID: 8230
	public GameObject Panel;

	// Token: 0x04002027 RID: 8231
	public Transform Highlight;

	// Token: 0x04002028 RID: 8232
	public UITexture Portrait;

	// Token: 0x04002029 RID: 8233
	public int ID = 1;
}
