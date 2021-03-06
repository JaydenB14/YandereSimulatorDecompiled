// Decompiled with JetBrains decompiler
// Type: IDCardScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class IDCardScript : MonoBehaviour
{
  public PromptScript Prompt;
  public bool Fake;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    this.Prompt.Yandere.StolenObject = this.gameObject;
    if (!this.Fake)
    {
      this.Prompt.Yandere.Inventory.IDCard = true;
      this.Prompt.Yandere.TheftTimer = 1f;
    }
    else
      this.Prompt.Yandere.Inventory.FakeID = true;
    this.Prompt.Hide();
    this.gameObject.SetActive(false);
  }
}
