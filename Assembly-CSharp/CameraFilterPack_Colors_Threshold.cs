﻿using System;
using UnityEngine;

// Token: 0x02000171 RID: 369
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Threshold")]
public class CameraFilterPack_Colors_Threshold : MonoBehaviour
{
	// Token: 0x17000275 RID: 629
	// (get) Token: 0x06000D65 RID: 3429 RVA: 0x000760F7 File Offset: 0x000742F7
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

	// Token: 0x06000D66 RID: 3430 RVA: 0x0007612B File Offset: 0x0007432B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Threshold");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D67 RID: 3431 RVA: 0x0007614C File Offset: 0x0007434C
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
			this.material.SetFloat("_Distortion", this.Threshold);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D68 RID: 3432 RVA: 0x000761D2 File Offset: 0x000743D2
	private void Update()
	{
	}

	// Token: 0x06000D69 RID: 3433 RVA: 0x000761D4 File Offset: 0x000743D4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011B2 RID: 4530
	public Shader SCShader;

	// Token: 0x040011B3 RID: 4531
	private float TimeX = 1f;

	// Token: 0x040011B4 RID: 4532
	[Range(0f, 1f)]
	public float Threshold = 0.3f;

	// Token: 0x040011B5 RID: 4533
	private Material SCMaterial;
}
