
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

//image imitate vedio window
public class UIDragResizeByMocha : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("check the valid edge width")]
    public float m_validityWidth = 10f;


    //save drag direction(default is no-op)
    private DragDirection m_direction = DragDirection.None;

    //1.up  //5.Upper left corner
    //2.down  //6.down left corner
    //3.left  //7.upper right corner
    //4.right  //8.down right corner

    //save the current picture position
    private Vector3 tTargetPos;
    //save the current mouse position
    private Vector3 tMousePos;
    //save the current picture width
    private float tWidth;
    //save the current picture height
    private float tHeight;

    //save the some unmovepoint 
    
    private Vector3 m_basePoint;

    /// <summary>
    /// drag refresh data
    /// </summary>
    /// <param name="eventData"></param>
    void DoRefresh(PointerEventData eventData)
    {
        //refresh mouse position
        tMousePos = eventData.position;
        //refresh image position
        tTargetPos = transform.position;
        //refresh image width
        tWidth = GetComponent<RectTransform>().sizeDelta.x;
        //refresh image height
        tHeight = GetComponent<RectTransform>().sizeDelta.y;
    }

    //begin drag
    public void OnBeginDrag(PointerEventData eventData)
    {
        //refresh data
        DoRefresh(eventData);

    }
    //on drag
    public void OnDrag(PointerEventData eventData)
    {
        //refresh data
        DoRefresh(eventData);

        #region judge the direction
        //mouse position with limited distance of left border, set the direction
        if (tMousePos.x < (tTargetPos.x - tWidth / 2.0f + m_validityWidth))
        {
            m_direction = DragDirection.Left;
            //up
            if (tMousePos.y > (tTargetPos.y + tHeight / 2.0f - m_validityWidth))
            {
                m_direction = DragDirection.LeftUp;
            }
            //down
            else if ((tMousePos.y < (tTargetPos.y - tHeight / 2.0f + m_validityWidth)))
            {
                m_direction = DragDirection.LeftDown;
            }

        }
        //mouse postion of right border
        else if (tMousePos.x > (tTargetPos.x + tWidth / 2.0f - m_validityWidth))
        {
            m_direction = DragDirection.Right;
            //up
            if (tMousePos.y > (tTargetPos.y + tHeight / 2.0f - m_validityWidth))
            {
                m_direction = DragDirection.RightUp;
            }
            //down
            else if ((tMousePos.y < (tTargetPos.y - tHeight / 2.0f + m_validityWidth)))
            {
                m_direction = DragDirection.RightDown;
            }
        }
        //up border
        else if (tMousePos.y > (tTargetPos.y + tHeight / 2.0f - m_validityWidth))
        {
            m_direction = DragDirection.Up;
            //left
            if (tMousePos.x < (tTargetPos.x - tWidth / 2.0f + m_validityWidth))
            {
                m_direction = DragDirection.LeftUp;
            }
            //right
            else if (tMousePos.x > (tTargetPos.x + tWidth / 2.0f - m_validityWidth))
            {
                m_direction = DragDirection.RightUp;
            }
        }
        //down border
        else if ((tMousePos.y < (tTargetPos.y - tHeight / 2.0f + m_validityWidth)))
        {
            m_direction = DragDirection.Down;
            //left
            if (tMousePos.x < (tTargetPos.x - tWidth / 2.0f + m_validityWidth))
            {
                m_direction = DragDirection.LeftDown;
            }
            //right
            else if (tMousePos.x > (tTargetPos.x + tWidth / 2.0f - m_validityWidth))
            {
                m_direction = DragDirection.RightDown;
            }
        }
        else
        {
            m_direction = DragDirection.None;
        }


        #endregion

        //Make corresponding imitation video window scaling according to the direction of the current decision
        switch (m_direction)
        {
            case DragDirection.Left:
                DoLeft();
                break;
            case DragDirection.Right:
                DoRight();
                break;
            case DragDirection.Up:
                DoUp();
                break;
            case DragDirection.Down:
                DoDown();
                break;
            case DragDirection.LeftUp:
                DoLeftUp();
                break;
            case DragDirection.LeftDown:
                DoLeftDown();
                break;
            case DragDirection.RightUp:
                DoRightUp();
                break;
            case DragDirection.RightDown:
                DoRightDown();
                break;
            default:
                Debug.Assert(false);
                break;
        }

    }

    #region every direction
    /// <summary>
    /// drag left set size
    /// </summary>
    void DoLeft()
    {
        //set the base point
        m_basePoint = tTargetPos + new Vector3(tWidth / 2.0f, 0, 0);
        //set the picture width
        float ttWidth = Mathf.Abs(m_basePoint.x - tMousePos.x);
        GetComponent<RectTransform>().sizeDelta = new Vector2(ttWidth, tHeight);
        //set the positon of image
        transform.position = m_basePoint - new Vector3(ttWidth / 2.0f, 0, 0);
    }
    /// <summary>
    /// drag left chang size
    /// </summary>
    void DoRight()
    {
        //set base point
        m_basePoint = tTargetPos - new Vector3(tWidth / 2.0f, 0, 0);
        //set picture width
        float ttWidth = Mathf.Abs(m_basePoint.x - tMousePos.x);
        GetComponent<RectTransform>().sizeDelta = new Vector2(ttWidth, tHeight);
        //set picture position
        transform.position = m_basePoint + new Vector3(ttWidth / 2.0f, 0, 0);
    }
    /// <summary>
    /// drag up
    /// </summary>
    void DoUp()
    {
        //base point
        m_basePoint = tTargetPos - new Vector3(0, tHeight / 2.0f, 0);
        //height
        float ttHeight = Mathf.Abs(m_basePoint.y - tMousePos.y);
        GetComponent<RectTransform>().sizeDelta = new Vector2(tWidth, ttHeight);
        //postion
        transform.position = m_basePoint + new Vector3(0, ttHeight / 2.0f, 0);
    }
    /// <summary>
    /// drag down
    /// </summary>
    void DoDown()
    {
        //base point
        m_basePoint = tTargetPos + new Vector3(0, tHeight / 2.0f, 0);
        //height
        float ttHeight = Mathf.Abs(m_basePoint.y - tMousePos.y);
        GetComponent<RectTransform>().sizeDelta = new Vector2(tWidth, ttHeight);
        //position
        transform.position = m_basePoint - new Vector3(0, ttHeight / 2.0f, 0);
    }
    /// <summary>
    /// upper left
    /// </summary>
    void DoLeftUp()
    {
        //base point
        m_basePoint = tTargetPos + new Vector3(tWidth / 2.0f, -tHeight / 2.0f, 0);
        //width
        float ttWidth = Mathf.Abs(m_basePoint.x - tMousePos.x);
        //height
        float ttHeight = Mathf.Abs(m_basePoint.y - tMousePos.y);
        GetComponent<RectTransform>().sizeDelta = new Vector2(ttWidth, ttHeight);
        //position
        transform.position = m_basePoint + new Vector3(-ttWidth / 2.0f, ttHeight / 2.0f, 0);
    }
    /// <summary>
    /// left down
    /// </summary>
    void DoLeftDown()
    {
        //base point
        m_basePoint = tTargetPos + new Vector3(tWidth / 2.0f, tHeight / 2.0f, 0);
        //width
        float ttWidth = Mathf.Abs(m_basePoint.x - tMousePos.x);
        //height
        float ttHeight = Mathf.Abs(m_basePoint.y - tMousePos.y);
        GetComponent<RectTransform>().sizeDelta = new Vector2(ttWidth, ttHeight);
        //position
        transform.position = m_basePoint + new Vector3(-ttWidth / 2.0f, -ttHeight / 2.0f, 0);
    }
    /// <summary>
    /// right upper
    /// </summary>
    void DoRightUp()
    {
        //base point
        m_basePoint = tTargetPos + new Vector3(-tWidth / 2.0f, -tHeight / 2.0f, 0);
        //width
        float ttWidth = Mathf.Abs(m_basePoint.x - tMousePos.x);
        //height
        float ttHeight = Mathf.Abs(m_basePoint.y - tMousePos.y);
        GetComponent<RectTransform>().sizeDelta = new Vector2(ttWidth, ttHeight);
        //position
        transform.position = m_basePoint + new Vector3(ttWidth / 2.0f, ttHeight / 2.0f, 0);
    }
    /// <summary>
    /// right down
    /// </summary>
    void DoRightDown()
    {
        //base point
        m_basePoint = tTargetPos + new Vector3(-tWidth / 2.0f, tHeight / 2.0f, 0);
        //width
        float ttWidth = Mathf.Abs(m_basePoint.x - tMousePos.x);
        //height
        float ttHeight = Mathf.Abs(m_basePoint.y - tMousePos.y);
        GetComponent<RectTransform>().sizeDelta = new Vector2(ttWidth, ttHeight);
        //position
        transform.position = m_basePoint + new Vector3(ttWidth / 2.0f, -ttHeight / 2.0f, 0);
    }
    #endregion

    //end drag
    public void OnEndDrag(PointerEventData eventData)
    {
        //reset the direction
        m_direction = DragDirection.None;
    }

}

/// <summary>
/// emmu direction
/// </summary>
public enum DragDirection
{
    None,       
    Up,         
    Down,       
    Left,       
    Right,      
    LeftUp,     
    RightUp,    
    LeftDown,   
    RightDown   
}