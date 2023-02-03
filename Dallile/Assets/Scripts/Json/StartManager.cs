using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

[System.Serializable]

public class SaveStartData
{
    public bool isStart;
}

public class StartManager : MonoBehaviour
{
    string path;

    //JSON颇老 积己 棺 历厘
    void Start()
    {
        path = Path.Combine(Application.dataPath, "StartboolData.json");
        JsonLoadB();
    }

    public void JsonLoadB()
    {
        SaveStartData saveData = new SaveStartData();

        if (!File.Exists(path))
        {
            JsonSaveB(); //?
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveStartData>(loadJson);

            if (saveData != null)
            {

                StartScript.isStart = saveData.isStart;

                //ReadyScripts.Instance.Date = saveData.power;

            }
        }
    }

    public void JsonSaveB()
    {
        SaveStartData saveData = new SaveStartData();

        saveData.isStart = StartScript.isStart;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }


}

