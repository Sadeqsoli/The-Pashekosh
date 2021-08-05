using UnityEngine;
using RTLTMPro;

public class InsectIntro : MonoBehaviour
{
    [SerializeField] Transform InsectPlace;
    [SerializeField] RTLTextMeshPro InsectNameTXT;
    [SerializeField] RTLTextMeshPro InsectDescriptionTXT;


    public void SetIntroductionCard(IntroCard introCard,int rnd)
    {
        SetOn(rnd);

        InsectNameTXT.text = introCard.InsectName;
        InsectDescriptionTXT.text = introCard.InsectDescription;

    }

    void SetOn(int goNumb)
    {
        int ChildCount = InsectPlace.childCount;
        if(ChildCount <= goNumb)
        {
            for (int i = 0; i < ChildCount; i++)
            {
                    InsectPlace.GetChild(i).gameObject.SetActive(false);
            }
            InsectPlace.GetChild(ChildCount - 1).gameObject.SetActive(true);
        }
        else
        {
            if (ChildCount > 0)
                for (int i = 0; i < ChildCount; i++)
                {
                    if (i == goNumb)
                    {
                        InsectPlace.GetChild(i).gameObject.SetActive(true);
                    }
                    else
                    {
                        InsectPlace.GetChild(i).gameObject.SetActive(false);
                    }
                }
        }
    }

}//EndClasss
