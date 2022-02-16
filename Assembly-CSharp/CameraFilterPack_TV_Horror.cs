﻿using System;
using UnityEngine;

// Token: 0x0200020E RID: 526
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Horror")]
public class CameraFilterPack_TV_Horror : MonoBehaviour
{
	// Token: 0x17000312 RID: 786
	// (get) Token: 0x06001137 RID: 4407 RVA: 0x0008710D File Offset: 0x0008530D
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

	// Token: 0x06001138 RID: 4408 RVA: 0x00087141 File Offset: 0x00085341
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_TV_HorrorFX") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/TV_Horror");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001139 RID: 4409 RVA: 0x00087178 File Offset: 0x00085378
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
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600113A RID: 4410 RVA: 0x0008725A File Offset: 0x0008545A
	private void Update()
	{
	}

	// Token: 0x0600113B RID: 4411 RVA: 0x0008725C File Offset: 0x0008545C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D0 RID: 5584
	public Shader SCShader;

	// Token: 0x040015D1 RID: 5585
	private float TimeX = 1f;

	// Token: 0x040015D2 RID: 5586
	private Material SCMaterial;

	// Token: 0x040015D3 RID: 5587
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015D4 RID: 5588
	[Range(0f, 1f)]
	public float Distortion = 1f;

	// Token: 0x040015D5 RID: 5589
	private Texture2D Texture2;
}
