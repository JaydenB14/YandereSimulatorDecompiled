// Decompiled with JetBrains decompiler
// Type: YanvaniaCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.PostProcessing;

public class YanvaniaCameraScript : MonoBehaviour
{
  public PostProcessingProfile Profile;
  public YanvaniaYanmontScript Yanmont;
  public GameObject Jukebox;
  public bool Cutscene;
  public bool StopMusic = true;
  public float TargetZoom;
  public float Zoom;

  private void Start()
  {
    this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
    {
      focusDistance = 2f
    };
    this.transform.position = this.Yanmont.transform.position + new Vector3(0.0f, 1.5f, -5.85f);
  }

  private void FixedUpdate()
  {
    this.TargetZoom += Input.GetAxis("Mouse ScrollWheel") * 10f;
    if ((double) this.TargetZoom < 0.0)
      this.TargetZoom = 0.0f;
    if ((double) this.TargetZoom > 3.84999990463257)
      this.TargetZoom = 3.85f;
    this.Zoom = Mathf.Lerp(this.Zoom, this.TargetZoom, Time.deltaTime);
    if (!this.Cutscene)
    {
      this.TargetZoom += Input.GetAxis("Mouse ScrollWheel") * 10f;
      this.transform.position = this.Yanmont.transform.position + new Vector3(0.0f, 1.5f, this.Zoom - 5.85f);
      if ((double) this.transform.position.x <= 47.9000015258789)
        return;
      this.transform.position = new Vector3(47.9f, this.transform.position.y, this.transform.position.z);
    }
    else
    {
      if (this.StopMusic)
      {
        if ((double) this.Yanmont.Dracula.Health > 0.0)
          this.TargetZoom = 3.85f;
        AudioSource component = this.Jukebox.GetComponent<AudioSource>();
        component.volume -= Time.deltaTime * ((double) this.Yanmont.Health > 0.0 ? 0.2f : 0.025f);
        if ((double) component.volume <= 0.0)
          this.StopMusic = false;
      }
      this.transform.position = new Vector3(Mathf.MoveTowards(this.transform.position.x, -34.675f, Time.deltaTime * this.Yanmont.walkSpeed), 8f, this.Zoom - 5.85f);
    }
  }
}
