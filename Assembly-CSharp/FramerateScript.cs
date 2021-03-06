// Decompiled with JetBrains decompiler
// Type: FramerateScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FramerateScript : MonoBehaviour
{
  public float updateInterval = 0.5f;
  private float accum;
  private int frames;
  private float timeleft;
  public float FpsAverage;
  public float FpsCurrent;
  public UILabel FPSLabel;

  private void Start() => this.timeleft = this.updateInterval;

  private void Update()
  {
    this.FpsCurrent = 1f / Time.unscaledDeltaTime;
    this.timeleft -= Time.unscaledDeltaTime;
    this.accum += this.FpsCurrent;
    ++this.frames;
    if ((double) this.timeleft > 0.0)
      return;
    this.FpsAverage = this.accum / (float) this.frames;
    this.timeleft = this.updateInterval;
    this.accum = 0.0f;
    this.frames = 0;
    int num = Mathf.Clamp((int) this.FpsAverage, 0, Application.targetFrameRate);
    Mathf.Clamp((int) this.FpsCurrent, 0, Application.targetFrameRate);
    this.FPSLabel.text = "FPS: " + num.ToString();
  }
}
