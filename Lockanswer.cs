using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lockanswer : MonoBehaviour {
    public Text text;
    public GameObject lockAnswer;
    bool isopen = true;
    public GameObject A;
    public GameObject B;
    public GameObject C;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    public void changeValue()
    {
        AudioManager.PlayAudioEffectA("mailsound");
        Debug.Log(111);
        if ((text.text == 210519.ToString()))
        {
            Debug.Log(22);
            SceneManager.LoadScene("room4");
        }
    }
    public void Lock()
    {
        AudioManager.PlayAudioEffectA("button");
        A.SetActive(false);
        B.SetActive(false);
        C.SetActive(false);
        if(isopen)
        {
            lockAnswer.SetActive(true);
            isopen = !isopen;
        }else
        {
            lockAnswer.SetActive(false);
            isopen = !isopen;
        }
      
    }
}
