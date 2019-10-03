using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubbishTitle : MonoBehaviour {
    public Sprite sprite;
    public Image image;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frameTimu
    void Update () {
		
	}
    public void DianJi()
    {
        image.sprite = sprite;
    }
}
