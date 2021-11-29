﻿using System;
using UnityEngine;

// Token: 0x02000115 RID: 277
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Snow")]
public class CameraFilterPack_3D_Snow : MonoBehaviour
{
	// Token: 0x1700021A RID: 538
	// (get) Token: 0x06000AFE RID: 2814 RVA: 0x0006A19C File Offset: 0x0006839C
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

	// Token: 0x06000AFF RID: 2815 RVA: 0x0006A1D0 File Offset: 0x000683D0
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Blizzard1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/3D_Snow");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B00 RID: 2816 RVA: 0x0006A208 File Offset: 0x00068408
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
			this.material.SetFloat("_Value", this.Fade);
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("_Value4", this.Speed * 6f);
			this.material.SetFloat("_Value5", this.Size);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("Drop_Near", this.Snow_Near);
			this.material.SetFloat("Drop_Far", this.Snow_Far);
			this.material.SetFloat("Drop_With_Obj", this.SnowWithoutObject);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetTexture("Texture2", this.Texture2);
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B01 RID: 2817 RVA: 0x0006A39D File Offset: 0x0006859D
	private void Update()
	{
	}

	// Token: 0x06000B02 RID: 2818 RVA: 0x0006A39F File Offset: 0x0006859F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000ECF RID: 3791
	public Shader SCShader;

	// Token: 0x04000ED0 RID: 3792
	public bool _Visualize;

	// Token: 0x04000ED1 RID: 3793
	private float TimeX = 1f;

	// Token: 0x04000ED2 RID: 3794
	private Material SCMaterial;

	// Token: 0x04000ED3 RID: 3795
	[Range(0f, 100f)]
	public float _FixDistance = 5f;

	// Token: 0x04000ED4 RID: 3796
	[Range(-0.5f, 0.99f)]
	public float Snow_Near = 0.08f;

	// Token: 0x04000ED5 RID: 3797
	[Range(0f, 1f)]
	public float Snow_Far = 0.55f;

	// Token: 0x04000ED6 RID: 3798
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000ED7 RID: 3799
	[Range(0f, 2f)]
	public float Intensity = 1f;

	// Token: 0x04000ED8 RID: 3800
	[Range(0.4f, 2f)]
	public float Size = 1f;

	// Token: 0x04000ED9 RID: 3801
	[Range(0f, 0.5f)]
	public float Speed = 0.275f;

	// Token: 0x04000EDA RID: 3802
	[Range(0f, 1f)]
	public float SnowWithoutObject = 1f;

	// Token: 0x04000EDB RID: 3803
	private Texture2D Texture2;
}