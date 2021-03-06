// Decompiled with JetBrains decompiler
// Type: VoidGoddessScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class VoidGoddessScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public PromptScript Prompt;
  public GameObject BloodyUniform;
  public GameObject SeveredLimb;
  public GameObject NewPortrait;
  public GameObject BloodPool;
  public GameObject Portrait;
  public GameObject Goddess;
  public Transform BloodParent;
  public Transform Highlight;
  public Transform Window;
  public Transform Head;
  public UITexture[] Portraits;
  public Animation[] Legs;
  public bool PassingJudgement;
  public bool Initialized;
  public bool Disabled;
  public bool Follow;
  public int Selected;
  public int Column;
  public int Row;
  public int ID;
  public Texture Headmaster;
  public Texture Counselor;
  public Texture Infochan;

  public void Start()
  {
    if (this.Initialized)
      return;
    if (this.gameObject.activeInHierarchy)
    {
      this.Legs[1]["SpiderLegWiggle"].speed = 1f;
      this.Legs[2]["SpiderLegWiggle"].speed = 0.95f;
      this.Legs[3]["SpiderLegWiggle"].speed = 0.9f;
      this.Legs[4]["SpiderLegWiggle"].speed = 0.85f;
      this.Legs[5]["SpiderLegWiggle"].speed = 0.8f;
      this.Legs[6]["SpiderLegWiggle"].speed = 0.75f;
      this.Legs[7]["SpiderLegWiggle"].speed = 0.7f;
      this.Legs[8]["SpiderLegWiggle"].speed = 0.65f;
    }
    string str = "";
    if (GameGlobals.Eighties)
      str = "1989";
    for (this.ID = 1; this.ID < 101; ++this.ID)
    {
      this.NewPortrait = Object.Instantiate<GameObject>(this.Portrait, this.transform.position, Quaternion.identity);
      this.NewPortrait.transform.parent = this.Window;
      this.NewPortrait.transform.localScale = new Vector3(1f, 1f, 1f);
      this.NewPortrait.transform.localPosition = new Vector3((float) (this.Column * 100 - 450), (float) (450 - this.Row * 100), 0.0f);
      this.Portraits[this.ID] = this.NewPortrait.GetComponent<UITexture>();
      if (!this.StudentManager.Eighties && this.ID > 11 && this.ID < 21)
        this.NewPortrait.GetComponent<UITexture>().mainTexture = this.Prompt.Yandere.PauseScreen.StudentInfoMenu.RivalPortraits[this.ID];
      else if (this.ID < 98)
      {
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits" + str + "/Student_" + this.ID.ToString() + ".png");
        this.NewPortrait.GetComponent<UITexture>().mainTexture = (Texture) www.texture;
      }
      else if (this.ID == 98)
        this.NewPortrait.GetComponent<UITexture>().mainTexture = this.Counselor;
      else if (this.ID == 99)
        this.NewPortrait.GetComponent<UITexture>().mainTexture = this.Headmaster;
      else if (this.ID == 100)
        this.NewPortrait.GetComponent<UITexture>().mainTexture = this.Infochan;
      ++this.Column;
      if (this.Column == 10)
      {
        this.Column = 0;
        ++this.Row;
      }
    }
    this.Window.parent.gameObject.SetActive(false);
    this.Selected = 1;
    this.Column = 0;
    this.Row = 0;
    this.UpdatePortraits();
    this.Initialized = true;
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Goddess.activeInHierarchy)
      {
        this.Prompt.Yandere.Police.Invalid = true;
        this.Prompt.Label[0].text = "     Pass Judgement";
        this.Prompt.Label[1].text = "     Dismiss";
        this.Prompt.Label[2].text = "     Follow";
        this.Prompt.HideButton[1] = false;
        this.Prompt.HideButton[2] = false;
        this.Prompt.OffsetX[0] = 0.0f;
        this.Goddess.SetActive(true);
      }
      else
      {
        this.Window.parent.gameObject.SetActive(true);
        this.Window.gameObject.SetActive(true);
        this.Prompt.Yandere.CanMove = false;
        this.PassingJudgement = true;
      }
    }
    if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
    {
      this.Prompt.Circle[1].fillAmount = 1f;
      this.Prompt.Label[0].text = "     Summon An Ancient Evil";
      this.Prompt.Label[1].text = "";
      this.Prompt.Label[2].text = "";
      this.Prompt.HideButton[1] = true;
      this.Prompt.HideButton[2] = true;
      this.Prompt.OffsetX[0] = 0.0f;
      this.transform.position = new Vector3(-9.5f, 1f, -75f);
      this.Goddess.SetActive(false);
      this.Follow = false;
    }
    if ((double) this.Prompt.Circle[2].fillAmount == 0.0)
    {
      this.Prompt.Circle[2].fillAmount = 1f;
      this.Follow = !this.Follow;
    }
    if (this.Follow && (double) Vector3.Distance(this.Prompt.Yandere.transform.position + new Vector3(0.0f, 1f, 0.0f), this.transform.position) > 1.0)
      this.transform.position = Vector3.Lerp(this.transform.position, this.Prompt.Yandere.transform.position + new Vector3(0.0f, 1f, 0.0f), Time.deltaTime);
    if (!this.PassingJudgement)
      return;
    if (this.InputManager.TappedUp)
    {
      --this.Row;
      this.UpdateHighlight();
    }
    else if (this.InputManager.TappedDown)
    {
      ++this.Row;
      this.UpdateHighlight();
    }
    if (this.InputManager.TappedLeft)
    {
      --this.Column;
      this.UpdateHighlight();
    }
    else if (this.InputManager.TappedRight)
    {
      ++this.Column;
      this.UpdateHighlight();
    }
    if (Input.GetButtonDown("A"))
    {
      this.StudentManager.DisableStudent(this.Selected);
      this.UpdatePortraits();
    }
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      if (!this.Disabled)
      {
        this.StudentManager.DisableEveryone();
        this.Disabled = true;
      }
      else
      {
        for (this.ID = 1; this.ID < 101; ++this.ID)
          this.StudentManager.DisableStudent(this.ID);
      }
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      for (this.ID = 1; this.ID < 11; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      for (this.ID = 11; this.ID < 21; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha4))
    {
      for (this.ID = 21; this.ID < 26; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha5))
    {
      for (this.ID = 26; this.ID < 31; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha6))
    {
      for (this.ID = 31; this.ID < 36; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha7))
    {
      for (this.ID = 36; this.ID < 41; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha8))
    {
      for (this.ID = 41; this.ID < 46; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha9))
    {
      for (this.ID = 46; this.ID < 51; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown(KeyCode.Alpha0))
    {
      for (this.ID = 51; this.ID < 56; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("-"))
    {
      for (this.ID = 56; this.ID < 61; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("="))
    {
      for (this.ID = 61; this.ID < 66; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("r"))
    {
      for (this.ID = 66; this.ID < 71; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("t"))
    {
      for (this.ID = 71; this.ID < 76; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("y"))
    {
      for (this.ID = 76; this.ID < 81; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("u"))
    {
      for (this.ID = 81; this.ID < 86; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("i"))
    {
      for (this.ID = 86; this.ID < 90; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("o"))
    {
      for (this.ID = 90; this.ID < 98; ++this.ID)
        this.StudentManager.DisableStudent(this.ID);
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("p"))
    {
      for (this.ID = 1; this.ID < 101; ++this.ID)
      {
        if (this.ID != 21 && this.ID != 26 && this.ID != 31 && this.ID != 36 && this.ID != 41 && this.ID != 46 && this.ID != 51 && this.ID != 56 && this.ID != 61 && this.ID != 66 && this.ID != 71)
          this.StudentManager.DisableStudent(this.ID);
      }
      this.UpdatePortraits();
    }
    else if (Input.GetKeyDown("space"))
    {
      for (this.ID = 2; this.ID < 101; ++this.ID)
      {
        if (this.ID != 1 && this.ID != 2 && this.ID != 3 && this.ID != 6 && this.ID != 10 && this.ID != 11 && this.ID != 26 && this.ID != 36 && this.ID != 39 && this.ID != 41 && this.ID != 42 && this.ID != 43 && this.ID != 44 && this.ID != 45 && this.ID != 46 && this.ID != 47 && this.ID != 48 && this.ID != 49 && this.ID != 50 && this.ID != 71 && this.ID != 81 && this.ID != 82 && this.ID != 83 && this.ID != 84 && this.ID != 85)
          this.StudentManager.DisableStudent(this.ID);
      }
      if (this.StudentManager.Students[7].gameObject.activeInHierarchy)
        this.StudentManager.DisableStudent(7);
      this.UpdatePortraits();
    }
    if (Input.GetButtonDown("B"))
    {
      this.Window.parent.gameObject.SetActive(false);
      this.Prompt.Yandere.CanMove = true;
      this.Prompt.Yandere.Shoved = false;
      this.PassingJudgement = false;
    }
    if (Input.GetKeyDown(KeyCode.Z))
    {
      this.StudentManager.Students[this.Selected].transform.position = this.Prompt.Yandere.transform.position + this.Prompt.Yandere.transform.forward;
      Physics.SyncTransforms();
    }
    if (!Input.GetKeyDown(KeyCode.X))
      return;
    this.StudentManager.Students[this.Selected].BecomeRagdoll();
    this.StudentManager.Students[this.Selected].Ragdoll.NeckSnapped = true;
  }

  private void UpdateHighlight()
  {
    if (this.Row < 0)
      this.Row = 9;
    else if (this.Row > 9)
      this.Row = 0;
    if (this.Column < 0)
      this.Column = 9;
    else if (this.Column > 9)
      this.Column = 0;
    this.Highlight.localPosition = new Vector3((float) (100 * this.Column - 450), (float) (450 - 100 * this.Row), this.Highlight.localPosition.z);
    this.Selected = 1 + this.Row * 10 + this.Column;
  }

  public void UpdatePortraits()
  {
    for (this.ID = 1; this.ID < 98; ++this.ID)
    {
      if ((Object) this.Portraits[this.ID] != (Object) null)
      {
        if ((Object) this.StudentManager.Students[this.ID] != (Object) null)
        {
          if (this.StudentManager.Students[this.ID].gameObject.activeInHierarchy)
            this.Portraits[this.ID].color = new Color(1f, 1f, 1f, 1f);
          else
            this.Portraits[this.ID].color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
          this.Portraits[this.ID].color = new Color(1f, 1f, 1f, 0.5f);
      }
    }
  }
}
