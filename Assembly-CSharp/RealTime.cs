﻿using System;
using UnityEngine;

// Token: 0x0200007C RID: 124
public class RealTime : MonoBehaviour
{
	// Token: 0x1700006C RID: 108
	// (get) Token: 0x06000467 RID: 1127 RVA: 0x0002C7D7 File Offset: 0x0002A9D7
	public static float time
	{
		get
		{
			return Time.unscaledTime;
		}
	}

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x06000468 RID: 1128 RVA: 0x0002C7DE File Offset: 0x0002A9DE
	public static float deltaTime
	{
		get
		{
			return Time.unscaledDeltaTime;
		}
	}
}