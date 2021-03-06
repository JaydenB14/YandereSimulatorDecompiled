// Decompiled with JetBrains decompiler
// Type: SplashCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SplashCameraScript : MonoBehaviour
{
  public Camera MyCamera;
  public bool Show;
  public float Timer;

  private void Start()
  {
    this.MyCamera.enabled = false;
    this.MyCamera.rect = new Rect(0.0f, 0.219f, 0.0f, 0.0f);
  }

  private void Update()
  {
    if (this.Show)
    {
      this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.4f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.71104f, Time.deltaTime * 10f));
      this.Timer += Time.deltaTime;
      if ((double) this.Timer <= 15.0)
        return;
      this.Show = false;
      this.Timer = 0.0f;
    }
    else
    {
      this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.0f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.0f, Time.deltaTime * 10f));
      if (!this.MyCamera.enabled || (double) this.MyCamera.rect.width >= 0.100000001490116)
        return;
      this.MyCamera.enabled = false;
    }
  }
}
