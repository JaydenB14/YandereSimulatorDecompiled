// Decompiled with JetBrains decompiler
// Type: AnimatedWidget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
public class AnimatedWidget : MonoBehaviour
{
  public float width = 1f;
  public float height = 1f;
  private UIWidget mWidget;

  private void OnEnable()
  {
    this.mWidget = this.GetComponent<UIWidget>();
    this.LateUpdate();
  }

  private void LateUpdate()
  {
    if (!((Object) this.mWidget != (Object) null))
      return;
    this.mWidget.width = Mathf.RoundToInt(this.width);
    this.mWidget.height = Mathf.RoundToInt(this.height);
  }
}
