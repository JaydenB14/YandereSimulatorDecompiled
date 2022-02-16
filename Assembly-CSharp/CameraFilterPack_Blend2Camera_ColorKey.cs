﻿using System;
using UnityEngine;

// Token: 0x0200012B RID: 299
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Chroma Key/Color Key")]
public class CameraFilterPack_Blend2Camera_ColorKey : MonoBehaviour
{
	// Token: 0x1700022F RID: 559
	// (get) Token: 0x06000B8A RID: 2954 RVA: 0x0006D46B File Offset: 0x0006B66B
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

	// Token: 0x06000B8B RID: 2955 RVA: 0x0006D4A0 File Offset: 0x0006B6A0
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture((int)this.ScreenSize.x, (int)this.ScreenSize.y, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B8C RID: 2956 RVA: 0x0006D514 File Offset: 0x0006B714
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.Adjust);
			this.material.SetFloat("_Value3", this.Precision);
			this.material.SetFloat("_Value4", this.Luminosity);
			this.material.SetFloat("_Value5", this.Change_Red);
			this.material.SetFloat("_Value6", this.Change_Green);
			this.material.SetFloat("_Value7", this.Change_Blue);
			this.material.SetColor("_ColorKey", this.ColorKey);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B8D RID: 2957 RVA: 0x0006D65B File Offset: 0x0006B85B
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000B8E RID: 2958 RVA: 0x0006D685 File Offset: 0x0006B885
	private void OnEnable()
	{
		this.Start();
		this.Update();
	}

	// Token: 0x06000B8F RID: 2959 RVA: 0x0006D694 File Offset: 0x0006B894
	private void OnDisable()
	{
		if (this.Camera2 != null && this.Camera2.targetTexture != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000FB2 RID: 4018
	private string ShaderName = "CameraFilterPack/Blend2Camera_ColorKey";

	// Token: 0x04000FB3 RID: 4019
	public Shader SCShader;

	// Token: 0x04000FB4 RID: 4020
	public Camera Camera2;

	// Token: 0x04000FB5 RID: 4021
	private float TimeX = 1f;

	// Token: 0x04000FB6 RID: 4022
	private Material SCMaterial;

	// Token: 0x04000FB7 RID: 4023
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04000FB8 RID: 4024
	public Color ColorKey;

	// Token: 0x04000FB9 RID: 4025
	[Range(-0.2f, 0.2f)]
	public float Adjust;

	// Token: 0x04000FBA RID: 4026
	[Range(-0.2f, 0.2f)]
	public float Precision;

	// Token: 0x04000FBB RID: 4027
	[Range(-0.2f, 0.2f)]
	public float Luminosity;

	// Token: 0x04000FBC RID: 4028
	[Range(-0.3f, 0.3f)]
	public float Change_Red;

	// Token: 0x04000FBD RID: 4029
	[Range(-0.3f, 0.3f)]
	public float Change_Green;

	// Token: 0x04000FBE RID: 4030
	[Range(-0.3f, 0.3f)]
	public float Change_Blue;

	// Token: 0x04000FBF RID: 4031
	private RenderTexture Camera2tex;

	// Token: 0x04000FC0 RID: 4032
	private Vector2 ScreenSize;
}
