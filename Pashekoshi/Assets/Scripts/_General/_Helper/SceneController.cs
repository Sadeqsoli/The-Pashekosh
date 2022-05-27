using System.Collections;
using RTLTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : Singleton<SceneController>
{
    [SerializeField] Image BackgroundIMG;
    [SerializeField] GameObject ProgressPack;
    [SerializeField] Image ProgressIMG;
    [SerializeField] RTLTextMeshPro ProgressTXT;
    [SerializeField] Button StartButton;
    [SerializeField] InsectIntro InsectIntroduction;
    [SerializeField] IntroCard[] IntroCards;
    int TapCount = 0;
    float NewTime = 0;
    float MaxDubbleTapTime = 0.3f;
    public UnityAction escapeButtonAction;


    public void GoToNextOrPrevScene(bool isGoingNext, bool isGoingGamePlay = false)
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        int nextOrPrevSceneIndex;
        if (isGoingNext)
        {
            nextOrPrevSceneIndex = currentBuildIndex + 1;
        }
        else
        {
            nextOrPrevSceneIndex = currentBuildIndex - 1;
        }
        StartCoroutine(LoadScene(nextOrPrevSceneIndex, isGoingGamePlay));
    }
    public void GoToSpecificScene(int sceneIndex)
    {
        StartCoroutine(LoadScene(sceneIndex));
    }
    public void GoToSpecificScene(string sceneName, bool isSplash = false)
    {
        StartCoroutine(LoadScene(sceneName, isSplash));
    }
    public void ResetScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadScene(sceneIndex));
    }
    public void QuitByEscapeButton()
    {
        // Check if Back was pressed this frame
        if (EscapeButtonWasHit())
        {
            TapCount += 1;
            if (TapCount == 1)
            {
                NewTime = Time.time + MaxDubbleTapTime;
                //Toast.Instance.SendToast("For quiting tap back button two time!");
            }
            else if (TapCount == 2 && NewTime < Time.time)
            {
                // Quit the application
                NewTime = 0;
                TapCount = 0;
                //Toast.Instance.SendToast("Quit!");
                Application.Quit(0);
            }
        }

    }

    void Start()
    {
        BackgroundIMG.gameObject.SetActive(false);
        StartButton.gameObject.SetActive(false);
        ProgressPack.gameObject.SetActive(true);

        //StartButton.ChangeListener(CloseWaitingPanel);
    }




    void GoBackByEscapeButton()
    {
        // Check if Back was pressed this frame
        if (EscapeButtonWasHit())
        {
            escapeButtonAction?.Invoke();
        }
    }

    bool EscapeButtonWasHit()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                return true;
            }
        }
        return false;
    }


    IEnumerator LoadScene(int sceneIndex, bool isGoingGamePlay = false)
    {
        InitAIntroCard();
        ProgressIMG.fillAmount = 0f;
        ProgressTXT.text = "%0";
        float delay = 2f;

        BackgroundIMG.transform.Scaler(TTScale.YScaleUp);

        yield return new WaitForSecondsRealtime(delay);
        AsyncOperation asyncLoader = SceneManager.LoadSceneAsync(sceneIndex);

        while (!asyncLoader.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoader.progress / 0.9f);
            ProgressIMG.fillAmount = progress;
            ProgressTXT.text = "% " + (progress * 100).ToString("###");
            yield return null;
        }
        yield return new WaitForSecondsRealtime(delay);
        if (isGoingGamePlay)
        {
            ProgressPack.SetActive(true);
            ProgressPack.gameObject.transform.Scaler(TTScale.ScaleDown, () =>
            {
                CloseWaitingPanel(isGoingGamePlay);
                //StartButton.gameObject.transform.Scaler(TTScale.ScaleUp, () => Time.timeScale = 0);
            });
        }
        else
            CloseWaitingPanel(isGoingGamePlay);
    }
    IEnumerator LoadScene(string sceneName, bool isGoingGamePlay = false)
    {
        InitAIntroCard();
        ProgressIMG.fillAmount = 0f;
        ProgressTXT.text = "%0";
        float delay = 2f;

        BackgroundIMG.transform.Scaler(TTScale.YScaleUp);

        yield return new WaitForSecondsRealtime(delay);
        AsyncOperation asyncLoader = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoader.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoader.progress / 0.9f);
            ProgressIMG.fillAmount = progress;
            ProgressTXT.text = "% " + (progress * 100).ToString("###");
            yield return null;
        }
        yield return new WaitForSecondsRealtime(delay);
        if (isGoingGamePlay)
        {
            ProgressPack.gameObject.SetActive(true);
            ProgressPack.gameObject.transform.Scaler(TTScale.ScaleDown, () =>
            {
                CloseWaitingPanel(isGoingGamePlay);
            });
        }
        else
            CloseWaitingPanel(isGoingGamePlay);
    }

    void CloseWaitingPanel(bool isGoingToGamePlay)
    {
        //if (isGoingToGamePlay)
        //    SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        Time.timeScale = 1;
        BackgroundIMG.gameObject.transform.Scaler(TTScale.YScaleDown, () =>
        {
            Debug.Log("Background Scaled Down!");
        });
    }
    void InitAIntroCard()
    {
        StartButton.gameObject.SetActive(false);
        InsectIntroduction.transform.Scaler(TTScale.ScaleUp);
        int rnd = Random.Range(0, IntroCards.Length);
        InsectIntroduction.SetIntroductionCard(IntroCards[rnd], rnd);
    }


    void Update()
    {
        GoBackByEscapeButton();
    }

}//EndCalssss

//AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
//activity.Call<bool>("moveTaskToBack", true);