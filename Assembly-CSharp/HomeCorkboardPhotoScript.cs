// Decompiled with JetBrains decompiler
// Type: HomeCorkboardPhotoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeCorkboardPhotoScript : MonoBehaviour
{
  public int ArrayID;
  public int ID;

  private void OnTriggerStay(Collider other)
  {
    if (other.gameObject.layer != 4)
      return;
    this.transform.localScale = new Vector3(Mathf.MoveTowards(this.transform.localScale.x, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(this.transform.localScale.y, 1f, Time.deltaTime * 10f), Mathf.MoveTowards(this.transform.localScale.z, 1f, Time.deltaTime * 10f));
  }
}
