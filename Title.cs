using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {
    public GameObject titleTip;
    bool isOpen = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OpenTitle()
    {
        AudioManager.PlayAudioEffectA("button");
        if (isOpen)
        {
            titleTip.SetActive(true);
            isOpen = !isOpen;
        }else
        {
            titleTip.SetActive(false);
            isOpen = !isOpen;
        }
    }
}
