// Decompiled with JetBrains decompiler
// Type: YanSaveStaticIdentifier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class YanSaveStaticIdentifier : MonoBehaviour
{
  [SerializeField]
  public List<string> StaticTypeNames = new List<string>();
  [SerializeField]
  public List<KeyValuePair<System.Type, string>> DisabledMembers = new List<KeyValuePair<System.Type, string>>();
  [SerializeField]
  public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
