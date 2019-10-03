using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUIManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioManager.AudioBackgroundVolumns = 1f;
        AudioManager.AudioEffectVolumns = 1f;
        AudioManager.PlayBackground("endbg");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Restart()
    {
        AudioManager.PlayAudioEffectA("button");
        SceneManager.LoadScene("start");
    }
    public void endGame()
    {
        AudioManager.PlayAudioEffectA("button");
        Application.Quit();
    }
}
