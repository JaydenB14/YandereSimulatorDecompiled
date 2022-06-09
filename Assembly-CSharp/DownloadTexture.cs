﻿// Decompiled with JetBrains decompiler
// Type: DownloadTexture
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof (UITexture))]
public class DownloadTexture : MonoBehaviour
{
  public string url = "http://www.yourwebsite.com/logo.png";
  public bool pixelPerfect = true;
  private Texture2D mTex;

  private IEnumerator Start()
  {
    DownloadTexture downloadTexture = this;
    UnityWebRequest www = UnityWebRequest.Get(downloadTexture.url);
    yield return (object) www.SendWebRequest();
    downloadTexture.mTex = DownloadHandlerTexture.GetContent(www);
    if ((Object) downloadTexture.mTex != (Object) null)
    {
      UITexture component = downloadTexture.GetComponent<UITexture>();
      component.mainTexture = (Texture) downloadTexture.mTex;
      if (downloadTexture.pixelPerfect)
        component.MakePixelPerfect();
    }
    www.Dispose();
  }

  private void OnDestroy()
  {
    if (!((Object) this.mTex != (Object) null))
      return;
    Object.Destroy((Object) this.mTex);
  }
}
