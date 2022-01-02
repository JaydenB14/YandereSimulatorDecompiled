﻿using System;
using UnityEngine;

// Token: 0x02000465 RID: 1125
public class TaskManagerScript : MonoBehaviour
{
	// Token: 0x06001E75 RID: 7797 RVA: 0x001AAD7C File Offset: 0x001A8F7C
	public void Start()
	{
		for (int i = 1; i < 101; i++)
		{
			this.TaskStatus[i] = TaskGlobals.GetTaskStatus(i);
		}
		for (int j = 1; j < this.TaskObjects.Length; j++)
		{
			if (this.TaskObjects[j] != null)
			{
				this.TaskObjects[j].SetActive(false);
			}
		}
		if (this.TaskStatus[46] == 1)
		{
			TaskGlobals.SetTaskStatus(46, 0);
			this.TaskStatus[46] = 0;
		}
		if (this.StudentManager != null)
		{
			this.UpdateTaskStatus();
		}
		this.Initialized = true;
	}

	// Token: 0x06001E76 RID: 7798 RVA: 0x001AAE10 File Offset: 0x001A9010
	public void CheckTaskPickups()
	{
		if (!this.StudentManager.Eighties)
		{
			if (this.TaskStatus[11] == 1 && this.Prompts[11].Circle[3] != null && this.Prompts[11].Circle[3].fillAmount == 0f)
			{
				if (this.StudentManager.Students[11] != null)
				{
					this.StudentManager.Students[11].TaskPhase = 5;
				}
				this.Yandere.NotificationManager.TopicName = "Cats";
				this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
				ConversationGlobals.SetTopicLearnedByStudent(15, 11, true);
				this.TaskStatus[11] = 2;
				UnityEngine.Object.Destroy(this.TaskObjects[11]);
			}
			if (this.TaskStatus[25] == 1 && this.Prompts[25].Circle[3].fillAmount == 0f)
			{
				if (this.StudentManager.Students[25] != null)
				{
					this.StudentManager.Students[25].TaskPhase = 5;
				}
				this.TaskStatus[25] = 2;
				UnityEngine.Object.Destroy(this.TaskObjects[25]);
			}
			if (this.TaskStatus[37] == 1 && this.Prompts[37].Circle[3] != null && this.Prompts[37].Circle[3].fillAmount == 0f)
			{
				if (this.StudentManager.Students[37] != null)
				{
					this.StudentManager.Students[37].TaskPhase = 5;
				}
				this.TaskStatus[37] = 2;
				UnityEngine.Object.Destroy(this.TaskObjects[37]);
			}
		}
	}

