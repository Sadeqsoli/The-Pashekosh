using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CharDroppable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler,IPointerClickHandler
{
    #region Properties
    public bool IsSelected { get { return isSelected; } set { isSelected = value; } }
    public bool IsFilled { get { return isFilled; } set { isFilled = value; } }
    public bool IsEntered { get { return isEntered; } set { isEntered = value; } }
    #endregion

    #region Fields
    /// <summary>
    /// Control fields for droppable to connect with draggable
    /// </summary>
     bool isFilled = false;
     bool isEntered = false;
     bool isSelected = false;

    #endregion

    #region Public Methods
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        gameObject.GetComponent<Image>().color = Color.yellow;

        CharDraggable charDraggable = eventData.pointerDrag.GetComponent<CharDraggable>();
        if (charDraggable != null)
        {
            charDraggable.PlaceHolderParent = this.transform;
            isEntered = true;
            Debug.Log("Entered");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        gameObject.GetComponent<Image>().color = Color.gray;
        CharDraggable charDraggable = eventData.pointerDrag.GetComponent<CharDraggable>();
        if (charDraggable != null && eventData != null /*&& charDraggable.PlaceHolderParent == this.transform*/)
        {
            charDraggable.PlaceHolderParent = charDraggable.InitialPos;
            IsFilled = false;
            isEntered = false;
            Debug.Log("Exit");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        CharDraggable charDraggable = eventData.pointerDrag.GetComponent<CharDraggable>();
        if (charDraggable != null && isFilled == false)
        {
            charDraggable.InitialPos = this.transform;
            gameObject.GetComponent<Image>().color = Color.gray;
            //gameObject.SetActive(false);
            isFilled = true;
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        //isPointerDown = true;
        ObjectSelected();
    }

    #endregion


    #region Private Methods
    void Start()
    {

    }//Startttttt

    void ObjectSelected()
    {
        isSelected = !isSelected;
        if (isSelected == true)
        {
            gameObject.GetComponent<Image>().color = new Color32(190, 190, 50, 255);
        }
        else if (isSelected == false)
        {
            gameObject.GetComponent<Image>().color = new Color32(125, 125, 125, 255);
        }
    }



    void Update()
    {


    }//Updateee
    #endregion
}//EndClasssss/SadeQ
