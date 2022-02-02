﻿using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
[AddComponentMenu("NGUI/Interaction/Button Message (Legacy)")]
public class UIButtonMessage : MonoBehaviour
{
	// Token: 0x06000136 RID: 310 RVA: 0x0001442C File Offset: 0x0001262C
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06000137 RID: 311 RVA: 0x00014435 File Offset: 0x00012635
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00014450 File Offset: 0x00012650
	private void OnHover(bool isOver)
	{
		if (base.enabled && ((isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOver) || (!isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOut)))
		{
			this.Send();
		}
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00014478 File Offset: 0x00012678
	private void OnPress(bool isPressed)
	{
		if (base.enabled && ((isPressed && this.trigger == UIButtonMessage.Trigger.OnPress) || (!isPressed && this.trigger == UIButtonMessage.Trigger.OnRelease)))
		{
			this.Send();
		}
	}

	// Token: 0x0600013A RID: 314 RVA: 0x000144A0 File Offset: 0x000126A0
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0600013B RID: 315 RVA: 0x000144BC File Offset: 0x000126BC
	private void OnClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnClick)
		{
			this.Send();
		}
	}

	// Token: 0x0600013C RID: 316 RVA: 0x000144D4 File Offset: 0x000126D4
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnDoubleClick)
		{
			this.Send();
		}
	}

	// Token: 0x0600013D RID: 317 RVA: 0x000144F0 File Offset: 0x000126F0
	private void Send()
	{
		if (string.IsNullOrEmpty(this.functionName))
		{
			return;
		}
		if (this.target == null)
		{
			this.target = base.gameObject;
		}
		if (this.includeChildren)
		{
			Transform[] componentsInChildren = this.target.GetComponentsInChildren<Transform>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				componentsInChildren[i].gameObject.SendMessage(this.functionName, base.gameObject, SendMessageOptions.DontRequireReceiver);
				i++;
			}
			return;
		}
		this.target.SendMessage(this.functionName, base.gameObject, SendMessageOptions.DontRequireReceiver);
	}

	// Token: 0x040002FC RID: 764
	public GameObject target;

	// Token: 0x040002FD RID: 765
	public string functionName;

	// Token: 0x040002FE RID: 766
	public UIButtonMessage.Trigger trigger;

	// Token: 0x040002FF RID: 767
	public bool includeChildren;

	// Token: 0x04000300 RID: 768
	private bool mStarted;

	// Token: 0x020005C3 RID: 1475
	[DoNotObfuscateNGUI]
	public enum Trigger
	{
		// Token: 0x04004D00 RID: 19712
		OnClick,
		// Token: 0x04004D01 RID: 19713
		OnMouseOver,
		// Token: 0x04004D02 RID: 19714
		OnMouseOut,
		// Token: 0x04004D03 RID: 19715
		OnPress,
		// Token: 0x04004D04 RID: 19716
		OnRelease,
		// Token: 0x04004D05 RID: 19717
		OnDoubleClick
	}
}
