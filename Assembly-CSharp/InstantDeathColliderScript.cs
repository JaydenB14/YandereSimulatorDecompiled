﻿using System;
using UnityEngine;

// Token: 0x02000336 RID: 822
public class InstantDeathColliderScript : MonoBehaviour
{
	// Token: 0x060018D0 RID: 6352 RVA: 0x000F4FC3 File Offset: 0x000F31C3
	private void Update()
	{
		this.Frame++;
		if (this.Frame > 1)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x060018D1 RID: 6353 RVA: 0x000F4FE8 File Offset: 0x000F31E8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				if (component.Rival)
				{
					component.StudentManager.RivalEliminated = true;
					component.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Accident;
					Debug.Log("Attempting to tell the game that the rival was murdered.");
				}
				component.DeathType = DeathType.Explosion;
				component.BecomeRagdoll();
				Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
				rigidbody.isKinematic = false;
				Vector3 a = rigidbody.transform.position - base.transform.position;
				rigidbody.AddForce(a * 5000f);
			}
		}
	}

	// Token: 0x04002624 RID: 9764
	public int Frame;
}
