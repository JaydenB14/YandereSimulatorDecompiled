﻿using System;
using UnityEngine;

// Token: 0x02000415 RID: 1045
public class SciFiTerminalScript : MonoBehaviour
{
	// Token: 0x06001C52 RID: 7250 RVA: 0x0014AD16 File Offset: 0x00148F16
	private void Start()
	{
		if (this.Student.StudentID != 65)
		{
			base.enabled = false;
			return;
		}
		this.RobotArms = this.Student.StudentManager.RobotArms;
	}

	// Token: 0x06001C53 RID: 7251 RVA: 0x0014AD48 File Offset: 0x00148F48
	private void Update()
	{
		if (this.RobotArms != null)
		{
			if ((double)Vector3.Distance(this.RobotArms.TerminalTarget.position, base.transform.position) < 0.3 || (double)Vector3.Distance(this.RobotArms.TerminalTarget.position, this.OtherFinger.position) < 0.3)
			{
				if (!this.Updated)
				{
					this.Updated = true;
					if (!this.RobotArms.On[0])
					{
						this.RobotArms.ActivateArms();
						return;
					}
					this.RobotArms.ToggleWork();
					return;
				}
			}
			else
			{
				this.Updated = false;
			}
		}
	}

	// Token: 0x04003245 RID: 12869
	public StudentScript Student;

	// Token: 0x04003246 RID: 12870
	public RobotArmScript RobotArms;

	// Token: 0x04003247 RID: 12871
	public Transform OtherFinger;

	// Token: 0x04003248 RID: 12872
	public bool Updated;
}
