﻿using System;
using UnityEngine;

// Token: 0x02000184 RID: 388
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Water_Drop")]
public class CameraFilterPack_Distortion_Water_Drop : MonoBehaviour
{
	// Token: 0x17000288 RID: 648
	// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x00077BAC File Offset: 0x00075DAC
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

	// Token: 0x06000DD8 RID: 3544 RVA: 0x00077BE0 File Offset: 0x00075DE0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Water_Drop");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DD9 RID: 3545 RVA: 0x00077C04 File Offset: 0x00075E04
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
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			this.material.SetFloat("_CenterX", this.CenterX);
			this.material.SetFloat("_CenterY", this.CenterY);
			this.material.SetFloat("_WaveIntensity", this.WaveIntensity);
			this.material.SetInt("_NumberOfWaves", this.NumberOfWaves);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DDA RID: 3546 RVA: 0x00077CF5 File Offset: 0x00075EF5
	private void Update()
	{
	}

	// Token: 0x06000DDB RID: 3547 RVA: 0x00077CF7 File Offset: 0x00075EF7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400121B RID: 4635
	public Shader SCShader;

	// Token: 0x0400121C RID: 4636
	private float TimeX = 1f;

	// Token: 0x0400121D RID: 4637
	private Material SCMaterial;

	// Token: 0x0400121E RID: 4638
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x0400121F RID: 4639
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x04001220 RID: 4640
	[Range(0f, 10f)]
	public float WaveIntensity = 1f;

	// Token: 0x04001221 RID: 4641
	[Range(0f, 20f)]
	public int NumberOfWaves = 5;
}
