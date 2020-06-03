using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonLongProcess : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    #region Properties
    #endregion

    #region Fields
    bool pointerUp = true;
    bool readyToGo = false;
    float pointerUpTimer;

    float requiredHoldTime = 2f;
    [SerializeField] Image fillImage = null;
    [SerializeField] UnityEvent offLongClick = null;
    [SerializeField] UnityEvent onLongClick = null;
    #endregion

    #region Public Methods
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerUp = false;
        readyToGo = true;
        //onLongClick.AddListener(recordManager.OnStartRecordingPressed);
        Debug.Log("OnPointerDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerUp = true;
        Debug.Log("OnPointerUp");
    }
    #endregion

    #region Private Methods
    private void Awake()
    {
        pointerUp = false;
        readyToGo = false;
    }//Awakeeeee



    private void Reset()
    {
        readyToGo = false;
        pointerUp = false;
        pointerUpTimer = 0;
        fillImage.fillAmount = pointerUpTimer / requiredHoldTime;
    }





    private void Update()
    {
        if (pointerUp)
        {
            //Microphone.End(Microphone.devices[0]);
            pointerUpTimer += Time.deltaTime;
            if (pointerUpTimer >= requiredHoldTime)
            {
                if (offLongClick != null)
                    offLongClick.Invoke();
                Reset();
            }
            fillImage.fillAmount = pointerUpTimer / requiredHoldTime;
        }
        else if(!pointerUp && readyToGo)
        {
            if (onLongClick != null)
                onLongClick.Invoke();
            Reset();
        }
    }//Updateeee

   
    #endregion

}//EndCalssss/SadeQ