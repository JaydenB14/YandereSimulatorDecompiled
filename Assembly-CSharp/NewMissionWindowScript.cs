﻿using System;
using UnityEngine;

// Token: 0x02000373 RID: 883
public class NewMissionWindowScript : MonoBehaviour
{
	// Token: 0x060019C2 RID: 6594 RVA: 0x00108620 File Offset: 0x00106820
	private void Start()
	{
		this.UpdateHighlight();
		for (int i = 1; i < 11; i++)
		{
			this.Portrait[i].mainTexture = this.BlankPortrait;
			this.NameLabel[i].text = "Kill: (Nobody)";
			this.MethodLabel[i].text = "By: Attacking";
			this.DeathSkulls[i].SetActive(false);
		}
		this.DifficultyOptions.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x060019C3 RID: 6595 RVA: 0x001086A4 File Offset: 0x001068A4
	private void ChangeFont(UILabel Text)
	{
		Text.trueTypeFont = this.Arial;
		if (Text.height == 150)
		{
			Text.height = 100;
		}
	}

	// Token: 0x060019C4 RID: 6596 RVA: 0x001086C8 File Offset: 0x001068C8
	private void Update()
	{
		if (!this.ChangingDifficulty)
		{
			if (this.InputManager.TappedDown)
			{
				this.Row++;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedUp)
			{
				this.Row--;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedRight)
			{
				this.Column++;
				this.UpdateHighlight();
			}
			if (this.InputManager.TappedLeft)
			{
				this.Column--;
				this.UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				int num = 0;
				for (int i = 0; i < 11; i++)
				{
					if (this.Target[i] > 0)
					{
						num++;
					}
				}
				if (this.Row == 5)
				{
					if (this.Column == 1)
					{
						if (num > 0)
						{
							Globals.DeleteAll();
							this.SaveInfo();
							this.MissionModeMenu.GetComponent<AudioSource>().PlayOneShot(this.MissionModeMenu.InfoLines[6]);
							SchoolGlobals.SchoolAtmosphere = 1f - (float)num * 0.1f;
							SchoolGlobals.SchoolAtmosphereSet = true;
							MissionModeGlobals.MissionMode = true;
							MissionModeGlobals.MultiMission = true;
							MissionModeGlobals.MissionDifficulty = num;
							ClassGlobals.BiologyGrade = 1;
							ClassGlobals.ChemistryGrade = 1;
							ClassGlobals.LanguageGrade = 1;
							ClassGlobals.PhysicalGrade = 1;
							ClassGlobals.PsychologyGrade = 1;
							this.MissionModeMenu.PromptBar.Show = false;
							this.MissionModeMenu.Speed = 0f;
							this.MissionModeMenu.Phase = 4;
							base.enabled = false;
						}
					}
					else if (this.Column == 2)
					{
						this.Randomize();
					}
					else if (this.Column == 3)
					{
						this.ChangingDifficulty = true;
						this.MissionModeMenu.PromptBar.ClearButtons();
						this.MissionModeMenu.PromptBar.Label[0].text = "Change";
						this.MissionModeMenu.PromptBar.Label[1].text = "Back";
						this.MissionModeMenu.PromptBar.Label[2].text = "Aggression";
						this.MissionModeMenu.PromptBar.UpdateButtons();
						this.MissionModeMenu.PromptBar.Show = true;
					}
				}
			}
			if (Input.GetButtonDown("B"))
			{
				this.MissionModeMenu.PromptBar.ClearButtons();
				this.MissionModeMenu.PromptBar.Label[0].text = "Accept";
				this.MissionModeMenu.PromptBar.Label[4].text = "Choose";
				this.MissionModeMenu.PromptBar.UpdateButtons();
				this.MissionModeMenu.PromptBar.Show = true;
				this.MissionModeMenu.TargetID = 0;
				this.MissionModeMenu.Phase = 2;
				base.enabled = false;
			}
			if (Input.GetButtonDown("X"))
			{
				if (this.Row == 1)
				{
					for (int j = 1; j < 11; j++)
					{
						this.UnsafeNumbers[j] = this.Target[j];
					}
					this.Increment(0);
					if (this.Target[this.Column] != 0)
					{
						while ((this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[1]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[2]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[3]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[4]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[5]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[6]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[7]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[8]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[9]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[10]))
						{
							this.Increment(0);
						}
					}
					this.UnsafeNumbers[this.Column] = this.Target[this.Column];
				}
				else if (this.Row == 2)
				{
					this.Method[this.Column]++;
					if (this.Method[this.Column] == this.MethodNames.Length)
					{
						this.Method[this.Column] = 0;
					}
					this.MethodLabel[this.Column].text = "By: " + this.MethodNames[this.Method[this.Column]];
				}
				else if (this.Row == 3)
				{
					for (int k = 1; k < 11; k++)
					{
						this.UnsafeNumbers[k] = this.Target[k];
					}
					this.Increment(5);
					if (this.Target[this.Column + 5] != 0)
					{
						while ((this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[1]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[2]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[3]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[4]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[5]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[6]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[7]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[8]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[9]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[10]))
						{
							this.Increment(5);
						}
					}
					this.UnsafeNumbers[this.Column + 5] = this.Target[this.Column + 5];
				}
				else if (this.Row == 4)
				{
					this.Method[this.Column + 5]++;
					if (this.Method[this.Column + 5] == this.MethodNames.Length)
					{
						this.Method[this.Column + 5] = 0;
					}
					this.MethodLabel[this.Column + 5].text = "By: " + this.MethodNames[this.Method[this.Column + 5]];
				}
			}
			if (Input.GetButtonDown("Y"))
			{
				if (this.Row == 1)
				{
					for (int l = 1; l < 11; l++)
					{
						this.UnsafeNumbers[l] = this.Target[l];
					}
					this.Decrement(0);
					if (this.Target[this.Column] != 0)
					{
						while ((this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[1]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[2]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[3]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[4]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[5]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[6]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[7]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[8]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[9]) || (this.Target[this.Column] != 0 && this.Target[this.Column] == this.UnsafeNumbers[10]))
						{
							Debug.Log("Unsafe number. We're going to have to decrement.");
							this.Decrement(0);
						}
					}
					this.UnsafeNumbers[this.Column] = this.Target[this.Column];
				}
				else if (this.Row == 2)
				{
					this.Method[this.Column]--;
					if (this.Method[this.Column] < 0)
					{
						this.Method[this.Column] = this.MethodNames.Length - 1;
					}
					this.MethodLabel[this.Column].text = "By: " + this.MethodNames[this.Method[this.Column]];
				}
				else if (this.Row == 3)
				{
					for (int m = 1; m < 11; m++)
					{
						this.UnsafeNumbers[m] = this.Target[m];
					}
					this.Decrement(5);
					if (this.Target[this.Column + 5] != 0)
					{
						while ((this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[1]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[2]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[3]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[4]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[5]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[6]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[7]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[8]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[9]) || (this.Target[this.Column + 5] != 0 && this.Target[this.Column + 5] == this.UnsafeNumbers[10]))
						{
							Debug.Log("Unsafe number. We're going to have to decrement.");
							this.Decrement(5);
						}
					}
					this.UnsafeNumbers[this.Column + 5] = this.Target[this.Column + 5];
				}
				else if (this.Row == 4)
				{
					this.Method[this.Column + 5]--;
					if (this.Method[this.Column + 5] < 0)
					{
						this.Method[this.Column + 5] = this.MethodNames.Length - 1;
					}
					this.MethodLabel[this.Column + 5].text = "By: " + this.MethodNames[this.Method[this.Column + 5]];
				}
			}
			if (Input.GetKeyDown("space"))
			{
				this.FillOutInfo();
			}
			this.DifficultyOptions.localScale = Vector3.Lerp(this.DifficultyOptions.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
		}
		else
		{
			this.DifficultyOptions.localScale = Vector3.Lerp(this.DifficultyOptions.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (Input.GetButtonDown("A"))
			{
				this.NemesisDifficulty++;
				this.UpdateNemesisDifficulty();
			}
			if (Input.GetButtonDown("X"))
			{
				this.NemesisAggression = !this.NemesisAggression;
				this.UpdateNemesisDifficulty();
			}
			if (Input.GetButtonDown("B"))
			{
				this.MissionModeMenu.PromptBar.ClearButtons();
				this.MissionModeMenu.PromptBar.Label[0].text = "";
				this.MissionModeMenu.PromptBar.Label[1].text = "Return";
				this.MissionModeMenu.PromptBar.Label[2].text = "Adjust Up";
				this.MissionModeMenu.PromptBar.Label[3].text = "Adjust Down";
				this.MissionModeMenu.PromptBar.Label[4].text = "Selection";
				this.MissionModeMenu.PromptBar.Label[5].text = "Selection";
				this.MissionModeMenu.PromptBar.UpdateButtons();
				this.Column = 1;
				this.Row = 1;
				this.UpdateHighlight();
				this.ChangingDifficulty = false;
			}
		}
		this.UpdateNemesisList();
	}

	// Token: 0x060019C5 RID: 6597 RVA: 0x001095E8 File Offset: 0x001077E8
	private void Increment(int Number)
	{
		this.Target[this.Column + Number]++;
		if (this.Target[this.Column + Number] == 1)
		{
			this.Target[this.Column + Number] = 2;
		}
		else if (this.Target[this.Column + Number] == 12)
		{
			this.Target[this.Column + Number] = 21;
		}
		else if (this.Target[this.Column + Number] > 89)
		{
			this.Target[this.Column + Number] = 0;
		}
		if (this.Target[this.Column + Number] == 0)
		{
			this.NameLabel[this.Column + Number].text = "Kill: Nobody";
		}
		else
		{
			this.NameLabel[this.Column + Number].text = "Kill: " + this.JSON.Students[this.Target[this.Column + Number]].Name;
		}
		WWW www = new WWW(string.Concat(new string[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits/Student_",
			this.Target[this.Column + Number].ToString(),
			".png"
		}));
		this.Portrait[this.Column + Number].mainTexture = www.texture;
	}

	// Token: 0x060019C6 RID: 6598 RVA: 0x0010974C File Offset: 0x0010794C
	private void Decrement(int Number)
	{
		this.Target[this.Column + Number]--;
		Debug.Log("Decremented. Number has become: " + this.Target[this.Column + Number].ToString());
		if (this.Target[this.Column + Number] == 1)
		{
			this.Target[this.Column + Number] = 0;
			Debug.Log("Correcting to 0.");
		}
		else if (this.Target[this.Column + Number] == 20)
		{
			this.Target[this.Column + Number] = 11;
			Debug.Log("Correcting to 11.");
		}
		else if (this.Target[this.Column + Number] == -1)
		{
			this.Target[this.Column + Number] = 89;
			Debug.Log("Correcting to 89.");
		}
		if (this.Target[this.Column + Number] == 0)
		{
			this.NameLabel[this.Column + Number].text = "Kill: Nobody";
		}
		else
		{
			this.NameLabel[this.Column + Number].text = "Kill: " + this.JSON.Students[this.Target[this.Column + Number]].Name;
		}
		WWW www = new WWW(string.Concat(new string[]
		{
			"file:///",
			Application.streamingAssetsPath,
			"/Portraits/Student_",
			this.Target[this.Column + Number].ToString(),
			".png"
		}));
		this.Portrait[this.Column + Number].mainTexture = www.texture;
	}

	// Token: 0x060019C7 RID: 6599 RVA: 0x001098F4 File Offset: 0x00107AF4
	private void Randomize()
	{
		int i;
		for (i = 1; i < 11; i++)
		{
			this.Target[i] = UnityEngine.Random.Range(2, 89);
			this.Method[i] = UnityEngine.Random.Range(0, 7);
			this.MethodLabel[i].text = "By: " + this.MethodNames[this.Method[i]];
		}
		i = 1;
		this.Column = 0;
		while (i < 11)
		{
			for (int j = 1; j < 11; j++)
			{
				this.UnsafeNumbers[j] = this.Target[j];
			}
			while (this.Target[i] == this.UnsafeNumbers[1] || this.Target[i] == this.UnsafeNumbers[2] || this.Target[i] == this.UnsafeNumbers[3] || this.Target[i] == this.UnsafeNumbers[4] || this.Target[i] == this.UnsafeNumbers[5] || this.Target[i] == this.UnsafeNumbers[6] || this.Target[i] == this.UnsafeNumbers[7] || this.Target[i] == this.UnsafeNumbers[8] || this.Target[i] == this.UnsafeNumbers[9] || this.Target[i] == this.UnsafeNumbers[10] || this.Target[i] == 0 || (this.Target[i] > 11 && this.Target[i] < 21))
			{
				this.Increment(i);
			}
			i++;
		}
		this.Column = 2;
	}

	// Token: 0x060019C8 RID: 6600 RVA: 0x00109A84 File Offset: 0x00107C84
	public void UpdateHighlight()
	{
		this.MissionModeMenu.PromptBar.Label[0].text = "";
		if (this.Row < 1)
		{
			this.Row = 5;
		}
		else if (this.Row > 5)
		{
			this.Row = 1;
		}
		if (this.Row < 5)
		{
			if (this.Column < 1)
			{
				this.Column = 5;
			}
			else if (this.Column > 5)
			{
				this.Column = 1;
			}
			int num = 0;
			if (this.Row == 1)
			{
				num = 225;
			}
			else if (this.Row == 2)
			{
				num = 125;
			}
			else if (this.Row == 3)
			{
				num = -300;
			}
			else if (this.Row == 4)
			{
				num = -400;
			}
			this.Highlight.localPosition = new Vector3((float)(-1200 + 400 * this.Column), (float)num, 0f);
			return;
		}
		if (this.Column < 1)
		{
			this.Column = 3;
		}
		else if (this.Column > 3)
		{
			this.Column = 1;
		}
		this.Highlight.localPosition = new Vector3((float)(-1200 + 600 * this.Column), -525f, 0f);
		if (this.Column == 1)
		{
			if (this.Target[1] + this.Target[2] + this.Target[3] + this.Target[4] + this.Target[5] + this.Target[6] + this.Target[7] + this.Target[8] + this.Target[9] + this.Target[10] == 0)
			{
				this.MissionModeMenu.PromptBar.Label[0].text = "";
			}
			else
			{
				this.MissionModeMenu.PromptBar.Label[0].text = "Confirm";
			}
		}
		else if (this.Column == 2)
		{
			this.MissionModeMenu.PromptBar.Label[0].text = "Confirm";
		}
		else
		{
			this.MissionModeMenu.PromptBar.Label[0].text = "";
		}
		this.MissionModeMenu.PromptBar.UpdateButtons();
	}

	// Token: 0x060019C9 RID: 6601 RVA: 0x00109CB0 File Offset: 0x00107EB0
	private void SaveInfo()
	{
		for (int i = 1; i < 11; i++)
		{
			PlayerPrefs.SetInt("MissionModeTarget" + i.ToString(), this.Target[i]);
			PlayerPrefs.SetInt("MissionModeMethod" + i.ToString(), this.Method[i]);
		}
		MissionModeGlobals.NemesisDifficulty = this.NemesisDifficulty;
		MissionModeGlobals.NemesisAggression = this.NemesisAggression;
	}

	// Token: 0x060019CA RID: 6602 RVA: 0x00109D1C File Offset: 0x00107F1C
	public void FillOutInfo()
	{
		for (int i = 1; i < 11; i++)
		{
			this.ChangeFont(this.NameLabel[i]);
			this.ChangeFont(this.MethodLabel[i]);
			this.Target[i] = PlayerPrefs.GetInt("MissionModeTarget" + i.ToString());
			this.Method[i] = PlayerPrefs.GetInt("MissionModeMethod" + i.ToString());
			if (this.Target[i] == 0)
			{
				this.NameLabel[i].text = "Kill: Nobody";
			}
			else
			{
				this.NameLabel[i].text = "Kill: " + this.JSON.Students[this.Target[i]].Name;
			}
			WWW www = new WWW(string.Concat(new string[]
			{
				"file:///",
				Application.streamingAssetsPath,
				"/Portraits/Student_",
				this.Target[i].ToString(),
				".png"
			}));
			this.Portrait[i].mainTexture = www.texture;
			this.MethodLabel[i].text = "By: " + this.MethodNames[this.Method[i]];
			this.DeathSkulls[i].SetActive(false);
		}
	}

	// Token: 0x060019CB RID: 6603 RVA: 0x00109E6E File Offset: 0x0010806E
	public void HideButtons()
	{
		this.Button[0].SetActive(false);
		this.Button[1].SetActive(false);
		this.Button[2].SetActive(false);
		this.Button[3].SetActive(false);
	}

	// Token: 0x060019CC RID: 6604 RVA: 0x00109EA8 File Offset: 0x001080A8
	private void UpdateNemesisDifficulty()
	{
		if (this.NemesisDifficulty < 0)
		{
			this.NemesisDifficulty = 4;
		}
		else if (this.NemesisDifficulty > 4)
		{
			this.NemesisDifficulty = 0;
		}
		if (this.NemesisDifficulty == 0)
		{
			this.NemesisLabel.text = "Nemesis: Off";
			return;
		}
		this.NemesisLabel.text = "Nemesis: On";
		this.NemesisPortrait.mainTexture = ((this.NemesisDifficulty > 2) ? this.AnonymousPortrait : this.NemesisGraphic);
	}

	// Token: 0x060019CD RID: 6605 RVA: 0x00109F24 File Offset: 0x00108124
	private void UpdateNemesisList()
	{
		if (this.NemesisDifficulty == 0)
		{
			this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, Vector3.zero, Time.deltaTime * 10f);
			this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
			this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (this.NemesisDifficulty == 1)
		{
			this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
			this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (this.NemesisDifficulty == 2)
		{
			this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else if (this.NemesisDifficulty == 3)
		{
			this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, Vector3.zero, Time.deltaTime * 10f);
			this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
		else if (this.NemesisDifficulty == 4)
		{
			this.NemesisObjectives[1].localScale = Vector3.Lerp(this.NemesisObjectives[1].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.NemesisObjectives[2].localScale = Vector3.Lerp(this.NemesisObjectives[2].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.NemesisObjectives[3].localScale = Vector3.Lerp(this.NemesisObjectives[3].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
		}
		if (this.NemesisAggression)
		{
			this.NemesisObjectives[4].localScale = Vector3.Lerp(this.NemesisObjectives[4].localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			return;
		}
		this.NemesisObjectives[4].localScale = Vector3.Lerp(this.NemesisObjectives[4].localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
	}

	// Token: 0x0400293C RID: 10556
	public MissionModeMenuScript MissionModeMenu;

	// Token: 0x0400293D RID: 10557
	public InputManagerScript InputManager;

	// Token: 0x0400293E RID: 10558
	public JsonScript JSON;

	// Token: 0x0400293F RID: 10559
	public GameObject[] DeathSkulls;

	// Token: 0x04002940 RID: 10560
	public GameObject[] Button;

	// Token: 0x04002941 RID: 10561
	public UILabel[] MethodLabel;

	// Token: 0x04002942 RID: 10562
	public UILabel[] NameLabel;

	// Token: 0x04002943 RID: 10563
	public UITexture[] Portrait;

	// Token: 0x04002944 RID: 10564
	public bool ChangingDifficulty;

	// Token: 0x04002945 RID: 10565
	public int[] UnsafeNumbers;

	// Token: 0x04002946 RID: 10566
	public int[] Target;

	// Token: 0x04002947 RID: 10567
	public int[] Method;

	// Token: 0x04002948 RID: 10568
	public string[] MethodNames;

	// Token: 0x04002949 RID: 10569
	public int Selected;

	// Token: 0x0400294A RID: 10570
	public int Column;

	// Token: 0x0400294B RID: 10571
	public int Row;

	// Token: 0x0400294C RID: 10572
	public Transform DifficultyOptions;

	// Token: 0x0400294D RID: 10573
	public Transform Highlight;

	// Token: 0x0400294E RID: 10574
	public Texture BlankPortrait;

	// Token: 0x0400294F RID: 10575
	public Font Arial;

	// Token: 0x04002950 RID: 10576
	public int NemesisDifficulty;

	// Token: 0x04002951 RID: 10577
	public bool NemesisAggression;

	// Token: 0x04002952 RID: 10578
	public UILabel NemesisLabel;

	// Token: 0x04002953 RID: 10579
	public UITexture NemesisPortrait;

	// Token: 0x04002954 RID: 10580
	public Texture AnonymousPortrait;

	// Token: 0x04002955 RID: 10581
	public Texture NemesisGraphic;

	// Token: 0x04002956 RID: 10582
	public Transform[] NemesisObjectives;
}