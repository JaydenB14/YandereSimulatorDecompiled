// Decompiled with JetBrains decompiler
// Type: DebugEnablerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DebugEnablerScript : MonoBehaviour
{
  public GameObject StandWeapons;
  public GameObject VoidGoddess;
  public GameObject MurderKit;
  public GameObject Memes;
  public GameObject Keys;
  public DebugMenuScript DebugMenu;
  public YandereScript Yandere;
  public SkullScript Skull;
  public PrayScript Turtle;
  public DoorScript MemeClosetDoor;
  public PromptScript Prompt;
  public bool Editor;
  public int Spaces;

  private void Start()
  {
    this.StandWeapons.SetActive(false);
    this.Keys.SetActive(false);
    if (MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.LoveSick || !GameGlobals.Eighties && DateGlobals.Week == 2)
    {
      if (GameGlobals.Debug || this.Editor)
        this.gameObject.SetActive(false);
      else
        Object.Destroy((Object) this.gameObject);
    }
    if (!GameGlobals.Debug && !this.Editor)
      return;
    this.Editor = true;
    this.EnableDebug();
  }

  public void EnableDebug()
  {
    this.Yandere.NotificationManager.CustomText = "Debug Commands Enabled!";
    this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    Debug.Log((object) "Enabling the use of debug commands.");
    this.Yandere.Inventory.PantyShots = 100;
    this.Yandere.NoDebug = false;
    this.Yandere.EggBypass = 10;
    this.Yandere.Egg = false;
    this.StandWeapons.SetActive(true);
    this.VoidGoddess.SetActive(true);
    this.MurderKit.SetActive(true);
    this.Memes.SetActive(true);
    if (!GameGlobals.Eighties)
      this.Keys.SetActive(true);
    this.DebugMenu.MissionMode = false;
    this.DebugMenu.NoDebug = false;
    this.Yandere.NoDebug = false;
    this.Turtle.enabled = true;
    this.MemeClosetDoor.Locked = false;
    this.gameObject.SetActive(false);
    this.Skull.Prompt.enabled = true;
    this.Skull.enabled = true;
    GameGlobals.Debug = true;
  }
}
