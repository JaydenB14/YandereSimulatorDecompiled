// Decompiled with JetBrains decompiler
// Type: NormalsReplacementShader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NormalsReplacementShader : MonoBehaviour
{
  [SerializeField]
  private Shader normalsShader;
  private RenderTexture renderTexture;
  private Camera camera;

  private void Start()
  {
    Camera component = this.GetComponent<Camera>();
    this.renderTexture = new RenderTexture(component.pixelWidth, component.pixelHeight, 24);
    Shader.SetGlobalTexture("_CameraNormalsTexture", (Texture) this.renderTexture);
    this.camera = new GameObject("Normals camera").AddComponent<Camera>();
    this.camera.CopyFrom(component);
    this.camera.transform.SetParent(this.transform);
    this.camera.targetTexture = this.renderTexture;
    this.camera.SetReplacementShader(this.normalsShader, "RenderType");
    this.camera.depth = component.depth - 1f;
  }
}
