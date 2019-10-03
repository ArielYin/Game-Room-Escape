using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIManager : MonoBehaviour {
    public GameObject tip;
    public GameObject tipTwo;
    public Slider Bgslider;
    public Slider Amslider;
    public bool isOpen = true;
    public bool isOpenTwo = true;
    // Use this for initialization
    void Start () {
        AudioManager.AudioBackgroundVolumns = 1f;
        AudioManager.AudioEffectVolumns = 1f;
        AudioManager.PlayBackground("gamebg");
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    public void BgMusic()
    {
        AudioManager._AudioSource_BackgroundAudio.volume = Bgslider.value;
        
    }
    public void AmMusic()
    {
        AudioManager._AudioSource_AudioEffectA.volume = Amslider.value;
      
    }
    public void NextScece()
    {
        AudioManager.PlayAudioEffectA("button");
        SceneManager.LoadScene("room1");
    }
    public void Tip()
    {
        AudioManager.PlayAudioEffectA("button");
        if (isOpen)
        {
            tip.SetActive(true);
            isOpen = !isOpen;
        }else
        {
            tip.SetActive(false);
            isOpen = !isOpen;
        }
    }
    public void ExitGame()
    {
        AudioManager.PlayAudioEffectA("button");
        Application.Quit();
    }
    public void MusicPanel()
    {
        AudioManager.PlayAudioEffectA("button");
        if (isOpenTwo)
        {
            tipTwo.SetActive(true);
            isOpenTwo = !isOpenTwo;
        }
        else
        {
            tipTwo.SetActive(false);
            isOpenTwo = !isOpenTwo;
        }
    }
}
