
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

//UI drag function
public class UIDragByMocha : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("whether drag")]
    public bool m_isPrecision;

    //save offset of picture and mouse
    private Vector3 m_offset;

    //save the current picture RectTransform component
    private RectTransform m_rt;
    void Start()
    {
        AudioManager.AudioBackgroundVolumns = 1f;
        AudioManager.AudioEffectVolumns = 1f;
        AudioManager.PlayBackground("gamebg");
        //initialiazation
        m_rt = gameObject.GetComponent<RectTransform>();
    }

    //begin drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        AudioManager.PlayAudioEffectA("button");
        //if drage direct, compute the offset
        if (m_isPrecision)
        {
            // save the postion of the current mouse
            Vector3 tWorldPos;
            //UI screen point change  in the world point
            RectTransformUtility.ScreenPointToWorldPointInRectangle(m_rt, eventData.position, eventData.pressEventCamera, out tWorldPos);
            //compute the offset   
            m_offset = transform.position - tWorldPos;
        }
        //default
        else
        {
            m_offset = Vector3.zero;
        }

        SetDraggedPosition(eventData);
    }

    //on drag
    public void OnDrag(PointerEventData eventData)
    {
        AudioManager.PlayAudioEffectA("drag");
        SetDraggedPosition(eventData);
    }

    //end the drag
    public void OnEndDrag(PointerEventData eventData)
    {
        AudioManager.PlayAudioEffectA("button");
        SetDraggedPosition(eventData);
    }

    /// <summary>
    /// set picture 
    /// </summary>
    /// <param name="eventData"></param>
    private void SetDraggedPosition(PointerEventData eventData)
    {
        //save the current mouse location
        Vector3 globalMousePos;
        //UI screen point change into world point
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_rt, eventData.position, eventData.pressEventCamera, out globalMousePos))
        {
            //set possition and offset
            m_rt.position = globalMousePos + m_offset;
        }
    }
}