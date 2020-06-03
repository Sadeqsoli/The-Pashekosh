using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class CharDraggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerClickHandler
{
    #region Properties
    public static CharDraggable SharedInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new CharDraggable();
            }
            return instance;
        }
    }
    public Transform InitialPos { get { return initialPos; } set { initialPos = value; } }
    public Transform PlaceHolderParent { get { return placeholderParent; } set { placeholderParent = value; } }
    #endregion

    #region Fields
    /// <summary>
    /// static instance for universal use in the project.
    /// </summary>
    static CharDraggable instance = null;

    /// <summary>
    /// these fields are for Drag And drop
    /// </summary>
    Transform initialPos, initialPoseParent;
    Transform placeholderParent;
    GameObject[] dropPlaces;
    Transform dragPlace;
    GameObject placeHolder = null;

    #endregion

    #region Public Methods

    public void OnBeginDrag(PointerEventData eventData)
    {
        initialPos = this.transform.parent;
        placeholderParent = initialPos;
        this.transform.SetParent(initialPoseParent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        SetTransform(initialPos);
        //this.transform.SetSiblingIndex(FindCloseDroppable(dropPlaces));
        ChangeColorToNormal();
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Debug.Log("EndDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        //placeHolder.transform.SetSiblingIndex(FindSiblingIndexDroppable());
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.transform.parent == dragPlace)
        {
            SetTransform(SetOneAsFirst(dropPlaces));
        }
        else if (IsCharOnDropPalce(dropPlaces, this.transform.parent))
        {
            this.transform.SetParent(dragPlace);
            this.transform.localScale = Vector3.one;
        }
        Debug.Log("Pointer Clicked");
    }






    #endregion


    #region Private Methods
    void Start()
    {
        instance = this;
        initialPos = this.transform.parent;

        initialPoseParent = initialPos.parent;

        dropPlaces = GameObject.FindGameObjectsWithTag("chardropzone");
        dragPlace = GameObject.FindGameObjectWithTag("dragzone").transform;
        
    }//Startttttt


    void ChangeColorToNormal()
    {
        foreach (GameObject droppable in dropPlaces)
        {
            if (droppable != null)
            {
                droppable.GetComponent<Image>().color = Color.gray;
            }
        }
    }

    int FindCloseDroppable(GameObject[] allDroppables)
    {
        for (int i = 0; i < allDroppables.Length; i++)
        {
            CharDroppable charDroppable = allDroppables[i].GetComponent<CharDroppable>();
            if (charDroppable.IsEntered == true)
            {
                return allDroppables[i].transform.GetSiblingIndex();
            }
        }
        return gameObject.transform.GetSiblingIndex();
    }


    Transform SetOneAsFirst(GameObject[] gameObj)
    {
        for (int i = 0; i < gameObj.Length; i++)
        {
            if (gameObj[i] != null)
            {
                CharDroppable charDroppable = gameObj[i].GetComponent<CharDroppable>();
                if (charDroppable.IsSelected == true && charDroppable.IsFilled == false)
                {
                    Transform firstTransform = charDroppable.transform;
                    charDroppable.IsFilled = true;
                    charDroppable.IsSelected = false;
                    gameObj[i].GetComponent<Image>().color = Color.gray;
                    return firstTransform;
                }
            }
        }
        for (int k = 0; k < gameObj.Length; k++)
        {
            if (gameObj[k] != null)
            {
                CharDroppable charDroppable = gameObj[k].GetComponent<CharDroppable>();
                if (charDroppable.IsFilled == false)
                {
                    Transform firstTransform = charDroppable.transform;
                    charDroppable.IsFilled = true;
                    gameObj[k].GetComponent<Image>().color = Color.gray;
                    return firstTransform;
                }
            }
        }
        return initialPos;
    }
    bool IsCharOnDropPalce(GameObject[] gameObj, Transform targetTransform)
    {
        for (int i = 0; i < gameObj.Length; i++)
        {
            Transform currentTransform = gameObj[i].transform;
            if (currentTransform == targetTransform)
            {
                gameObj[i].GetComponent<CharDroppable>().IsFilled = false;
                return true;
            }
        }
        return false;
    }
    void SetTransform(Transform CurrentTransform)
    {
        transform.SetParent(CurrentTransform);
        initialPos = CurrentTransform;
        gameObject.transform.localScale = Vector3.one;
        gameObject.transform.localPosition = Vector3.zero;
    }






    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
