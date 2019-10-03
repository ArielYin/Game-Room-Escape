using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OpenQuestion : MonoBehaviour {
    public GameObject Question;
    public GameObject nextButton;


    public GameObject closeOne;
    public GameObject closeTwo;
    public GameObject closeThree;
    // Use this for initialization
    void Start () {
        AudioManager.AudioBackgroundVolumns = 1f;
        AudioManager.AudioEffectVolumns = 1f;
        AudioManager.PlayBackground("gamebg");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Open()
    {
        AudioManager.PlayAudioEffectA("button");
        Question.SetActive(true);

        closeOne.SetActive(false);
        closeThree.SetActive(false);
        closeTwo.SetActive(false);
        nextButton.GetComponent<Button>().enabled = true;
    }
}
