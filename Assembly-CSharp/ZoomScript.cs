﻿using System;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class ZoomScript : MonoBehaviour
{
	// Token: 0x0600212A RID: 8490 RVA: 0x001EC430 File Offset: 0x001EA630
	private void Update()
	{
		if (this.Yandere.FollowHips)
		{
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime));
		}
		if (this.Yandere.Stance.Current == StanceType.Crawling)
		{
			this.Height = 0.05f;
		}
		else if (this.Yandere.Stance.Current == StanceType.Crouching)
		{
			this.Height = 0.4f;
		}
		else
		{
			this.Height = 1f;
		}
		if (!this.Yandere.FollowHips)
		{
			if (this.Yandere.FlameDemonic)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, this.Height + this.Zoom + 0.4f, Time.deltaTime), base.transform.localPosition.z);
			}
			else if (this.Yandere.Slender)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, this.Height + this.Zoom + this.Slender, Time.deltaTime), base.transform.localPosition.z);
			}
			else if (this.Yandere.Stand.Stand.activeInHierarchy)
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, this.Height - this.Zoom * 0.5f + this.Slender * 0.5f, Time.deltaTime), base.transform.localPosition.z);
			}
			else
			{
				base.transform.localPosition = new Vector3(base.transform.localPosition.x, Mathf.MoveTowards(base.transform.localPosition.y, this.Height + this.Zoom, Time.deltaTime), base.transform.localPosition.z);
			}
		}
		else if (!this.Yandere.SithLord)
		{
			base.transform.position = new Vector3(base.transform.position.x, Mathf.MoveTowards(base.transform.position.y, this.Yandere.Hips.position.y + this.Zoom, Time.deltaTime), base.transform.position.z);
		}
		else
		{
			base.transform.position = new Vector3(base.transform.position.x, Mathf.MoveTowards(base.transform.position.y, this.Yandere.Hips.position.y, Time.deltaTime), base.transform.position.z);
		}
		if (!this.Yandere.Aiming && this.Yandere.CanMove && !this.Yandere.PauseScreen.Show)
		{
			this.TargetZoom += Input.GetAxis("Mouse ScrollWheel");
		}
		if (this.Yandere.SithLord || this.Yandere.Riding)
		{
			this.Slender = Mathf.Lerp(this.Slender, 2.5f, Time.deltaTime);
		}
		else if (this.Yandere.Slender || this.Yandere.Stand.Stand.activeInHierarchy || this.Yandere.Blasting || this.Yandere.PK || this.Yandere.Shipgirl || this.TallHat.activeInHierarchy || this.Yandere.Man.activeInHierarchy || this.Yandere.Pod.activeInHierarchy || this.Yandere.LucyHelmet.activeInHierarchy || this.Yandere.Kagune[0].activeInHierarchy || this.Yandere.Demonic || this.Yandere.FloppyHat.activeInHierarchy)
		{
			this.Slender = Mathf.Lerp(this.Slender, 0.5f, Time.deltaTime);
		}
		else
		{
			this.Slender = Mathf.Lerp(this.Slender, 0f, Time.deltaTime);
		}
		if (this.TargetZoom < 0f)
		{
			this.TargetZoom = 0f;
		}
		if (this.Yandere.Stance.Current == StanceType.Crawling)
		{
			if (this.TargetZoom > 0.3f)
			{
				this.TargetZoom = 0.3f;
			}
		}
		else if (this.TargetZoom > 0.4f)
		{
			this.TargetZoom = 0.4f;
		}
		if (this.Zoom != this.TargetZoom)
		{
			this.Zoom = Mathf.MoveTowards(this.Zoom, this.TargetZoom, Time.deltaTime);
			this.Yandere.CameraEffects.UpdateDOF(2f - this.Zoom * 3.75f);
		}
		if (!this.Yandere.Possessed)
		{
			this.CameraScript.distance = 2f - this.Zoom * 3.33333f + this.Slender;
			this.CameraScript.distanceMax = 2f - this.Zoom * 3.33333f + this.Slender;
			this.CameraScript.distanceMin = 2f - this.Zoom * 3.33333f + this.Slender;
			if (this.Yandere.TornadoHair.activeInHierarchy || (this.CardboardBox != null && this.CardboardBox.transform.parent == this.Yandere.Hips))
			{
				this.CameraScript.distanceMax += 3f;
			}
		}
		else
		{
			this.CameraScript.distance = 5f;
			this.CameraScript.distanceMax = 5f;
		}
		if (!this.Yandere.TimeSkipping)
		{
			this.Timer += Time.deltaTime;
			this.ShakeStrength = Mathf.Lerp(this.ShakeStrength, 1f - this.Yandere.Sanity * 0.01f, Time.deltaTime);
			if (this.Timer > 0.1f + this.Yandere.Sanity * 0.01f)
			{
				this.Target.x = UnityEngine.Random.Range(-this.ShakeStrength, this.ShakeStrength);
				this.Target.y = base.transform.localPosition.y;
				this.Target.z = UnityEngine.Random.Range(-this.ShakeStrength, this.ShakeStrength);
				this.Timer = 0f;
			}
		}
		else
		{
			this.Target = new Vector3(0f, base.transform.localPosition.y, 0f);
		}
		if (this.Yandere.RoofPush)
		{
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime * 10f), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime * 10f));
			return;
		}
		base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, this.Target, Time.deltaTime * this.ShakeStrength * 0.1f);
	}

	// Token: 0x0600212B RID: 8491 RVA: 0x001ECCA0 File Offset: 0x001EAEA0
	public void LateUpdate()
	{
		base.transform.eulerAngles = Vector3.zero;
		if (this.OverShoulder)
		{
			Vector3 lhs = this.Yandere.MainCamera.transform.TransformDirection(Vector3.forward);
			base.transform.position = new Vector3(this.Yandere.transform.position.x + this.midOffset * Vector3.Dot(lhs, Vector3.forward), base.transform.position.y, this.Yandere.transform.position.z + this.midOffset * Vector3.Dot(lhs, -Vector3.right));
			return;
		}
		if (this.Yandere.FollowHips)
		{
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, this.Yandere.Hips.position.x, Time.deltaTime), base.transform.position.y, Mathf.MoveTowards(base.transform.position.z, this.Yandere.Hips.position.z, Time.deltaTime));
			return;
		}
		base.transform.localPosition = new Vector3(0f, base.transform.localPosition.y, 0f);
	}

	// Token: 0x04004967 RID: 18791
	public CardboardBoxScript CardboardBox;

	// Token: 0x04004968 RID: 18792
	public RPG_Camera CameraScript;

	// Token: 0x04004969 RID: 18793
	public YandereScript Yandere;

	// Token: 0x0400496A RID: 18794
	public float TargetZoom;

	// Token: 0x0400496B RID: 18795
	public float Zoom;

	// Token: 0x0400496C RID: 18796
	public float ShakeStrength;

	// Token: 0x0400496D RID: 18797
	public float midOffset = 0.25f;

	// Token: 0x0400496E RID: 18798
	public float Slender;

	// Token: 0x0400496F RID: 18799
	public float Height;

	// Token: 0x04004970 RID: 18800
	public float Timer;

	// Token: 0x04004971 RID: 18801
	public Vector3 Target;

	// Token: 0x04004972 RID: 18802
	public bool OverShoulder;

	// Token: 0x04004973 RID: 18803
	public bool MoveCamera;

	// Token: 0x04004974 RID: 18804
	public GameObject TallHat;
}
