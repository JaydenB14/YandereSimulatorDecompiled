// Decompiled with JetBrains decompiler
// Type: DoItScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DoItScript : MonoBehaviour
{
  public UILabel MyLabel;
  public bool Fade;

  private void Start() => this.MyLabel.fontSize = Random.Range(50, 100);

  private void Update()
  {
    this.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
    if (!this.Fade)
    {
      this.MyLabel.alpha += Time.deltaTime;
      if ((double) this.MyLabel.alpha < 1.0)
        return;
      this.Fade = true;
    }
    else
    {
      this.MyLabel.alpha -= Time.deltaTime;
      if ((double) this.MyLabel.alpha > 0.0)
        return;
      Object.Destroy((Object) this.gameObject);
    }
  }
}
