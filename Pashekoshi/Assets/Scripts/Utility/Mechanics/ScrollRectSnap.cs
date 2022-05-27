using UnityEngine;
using UnityEngine.UI;


public class ScrollRectSnap : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    [SerializeField] Scrollbar scrollBar;
    [SerializeField] float scroll_pos = 0.5f;
    [SerializeField] float[] pos;
    [SerializeField] bool isDragging;

    #endregion

    #region Public Methods
    public void SetToFalse()
    {
        isDragging = false;
    }
    public void SetToTrue()
    {
        isDragging = true;
    }
    #endregion


    #region Private Methods
    void Start()
    {
        isDragging = false;
    }//Startttttt





    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }
        if (isDragging)
        {
            scroll_pos = scrollBar.GetComponent<Scrollbar>().value;

        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollBar.value = Mathf.Lerp(scrollBar.value, pos[i], 0.9f);
                }
            }
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale,
                                             new Vector2(1f, 1f), 1.5f);
                    transform.GetChild(i).GetComponent<Button>().interactable = true;
                    transform.GetChild(i).GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
                    for (int j = 0; j < pos.Length; j++)
                    {
                        if (j != i)
                        {
                            transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale,
                                             new Vector2(0.8f, 0.8f), 1.5f);
                            transform.GetChild(j).GetComponent<Button>().interactable = false;
                            transform.GetChild(j).GetComponent<RectTransform>().eulerAngles =  new Vector3(0,0,10);
                        }
                    }
                }
            }
        }

    }//Updateeeee
    #endregion
}//EndClasssss/SadeQ
