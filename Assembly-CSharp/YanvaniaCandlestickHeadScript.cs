// Decompiled with JetBrains decompiler
// Type: YanvaniaCandlestickHeadScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
  public GameObject Fire;
  public Vector3 Rotation;
  public float Value;

  private void Start()
  {
    Rigidbody component = this.GetComponent<Rigidbody>();
    component.AddForce(this.transform.up * 100f);
    component.AddForce(this.transform.right * 100f);
    this.Value = Random.Range(-1f, 1f);
  }

  private void Update()
  {
    this.Rotation += new Vector3(this.Value, this.Value, this.Value);
    this.transform.localEulerAngles = this.Rotation;
    if ((double) this.transform.localPosition.y >= 0.230000004172325)
      return;
    Object.Instantiate<GameObject>(this.Fire, this.transform.position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
