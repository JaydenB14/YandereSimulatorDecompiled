﻿using System;
using UnityEngine;

// Token: 0x02000411 RID: 1041
public class SchemesScript : MonoBehaviour
{
	// Token: 0x06001C4C RID: 7244 RVA: 0x0014A3D4 File Offset: 0x001485D4
	private void Start()
	{
		for (int i = 1; i < this.SchemeNameLabels.Length; i++)
		{
			if (!SchemeGlobals.GetSchemeStatus(i))
			{
				this.SchemeDeadlineLabels[i].text = this.SchemeDeadlines[i];
				this.SchemeNameLabels[i].text = this.SchemeNames[i];
			}
		}
		this.DisableScheme[1] = true;
		this.DisableScheme[2] = true;
		this.DisableScheme[3] = true;
		this.DisableScheme[4] = true;
		this.DisableScheme[5] = true;
		this.DisableScheme[21] = true;
		this.DisableScheme[22] = true;
		this.DisableScheme[23] = true;
		this.DisableScheme[24] = true;
		this.DisableScheme[25] = true;
		if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			this.DisableScheme[1] = false;
			this.DisableScheme[21] = false;
		}
		if (DateGlobals.Weekday == DayOfWeek.Tuesday)
		{
			this.DisableScheme[2] = false;
			this.DisableScheme[22] = false;
		}
		if (DateGlobals.Weekday == DayOfWeek.Wednesday)
		{
			this.DisableScheme[3] = false;
			this.DisableScheme[23] = false;
		}
		if (DateGlobals.Weekday == DayOfWeek.Thursday)
		{
			this.DisableScheme[4] = false;
			this.DisableScheme[24] = false;
		}
		if (DateGlobals.Weekday == DayOfWeek.Friday)
		{
			this.DisableScheme[5] = false;
			this.DisableScheme[25] = false;
		}
		if (DateGlobals.Weekday != DayOfWeek.Monday)
		{
			this.DisableScheme[6] = true;
		}
		if (DateGlobals.Weekday != DayOfWeek.Thursday)
		{
			this.DisableScheme[20] = true;
		}
		if (this.NextStepInput != null)
		{
			this.NextStepInput.SetActive(false);
		}
		this.UpdateSchemeInfo();
	}

	// Token: 0x06001C4D RID: 7245 RVA: 0x0014A550 File Offset: 0x00148750
	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			if (this.ID == 1)
			{
				this.ListPosition--;
				if (this.ListPosition < 0)
				{
					this.ListPosition = this.Limit - 15;
					this.ID = 15;
				}
			}
			else
			{
				this.ID--;
			}
			this.UpdateSchemeInfo();
		}
		if (this.InputManager.TappedDown)
		{
			if (this.ID == 15)
			{
				this.ListPosition++;
				if (this.ID + this.ListPosition > this.Limit)
				{
					this.ListPosition = 0;
					this.ID = 1;
				}
			}
			else
			{
				this.ID++;
			}
			this.UpdateSchemeInfo();
		}
		if (Input.GetButtonDown("A"))
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.PromptBar.Label[0].text != string.Empty)
			{
				if (this.SchemeNameLabels[this.ID].color.a == 1f)
				{
					this.SchemeManager.enabled = true;
					this.SchemeManager.CurrentScheme = this.ID + this.ListPosition;
					if (this.ID == 5)
					{
						this.SchemeManager.ClockCheck = true;
					}
					if (!SchemeGlobals.GetSchemeUnlocked(this.ID + this.ListPosition))
					{
						if (this.Inventory.PantyShots >= this.SchemeCosts[this.ID + this.ListPosition])
						{
							this.Inventory.PantyShots -= this.SchemeCosts[this.ID + this.ListPosition];
							SchemeGlobals.SetSchemeUnlocked(this.ID + this.ListPosition, true);
							SchemeGlobals.CurrentScheme = this.ID + this.ListPosition;
							if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) == 0)
							{
								SchemeGlobals.SetSchemeStage(this.ID + this.ListPosition, 1);
							}
							this.UpdateSchemeDestinations();
							this.UpdateInstructions();
							this.UpdateSchemeList();
							this.UpdateSchemeInfo();
							component.clip = this.InfoPurchase;
							component.Play();
						}
					}
					else
					{
						if (SchemeGlobals.CurrentScheme == this.ID + this.ListPosition)
						{
							SchemeGlobals.CurrentScheme = 0;
							this.SchemeManager.CurrentScheme = 0;
							this.SchemeManager.enabled = false;
						}
						else
						{
							SchemeGlobals.CurrentScheme = this.ID + this.ListPosition;
						}
						this.UpdateSchemeDestinations();
						this.UpdateInstructions();
						this.UpdateSchemeInfo();
					}
				}
			}
			else if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) != 100 && this.Inventory.PantyShots < this.SchemeCosts[this.ID + this.ListPosition])
			{
				component.clip = this.InfoAfford;
				component.Play();
			}
		}
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.FavorMenu.SetActive(true);
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001C4E RID: 7246 RVA: 0x0014A8A4 File Offset: 0x00148AA4
	public void UpdateSchemeList()
	{
		for (int i = 1; i < this.SchemeNameLabels.Length; i++)
		{
			if (SchemeGlobals.GetSchemeStage(i + this.ListPosition) == 100)
			{
				UILabel uilabel = this.SchemeNameLabels[i];
				uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
				this.SchemeCostLabels[i].text = string.Empty;
			}
			else
			{
				if (SchemeGlobals.GetSchemeUnlocked(i))
				{
					this.SchemeCostLabels[i].text = this.SchemeCosts[i].ToString();
				}
				else
				{
					this.SchemeCostLabels[i].text = string.Empty;
				}
				if (SchemeGlobals.GetSchemeStage(i) > SchemeGlobals.GetSchemePreviousStage(i))
				{
					SchemeGlobals.SetSchemePreviousStage(i, SchemeGlobals.GetSchemeStage(i));
				}
			}
		}
	}

	// Token: 0x06001C4F RID: 7247 RVA: 0x0014A980 File Offset: 0x00148B80
	public void UpdateSchemeInfo()
	{
		if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) != 100)
		{
			if (!SchemeGlobals.GetSchemeUnlocked(this.ID + this.ListPosition))
			{
				this.Arrow.gameObject.SetActive(false);
				if (this.Inventory != null)
				{
					this.PromptBar.Label[0].text = ((this.Inventory.PantyShots >= this.SchemeCosts[this.ID + this.ListPosition]) ? "Purchase" : string.Empty);
				}
				this.PromptBar.UpdateButtons();
			}
			else if (SchemeGlobals.CurrentScheme == this.ID + this.ListPosition)
			{
				this.Arrow.gameObject.SetActive(true);
				this.Arrow.localPosition = new Vector3(this.Arrow.localPosition.x, -10f - 21f * (float)SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition), this.Arrow.localPosition.z);
				this.PromptBar.Label[0].text = "Stop Tracking";
				this.PromptBar.UpdateButtons();
			}
			else
			{
				this.Arrow.gameObject.SetActive(false);
				this.PromptBar.Label[0].text = "Start Tracking";
				this.PromptBar.UpdateButtons();
			}
		}
		else
		{
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.UpdateButtons();
		}
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
		for (int i = 1; i < this.SchemeNameLabels.Length; i++)
		{
			this.SchemeNameLabels[i].text = this.SchemeNames[i + this.ListPosition];
			this.SchemeCostLabels[i].text = (this.SchemeCosts[i + this.ListPosition].ToString() ?? "");
			this.SchemeDeadlineLabels[i].text = this.SchemeDeadlines[i + this.ListPosition];
			if (this.DisableScheme[i + this.ListPosition])
			{
				this.SchemeNameLabels[i].color = new Color(0f, 0f, 0f, 0.5f);
			}
			else
			{
				this.SchemeNameLabels[i].color = new Color(0f, 0f, 0f, 1f);
			}
			if (this.SchemeManager != null)
			{
				if (this.SchemeManager.CurrentScheme == i + this.ListPosition)
				{
					this.Exclamations[i].enabled = true;
				}
				else
				{
					this.Exclamations[i].enabled = false;
				}
			}
		}
		this.SchemeIcon.mainTexture = this.SchemeIcons[this.ID + this.ListPosition];
		this.SchemeDesc.text = this.SchemeDescs[this.ID + this.ListPosition];
		if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) == 100)
		{
			this.SchemeInstructions.text = "This scheme is no longer available.";
		}
		else
		{
			this.SchemeInstructions.text = ((!SchemeGlobals.GetSchemeUnlocked(this.ID + this.ListPosition)) ? ("Skills Required:\n" + this.SchemeSkills[this.ID + this.ListPosition]) : this.SchemeSteps[this.ID + this.ListPosition]);
		}
		this.UpdatePantyCount();
	}

	// Token: 0x06001C50 RID: 7248 RVA: 0x0014AD3B File Offset: 0x00148F3B
	public void UpdatePantyCount()
	{
		if (this.Inventory != null)
		{
			this.PantyCount.text = this.Inventory.PantyShots.ToString();
		}
	}

	// Token: 0x06001C51 RID: 7249 RVA: 0x0014AD68 File Offset: 0x00148F68
	public void UpdateInstructions()
	{
		this.Steps = this.SchemeSteps[SchemeGlobals.CurrentScheme].Split(new char[]
		{
			'\n'
		});
		if (SchemeGlobals.CurrentScheme > 0)
		{
			if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) < 100)
			{
				if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) < 1)
				{
					SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, this.Steps.Length);
				}
				else if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) > this.Steps.Length)
				{
					SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, 1);
				}
				this.HUDIcon.SetActive(true);
				this.HUDInstructions.text = this.Steps[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) - 1].ToString();
			}
			else
			{
				this.Arrow.gameObject.SetActive(false);
				this.HUDIcon.gameObject.SetActive(false);
				this.HUDInstructions.text = string.Empty;
				this.SchemeManager.CurrentScheme = 0;
			}
		}
		else
		{
			this.HUDIcon.SetActive(false);
			this.HUDInstructions.text = string.Empty;
		}
		if (SchemeGlobals.CurrentScheme < 7)
		{
			this.NextStepInput.SetActive(false);
			return;
		}
		this.NextStepInput.SetActive(true);
	}

	// Token: 0x06001C52 RID: 7250 RVA: 0x0014AEA0 File Offset: 0x001490A0
	public void UpdateSchemeDestinations()
	{
		if (this.StudentManager.Students[this.StudentManager.RivalID] != null)
		{
			this.Scheme1Destinations[3] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
			this.Scheme1Destinations[7] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
			this.Scheme4Destinations[5] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
			this.Scheme4Destinations[6] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
		}
		if (this.StudentManager.Students[2] != null)
		{
			this.Scheme2Destinations[1] = this.StudentManager.Students[2].transform;
		}
		if (this.StudentManager.Students[97] != null)
		{
			this.Scheme5Destinations[3] = this.StudentManager.Students[97].transform;
		}
		if (SchemeGlobals.CurrentScheme == 1)
		{
			this.SchemeDestinations = this.Scheme1Destinations;
			return;
		}
		if (SchemeGlobals.CurrentScheme == 2)
		{
			this.SchemeDestinations = this.Scheme2Destinations;
			return;
		}
		if (SchemeGlobals.CurrentScheme == 3)
		{
			this.SchemeDestinations = this.Scheme3Destinations;
			return;
		}
		if (SchemeGlobals.CurrentScheme == 4)
		{
			this.SchemeDestinations = this.Scheme4Destinations;
			return;
		}
		if (SchemeGlobals.CurrentScheme == 5)
		{
			this.SchemeDestinations = this.Scheme5Destinations;
		}
	}

	// Token: 0x04003217 RID: 12823
	public StudentManagerScript StudentManager;

	// Token: 0x04003218 RID: 12824
	public SchemeManagerScript SchemeManager;

	// Token: 0x04003219 RID: 12825
	public InputManagerScript InputManager;

	// Token: 0x0400321A RID: 12826
	public InventoryScript Inventory;

	// Token: 0x0400321B RID: 12827
	public PromptBarScript PromptBar;

	// Token: 0x0400321C RID: 12828
	public GameObject NextStepInput;

	// Token: 0x0400321D RID: 12829
	public GameObject FavorMenu;

	// Token: 0x0400321E RID: 12830
	public Transform Highlight;

	// Token: 0x0400321F RID: 12831
	public Transform Arrow;

	// Token: 0x04003220 RID: 12832
	public UILabel SchemeInstructions;

	// Token: 0x04003221 RID: 12833
	public UITexture SchemeIcon;

	// Token: 0x04003222 RID: 12834
	public UILabel PantyCount;

	// Token: 0x04003223 RID: 12835
	public UILabel SchemeDesc;

	// Token: 0x04003224 RID: 12836
	public UILabel[] SchemeDeadlineLabels;

	// Token: 0x04003225 RID: 12837
	public UILabel[] SchemeCostLabels;

	// Token: 0x04003226 RID: 12838
	public UILabel[] SchemeNameLabels;

	// Token: 0x04003227 RID: 12839
	public UISprite[] Exclamations;

	// Token: 0x04003228 RID: 12840
	public Texture[] SchemeIcons;

	// Token: 0x04003229 RID: 12841
	public int[] SchemeCosts;

	// Token: 0x0400322A RID: 12842
	public Transform[] SchemeDestinations;

	// Token: 0x0400322B RID: 12843
	public string[] SchemeDeadlines;

	// Token: 0x0400322C RID: 12844
	public string[] SchemeSkills;

	// Token: 0x0400322D RID: 12845
	public string[] SchemeDescs;

	// Token: 0x0400322E RID: 12846
	public string[] SchemeNames;

	// Token: 0x0400322F RID: 12847
	[Multiline]
	[SerializeField]
	public string[] SchemeSteps;

	// Token: 0x04003230 RID: 12848
	public int ListPosition = 1;

	// Token: 0x04003231 RID: 12849
	public int Limit = 20;

	// Token: 0x04003232 RID: 12850
	public int ID = 1;

	// Token: 0x04003233 RID: 12851
	public string[] Steps;

	// Token: 0x04003234 RID: 12852
	public AudioClip InfoPurchase;

	// Token: 0x04003235 RID: 12853
	public AudioClip InfoAfford;

	// Token: 0x04003236 RID: 12854
	public Transform[] Scheme1Destinations;

	// Token: 0x04003237 RID: 12855
	public Transform[] Scheme2Destinations;

	// Token: 0x04003238 RID: 12856
	public Transform[] Scheme3Destinations;

	// Token: 0x04003239 RID: 12857
	public Transform[] Scheme4Destinations;

	// Token: 0x0400323A RID: 12858
	public Transform[] Scheme5Destinations;

	// Token: 0x0400323B RID: 12859
	public bool[] DisableScheme;

	// Token: 0x0400323C RID: 12860
	public GameObject HUDIcon;

	// Token: 0x0400323D RID: 12861
	public UILabel HUDInstructions;
}
