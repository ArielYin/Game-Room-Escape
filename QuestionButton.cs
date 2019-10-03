using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionButton : MonoBehaviour {
    public GameObject question;
    public GameObject questionPass;
    public GameObject questionPassTwo;
    public GameObject locks;
    public GameObject nextButton;
	// Use this for initialization
	void Start () {
        AudioManager.AudioBackgroundVolumns = 1f;
        AudioManager.AudioEffectVolumns = 1f;
        AudioManager.PlayBackground("gamebg");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TipQuestion()
    {
        AudioManager.PlayAudioEffectA("button");
        locks.SetActive(false);
        question.SetActive(true);
        questionPass.SetActive(false);
        questionPassTwo.SetActive(false);
        nextButton.GetComponent<Button>().enabled = true;
    }
}
