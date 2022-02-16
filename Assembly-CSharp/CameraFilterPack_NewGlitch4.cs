﻿using System;
using UnityEngine;

// Token: 0x020001E7 RID: 487
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch4")]
public class CameraFilterPack_NewGlitch4 : MonoBehaviour
{
	// Token: 0x170002EB RID: 747
	// (get) Token: 0x06001046 RID: 4166 RVA: 0x00082765 File Offset: 0x00080965
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

	// Token: 0x06001047 RID: 4167 RVA: 0x00082799 File Offset: 0x00080999
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch4");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001048 RID: 4168 RVA: 0x000827BC File Offset: 0x000809BC
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
			this.material.SetFloat("_Speed", this.__Speed);
			this.material.SetFloat("Fade", this._Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001049 RID: 4169 RVA: 0x00082888 File Offset: 0x00080A88
	private void Update()
	{
	}

	// Token: 0x0600104A RID: 4170 RVA: 0x0008288A File Offset: 0x00080A8A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014B7 RID: 5303
	public Shader SCShader;

	// Token: 0x040014B8 RID: 5304
	private float TimeX = 1f;

	// Token: 0x040014B9 RID: 5305
	private Material SCMaterial;

	// Token: 0x040014BA RID: 5306
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014BB RID: 5307
	[Range(0f, 1f)]
	public float _Fade = 1f;
}
