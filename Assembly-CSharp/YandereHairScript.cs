// Decompiled with JetBrains decompiler
// Type: YandereHairScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YandereHairScript : MonoBehaviour
{
  public YandereScript Yandere;
  public int Frame;
  public int Limit;

  private void Start()
  {
    ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
    this.Limit = this.Yandere.Hairstyles.Length - 1;
  }

  private void Update()
  {
    if (this.Yandere.Hairstyle >= this.Limit)
      return;
    ++this.Frame;
    if (this.Frame == 1)
    {
      ++this.Yandere.Hairstyle;
      this.Yandere.UpdateHair();
    }
    if (this.Frame != 2)
      return;
    ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
    this.Frame = 0;
  }
}
