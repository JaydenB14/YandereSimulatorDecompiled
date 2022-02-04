﻿using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x0200029C RID: 668
public class EightiesEffectEnablerScript : MonoBehaviour
{
	// Token: 0x06001404 RID: 5124 RVA: 0x000BE4B0 File Offset: 0x000BC6B0
	public void Start()
	{
		if (this.EightiesEffects != null)
		{
			this.EightiesEffects.enabled = GameGlobals.Eighties;
			if (this.EightiesFilter != null)
			{
				this.EightiesFilter.enabled = GameGlobals.Eighties;
			}
		}
		this.UpdateEightiesEffects();
	}

	// Token: 0x06001405 RID: 5125 RVA: 0x000BE500 File Offset: 0x000BC700
	public void UpdateEightiesEffects()
	{
		if (this.EightiesEffects != null)
		{
			this.EightiesEffects.useStaticNoise = !OptionGlobals.DisableStatic;
			this.EightiesEffects.useDisplacementWaves = !OptionGlobals.DisableDisplacement;
			this.EightiesEffects.useChromaticAberration = !OptionGlobals.DisableAbberation;
			this.EightiesEffects.useVignette = !OptionGlobals.DisableVignette;
			this.EightiesEffects.useRadialDistortion = !OptionGlobals.DisableDistortion;
			this.EightiesEffects.useScanlines = !OptionGlobals.DisableScanlines;
			this.EightiesEffects.useBottomNoise = !OptionGlobals.DisableNoise;
			this.EightiesEffects.useBottomStretch = !OptionGlobals.DisableNoise;
		}
		if (this.EightiesFilter != null)
		{
			this.EightiesFilter.enabled = !OptionGlobals.DisableTint;
			return;
		}
		Debug.Log("No 80s tint in this scene. Consider adding one?");
	}

	// Token: 0x04001DEF RID: 7663
	public RetroCameraEffect EightiesEffects;

	// Token: 0x04001DF0 RID: 7664
	public CameraFilterPack_Colors_Adjust_PreFilters EightiesFilter;

	// Token: 0x04001DF1 RID: 7665
	public int Eights;
}
