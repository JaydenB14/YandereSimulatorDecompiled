﻿using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
public class EventManagerScript : MonoBehaviour
{
	// Token: 0x0600144A RID: 5194 RVA: 0x000C5360 File Offset: 0x000C3560
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			this.EventCheck = true;
		}
		if (this.OsanaID == 3)
		{
			if (GameGlobals.Eighties || DateGlobals.Weekday != DayOfWeek.Thursday || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode)
			{
				base.enabled = false;
			}
			else
			{
				this.EventCheck = true;
			}
		}
		this.NoteLocker.Prompt.enabled = true;
		this.NoteLocker.CanLeaveNote = true;
	}

	// Token: 0x0600144B RID: 5195 RVA: 0x000C53E4 File Offset: 0x000C35E4
	private void Update()
	{
		if (this.VoiceClip != null)
		{
			if (this.VoiceClipSource == null)
			{
				this.VoiceClipSource = this.VoiceClip.GetComponent<AudioSource>();
			}
			else
			{
				this.VoiceClipSource.pitch = Time.timeScale;
			}
		}
		if (!this.Clock.StopTime && this.EventCheck && this.CanHappen)
		{
			if (this.Clock.HourTime > this.StartTime + 1f)
			{
				base.enabled = false;
			}
			else if (this.Clock.HourTime > this.StartTime)
			{
				if (this.EventStudent[1] == null)
				{
					this.EventStudent[1] = this.StudentManager.Students[this.EventStudent1];
				}
				else if (!this.EventStudent[1].Alive)
				{
					this.EventCheck = false;
					base.enabled = false;
				}
				if (this.EventStudent[2] == null)
				{
					this.EventStudent[2] = this.StudentManager.Students[this.EventStudent2];
				}
				else if (!this.EventStudent[2].Alive)
				{
					this.EventCheck = false;
					base.enabled = false;
				}
				if (this.EventStudent[1] != null && this.EventStudent[2] != null && this.EventStudent[1].enabled && !this.EventStudent[1].Slave && !this.EventStudent[2].Slave && this.EventStudent[1].Indoors && !this.EventStudent[1].Wet && !this.EventStudent[1].Meeting && !this.EventStudent[1].Talking && (this.OsanaID < 2 || (this.OsanaID > 1 && Vector3.Distance(this.EventStudent[1].transform.position, this.EventLocation[1].position) < 1f)))
				{
					this.StartTimer += Time.deltaTime;
					if (this.StartTimer > 1f && this.EventStudent[1].Routine && this.EventStudent[2].Routine && !this.EventStudent[1].InEvent && !this.EventStudent[2].InEvent)
					{
						this.EventStudent[1].CurrentDestination = this.EventLocation[1];
						this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
						this.EventStudent[1].EventManager = this;
						this.EventStudent[1].InEvent = true;
						this.EventStudent[1].EmptyHands();
						this.EventStudent[2].InEvent = true;
						if (!this.Osana)
						{
							this.EventStudent[2].CurrentDestination = this.EventLocation[2];
							this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
							this.EventStudent[2].EventManager = this;
							this.EventStudent[2].InEvent = true;
							Debug.Log("Kokona's rooftop event just began?");
						}
						else
						{
							Debug.Log("One of Osana's ''talk privately with Raibaru'' events is beginning.");
							this.Yandere.PauseScreen.Hint.Show = true;
							if (DateGlobals.Weekday == DayOfWeek.Monday)
							{
								if ((double)this.StartTime < 7.3)
								{
									this.Yandere.PauseScreen.Hint.QuickID = 14;
								}
								else
								{
									this.Yandere.PauseScreen.Hint.QuickID = 18;
								}
							}
							if (DateGlobals.Weekday == DayOfWeek.Thursday)
							{
								this.Yandere.PauseScreen.Hint.QuickID = 13;
							}
							if ((double)this.StartTime > 15.5)
							{
								this.EventStudent[1].FollowTargetDestination.localPosition = new Vector3(1f, 0f, 1f);
							}
						}
						this.EventStudent[2].EmptyHands();
						this.EventStudent[1].SpeechLines.Stop();
						this.EventStudent[2].SpeechLines.Stop();
						this.EventCheck = false;
						this.EventOn = true;
					}
				}
			}
		}
		if (this.EventOn)
		{
			float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position);
			if (this.Clock.HourTime > this.EndTime || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Dying || this.EventStudent[2].Dying || this.EventStudent[1].Splashed || this.EventStudent[2].Splashed || this.EventStudent[1].Alarmed || this.EventStudent[2].Alarmed)
			{
				this.EndEvent();
				return;
			}
			if (this.Osana)
			{
				if (this.EventStudent[1].DistanceToDestination < 1f)
				{
					this.EventStudent[2].CurrentDestination = this.EventLocation[2];
					this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
					this.EventStudent[2].EventManager = this;
				}
				else
				{
					if (this.EventStudent[1].Pathfinding.canMove)
					{
						this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
					}
					this.EventStudent[2].CurrentDestination = this.EventStudent[1].FollowTargetDestination;
					this.EventStudent[2].Pathfinding.target = this.EventStudent[1].FollowTargetDestination;
				}
			}
			else
			{
				if (this.EventStudent[1].DistanceToDestination > 1f)
				{
					this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
				}
				if (this.EventStudent[2].DistanceToDestination > 1f)
				{
					this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
				}
			}
			if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[1].Private)
			{
				this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
				this.EventStudent[1].Private = true;
				this.StudentManager.UpdateStudents(0);
			}
			if (Vector3.Distance(this.EventStudent[2].transform.position, this.EventLocation[2].position) < 1f && !this.EventStudent[2].Pathfinding.canMove && !this.StopWalking)
			{
				this.StopWalking = true;
				this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
				this.EventStudent[2].Private = true;
				this.StudentManager.UpdateStudents(0);
			}
			if (this.StopWalking && this.EventPhase == 1)
			{
				this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
			}
			if (Vector3.Distance(this.EventStudent[1].transform.position, this.EventLocation[1].position) < 1f && !this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
			{
				if (this.EventPhase == 1)
				{
					this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
				}
				if (this.Osana)
				{
					this.SettleFriend();
				}
				if (!this.Spoken)
				{
					this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade(this.EventAnim[this.EventPhase]);
					if (num < 10f)
					{
						this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
					}
					AudioClipPlayer.Play(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.Spoken = true;
				}
				else
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > this.EventClip[this.EventPhase].length)
					{
						this.EventSubtitle.text = string.Empty;
					}
					if (this.Yandere.transform.position.y < this.EventStudent[1].transform.position.y - 1f)
					{
						this.EventSubtitle.transform.localScale = Vector3.zero;
					}
					else if (num < 10f)
					{
						this.Scale = Mathf.Abs((num - 10f) * 0.2f);
						if (this.Scale < 0f)
						{
							this.Scale = 0f;
						}
						if (this.Scale > 1f)
						{
							this.Scale = 1f;
						}
						this.Jukebox.Dip = 1f - 0.5f * this.Scale;
						this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
					}
					else
					{
						this.EventSubtitle.transform.localScale = Vector3.zero;
					}
					Animation characterAnimation = this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation;
					if (characterAnimation[this.EventAnim[this.EventPhase]].time >= characterAnimation[this.EventAnim[this.EventPhase]].length - 1f)
					{
						characterAnimation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].IdleAnim, 1f);
					}
					if (this.Timer > this.EventClip[this.EventPhase].length + 1f)
					{
						this.Spoken = false;
						this.EventPhase++;
						this.Timer = 0f;
						if (this.EventPhase == this.EventSpeech.Length)
						{
							this.EndEvent();
						}
					}
					if (!this.Suitor && this.Yandere.transform.position.y > this.EventStudent[1].transform.position.y - 1f && this.EventPhase == 7 && num < 5f)
					{
						if (this.EventStudent1 == 25)
						{
							if (!EventGlobals.Event1)
							{
								this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
								EventGlobals.Event1 = true;
							}
						}
						else if (this.OsanaID < 2 && !this.Yandere.Police.EndOfDay.LearnedOsanaInfo2)
						{
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
							this.Yandere.Police.EndOfDay.LearnedOsanaInfo2 = true;
							this.StudentManager.OsanaOfferHelp.Eavesdropped = true;
							if (SchemeGlobals.GetSchemeStage(6) == 2)
							{
								if (this.EventStudent[1].Friend)
								{
									SchemeGlobals.SetSchemeStage(6, 4);
								}
								else
								{
									SchemeGlobals.SetSchemeStage(6, 3);
								}
								this.Yandere.PauseScreen.Schemes.UpdateInstructions();
							}
						}
					}
				}
				if (base.enabled)
				{
					if (num < 3f)
					{
						this.Yandere.Eavesdropping = true;
						return;
					}
					this.Yandere.Eavesdropping = false;
				}
			}
		}
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x000C6000 File Offset: 0x000C4200
	private void SettleFriend()
	{
		this.EventStudent[2].MoveTowardsTarget(this.EventLocation[2].position);
		if (Quaternion.Angle(this.EventStudent[2].transform.rotation, this.EventLocation[2].rotation) > 1f)
		{
			this.EventStudent[2].transform.rotation = Quaternion.Slerp(this.EventStudent[2].transform.rotation, this.EventLocation[2].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x000C6094 File Offset: 0x000C4294
	public void EndEvent()
	{
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		this.EventStudent[1].CurrentDestination = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
		this.EventStudent[1].Pathfinding.target = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
		this.EventStudent[1].EventManager = null;
		this.EventStudent[1].InEvent = false;
		this.EventStudent[1].Private = false;
		this.EventStudent[2].CurrentDestination = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
		this.EventStudent[2].Pathfinding.target = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
		this.EventStudent[2].EventManager = null;
		this.EventStudent[2].InEvent = false;
		this.EventStudent[2].Private = false;
		if ((double)this.StartTime > 15.5)
		{
			this.EventStudent[1].FollowTargetDestination.localPosition = new Vector3(1f, 0f, 0f);
		}
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Jukebox.Dip = 1f;
		this.Yandere.Eavesdropping = false;
		this.EventSubtitle.text = string.Empty;
		this.EventCheck = false;
		this.EventOn = false;
		base.enabled = false;
	}

	// Token: 0x04001F28 RID: 7976
	public StudentManagerScript StudentManager;

	// Token: 0x04001F29 RID: 7977
	public NoteLockerScript NoteLocker;

	// Token: 0x04001F2A RID: 7978
	public UILabel EventSubtitle;

	// Token: 0x04001F2B RID: 7979
	public YandereScript Yandere;

	// Token: 0x04001F2C RID: 7980
	public JukeboxScript Jukebox;

	// Token: 0x04001F2D RID: 7981
	public ClockScript Clock;

	// Token: 0x04001F2E RID: 7982
	public StudentScript[] EventStudent;

	// Token: 0x04001F2F RID: 7983
	public Transform[] EventLocation;

	// Token: 0x04001F30 RID: 7984
	public AudioClip[] EventClip;

	// Token: 0x04001F31 RID: 7985
	public string[] EventSpeech;

	// Token: 0x04001F32 RID: 7986
	public string[] EventAnim;

	// Token: 0x04001F33 RID: 7987
	public int[] EventSpeaker;

	// Token: 0x04001F34 RID: 7988
	public GameObject VoiceClip;

	// Token: 0x04001F35 RID: 7989
	public AudioSource VoiceClipSource;

	// Token: 0x04001F36 RID: 7990
	public bool StopWalking;

	// Token: 0x04001F37 RID: 7991
	public bool EventCheck;

	// Token: 0x04001F38 RID: 7992
	public bool CanHappen;

	// Token: 0x04001F39 RID: 7993
	public bool HintGiven;

	// Token: 0x04001F3A RID: 7994
	public bool EventOn;

	// Token: 0x04001F3B RID: 7995
	public bool Suitor;

	// Token: 0x04001F3C RID: 7996
	public bool Spoken;

	// Token: 0x04001F3D RID: 7997
	public bool Osana;

	// Token: 0x04001F3E RID: 7998
	public float StartTimer;

	// Token: 0x04001F3F RID: 7999
	public float Timer;

	// Token: 0x04001F40 RID: 8000
	public float Scale;

	// Token: 0x04001F41 RID: 8001
	public float StartTime = 13.01f;

	// Token: 0x04001F42 RID: 8002
	public float EndTime = 13.5f;

	// Token: 0x04001F43 RID: 8003
	public int EventStudent1;

	// Token: 0x04001F44 RID: 8004
	public int EventStudent2;

	// Token: 0x04001F45 RID: 8005
	public int EventPhase;

	// Token: 0x04001F46 RID: 8006
	public int OsanaID = 1;
}