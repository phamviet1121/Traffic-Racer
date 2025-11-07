using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class save_data_json : MonoBehaviour
{
    public access_Data access_Data;
    public money_data dataToSave;
    public BoolArraySaver sourceData;

    private string FilePath_dataToSave => Path.Combine(Application.persistentDataPath, "money_data.json");
    private string FilePath_sourceData => Path.Combine(Application.persistentDataPath, "BoolArrayData.json");
    private string FilePath_access_Data => Path.Combine(Application.persistentDataPath, "AccessData.json");

    [ContextMenu("Save QuestInfo to JSON access_Data")]
    public void SaveToJson_access_Data()
    {
        AccessDataJSON jsonData = new AccessDataJSON
        {
            questInfos = new List<QuestInfo>(access_Data.questInfos)
        };

        string json = JsonUtility.ToJson(jsonData, true);
        File.WriteAllText(FilePath_access_Data, json);
        Debug.Log("✅ Saved AccessData to: " + FilePath_access_Data);
    }

    [ContextMenu("Load QuestInfo from JSON access_Data")]
    public void LoadFromJson_access_Data()
    {
        if (!File.Exists(FilePath_access_Data))
        {
            Debug.LogWarning("⚠️ File not found at: " + FilePath_access_Data);
            return;
        }

        string json = File.ReadAllText(FilePath_access_Data);
        AccessDataJSON jsonData = JsonUtility.FromJson<AccessDataJSON>(json);
        access_Data.questInfos = jsonData.questInfos.ToArray();

        Debug.Log("✅ Loaded AccessData from: " + FilePath_access_Data);
    }

    [ContextMenu("Save To JSON sourceData")]
    public void SaveToJson_sourceData()
    {
        BoolArrayData data = new BoolArrayData
        {
            index_Cars = new List<lever2>(sourceData.index_Cars)
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(FilePath_sourceData, json);
        Debug.Log("✅ Saved JSON to: " + FilePath_sourceData);
    }

    [ContextMenu("Load From JSON")]
    public void LoadFromJson_sourceData()
    {
        if (!File.Exists(FilePath_sourceData))
        {
            Debug.LogWarning("⚠️ JSON file not found at: " + FilePath_sourceData);
            return;
        }

        string json = File.ReadAllText(FilePath_sourceData);
        BoolArrayData data = JsonUtility.FromJson<BoolArrayData>(json);
        sourceData.index_Cars = data.index_Cars.ToArray();
        Debug.Log("✅ Loaded JSON from: " + FilePath_sourceData);
    }


    [ContextMenu("Save Money Data To JSON dataToSave")]
    public void SaveToJson_dataToSave()
    {
        MoneyDataJSON jsonData = new MoneyDataJSON
        {
            money_iocn = dataToSave.money_iocn
        };

        string json = JsonUtility.ToJson(jsonData, true);
        File.WriteAllText(FilePath_dataToSave, json);
        Debug.Log("Money data saved to: " + FilePath_dataToSave);
    }

    [ContextMenu("Load Money Data From JSON")]
    public void LoadFromJson_dataToSave()
    {
        if (!File.Exists(FilePath_dataToSave))
        {
            Debug.LogWarning("No file found to load.");
            return;
        }

        string json = File.ReadAllText(FilePath_dataToSave);
        MoneyDataJSON jsonData = JsonUtility.FromJson<MoneyDataJSON>(json);
        dataToSave.money_iocn = jsonData.money_iocn;

        Debug.Log("Money data loaded from: " + FilePath_dataToSave);
    }

    private void Awake()
    {
        if (access_Data != null)
            LoadFromJson_access_Data();

        if (sourceData != null)
            LoadFromJson_sourceData();

        if (dataToSave != null)
            LoadFromJson_dataToSave();
    }
    public void saveall()
    {
        if (access_Data != null)
            SaveToJson_access_Data();

        if (dataToSave != null)
            SaveToJson_dataToSave();

        if (sourceData != null)
            SaveToJson_sourceData();
    }    
    public void OnApplicationQuit()
    {
        if (access_Data != null)
            SaveToJson_access_Data();

        if (dataToSave != null)
            SaveToJson_dataToSave();

        if (sourceData != null)
            SaveToJson_sourceData();
    }
    [ContextMenu("delete From JSON")]
    public void DeleteAllJson()
    {
        DeleteJson_access_Data();
        DeleteJson_sourceData();
        DeleteJson_dataToSave();
    }
    public void DeleteJson_access_Data()
    {
        if (File.Exists(FilePath_access_Data))
        {
            File.Delete(FilePath_access_Data);
            Debug.Log("Deleted access_Data.json");
        }
    }

    public void DeleteJson_sourceData()
    {
        if (File.Exists(FilePath_sourceData))
        {
            File.Delete(FilePath_sourceData);
            Debug.Log("Deleted sourceData.json");
        }
    }

    public void DeleteJson_dataToSave()
    {
        if (File.Exists(FilePath_dataToSave))
        {
            File.Delete(FilePath_dataToSave);
            Debug.Log("Deleted dataToSave.json");
        }
    }
}    





[System.Serializable]
public class BoolArrayData
{
    public List<lever2> index_Cars = new List<lever2>();
}
[System.Serializable]
public class MoneyDataJSON
{
    public icon money_iocn;
}
[System.Serializable]
public class AccessDataJSON
{
    public List<QuestInfo> questInfos;
}
