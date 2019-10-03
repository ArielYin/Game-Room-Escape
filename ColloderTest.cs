using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColloderTest : MonoBehaviour {
    public GameObject gameObjecst;
    public Text text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D collider)
    {
        AudioManager.PlayAudioEffectA("insertusb");
        gameObjecst.SetActive(true);
        Debug.Log(collider.name);
      
    }

    // end trigger
    void OnTriggerExit2D(Collider2D collider)
    {
    

    }

    // stay trigger
    void OnTriggerStay2D(Collider2D collider)
    {
       

    }
    public void EndMovie()
    {
        AudioManager.PlayAudioEffectA("mailsound");
        if (text.text==2645.ToString())
        {
           
            SceneManager.LoadScene("loading");
        }
    }

}
