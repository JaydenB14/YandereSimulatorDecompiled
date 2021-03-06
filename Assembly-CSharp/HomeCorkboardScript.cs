// Decompiled with JetBrains decompiler
// Type: HomeCorkboardScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeCorkboardScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public PhotoGalleryScript PhotoGallery;
  public HomeYandereScript HomeYandere;
  public HomeCameraScript HomeCamera;
  public HomeWindowScript HomeWindow;
  public bool Loaded;

  private void Update()
  {
    if (this.HomeYandere.CanMove)
      return;
    if (!this.Loaded)
    {
      this.PhotoGallery.LoadingScreen.SetActive(false);
      this.PhotoGallery.UpdateButtonPrompts();
      this.PhotoGallery.enabled = true;
      this.PhotoGallery.gameObject.SetActive(true);
      this.Loaded = true;
    }
    if (this.PhotoGallery.Adjusting || this.PhotoGallery.Viewing || this.PhotoGallery.LoadingScreen.activeInHierarchy || !Input.GetButtonDown("B"))
      return;
    this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
    this.HomeCamera.Target = this.HomeCamera.Targets[0];
    this.HomeCamera.CorkboardLabel.SetActive(true);
    this.PhotoGallery.PromptBar.Show = false;
    this.PhotoGallery.enabled = false;
    this.HomeYandere.CanMove = true;
    this.HomeYandere.gameObject.SetActive(true);
    this.HomeWindow.Show = false;
    this.enabled = false;
    this.Loaded = false;
    this.PhotoGallery.SaveAllPhotographs();
    this.PhotoGallery.SaveAllStrings();
  }
}
