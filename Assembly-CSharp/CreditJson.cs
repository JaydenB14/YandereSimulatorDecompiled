// Decompiled with JetBrains decompiler
// Type: CreditJson
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class CreditJson : JsonData
{
  [SerializeField]
  private string name;
  [SerializeField]
  private int size;

  public static string FilePath => Path.Combine(JsonData.FolderPath, "Credits.json");

  public static CreditJson[] LoadFromJson(string path)
  {
    List<CreditJson> creditJsonList = new List<CreditJson>();
    foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path))
      creditJsonList.Add(new CreditJson()
      {
        name = TFUtils.LoadString(dictionary, "Name"),
        size = TFUtils.LoadInt(dictionary, "Size")
      });
    return creditJsonList.ToArray();
  }

  public string Name => this.name;

  public int Size => this.size;
}
