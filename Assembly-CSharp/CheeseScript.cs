﻿// Decompiled with JetBrains decompiler
// Type: CheeseScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CheeseScript : MonoBehaviour
{
  public GameObject GlowingEye;
  public PromptScript Prompt;
  public UILabel Subtitle;
  public float Timer;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Subtitle.text = "Knowing the mouse might one day leave its hole and get the cheese...It fills you with determination.";
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.GlowingEye.SetActive(true);
      this.Timer = 5f;
    }
    if ((double) this.Timer <= 0.0)
      return;
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer > 0.0)
      return;
    this.Prompt.enabled = true;
    this.Subtitle.text = string.Empty;
  }
}
