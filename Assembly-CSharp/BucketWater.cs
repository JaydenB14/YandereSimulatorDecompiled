﻿using System;
using UnityEngine;

// Token: 0x020000FC RID: 252
[Serializable]
public class BucketWater : BucketContents
{
	// Token: 0x17000201 RID: 513
	// (get) Token: 0x06000A74 RID: 2676 RVA: 0x0005D6A3 File Offset: 0x0005B8A3
	// (set) Token: 0x06000A75 RID: 2677 RVA: 0x0005D6AB File Offset: 0x0005B8AB
	public float Bloodiness
	{
		get
		{
			return this.bloodiness;
		}
		set
		{
			this.bloodiness = Mathf.Clamp01(value);
		}
	}

	// Token: 0x17000202 RID: 514
	// (get) Token: 0x06000A76 RID: 2678 RVA: 0x0005D6B9 File Offset: 0x0005B8B9
	// (set) Token: 0x06000A77 RID: 2679 RVA: 0x0005D6C1 File Offset: 0x0005B8C1
	public bool HasBleach
	{
		get
		{
			return this.hasBleach;
		}
		set
		{
			this.hasBleach = value;
		}
	}

	// Token: 0x17000203 RID: 515
	// (get) Token: 0x06000A78 RID: 2680 RVA: 0x0005D6CA File Offset: 0x0005B8CA
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Water;
		}
	}

	// Token: 0x17000204 RID: 516
	// (get) Token: 0x06000A79 RID: 2681 RVA: 0x0005D6CD File Offset: 0x0005B8CD
	public override bool IsCleaningAgent
	{
		get
		{
			return this.hasBleach;
		}
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x06000A7A RID: 2682 RVA: 0x0005D6D5 File Offset: 0x0005B8D5
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A7B RID: 2683 RVA: 0x0005D6D8 File Offset: 0x0005B8D8
	public override bool CanBeLifted(int strength)
	{
		return true;
	}

	// Token: 0x04000C4C RID: 3148
	[SerializeField]
	private float bloodiness;

	// Token: 0x04000C4D RID: 3149
	[SerializeField]
	private bool hasBleach;
}
