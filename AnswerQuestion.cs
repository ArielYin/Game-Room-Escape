using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerQuestion : MonoBehaviour {
    public GameObject mine;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TrueD()
    {
        AudioManager.PlayAudioEffectA("button");
        ColorBlock cb = new ColorBlock();
        cb.normalColor = Color.green;

        this.gameObject.GetComponent<Button>().colors = cb;
        this.gameObject.GetComponentInChildren<Text>().color = Color.green;

        mine.SetActive(false);
    }
    public void FalseD()
    {
        AudioManager.PlayAudioEffectA("button");
        ColorBlock cb = new ColorBlock();
        cb.normalColor = Color.red;
       
        this.gameObject.GetComponent<Button>().colors = cb;
        this.gameObject.GetComponentInChildren<Text>().color = Color.red;
    }
    public void nextGame()
    {
        AudioManager.PlayAudioEffectA("button");
        ColorBlock cb = new ColorBlock();
        cb.normalColor = Color.green;

        this.gameObject.GetComponent<Button>().colors = cb;
        this.gameObject.GetComponentInChildren<Text>().color = Color.green;

        SceneManager.LoadScene("room3");
    }
}
