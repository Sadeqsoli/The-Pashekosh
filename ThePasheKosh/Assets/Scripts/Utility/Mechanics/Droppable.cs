using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Droppable : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IDropHandler
{
    #region Properties
    public bool IsFilled { get { return isFilled; } set { isFilled = value; } }
    public bool IsEntered { get { return isEntered; } set { isEntered = value; } }
    #endregion

    #region Fields
    bool isFilled = false;
    bool isEntered = false;
    #endregion

    #region Public Methods
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        Draggable s = eventData.pointerDrag.GetComponent<Draggable>();
        if (s != null )
        {
            s.PlaceHolderParent = this.transform;
        }
        Debug.Log("Entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        Draggable s = eventData.pointerDrag.GetComponent<Draggable>();
        if (s != null && s.PlaceHolderParent == this.transform)
        {
            s.PlaceHolderParent = s.InitialPos;
        }
        Debug.Log("Exit");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if(draggable != null)
        {
            draggable.InitialPos = this.transform;
        }
        CharDraggable charDraggable = eventData.pointerDrag.GetComponent<CharDraggable>();
        if (charDraggable != null)
        {
            charDraggable.InitialPos = this.transform;
        }
    }

    #endregion


    #region Private Methods

    #endregion
}//EndClasssss/SadeQ
