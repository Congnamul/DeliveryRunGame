using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

[System.Serializable]
public class SaveData
{
    public int gold;
    public int DateWork;
    public int NogadaWork;
}

public class DataManager : MonoBehaviour
{
    string path;

    //JSON颇老 积己 棺 历厘
    void Start()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        if (!File.Exists(path))
        {

            JsonSave(); //?
        }
        else
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);

            if (saveData != null)
            {

                ReadyScripts.Instance.Gold = saveData.gold;
                ReadyScripts.Instance.DateWork = saveData.DateWork;
                ReadyScripts.Instance.NogadaWork = saveData.NogadaWork;
                //ReadyScripts.Instance.Date = saveData.power;

            }
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        saveData.gold = ReadyScripts.Instance.Gold;
        saveData.DateWork = ReadyScripts.Instance.DateWork;
        saveData.NogadaWork = ReadyScripts.Instance.NogadaWork;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

    public void JsonReset()
    {
        SaveData saveData = new SaveData();

        saveData.gold = 0;
        saveData.DateWork = 0;
        saveData.NogadaWork = 0;

        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

}

