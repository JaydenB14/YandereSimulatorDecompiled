﻿using System;
using UnityEngine;

// Token: 0x0200011D RID: 285
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/WaterDropPro")]
public class CameraFilterPack_AAA_WaterDropPro : MonoBehaviour
{
	// Token: 0x17000222 RID: 546
	// (get) Token: 0x06000B2E RID: 2862 RVA: 0x0006B4E4 File Offset: 0x000696E4
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06000B2F RID: 2863 RVA: 0x0006B518 File Offset: 0x00069718
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_WaterDrop") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/AAA_WaterDropPro");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B30 RID: 2864 RVA: 0x0006B550 File Offset: 0x00069750
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_SizeX", this.SizeX);
			this.material.SetFloat("_SizeY", this.SizeY);
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B31 RID: 2865 RVA: 0x0006B631 File Offset: 0x00069831
	private void Update()
	{
	}

	// Token: 0x06000B32 RID: 2866 RVA: 0x0006B633 File Offset: 0x00069833
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F2F RID: 3887
	public Shader SCShader;

	// Token: 0x04000F30 RID: 3888
	private float TimeX = 1f;

	// Token: 0x04000F31 RID: 3889
	[Range(8f, 64f)]
	public float Distortion = 8f;

	// Token: 0x04000F32 RID: 3890
	[Range(0f, 7f)]
	public float SizeX = 1f;

	// Token: 0x04000F33 RID: 3891
	[Range(0f, 7f)]
	public float SizeY = 0.5f;

	// Token: 0x04000F34 RID: 3892
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04000F35 RID: 3893
	private Material SCMaterial;

	// Token: 0x04000F36 RID: 3894
	private Texture2D Texture2;
}