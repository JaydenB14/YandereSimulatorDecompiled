// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.BrakeLight
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
  public class BrakeLight : MonoBehaviour
  {
    public CarController car;
    private Renderer m_Renderer;

    private void Start() => this.m_Renderer = this.GetComponent<Renderer>();

    private void Update() => this.m_Renderer.enabled = (double) this.car.BrakeInput > 0.0;
  }
}
