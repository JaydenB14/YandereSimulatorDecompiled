﻿using System;
using UnityEngine;

// Token: 0x020000BD RID: 189
public class RPG_Controller : MonoBehaviour
{
	// Token: 0x0600098B RID: 2443 RVA: 0x0004C597 File Offset: 0x0004A797
	private void Awake()
	{
		RPG_Controller.instance = this;
		this.characterController = (base.GetComponent("CharacterController") as CharacterController);
		RPG_Camera.CameraSetup();
		this.MainCamera = Camera.main;
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x0004C5C5 File Offset: 0x0004A7C5
	private void Update()
	{
		if (this.MainCamera == null)
		{
			return;
		}
		if (this.characterController == null)
		{
			Debug.Log("Error: No Character Controller component found! Please add one to the GameObject which has this script attached.");
			return;
		}
		this.GetInput();
		this.StartMotor();
	}

	// Token: 0x0600098D RID: 2445 RVA: 0x0004C5FC File Offset: 0x0004A7FC
	private void GetInput()
	{
		float d = 0f;
		float d2 = 0f;
		if (Input.GetButton("Horizontal Strafe"))
		{
			d = ((Input.GetAxis("Horizontal Strafe") < 0f) ? -1f : ((Input.GetAxis("Horizontal Strafe") > 0f) ? 1f : 0f));
		}
		if (Input.GetButton("Vertical"))
		{
			d2 = ((Input.GetAxis("Vertical") < 0f) ? -1f : ((Input.GetAxis("Vertical") > 0f) ? 1f : 0f));
		}
		if (Input.GetMouseButton(0) && Input.GetMouseButton(1))
		{
			d2 = 1f;
		}
		this.playerDir = d * Vector3.right + d2 * Vector3.forward;
		if (RPG_Animation.instance != null)
		{
			RPG_Animation.instance.SetCurrentMoveDir(this.playerDir);
		}
		if (this.characterController.isGrounded)
		{
			this.playerDirWorld = base.transform.TransformDirection(this.playerDir);
			if (Mathf.Abs(this.playerDir.x) + Mathf.Abs(this.playerDir.z) > 1f)
			{
				this.playerDirWorld.Normalize();
			}
			this.playerDirWorld *= this.walkSpeed;
			this.playerDirWorld.y = this.fallingThreshold;
			if (Input.GetButtonDown("Jump"))
			{
				this.playerDirWorld.y = this.jumpHeight;
				if (RPG_Animation.instance != null)
				{
					RPG_Animation.instance.Jump();
				}
			}
		}
		this.rotation.y = Input.GetAxis("Horizontal") * this.turnSpeed;
	}

	// Token: 0x0600098E RID: 2446 RVA: 0x0004C7C0 File Offset: 0x0004A9C0
	private void StartMotor()
	{
		this.playerDirWorld.y = this.playerDirWorld.y - this.gravity * Time.deltaTime;
		this.characterController.Move(this.playerDirWorld * Time.deltaTime);
		base.transform.Rotate(this.rotation);
		if (!Input.GetMouseButton(0))
		{
			RPG_Camera.instance.RotateWithCharacter();
		}
	}

	// Token: 0x0400082D RID: 2093
	public static RPG_Controller instance;

	// Token: 0x0400082E RID: 2094
	public CharacterController characterController;

	// Token: 0x0400082F RID: 2095
	public float walkSpeed = 10f;

	// Token: 0x04000830 RID: 2096
	public float turnSpeed = 2.5f;

	// Token: 0x04000831 RID: 2097
	public float jumpHeight = 10f;

	// Token: 0x04000832 RID: 2098
	public float gravity = 20f;

	// Token: 0x04000833 RID: 2099
	public float fallingThreshold = -6f;

	// Token: 0x04000834 RID: 2100
	private Vector3 playerDir;

	// Token: 0x04000835 RID: 2101
	private Vector3 playerDirWorld;

	// Token: 0x04000836 RID: 2102
	private Vector3 rotation = Vector3.zero;

	// Token: 0x04000837 RID: 2103
	private Camera MainCamera;
}
