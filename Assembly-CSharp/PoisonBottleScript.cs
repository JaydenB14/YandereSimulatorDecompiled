// Decompiled with JetBrains decompiler
// Type: PoisonBottleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PoisonBottleScript : MonoBehaviour
{
  public PromptScript Prompt;
  public bool Theft;
  public int ID;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    if (this.Theft)
      this.Prompt.Yandere.TheftTimer = 0.1f;
    if (this.ID == 1)
      ++this.Prompt.Yandere.Inventory.EmeticPoisons;
    else if (this.ID == 2)
      ++this.Prompt.Yandere.Inventory.LethalPoisons;
    else if (this.ID == 3)
      ++this.Prompt.Yandere.Inventory.EmeticPoisons;
    else if (this.ID == 4)
      ++this.Prompt.Yandere.Inventory.HeadachePoisons;
    else if (this.ID == 5)
      ++this.Prompt.Yandere.Inventory.SedativePoisons;
    else if (this.ID == 6)
      ++this.Prompt.Yandere.Inventory.SedativePoisons;
    this.Prompt.Yandere.StudentManager.UpdateAllBentos();
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.gameObject.SetActive(false);
  }
}
