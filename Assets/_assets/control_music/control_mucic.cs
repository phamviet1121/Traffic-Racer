using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class control_mucic : MonoBehaviour
{
    public Slider objSliderMusic;
    public Slider objSliderSound;
    public GameObject tickMusic;
    public GameObject tickSound;
    public Data_music data_music;

    public float ValueMusic;
    public bool isMusic;
    public float ValueSound;
    public bool isSound;
    public SaveMusic saveMusic;

    private void Start()
    {
        loadMusicData();
    }
    void Update()
    {
        // Nếu người dùng kéo slider → cập nhật volume

        if (objSliderMusic != null && objSliderMusic.value != ValueMusic)
        {
            ValueMusic = objSliderMusic.value;
            data_music.DataMusicQuest.valueMusic = ValueMusic;
        }
        if (objSliderSound != null && objSliderSound.value != ValueSound)
        {
            ValueSound = objSliderSound.value;
            data_music.DataMusicQuest.valueSound = ValueSound;
        }
    }
    public void saveMusicData()
    {
        saveMusic.SaveToJsonMusic();
    }
    [ContextMenu("loaddata")]
    public void loadMusicData()
    {
        saveMusic.LoadFromJson();
        isMusic= (data_music.DataMusicQuest.isMusic==1?true:false);
        isSound = (data_music.DataMusicQuest.isSound == 1 ? true : false);
        objSliderMusic.gameObject.SetActive(isMusic);
        tickMusic.SetActive(isMusic);
        objSliderSound.gameObject.SetActive(isSound);
        tickSound.SetActive(isSound);

        if (objSliderMusic.value != data_music.DataMusicQuest.valueMusic)
        { 
            objSliderMusic.value = data_music.DataMusicQuest.valueMusic;
            ValueMusic = data_music.DataMusicQuest.valueMusic;  
        }
        if (objSliderSound.value != data_music.DataMusicQuest.valueSound)
        {
            objSliderSound.value = data_music.DataMusicQuest.valueSound;
            ValueSound = data_music.DataMusicQuest.valueSound;
        }
    }

    public void clickOnOffMusic()
    {
        isMusic = isMusic == true ? false : true;
        data_music.DataMusicQuest.isMusic = isMusic == true ? 1 : 0;
        objSliderMusic.gameObject.SetActive(isMusic);
        tickMusic.SetActive(isMusic);
        saveMusic.SaveToJsonMusic();
    }
    public void clickOnOffSound()
    {
        isSound = isSound == true ? false : true;
        data_music.DataMusicQuest.isSound = isSound == true ? 1 : 0;
        objSliderSound.gameObject.SetActive(isSound);
        tickSound.SetActive(isSound);
        saveMusic.SaveToJsonMusic();
    }
    
}
