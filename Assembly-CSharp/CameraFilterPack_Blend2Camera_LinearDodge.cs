﻿using System;
using UnityEngine;

// Token: 0x02000138 RID: 312
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LinearDodge")]
public class CameraFilterPack_Blend2Camera_LinearDodge : MonoBehaviour
{
	// Token: 0x1700023C RID: 572
	// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x0006F367 File Offset: 0x0006D567
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

	// Token: 0x06000BF1 RID: 3057 RVA: 0x0006F39C File Offset: 0x0006D59C
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000BF2 RID: 3058 RVA: 0x0006F400 File Offset: 0x0006D600
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
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000BF3 RID: 3059 RVA: 0x0006F4F0 File Offset: 0x0006D6F0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x0006F528 File Offset: 0x0006D728
	private void Update()
	{
	}

	// Token: 0x06000BF5 RID: 3061 RVA: 0x0006F52A File Offset: 0x0006D72A
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x0006F562 File Offset: 0x0006D762
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001027 RID: 4135
	private string ShaderName = "CameraFilterPack/Blend2Camera_LinearDodge";

	// Token: 0x04001028 RID: 4136
	public Shader SCShader;

	// Token: 0x04001029 RID: 4137
	public Camera Camera2;

	// Token: 0x0400102A RID: 4138
	private float TimeX = 1f;

	// Token: 0x0400102B RID: 4139
	private Material SCMaterial;

	// Token: 0x0400102C RID: 4140
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400102D RID: 4141
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400102E RID: 4142
	private RenderTexture Camera2tex;
}
