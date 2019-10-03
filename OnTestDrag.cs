using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnTestDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 beginPos;
    private Image image;
    public static int i = 0;
    bool isMouse= false;
    bool isHandShank = false;
    bool isCamera = false;
    bool isKeyBoard = false;
    bool isFish = false;
   
    void Start()
    {
        AudioManager.AudioBackgroundVolumns = 1f;
        AudioManager.AudioEffectVolumns = 1f;
        AudioManager.PlayBackground("gamebg");
        if (this.gameObject.tag=="KeyBoard")
        {
            isKeyBoard = true;
        }
        else if(this.gameObject.tag == "Mouse")
        {
            isMouse = true;
        }
        else if (this.gameObject.tag == "Camera")
        {
            isCamera = true;
        }
        else if (this.gameObject.tag == "Hand")
        {
            isHandShank = true;
        }
        beginPos = transform.position;
        image = transform.GetComponent<Image>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(11111111111);
        Debug.Log(collider.name);
        isFish = true;

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log(11111111111);
        Debug.Log(collider.name);
        isFish = false;

    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        AudioManager.PlayAudioEffectA("button");
        image.raycastTarget = false;
        beginPos = transform.position;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        ; AudioManager.PlayAudioEffectA("drag");
        transform.position = Input.mousePosition;
        transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        OnTestDrag drag = eventData.pointerEnter.GetComponent<OnTestDrag>();
        if (drag != null && drag.transform != transform)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        AudioManager.PlayAudioEffectA("button");
        OnTestDrag drag = eventData.pointerEnter.GetComponent<OnTestDrag>();

        Debug.Log(i);
       
        if (isHandShank &&isFish )
        {
            i++;
            if (i == 4)
            {
             
                SceneManager.LoadScene("room2");
            }
            isHandShank = !isHandShank;
        }else if(isMouse && isFish)
        {
            i++;
            if (i == 4)
            {

                SceneManager.LoadScene("room2");
            }
            isMouse = !isMouse;
        }
        else if (isKeyBoard && isFish)
        {
            i++;
            if (i == 4)
            {

                SceneManager.LoadScene("room2");
            }
            isKeyBoard = !isKeyBoard;
        }
        else if (isCamera && isFish) { 
            i++;
            if (i == 4)
            {

                SceneManager.LoadScene("room2");
            }
            isCamera = !isCamera;
        }
        if (drag != null && drag.transform != transform)
        {
            
            Vector3 pos = drag.transform.position;
            drag.transform.position = beginPos;
            transform.position = pos;
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.position = beginPos;
            transform.localScale = Vector3.one;

        }
        image.raycastTarget = true;
    }

}
