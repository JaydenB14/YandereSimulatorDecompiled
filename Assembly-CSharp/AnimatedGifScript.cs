// Decompiled with JetBrains decompiler
// Type: AnimatedGifScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AnimatedGifScript : MonoBehaviour
{
  [SerializeField]
  private UISprite Sprite;
  [SerializeField]
  private string SpriteName;
  [SerializeField]
  private int Start;
  [SerializeField]
  private int Frame;
  [SerializeField]
  private int Limit;
  [SerializeField]
  private float FramesPerSecond;
  [SerializeField]
  private float CurrentSeconds;

  private void Awake()
  {
  }

  private float SecondsPerFrame => 1f / this.FramesPerSecond;

  private void Update()
  {
    this.CurrentSeconds += Time.unscaledDeltaTime;
    while ((double) this.CurrentSeconds >= (double) this.SecondsPerFrame)
    {
      this.CurrentSeconds -= this.SecondsPerFrame;
      ++this.Frame;
      if (this.Frame > this.Limit)
        this.Frame = this.Start;
    }
    this.Sprite.spriteName = this.SpriteName + this.Frame.ToString();
  }
}
