// Decompiled with JetBrains decompiler
// Type: PhoneJammerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PhoneJammerScript : MonoBehaviour
{
  public GameObject JammingLines;
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    ++this.Prompt.Yandere.Alphabet.Cheats;
    this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
    this.Prompt.Yandere.StudentManager.Jammed = true;
    this.JammingLines.SetActive(true);
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    this.enabled = false;
  }
}
