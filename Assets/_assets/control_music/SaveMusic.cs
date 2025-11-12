using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveMusic : MonoBehaviour
{
    public Data_music dataMusic;   // ScriptableObject cần lưu

    private string FilePath_music => Path.Combine(Application.persistentDataPath, "MusicData.json");

    [ContextMenu("Save DataMusic to JSON")]
    public void SaveToJsonMusic()
    {
        if (dataMusic == null || dataMusic.DataMusicQuest == null)
        {
            Debug.LogWarning("⚠️ dataMusic or DataMusicQuest is NULL!");
            return;
        }

        // 🔥 Tạo object JSON copy từng field
        MusicDataJSON jsonData = new MusicDataJSON
        {
            DataMusicQuest = new music
            {
                isMusic = dataMusic.DataMusicQuest.isMusic,
                valueMusic = dataMusic.DataMusicQuest.valueMusic,
                isSound = dataMusic.DataMusicQuest.isSound,
                valueSound = dataMusic.DataMusicQuest.valueSound
            }
        };

        string json = JsonUtility.ToJson(jsonData, true);
        File.WriteAllText(FilePath_music, json);

        Debug.Log("✅ Saved MusicData to: " + FilePath_music);
    }

    [ContextMenu("Load DataMusic from JSON")]
    public void LoadFromJson()
    {
        if (dataMusic == null || dataMusic.DataMusicQuest == null)
        {
            Debug.LogWarning("⚠️ dataMusic or DataMusicQuest is NULL!");
            return;
        }

        if (!File.Exists(FilePath_music))
        {
            Debug.Log("⚠️ File not found → Using default Music settings.");

            // ✅ Gán giá trị mặc định
            dataMusic.DataMusicQuest.isMusic = 1;
            dataMusic.DataMusicQuest.valueMusic = 1f;
            dataMusic.DataMusicQuest.isSound = 1;
            dataMusic.DataMusicQuest.valueSound = 1f;

            // ✅ Tạo file mặc định
            SaveToJsonMusic();
            return;
        }

        string json = File.ReadAllText(FilePath_music);
        MusicDataJSON jsonData = JsonUtility.FromJson<MusicDataJSON>(json);

        // ✅ Gán từng field vào ScriptableObject
        dataMusic.DataMusicQuest.isMusic = jsonData.DataMusicQuest.isMusic;
        dataMusic.DataMusicQuest.valueMusic = jsonData.DataMusicQuest.valueMusic;
        dataMusic.DataMusicQuest.isSound = jsonData.DataMusicQuest.isSound;
        dataMusic.DataMusicQuest.valueSound = jsonData.DataMusicQuest.valueSound;

        Debug.Log("✅ Loaded MusicData from: " + FilePath_music);
    }

    [ContextMenu("Delete Music JSON")]
    public void DeleteJson()
    {
        if (File.Exists(FilePath_music))
        {
            File.Delete(FilePath_music);
            Debug.Log("🗑️ Deleted: " + FilePath_music);

            // ✅ Reset về mặc định
            dataMusic.DataMusicQuest.isMusic = 1;
            dataMusic.DataMusicQuest.valueMusic = 1f;
            dataMusic.DataMusicQuest.isSound = 1;
            dataMusic.DataMusicQuest.valueSound = 1f;

            // ✅ Tạo lại file mặc định
            SaveToJsonMusic();
        }
        else
        {
            Debug.LogWarning("⚠️ No MusicData.json to delete.");
        }
    }

    private void Awake()
    {
        if (dataMusic != null)
            LoadFromJson();
    }


    private void OnApplicationQuit()
    {
        if (dataMusic != null)
            SaveToJsonMusic();
    }
}

[System.Serializable]
public class MusicDataJSON
{
    public music DataMusicQuest;
}
