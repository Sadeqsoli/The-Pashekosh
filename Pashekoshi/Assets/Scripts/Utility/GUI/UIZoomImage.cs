using UnityEngine;
using UnityEngine.UI;

public class UIZoomImage : MonoBehaviour
{
    Vector3 initialScale = new Vector3(1f, 1f, 1f);
    Vector3 wTapScale = new Vector3(2f, 2f, 2f);
    Vector3 maxScale = new Vector3(3f, 3f, 3f);
    Vector3 zoomScale = new Vector3(0.1f, 0.1f, 0.1f);
    int TapCount = 0;
    float MaxDubbleTapTime = 0.1f;
    float NewTime = 0;
    [SerializeField] private Text text = null;

    public void ZoomIn()
    {
        if (transform.localScale == maxScale)
            return;
        Debug.Log("Plus Scale!");
        if (transform.localScale.x < 1 || transform.localScale.y < 1 || transform.localScale.z < 1)
        {
            transform.localScale = initialScale;
        }
        transform.localScale += zoomScale;

    }

    public void ZoomOut()
    {
        if (transform.localScale == initialScale)
            return;
        if (transform.localScale.x < 1 || transform.localScale.y < 1 || transform.localScale.z < 1)
        {
            transform.localScale = initialScale;
        }
        Debug.Log("Minus Scale!");
        transform.localScale -= zoomScale;

    }

    private void Awake()
    {
        initialScale = transform.localScale;
        TapCount = 0;
    }





    //void DoubleTap()
    //{
    //    if (Input.touchCount == 1)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        if (touch.phase == TouchPhase.Ended)
    //        {
    //            TapCount += 1;
    //        }

    //        if (TapCount == 1)
    //        {

    //            NewTime = Time.time + MaxDubbleTapTime;
    //        }
    //        if (TapCount == 2)
    //        {

    //            NewTime = Time.time + MaxDubbleTapTime;
    //        }
    //        else if (TapCount == 3 && Time.time <= NewTime)
    //        {

    //            //Whatever you want after a dubble tap
    //            if (transform.localScale == initialScale)
    //            {
    //                transform.localScale += wTapScale;
    //                print("Zoom In");
    //            }
    //            else
    //            {
    //                transform.localScale -= wTapScale;
    //                print("Zoom Out");
    //            }



    //            TapCount = 0;
    //        }

    //    }
    //    if (Time.time > NewTime)
    //    {
    //        TapCount = 0;
    //    }
    //}


    private void Update()
    {
        text.text = "Size " + transform.localScale.ToString();

    }//Updateeeee

}//EndClasssss/SadeQ