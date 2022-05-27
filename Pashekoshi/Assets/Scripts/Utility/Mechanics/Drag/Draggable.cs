using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler,IPointerClickHandler
{
    #region Properties
    public static Draggable SharedInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new Draggable();
            }
            return instance;
        }
    }

    public bool IsSelected { get { return isSelected; } set { isSelected = value; } }
    public Transform InitialPos { get { return initialPos; } set { initialPos = value; } }
    public Transform PlaceHolderParent { get { return placeholderParent; } set { placeholderParent = value; } }
    #endregion

    #region Fields
    /// <summary>
    /// static field
    /// </summary>
    static Draggable instance = null;
    Transform initialPos;
    Transform placeholderParent;
    Transform dropPlace;
    Transform dragPlace;
    GameObject placeHolder = null;
    bool isSelected = false;

    #endregion

    #region Public Methods

    public void OnBeginDrag(PointerEventData eventData)
    {
        placeHolder = new GameObject();
        placeHolder.AddComponent<Image>();
        Color color = placeHolder.GetComponent<Image>().color;
        color.a = 0.2f;
        placeHolder.GetComponent<Image>().color = new Color(0, 0, 0, color.a);
        placeHolder.transform.SetParent(this.transform.parent);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;
        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        placeHolder.transform.localScale = Vector3.one;
        initialPos = this.transform.parent;
        placeholderParent = initialPos;
        this.transform.SetParent(initialPos.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        SetTransform(initialPos);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        Destroy(placeHolder);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Debug.Log("EndDrag");
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
        if (placeHolder.transform.parent != placeholderParent)
            placeHolder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;

        for (int i = 0; i < placeholderParent.childCount; i++)
        {
            if (this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (placeHolder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }
        placeHolder.transform.SetSiblingIndex(newSiblingIndex);
        placeHolder.transform.localScale = Vector3.one;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.transform.parent == dragPlace)
        {
            this.transform.SetParent(dropPlace);
            this.transform.localScale = Vector3.one;
        }
        else if(this.transform.parent == dropPlace)
        {
            this.transform.SetParent(dragPlace);
            this.transform.localScale = Vector3.one;
        }
    }


    #endregion


    #region Private Methods
    void Start()
    {
        instance = this;
        initialPos = this.transform.parent;
        dropPlace = GameObject.FindGameObjectWithTag("dropzone").transform;
        dragPlace = GameObject.FindGameObjectWithTag("dragzone").transform;
    }//Startttttt





    public void SetTransform(Transform CurrentTransform)
    {
        transform.SetParent(CurrentTransform);
        gameObject.transform.localScale = Vector3.one;
    }


    void Update()
    {

    }//Updateeeee
    #endregion
}//EndClasssss/SadeQ
