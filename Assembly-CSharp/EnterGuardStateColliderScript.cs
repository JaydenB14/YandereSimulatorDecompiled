﻿using System;
using UnityEngine;

// Token: 0x020002A5 RID: 677
public class EnterGuardStateColliderScript : MonoBehaviour
{
	// Token: 0x06001419 RID: 5145 RVA: 0x000C4DFD File Offset: 0x000C2FFD
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600141A RID: 5146 RVA: 0x000C4E24 File Offset: 0x000C3024
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.Teacher)
			{
				component.CharacterAnimation.CrossFade(component.GuardAnim);
				component.IgnoringPettyActions = true;
				component.Pathfinding.canSearch = false;
				component.Pathfinding.canMove = false;
				component.ReportPhase = 6;
				component.Guarding = true;
				component.Routine = false;
			}
		}
	}

	// Token: 0x04001EB7 RID: 7863
	public int Frame;
}