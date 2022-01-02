﻿using System;
using UnityEngine;

// Token: 0x020003D1 RID: 977
public class RingEventScript : MonoBehaviour
{
	// Token: 0x06001B62 RID: 7010 RVA: 0x00133EA0 File Offset: 0x001320A0
	private void Start()
	{
		this.HoldingPosition = new Vector3(0.0075f, -0.0355f, 0.0175f);
		this.HoldingRotation = new Vector3(15f, -70f, -135f);
		if (GameGlobals.RingStolen)
		{
			base.gameObject.SetActive(false);
		}
		if (GameGlobals.Eighties)
		{
			this.EventStudentID = 30;
			this.AccessoryID = 15;
		}
	}

	// Token: 0x06001B63 RID: 7011 RVA: 0x00133F0C File Offset: 0x0013210C
	private void Update()
	{
		if (!this.Clock.StopTime && !this.EventActive && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[this.EventStudentID];
			if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.EatingSnack && this.EventStudent.CurrentAction == StudentActionType.SitAndEatBento)
			{
				if (!this.EventStudent.WitnessedMurder && !this.EventStudent.Bullied)
				{
					if (this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].activeInHierarchy)
					{
						this.RingPrompt = this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].GetComponent<PromptScript>();
						this.RingCollider = this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].GetComponent<BoxCollider>();
						this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition;
						this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
						this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
						this.EventStudent.Obstacle.checkTime = 99f;
						this.EventStudent.InEvent = true;
						this.EventStudent.Private = true;
						this.EventActive = true;
						if (this.EventStudent.Following)
						{
							this.EventStudent.Pathfinding.canMove = true;
							this.EventStudent.Pathfinding.speed = 1f;
							this.EventStudent.Following = false;
							this.EventStudent.Routine = true;
							this.Yandere.Follower = null;
							this.Yandere.Followers--;
							this.EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
							this.EventStudent.Prompt.Label[0].text = "     Talk";
						}
					}
					else
					{
						Debug.Log("Disabling because the girl doesn't have her ring?");
						base.enabled = false;
					}
				}
				else
				{
					Debug.Log("Disabling because the girl witnessed murder or was bullied?");
					base.enabled = false;
				}
			}
		}
		if (this.EventActive)
		{
			if (this.EventStudent.DistanceToDestination < 0.5f)
			{
				this.EventStudent.Pathfinding.canSearch = false;
				this.EventStudent.Pathfinding.canMove = false;
			}
			if (this.EventStudent.Alarmed && this.Yandere.TheftTimer > 0f)
			{
				Debug.Log("Event ended because the owner of the ring witnessed the theft.");
				this.EventStudent.Yandere.NotificationManager.CustomText = "You failed to steal the ring.";
				this.EventStudent.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.LeftMiddleFinger;
				this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.OriginalPosition;
				this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				this.RingCollider.gameObject.SetActive(true);
				this.RingCollider.enabled = false;
				this.RingPrompt.Hide();
				this.RingPrompt.enabled = false;
				this.RingPrompt.GetComponent<RingScript>().enabled = false;
				this.EventStudent.RingReact = true;
				this.Yandere.Inventory.Ring = false;
				this.EndEvent();
				return;
			}
			if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dying || !this.EventStudent.Alive)
			{
				this.EndEvent();
				return;
			}
			if (!this.EventStudent.Pathfinding.canMove)
			{
				if (this.EventPhase == 1)
				{
					this.Timer += Time.deltaTime;
					this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
					this.EventPhase++;
				}
				else if (this.EventPhase == 2)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > this.EventStudent.CharacterAnimation[this.EventAnim[0]].length)
					{
						this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.EatAnim);
						this.EventStudent.Bento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
						this.EventStudent.Bento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
						this.EventStudent.Chopsticks[0].SetActive(true);
						this.EventStudent.Chopsticks[1].SetActive(true);
						this.EventStudent.Bento.SetActive(true);
						this.EventStudent.Lid.SetActive(false);
						this.RingCollider.enabled = true;
						this.RingPrompt.enabled = true;
						this.RingPrompt.GetComponent<RingScript>().enabled = true;
						this.RingPrompt.GetComponent<RingScript>().RingEvent = this;
						this.EventPhase++;
						this.Timer = 0f;
					}
					else if (this.Timer > 4f)
					{
						if (this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID] != null)
						{
							this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = null;
							if (!this.StudentManager.Eighties)
							{
								this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.position = new Vector3(-2.707666f, 12.4695f, -31.136f);
								this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.eulerAngles = new Vector3(-20f, 180f, 0f);
							}
							else
							{
								this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.position = new Vector3(4.946667f, 0.4768f, 18.65925f);
								this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.eulerAngles = new Vector3(-22.5f, 180f, 0f);
							}
						}
					}
					else if (this.Timer > 2.5f)
					{
						this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.RightHand;
						this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.HoldingPosition;
						this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localEulerAngles = this.HoldingRotation;
					}
				}
				else if (this.EventPhase == 3)
				{
					if (this.Clock.HourTime > 13.375f)
					{
						this.EventStudent.Bento.SetActive(false);
						this.EventStudent.Chopsticks[0].SetActive(false);
						this.EventStudent.Chopsticks[1].SetActive(false);
						if (this.RingCollider != null)
						{
							this.RingCollider.enabled = false;
						}
						if (this.RingPrompt != null)
						{
							this.RingPrompt.Hide();
							this.RingPrompt.enabled = false;
						}
						RingScript component = this.RingPrompt.GetComponent<RingScript>();
						if (component != null)
						{
							component.enabled = false;
						}
						this.EventStudent.CharacterAnimation[this.EventAnim[0]].time = this.EventStudent.CharacterAnimation[this.EventAnim[0]].length;
						this.EventStudent.CharacterAnimation[this.EventAnim[0]].speed = -1f;
						if (!this.RingStolen)
						{
							this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
						}
						else
						{
							this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[1]);
						}
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 4)
				{
					this.Timer += Time.deltaTime;
					if (!this.RingStolen && this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID] != null && this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].activeInHierarchy)
					{
						this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
						if (this.Timer > 2f)
						{
							this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.RightHand;
							this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.HoldingPosition;
							this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localEulerAngles = this.HoldingRotation;
						}
						if (this.Timer > 3f)
						{
							this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.LeftMiddleFinger;
							this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.OriginalPosition;
							this.RingCollider.enabled = false;
							this.RingPrompt.enabled = false;
							this.RingPrompt.Hide();
							this.RingPrompt.GetComponent<RingScript>().enabled = false;
						}
						if (this.Timer > 6f)
						{
							this.EndEvent();
						}
					}
					else
					{
						Debug.Log("The ring was stolen.");
						this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[1]);
						if (this.Timer > 1.5f)
						{
							if (Vector3.Distance(this.EventStudent.transform.position, this.Yandere.transform.position) < 10f)
							{
								this.EventSubtitle.text = this.EventSpeech[0];
								AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position + Vector3.up, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
							}
							this.EventPhase++;
						}
					}
				}
				else if (this.EventPhase == 5)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 9.5f)
					{
						this.EndEvent();
					}
				}
				float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (num < 11f)
				{
					if (num < 10f)
					{
						float num2 = Mathf.Abs((num - 10f) * 0.2f);
						if (num2 < 0f)
						{
							num2 = 0f;
						}
						if (num2 > 1f)
						{
							num2 = 1f;
						}
						this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
						return;
					}
					this.EventSubtitle.transform.localScale = Vector3.zero;
					return;
				}
			}
			else
			{
				this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.WalkAnim);
			}
		}
	}

	// Token: 0x06001B64 RID: 7012 RVA: 0x00134BCC File Offset: 0x00132DCC
	private void EndEvent()
	{
		if (!this.EventOver)
		{
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Obstacle.checkTime = 1f;
			if (!this.EventStudent.Dying)
			{
				this.EventStudent.Prompt.enabled = true;
			}
			this.EventStudent.Pathfinding.speed = 1f;
			this.EventStudent.TargetDistance = 0.5f;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents(0);
		}
		this.EventActive = false;
		base.enabled = false;
	}

	// Token: 0x06001B65 RID: 7013 RVA: 0x00134CE0 File Offset: 0x00132EE0
	public void ReturnRing()
	{
		if (this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID] != null)
		{
			this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.parent = this.EventStudent.LeftMiddleFinger;
			this.EventStudent.Cosmetic.FemaleAccessories[this.AccessoryID].transform.localPosition = this.OriginalPosition;
			this.RingCollider.enabled = false;
			this.RingPrompt.Hide();
			this.RingPrompt.enabled = false;
			this.RingPrompt.GetComponent<RingScript>().enabled = false;
		}
	}

	// Token: 0x04002EC9 RID: 11977
	public StudentManagerScript StudentManager;

	// Token: 0x04002ECA RID: 11978
	public YandereScript Yandere;

	// Token: 0x04002ECB RID: 11979
	public ClockScript Clock;

	// Token: 0x04002ECC RID: 11980
	public StudentScript EventStudent;

	// Token: 0x04002ECD RID: 11981
	public UILabel EventSubtitle;

	// Token: 0x04002ECE RID: 11982
	public AudioClip[] EventClip;

	// Token: 0x04002ECF RID: 11983
	public string[] EventSpeech;

	// Token: 0x04002ED0 RID: 11984
	public string[] EventAnim;

	// Token: 0x04002ED1 RID: 11985
	public GameObject VoiceClip;

	// Token: 0x04002ED2 RID: 11986
	public bool EventActive;

	// Token: 0x04002ED3 RID: 11987
	public bool RingStolen;

	// Token: 0x04002ED4 RID: 11988
	public bool EventOver;

	// Token: 0x04002ED5 RID: 11989
	public float EventTime = 13.1f;

	// Token: 0x04002ED6 RID: 11990
	public int EventStudentID = 2;

	// Token: 0x04002ED7 RID: 11991
	public int AccessoryID = 3;

	// Token: 0x04002ED8 RID: 11992
	public int EventPhase = 1;

	// Token: 0x04002ED9 RID: 11993
	public Vector3 OriginalPosition;

	// Token: 0x04002EDA RID: 11994
	public Vector3 HoldingPosition;

	// Token: 0x04002EDB RID: 11995
	public Vector3 HoldingRotation;

	// Token: 0x04002EDC RID: 11996
	public float CurrentClipLength;

	// Token: 0x04002EDD RID: 11997
	public float Timer;

	// Token: 0x04002EDE RID: 11998
	public PromptScript RingPrompt;

	// Token: 0x04002EDF RID: 11999
	public Collider RingCollider;
}