	// Token: 0x06001E77 RID: 7799 RVA: 0x001AAFD4 File Offset: 0x001A91D4
	public void UpdateTaskStatus()
	{
		if (!this.StudentManager.Eighties)
		{
			if (this.TaskStatus[8] == 1 && this.StudentManager.Students[8] != null)
			{
				if (this.StudentManager.Students[8].TaskPhase == 0)
				{
					this.StudentManager.Students[8].TaskPhase = 4;
				}
				if (this.Yandere.Inventory.Soda)
				{
					this.StudentManager.Students[8].TaskPhase = 5;
				}
			}
			if (this.TaskStatus[11] == 1)
			{
				if (this.StudentManager.Students[11] != null)
				{
					if (this.StudentManager.Students[11].TaskPhase == 0)
					{
						this.StudentManager.Students[11].TaskPhase = 4;
					}
					this.TaskObjects[11].SetActive(true);
				}
			}
			else if (this.TaskObjects[11] != null)
			{
				this.TaskObjects[11].SetActive(false);
			}
			if (this.TaskStatus[25] == 1)
			{
				if (this.StudentManager.Students[25] != null)
				{
					if (this.StudentManager.Students[25].TaskPhase == 0)
					{
						this.StudentManager.Students[25].TaskPhase = 4;
					}
					this.TaskObjects[25].SetActive(true);
				}
			}
			else if (this.TaskObjects[25] != null)
			{
				this.TaskObjects[25].SetActive(false);
			}
			if (this.TaskStatus[28] == 1 && this.StudentManager.Students[28] != null)
			{
				if (this.StudentManager.Students[28].TaskPhase == 0)
				{
					this.StudentManager.Students[28].TaskPhase = 4;
				}
				for (int i = 1; i < 26; i++)
				{
					if (TaskGlobals.GetKittenPhoto(i))
					{
						Debug.Log("Riku's Task can be turned in.");
						this.StudentManager.Students[28].TaskPhase = 5;
					}
				}
			}
			if (this.TaskStatus[30] == 1 && this.StudentManager.Students[30] != null && this.StudentManager.Students[30].TaskPhase == 0)
			{
				this.StudentManager.Students[30].TaskPhase = 4;
			}
			if (this.TaskStatus[36] == 1 && this.StudentManager.Students[36] != null)
			{
				if (this.StudentManager.Students[36].TaskPhase == 0)
				{
					this.StudentManager.Students[36].TaskPhase = 4;
				}
				if (this.GirlsQuestioned[1] && this.GirlsQuestioned[2] && this.GirlsQuestioned[3] && this.GirlsQuestioned[4] && this.GirlsQuestioned[5])
				{
					Debug.Log("Gema's task should be ready to turn in!");
					this.StudentManager.Students[36].TaskPhase = 5;
				}
			}
			if (this.TaskStatus[37] == 1)
			{
				if (this.StudentManager.Students[37] != null)
				{
					if (this.StudentManager.Students[37].TaskPhase == 0)
					{
						this.StudentManager.Students[37].TaskPhase = 4;
					}
					this.TaskObjects[37].SetActive(true);
				}
			}
			else if (this.TaskObjects[37] != null)
			{
				this.TaskObjects[37].SetActive(false);
			}
			if (this.TaskStatus[38] == 1)
			{
				if (this.StudentManager.Students[38] != null && this.StudentManager.Students[38].TaskPhase == 0)
				{
					this.StudentManager.Students[38].TaskPhase = 4;
				}
			}
			else if (this.TaskStatus[38] == 2 && this.StudentManager.Students[38] != null)
			{
				this.StudentManager.Students[38].TaskPhase = 5;
			}
			if (this.TaskStatus[46] == 1 && this.StudentManager.Students[46] != null)
			{
				if (this.StudentManager.Students[46].TaskPhase == 0)
				{
					this.StudentManager.Students[46].TaskPhase = 4;
				}
				if (this.StudentManager.Students[10] != null && Vector3.Distance(this.StudentManager.Students[46].transform.position, this.StudentManager.Students[10].transform.position) < 2f)
				{
					Debug.Log("Budo's task should be ready to turn in!");
					this.StudentManager.Students[46].TaskPhase = 5;
				}
			}
			if (ClubGlobals.GetClubClosed(ClubType.LightMusic) || this.StudentManager.Students[51] == null)
			{
				if (this.StudentManager.Students[52] != null)
				{
					this.StudentManager.Students[52].TaskPhase = 100;
				}
				this.TaskStatus[52] = 100;
			}
			else if (this.TaskStatus[52] == 1 && this.StudentManager.Students[52] != null)
			{
				this.StudentManager.Students[52].TaskPhase = 4;
				for (int j = 1; j < 52; j++)
				{
					if (TaskGlobals.GetGuitarPhoto(j))
					{
						this.StudentManager.Students[52].TaskPhase = 5;
					}
				}
			}
			if (this.TaskStatus[81] == 1 && this.StudentManager.Students[81] != null)
			{
				if (this.StudentManager.Students[81].TaskPhase == 0)
				{
					this.StudentManager.Students[81].TaskPhase = 4;
				}
				for (int k = 1; k < 26; k++)
				{
					if (TaskGlobals.GetHorudaPhoto(k))
					{
						Debug.Log("Musume's Task can be turned in.");
						this.StudentManager.Students[81].TaskPhase = 5;
					}
				}
				return;
			}
		}
		else if (this.TaskStatus[79] == 1 && this.StudentManager.Students[79] != null)
		{
			Debug.Log("Telling Yakuza's litle brother to change his destination.");
			ScheduleBlock scheduleBlock = this.StudentManager.Students[79].ScheduleBlocks[6];
			scheduleBlock.destination = "Wait";
			scheduleBlock.action = "Wait";
			ScheduleBlock scheduleBlock2 = this.StudentManager.Students[79].ScheduleBlocks[7];
			scheduleBlock2.destination = "Wait";
			scheduleBlock2.action = "Wait";
			this.StudentManager.Students[79].GetDestinations();
		}
	}

	// Token: 0x06001E78 RID: 7800 RVA: 0x001AB64C File Offset: 0x001A984C
	public void SaveTaskStatuses()
	{
		for (int i = 1; i < 101; i++)
		{
			TaskGlobals.SetTaskStatus(i, this.TaskStatus[i]);
			if (this.StudentManager.Students[i] != null)
			{
				PlayerGlobals.SetStudentFriend(i, this.StudentManager.Students[i].Friend);
			}
		}
	}

	// Token: 0x04003EE3 RID: 16099
	public StudentManagerScript StudentManager;

	// Token: 0x04003EE4 RID: 16100
	public YandereScript Yandere;

	// Token: 0x04003EE5 RID: 16101
	public GameObject[] TaskObjects;

	// Token: 0x04003EE6 RID: 16102
	public PromptScript[] Prompts;

	// Token: 0x04003EE7 RID: 16103
	public bool[] GirlsQuestioned;

	// Token: 0x04003EE8 RID: 16104
	public int[] TaskStatus;

	// Token: 0x04003EE9 RID: 16105
	public bool Initialized;
}