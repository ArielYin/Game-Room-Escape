using UnityEngine;

using System.Collections;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timers : MonoBehaviour
{

    public int TotalTime = 90;//total time
  
    public Text TimeText;//show time in the UI
    public string LoadsceneName;

    private int minute;//minute

    private int second;//second

    void Start()
    {

        StartCoroutine(startTime());   //start time

    }

    public IEnumerator startTime()
    {

        while (TotalTime >= 0)
        {

            //Debug.Log(TotalTime);//print each second left

            yield return new WaitForSeconds(1);//compute
                                               

            TotalTime--;

            TimeText.text = "Time:" + TotalTime;

            if (TotalTime <= 0)
            {                //if the left time is 0, change the scence

                LoadScene();

            }

            minute = TotalTime / 60; //print show minute

            second = TotalTime % 60; //print show second

            string length = minute.ToString();
            if (second >= 10)
            {

                TimeText.text = "0" + minute + ":" + second;
            }     //if the sceond>10 print 00:00

            else
                TimeText.text = "0" + minute + ":0" + second;      //if the secongd less than 10,the type 00:00

        }


    }

    void LoadScene()
    {

        SceneManager.LoadScene(LoadsceneName);//the end of the time change the scence

    }

}